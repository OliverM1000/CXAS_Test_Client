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
    public partial class UserUI : Form
    {
        #region Constants
        //----------------------------------
        private const Int32 OFFSET_RT = 0;
        private const Int32 OFFSET_KEYWORD = 1;
        private const Int32 OFFSET_COMMAND = 2;
        //----------------------------------
        #endregion



        #region Variables
        //----------------------------------
        private string __req;
        private string __res;
        private SendFunc __SendFunc;
        private FinalFunc __FinalFunc;
        private SetUserFunc __SetUserFunc;
        //----------------------------------
        #endregion



        #region Public Properties
        //----------------------------------
        public string UserName
        {
            get { return tbUser.Text; }
            set { tbUser.Text = value; }
        }
        public string CurrentUserName
        {
            get { return tbCurrentUser.Text; }
            set { tbCurrentUser.Text = value; }
        }
        //----------------------------------
        #endregion



        #region Delegates
        //----------------------------------
        public delegate Int32 SendFunc(object _sender, ref string _req, ref string _res);
        public delegate void FinalFunc(object _sender, ref string _reg, ref string _res);
        public delegate void SetUserFunc(object _sender, string _user);
        //----------------------------------
        #endregion



        //==================================
        public UserUI(SendFunc _SendFunc, FinalFunc _FinalFunc, SetUserFunc _SetUserFunc)
        {
            __SendFunc = _SendFunc;
            __FinalFunc = _FinalFunc;
            __SetUserFunc = _SetUserFunc;

            InitializeComponent();            
        }
        //==================================        


        #region Private Methods
        //----------------------------------
        private Int32 EvaluateListUsers(ref string _res)
        {            
            string[] resArr;
            string[] resSplit;            

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")                
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "USER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "LIST_USERS")
                    return -1;


                resSplit = _res.Split("\r");
                for (Int32 i = 1; i < resSplit.Length; i++)
                {
                    rtbConsole.AppendText(resSplit[i].Replace(" ", "\t") + "\r\n");
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateListDatabases(ref string _res)
        {            
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "USER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "LIST_DBS")
                    return -1;


                resSplit = _res.Split("\r");
                for (Int32 i = 1; i < resSplit.Length; i++)
                {
                    rtbConsole.AppendText(resSplit[i].Replace(" ", "\t") + "\r\n");
                }

            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateCreate(ref string _res)
        {
            string[] resArr;

            try
            {
                resArr = _res.Split();                

                if (resArr.Length != 4)
                    return -1;

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "USER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "LIST_DBS")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetUser(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();
                if (resArr.Length != 4)
                    return -1;

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "SERVER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_USER")
                    return -1;

                resSplit = _res.Split("\r");

                this.CurrentUserName = resSplit[1];
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateSetUser(ref string _res)
        {
            string[] resArr;

            try
            {
                resArr = _res.Split();

                resArr = _res.Split();
                if (resArr.Length != 4)
                    return -1;

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "SERVER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "SET_USER")
                    return -1;

                this.CurrentUserName = resArr[3];
                __SetUserFunc(this, resArr[3]);
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateExist(ref string _res)
        {
            string[] resArr;
            string[] resSplit;


            try
            {
                resArr = _res.Split();
                if (resArr.Length != 5)
                    return -1;

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "USER")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "EXIST")
                    return -1;

                resSplit = _res.Split("\r");

                rtbConsole.Clear();
                rtbConsole.AppendText(resSplit[1]);
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
        //----------------------------------
        #endregion



        #region Buttons
        //----------------------------------
        private void btnListUsers_Click(object sender, EventArgs e)
        {
            Int32 rt;
            List<string> dbNames;

            rtbConsole.Clear();

            __res = "";
            __req = "USER LIST_USERS";
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt =  EvaluateListUsers(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................

        }
        private void btnListDatabases_Click(object sender, EventArgs e)
        {
            Int32 rt;
            List<string> dbNames;

            rtbConsole.Clear();

            __res = "";
            __req = "USER LIST_DBS";
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateListDatabases(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnCreateNewUser_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __res = "";
            __req = "USER CREATE_USER " + this.UserName;
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................


            rt = EvaluateCreate(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnGetCurrentUser_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __res = "";
            __req = "SERVER GET_USER";
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetUser(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnSetUser_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __res = "";
            __req = "SERVER SET_USER " + this.UserName;
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateSetUser(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        #endregion


        private void btnExist_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __res = "";
            __req = "USER EXIST " + this.UserName;
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateExist(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __res = "";
            __req = "USER DELETE " + this.UserName;
            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
    }
}
