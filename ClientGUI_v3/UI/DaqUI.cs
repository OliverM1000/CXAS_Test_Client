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
    public partial class DaqUI : Form
    {

        #region Constants
        //----------------------------------
        private const Int32 OFFSET_RT       = 0;
        private const Int32 OFFSET_KEYWORD  = 1;
        private const Int32 OFFSET_COMMAND  = 2;
        private const Int32 OFFSET_ARG_1    = 1;
        //----------------------------------
        #endregion


        #region Variables
        //----------------------------------
        private string __req;
        private string __res;
        private SendFunc __SendFunc;
        private FinalFunc __FinalFunc;
        //----------------------------------
        private System.Timers.Timer __getDaqDataTimer;
        //----------------------------------
        #endregion


        #region Public Properties
        //----------------------------------
        public Plot Plot { get; set; }
        //----------------------------------
        public string Prescaler
        {
            get { return tbTpsk.Text; }
            set { tbTpsk.Text = value; }
        }
        public string Baserate
        {
            get { return tbTbrt.Text; }
            set { tbTbrt.Text = value; }
        }
        //----------------------------------
        public string AdcConfig
        {
            get { return tbAdcConfig.Text; }
            set { tbAdcConfig.Text = value; }
        }
        public string CntConfig
        {
            get { return tbCntConfig.Text; }
            set { tbCntConfig.Text = value; }
        }
        public string EncConfig
        {
            get { return tbEncConfig.Text; }
            set { tbEncConfig.Text = value; }
        }
        //----------------------------------
        public string OffsetsNumSamples
        {
            get { return tbOffsetsNumSamples.Text; }
            set { tbOffsetsNumSamples.Text = value; }
        }
        public string OffsetsCountTime
        {
            get { return tbOffsetCountTime.Text; }
            set { tbOffsetCountTime.Text = value; }
        }
        //----------------------------------
        #endregion



        #region Delegates
        //----------------------------------
        public delegate Int32 SendFunc(object _sender, ref string _req, ref string _res);
        public delegate void FinalFunc(object _sender, ref string _reg, ref string _res);
        //----------------------------------
        #endregion


        //==================================
        public DaqUI(SendFunc _SendFunc, FinalFunc _FinalFunc)
        {
            __SendFunc = _SendFunc;
            __FinalFunc = _FinalFunc;

            InitializeComponent();
        }
        //==================================




        #region Private Methods
        //----------------------------------
        private void PlotData(double[][] _data)
        {
            if (this.Plot == null)
                return;

            this.Plot.PlotData(0, _data);
            
        }
        //----------------------------------
        private Int32 EvaluateSetPrescaler(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "SET_PRESCALER")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetPrescaler(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_PRESCALER")
                    return -1;

                resSplit = _res.Split("\r");
                this.Prescaler = resSplit[OFFSET_ARG_1];
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //----------------------------------
        private Int32 EvaluateSetBaserate(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "SET_BASERATE")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetBaserate(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_BASERATE")
                    return -1;

                resSplit = _res.Split("\r");
                this.Baserate = resSplit[OFFSET_ARG_1];
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //----------------------------------
        private Int32 EvaluateSetAdcConfig(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "SET_CONFIG_ADC")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetAdcConfig(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_CONFIG_ADC")
                    return -1;

                resSplit = _res.Split("\r");
                this.AdcConfig = resSplit[OFFSET_ARG_1];
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //----------------------------------
        private Int32 EvaluateSetCntConfig(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "SET_CONFIG_CNT")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetCntConfig(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_CONFIG_CNT")
                    return -1;

                resSplit = _res.Split("\r");
                this.CntConfig = resSplit[OFFSET_ARG_1];
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //----------------------------------
        private Int32 EvaluateSetEncConfig(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "SET_CONFIG_ENC")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetEncConfig(ref string _res)
        {
            string[] resArr;
            string[] resSplit;

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET_CONFIG_ENC")
                    return -1;

                resSplit = _res.Split("\r");
                this.EncConfig = resSplit[OFFSET_ARG_1];
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        //----------------------------------
        private Int32 EvaluateStart(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "START")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateStopDaq(ref string _res)
        {
            string[] resArr;


            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "STOP")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateGetDaqData(ref string _res, out double[][] _data)
        {
            string[] resArr;
            string[] resSplit;
            string[] data;

            _data = new double[2][];
            _data[0] = new double[2];
            _data[1] = new double[2];

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "DAQ")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "GET")
                    return -1;

                resSplit = _res.Split("\r");
                _data = new double[2][];
                _data[0] = new double[resSplit.Length - 1];
                _data[1] = new double[resSplit.Length - 1];
                for (Int32 i = 0; i < resSplit.Length - 1; i++)
                {
                    data = resSplit[i + 1].Split();

                    //_data[0][i] = Convert.ToDouble(data[0]);
                    _data[0][i] = Convert.ToDouble(i);
                    _data[1][i] = Convert.ToDouble(data[2]);
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
        //----------------------------------
        #endregion





        private Int32 EvaluateOffsetsCount(ref string _res)
        {
            return 1;
        }

        private Int32 EvaluateOffsetsStatus(ref string _res)
        {
            return 1;
        }

        private Int32 EvaluateOffsetsAbort(ref string _res)
        {
            return 1;
        }

        private Int32 EvaluateOffsetsGet(ref string _res)
        {
            return 1;
        }



        #region Buttons
        //----------------------------------
        private void btnSetTPsk_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ SET_PRESCALER " + this.Prescaler;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateSetPrescaler(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................

        }
        private void btnGetTpsk_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ GET_PRESCALER";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetPrescaler(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        private void getTbrt_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ GET_BASERATE";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetBaserate(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnSetTbrt_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ SET_BASERATE " + this.Baserate;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateSetBaserate(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        private void btnSetAdcConfig_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ SET_CONFIG_ADC " + this.AdcConfig;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateSetAdcConfig(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnGetAdcConfig_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ GET_CONFIG_ADC";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetAdcConfig(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        private void bntSetCntConfig_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ SET_CONFIG_CNT " + this.CntConfig;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateSetCntConfig(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnGetCntConfig_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ GET_CONFIG_CNT";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetCntConfig(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        private void btnSetEncConfig_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ SET_CONFIG_ENC " + this.EncConfig;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateSetEncConfig(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnGetEncConfig_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ GET_CONFIG_ENC";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetEncConfig(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        private void btnStart_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ START";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateStart(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ STOP";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateStopDaq(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnStatus_Click(object sender, EventArgs e)
        {
            Int32 rt;

            __req = "DAQ STATUS";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................


            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            Int32 rt;
            double[][] data;


            __req = "DAQ GET";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetDaqData(ref __res, out data);
            if (rt > 0)
                PlotData(data);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnOffsetsCount_Click(object sender, EventArgs e)
        {
            Int32 rt;
            double[][] data;


            __req = "DAQ OFFSETS COUNT " + this.OffsetsNumSamples + " " + this.OffsetsCountTime;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................


            rt = EvaluateOffsetsCount(ref __res);
           

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        //----------------------------------
        #endregion



        private void btnOffsetsGet_Click(object sender, EventArgs e)
        {
            Int32 rt;
            double[][] data;


            __req = "DAQ OFFSETS GET";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................


            rt = EvaluateOffsetsGet(ref __res);


            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }

        private void btnDaqOffsetsAbort_Click(object sender, EventArgs e)
        {
            Int32 rt;
            double[][] data;


            __req = "DAQ OFFSETS ABORT";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateOffsetsAbort(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }
        private void btnOffsetsStatus_Click(object sender, EventArgs e)
        {
            Int32 rt;
            double[][] data;


            __req = "DAQ OFFSETS STATUS";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................


            rt = EvaluateOffsetsStatus(ref __res);


            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }





        private void btnGetDaqDataStartTimer_Click(object sender, EventArgs e)
        {
            double interval = Convert.ToDouble(nudGetDataTimerInterval.Value);

            __getDaqDataTimer = new System.Timers.Timer(interval);
            __getDaqDataTimer.Elapsed += __getDaqDataTimer_Elapsed;
            __getDaqDataTimer.AutoReset = true;
            __getDaqDataTimer.Enabled = true;


        }
        private void btnGetDaqDataStopTimer_Click(object sender, EventArgs e)
        {
            __getDaqDataTimer.Enabled = false;
        }
        private void __getDaqDataTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Int32 rt;
            double[][] data;


            __req = "DAQ GET";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateGetDaqData(ref __res, out data);
            if (rt > 0)
                PlotData(data);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................

            Application.DoEvents();
        }






    }
}
