namespace ClientGUI_v3
{
    public partial class MainLauncher : Form
    {

        const double LATTICE_SPACING = 1.9202;


        #region Variables
        //----------------------------------
        Debug __debug;
        Plot __plot;
        //----------------------------------
        UI.ClientUI __clientUi;
        UI.ClientUI.SendFunc __clientUiSendFunc;
        UI.ClientUI.FinalFunc __clientUiFinalFunc;
        //----------------------------------
        UI.UserUI __userUi;
        UI.UserUI.SetUserFunc __userUiSetUserFunc;
        UI.UserUI.SendFunc __userUiSendFunc;
        UI.UserUI.FinalFunc __userUiFinalFunc;
        //----------------------------------
        UI.CRegionUI __cRegionUi;
        UI.CRegionUI.SendFunc __cRegionUiSendFunc;
        UI.CRegionUI.FinalFunc __cRegionUiFinalFunc;
        //----------------------------------
        UI.DaqUI __daqUi;
        UI.DaqUI.SendFunc __daqUiSendFunc;
        UI.DaqUI.FinalFunc __daqUiFinalFunc;
        //----------------------------------
        #endregion



        //==================================
        public MainLauncher()
        {
            InitializeComponent();

            // PLOT
            __plot = new Plot(1);
            __plot.TopLevel = false;
            panelPlot.Controls.Add(__plot);
            __plot.Location = new Point(0, 0);
            __plot.Size = panelPlot.ClientSize;
            __plot.Show();

            // DEBUG
            __debug = new Debug();
            __debug.TopLevel = false;
            __debug.Location = new Point(0, 0);
            panelConsole.Controls.Add(__debug);
            __debug.Size = panelConsole.ClientSize;
            __debug.Location = new Point(0, 0);
            __debug.Show();



            // --= CLIENT =--
            __clientUiSendFunc = Com;
            __clientUiFinalFunc = ComFinal;
            __clientUi = new UI.ClientUI(__clientUiSendFunc, __clientUiFinalFunc);
            __clientUi.Connected += clientUI_Connected;
            __clientUi.AddToTabPage(ref tabControl1, "Server");



            // USER
            __userUiSetUserFunc = SetUser;
            __userUiSendFunc = Com;
            __userUiFinalFunc = ComFinal;
            __userUi = new UI.UserUI(__userUiSendFunc, __userUiFinalFunc, __userUiSetUserFunc);
            __userUi.AddToTabPage(ref tabControl1, "DB");

            // CREGION
            __cRegionUiSendFunc = Com;
            __cRegionUiFinalFunc = ComFinal;
            __cRegionUi = new UI.CRegionUI(__cRegionUiSendFunc, __cRegionUiFinalFunc);
            __cRegionUi.Plot = __plot;
            __cRegionUi.LatticeSpacing = LATTICE_SPACING; // <<<
            __cRegionUi.AddToTabPage(ref tabControl1, "C-Region");


            // DAQ
            __daqUiSendFunc = Com;
            __daqUiFinalFunc = ComFinal;
            __daqUi = new UI.DaqUI(__daqUiSendFunc, __daqUiFinalFunc);
            __daqUi.Plot = __plot;
            __daqUi.AddToTabPage(ref tabControl1, "DAQ");            
        }
        //==================================




        #region Private Methods
        //----------------------------------
        private void AddMessage(string _mesage, Color _color, FontStyle _style)
        {
            if (__debug == null)
                return;

            if (_mesage == null)
                return;

            __debug.AddLine(_mesage + "\n", _color, _style);
        }
        private void AddDebugMessage(string _mesage)
        {
            AddMessage(_mesage, Color.LightYellow, FontStyle.Regular);
        }
        private void AddResponseMessage(string _mesage)
        {
            AddMessage(_mesage, Color.DeepSkyBlue, FontStyle.Regular);
        }
        private void AddRequestMessage(string _mesage)
        {
            AddMessage(_mesage, Color.Goldenrod, FontStyle.Regular);
        }
        private void AddErrorMessage(string _mesage)
        {
            AddMessage(_mesage, Color.Tomato, FontStyle.Bold);
        }
        //----------------------------------
        private Int32 Com(object _sender, ref string _req, ref string _res)
        {
            Int32 rt;
            rt = __clientUi.SendBlocking(ref _req, ref _res);
            if (rt < 0)
            {
                _res = "Error: " + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + _res;
                return -1;
            }

            return 1;
        }
        private void ComFinal(object _sender, ref string _req, ref string _res)
        {
            if (_res.Contains("ERROR"))
            {
                AddErrorMessage("req: " + _req);
                AddErrorMessage("res: " + _res);
                return;
            }

            AddRequestMessage("req: " + _req);
            AddResponseMessage("res: " + _res);
        }
        //----------------------------------
        private void SetUser(object _sender, string _user)
        {
            __clientUi.UserName = _user;
        }
        //----------------------------------
        #endregion



        #region Events
        //----------------------------------
        private void clientUI_Connected(object sender, UI.ClientUiEventArgs arg)
        {
            if (arg.Error)
                AddErrorMessage("could not connect");
            else
                AddDebugMessage("Connected with ID: " + arg.ID);
        }

        //----------------------------------
        #endregion



        #region Buttons
        //----------------------------------
        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (__debug == null)
                return;

            __debug.Clear();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //----------------------------------
        #endregion
    }
}