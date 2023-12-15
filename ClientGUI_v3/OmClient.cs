using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ClientGUI_v3
{
    public class OmClient
    {

        #region Variables
        //---------------------------------
        private UInt64 __id;
        private TcpClient __client;
        private StreamReader __reader;
        private StreamWriter __writer;
        //---------------------------------
        #endregion


        #region Properties
        //---------------------------------
        public UInt64 ID { get { return __id; } }
        public string UserName { get; set; }
        //---------------------------------
        #endregion


        //==================================
        public OmClient(string _ipAddress, Int32 _port)
        {
            __id = 0;
            __client = new TcpClient(_ipAddress, _port);
        }
        //==================================


        #region Private Methods
        //---------------------------------
        private int GetClientIdFromServer(out UInt64 _id)
        {
            _id = 0;
            Int32 rt;
            string req = "";
            string res = "";
            string[] resArr;
            string[] resSplit;

            try
            {
                req = "0 SERVER GET_ID";
                rt = SendBlockingRaw(ref req, ref res);
                if (rt < 0)
                    return -1;

                resArr = res.Split();
                if (resArr.Length != 5)
                    return -1;

                if (resArr[0].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[1].ToUpper() != "SERVER")
                    return -1;

                if (resArr[2].ToUpper() != "GET_ID")
                    return -1;

                resSplit = res.Split("\r");

                _id = Convert.ToUInt64(resSplit[1]);
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //---------------------------------
        #endregion



        #region Public Methods
        //---------------------------------
        public Int32 Connect()
        {
            Int32 rt;
            __reader = new StreamReader(__client.GetStream(), Encoding.ASCII);
            __writer = new StreamWriter(__client.GetStream(), Encoding.ASCII);

            rt = GetClientIdFromServer(out __id);
            if(rt < 0)
            {
                __reader.Close();
                __writer.Close();
                __client.Close();
                return -1;
            }

            return 1;
        }
        public void Disconnect()
        {
            __reader.Close();
            __writer.Close();
            __client.Close();
        }



        //---------------------------------
        public Int32 SendBlocking(ref string _req, ref string _res)
        {
            Int32 rt;

            //_req = this.ID + " " + this.UserName + " " + _req;
            _req = this.UserName + " " + _req;
            rt = SendBlockingRaw(ref _req, ref _res);
            if (rt < 0)
                return -1;
            
            return 1;
        }
        public Int32 SendBlockingRaw(ref string _req, ref string _res)
        {
            StringBuilder sb = new StringBuilder(1000000);

            try
            {
                __writer.WriteLine(_req);
                __writer.Flush();

                //_res = "";
                //_res += (char)__reader.Read();
                sb.Append((char)__reader.Read());
                while (__reader.Peek() > -1)
                {
                    //_res += (char)__reader.Read();
                    sb.Append((char)__reader.Read());
                }
                //_res = _res.Substring(0, _res.Length - 2);
                _res = sb.ToString();
                _res = _res.Substring(0, _res.Length - 2);

            }
            catch (Exception ex)
            {
                return -1;
            }
            return 1;
        }
        //---------------------------------
        #endregion



    }
}
