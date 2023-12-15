using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI_v3.UI
{
    public partial class ClientUI : Form
    {


        #region Variables
        //----------------------------------
        private string __req;
        private string __res;
        private OmClient __client;
        private SendFunc __SendFunc;
        private FinalFunc __FinalFunc;
        //----------------------------------
        #endregion



        #region Events
        //----------------------------------
        public event ClientUiEventHandler Connected;
        //----------------------------------
        #endregion



        #region Properties
        //----------------------------------
        public string UserName
        {
            get { return __client.UserName; }
            set { __client.UserName = value; }
        }        
        public string IPAddress
        {
            get { return tbIpAddress.Text; }
            set { tbIpAddress.Text = value; }
        }
        public string Port
        {
            get { return tbPort.Text; }
            set { tbPort.Text = value; }
        }
        //----------------------------------
        public UInt64 ID { get { return __client.ID; } }
        //----------------------------------
        #endregion



        #region Delegates
        //----------------------------------
        public delegate Int32 SendFunc(object _sender, ref string _req, ref string _res);
        public delegate void FinalFunc(object _sender, ref string _reg, ref string _res);        
        //----------------------------------
        #endregion



        //==================================
        public ClientUI(SendFunc _SendFunc, FinalFunc _FinalFunc)
        {
            __SendFunc = _SendFunc;
            __FinalFunc = _FinalFunc;

            InitializeComponent();            
        }
        //==================================


        private const Int32 OFFSET_RT = 0;
        private const Int32 OFFSET_KEYWORD = 1;
        private const Int32 OFFSET_COMMAND = 2;


        #region Private Methods
        //----------------------------------
        private Int32 EvaluateGetId(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "SERVER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_ID")
                    return -1;

                resSplit = _res.Split("\r");

                //Int32 id = resSplit[1];

            }
            catch (Exception ex)
            {
                return -1;
            }


            return 1;
        }
        private Int32 EvaluateListIds(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "SERVER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "LIST_IDS")
                    return -1;


                resSplit = _res.Split("\r");
                for (Int32 i = 1; i < resSplit.Length; i++)
                {
                    //rtbConsole.AppendText(resSplit[i].Replace(" ", "\t") + "\r\n");
                }

            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //----------------------------------
        #endregion



        #region Public Methods
        //----------------------------------
        public void AddToTabPage(ref TabControl _tabControl, string _title)
        {
            TabPage tabPage = new TabPage(_title);

            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            tabPage.Controls.Add(this);
            this.Show();
            _tabControl.Controls.Add(tabPage);
        }
        public Int32 SendBlocking(ref string _req, ref string _res)
        {
            if (__client == null)
            {
                _res = this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + "OBJECT_IS_NULL";
                return -1;
            }

            return __client.SendBlocking(ref _req, ref _res);
        }
        //----------------------------------
        #endregion




        #region Emit Events
        //----------------------------------
        protected private void EmitConnected(bool _err)
        {
            if (Connected == null)
                return;

            ClientUiEventArgs args = new ClientUiEventArgs();
            args.Error = _err;
            args.ID = this.ID;
            Connected(this, args);
        }
        //----------------------------------
        #endregion




        #region Buttons
        //----------------------------------
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __client = new OmClient(this.IPAddress, Convert.ToInt32(this.Port));            
            rt = __client.Connect();

            if (rt < 0)
                EmitConnected(true);
            else
                EmitConnected(false);

        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if(__client != null)
                __client.Disconnect();
        }

        //----------------------------------
        #endregion







        private void btnGetId_Click(object sender, EventArgs e)
        {
            Int32 rt;          

            __res = "";
            __req = "SERVER GET_ID";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetId(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }



        private void btnListIds_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __res = "";
            __req = "SERVER LIST_IDS";
            
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateListIds(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }



    }



    public class ClientUiEventArgs : EventArgs
    {
        public UInt64 ID {get; set;}
        public bool Error { get; set; }
    }
    public delegate void ClientUiEventHandler(object sender, ClientUiEventArgs arg);

}
