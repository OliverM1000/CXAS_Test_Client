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
    public partial class CRegionUI : Form
    {
        #region Constants
        //----------------------------------
        private const Int32 OFFSET_RT = 0;
        private const Int32 OFFSET_KEYWORD = 1;
        private const Int32 OFFSET_COMMAND = 2;
        //----------------------------------
        private const Int32 OFFSET_TYPE = 3;
        private const Int32 OFFSET_REAL_POINTS = 7;
        private const Int32 OFFSET_TYPE_S_DATA = 13;
        private const Int32 OFFSET_TYPE_EXAFS_DATA = 17;
        //----------------------------------
        private const Int32 RESPONSE_LENGTH_READ_S = 14;
        private const Int32 RESPONSE_LENGTH_READ_EXAFS = 17;
        //----------------------------------
        #endregion


        #region Variables
        //----------------------------------
        private string __req;
        private string __res;
        private SendFunc __SendFunc;
        private FinalFunc __FinalFunc;
        //----------------------------------
        #endregion



        #region Public Properties
        //----------------------------------
        public Plot Plot { get; set; }
        public double LatticeSpacing {get; set;}
        //----------------------------------
        public string Type
        {
            get { return tbType.Text; }
            set { tbType.Text = value; }
        }
        public string CRegionName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Element
        {
            get { return tbElement.Text; }
            set { tbElement.Text = value; }
        }
        public string Edge
        {
            get { return tbEdge.Text; }
            set { tbEdge.Text = value; }
        }
        public string Points
        {
            get { return tbPoints.Text; }
            set { tbPoints.Text = value; }
        }
        public string EEdge
        {
            get { return tbEEdge.Text; }
            set { tbEEdge.Text = value; }
        }
        public string E1
        {
            get { return tbE1.Text; }
            set { tbE1.Text = value; }
        }
        public string E2
        {
            get { return tbE2.Text; }
            set { tbE2.Text = value; }
        }
        //----------------------------------
        public string EDot
        {
            get { return tbEDot.Text; }
            set { tbEDot.Text = value; }
        }
        public string EDotDot
        {
            get { return tbEDotDot.Text; }
            set { tbEDotDot.Text = value; }
        }
        //----------------------------------
        public string Scaling
        {
            get { return tbScaling.Text; }
            set { tbScaling.Text = value; }
        }
        public string k0
        {
            get { return tbK0.Text; }
            set { tbK0.Text = value; }
        }
        public string k0Dot
        {
            get { return tbK0Dot.Text; }
            set { tbK0Dot.Text = value; }
        }
        public string TTA
        {
            get { return tbTTA.Text; }
            set { tbTTA.Text = value; }
        }
        public string TTD
        {
            get { return tbTTD.Text; }
            set { tbTTD.Text = value; }
        }
        //----------------------------------
        #endregion



        #region Private Properties
        //----------------------------------
        private Int32 RealPoints
        {
            get { return Convert.ToInt32(tbRealPoints.Text); }
            set { tbRealPoints.Text = value.ToString("F0"); }
        }
        private double dE
        {
            get { return Convert.ToDouble(tbDE.Text); }
            set { tbDE.Text = value.ToString("F2"); }
        }
        private double MinTime
        {
            get { return Convert.ToDouble(tbMinTime.Text); }
            set { tbMinTime.Text = value.ToString("F4"); }
        }
        private double MaxTime
        {
            get { return Convert.ToDouble(tbMaxTime.Text); }
            set { tbMaxTime.Text = value.ToString("F4"); }
        }
        private double TotalTime
        {
            get { return Convert.ToDouble(tbTotalTime.Text); }
            set { tbTotalTime.Text = value.ToString("F2"); }
        }
        private double MaxPhiDot
        {
            get { return Convert.ToDouble(tbMaxPhiDot.Text); }
            set { tbMaxPhiDot.Text = value.ToString("F2"); }
        }
        private double MaxPhiDotDot
        {
            get { return Convert.ToDouble(tbMaxPhiDotDot.Text); }
            set { tbMaxPhiDotDot.Text = value.ToString("F2"); }
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
        public CRegionUI(SendFunc _SendFunc, FinalFunc _FinalFunc)
        {
            __SendFunc = _SendFunc;
            __FinalFunc = _FinalFunc;

            InitializeComponent();
        }
        //==================================


        #region Priavte Methods
        //----------------------------------
        private void PlotData(double[][] _data)
        {
            if (this.Plot == null)
                return;

            this.Plot.PlotData(0, _data);
        }
        private void ClearPlot()
        {
            this.Plot.ClearPlot(0);
        }
        //----------------------------------
        private Int32 CalculateCRegionInfo(ref double[][] _data)
        {
            Int32 rt;
            double tmp;
            double tmpPhiA, tmpPhiB;
            double tmpPhiDotA, tmpPhiDotB;
            double tmpPhiDotDot;


            double dE;
            double minTime;
            double maxTime;
            double totalTime;
            double maxPhiDot;
            double maxPhiDotDot;


            // find minTime, maxTime, totalTime, dE
            totalTime = _data[0][_data[0].Length - 1];
            minTime = _data[0][_data[0].Length - 1];
            maxTime = 0;
            dE = 0;
            for (Int32 i = 0; i < _data[0].Length - 1; i++)
            {
                tmp = _data[0][i + 1] - _data[0][i];

                if (tmp < minTime)
                    minTime = tmp;

                if (tmp > maxTime)
                    maxTime = tmp;

                tmp = _data[1][i + 1] - _data[1][i];
                if (tmp > dE)
                    dE = tmp;
            }

            this.TotalTime = totalTime;
            this.MinTime = minTime;
            this.MaxTime = maxTime;
            this.dE = dE;



            //find maxPhiDot, maxPhiDotDot
            maxPhiDot = 0;
            maxPhiDotDot = 0;
            for (Int32 i = 0; i < _data[0].Length - 3; i++)
            {
                rt = XasUtils.ConvertEnergyToAngle(_data[1][i + 2], this.LatticeSpacing, out tmpPhiA);
                if (rt < 0) return -1;
                rt = XasUtils.ConvertEnergyToAngle(_data[1][i + 0], this.LatticeSpacing, out tmpPhiB);
                if (rt < 0) return -1;
                tmpPhiDotA = tmpPhiA - tmpPhiB;
                tmpPhiDotA /= _data[0][i + 2] - _data[0][i];


                rt = XasUtils.ConvertEnergyToAngle(_data[1][i + 3], this.LatticeSpacing, out tmpPhiA);
                if (rt < 0) return -1;
                rt = XasUtils.ConvertEnergyToAngle(_data[1][i + 1], this.LatticeSpacing, out tmpPhiB);
                if (rt < 0) return -1;
                tmpPhiDotB = tmpPhiA - tmpPhiB;
                tmpPhiDotB /= _data[0][i + 3] - _data[0][i + 1];


                tmpPhiDotDot = tmpPhiB - tmpPhiA;
                tmpPhiDotDot /= _data[0][i + 2] - _data[0][i + 1];


                if (Math.Abs(tmpPhiDotA) > maxPhiDot)
                    maxPhiDot = Math.Abs(tmpPhiDotA);

                if (Math.Abs(tmpPhiDotDot) > maxPhiDotDot)
                    maxPhiDotDot = Math.Abs(tmpPhiDotDot);

            }

            this.MaxPhiDot = maxPhiDot;
            this.MaxPhiDotDot = maxPhiDotDot;

            return 1;

        }
        //----------------------------------
        private Int32 EvaluateMake(ref string _res, out double[][] _trajectory)
        {
            Int32 rt;
            string[] resArr;
            string[] resSplit;
            string[] data;            


            _trajectory = new double[2][];
            _trajectory[0] = new double[2];
            _trajectory[1] = new double[2];

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "CREGION")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "MAKE")
                    return -1;


                resSplit = _res.Split("\r");                
                _trajectory = new double[2][];
                _trajectory[0] = new double[resSplit.Length - 1];
                _trajectory[1] = new double[resSplit.Length - 1];
                for (Int32 i = 0; i < resSplit.Length - 1; i++)
                {
                    data = resSplit[i + 1].Split();
                    
                    _trajectory[0][i] = Convert.ToDouble(data[0]);
                    _trajectory[1][i] = Convert.ToDouble(data[1]);
                }

                rt = CalculateCRegionInfo(ref _trajectory);
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        private Int32 EvaluateList(ref string _res)
        {
            Int32 rt;
            string[] resArr;
            string[] resSplit;


            try
            {
                resArr = _res.Split();
              
                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "CREGION")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "LIST")
                    return -1;


                resSplit = _res.Split("\r");
                for (int i = 1; i < resSplit.Length; i++)
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

        private Int32 EvaluateRead(ref string _res)
        {
            string[] resArr;
            string[] resSplit;
            
            Int32 OFFSET_TYPE       = 0;
            Int32 OFFSET_NAME       = 1;
            Int32 OFFSET_ELEMENT    = 2;
            Int32 OFFSET_EDGE       = 3;
            Int32 OFFSET_POINTS     = 4;
            Int32 OFFSET_EEDGE      = 5;
            Int32 OFFSET_E1         = 6;
            Int32 OFFSET_E2         = 7;
            
            Int32 OFFSET_EDOT       = 8;
            Int32 OFFSET_EDOTDOT    = 9;

            Int32 OFFSET_K0         = 8;
            Int32 OFFSET_K0DOT      = 9;
            Int32 OFFSET_SCALING    = 10;
            Int32 OFFSET_TTA        = 11;
            Int32 OFFSET_TTD        = 12;

            try
            {
                resArr = _res.Split();

                if (    resArr.Length != RESPONSE_LENGTH_READ_S &&
                        resArr.Length != RESPONSE_LENGTH_READ_EXAFS)
                    return -1;

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "CREGION")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "READ")
                    return -1;


                resSplit = _res.Split("\r");
                
                this.Type           = resSplit[1].Split()[OFFSET_TYPE];
                this.CRegionName    = resSplit[1].Split()[OFFSET_NAME];
                this.Element        = resSplit[1].Split()[OFFSET_ELEMENT];
                this.Edge           = resSplit[1].Split()[OFFSET_EDGE];
                this.Points         = resSplit[1].Split()[OFFSET_POINTS];
                this.EEdge          = resSplit[1].Split()[OFFSET_EEDGE];
                this.E1             = resSplit[1].Split()[OFFSET_E1];
                this.E2             = resSplit[1].Split()[OFFSET_E2];


                if (resSplit[1].Split()[OFFSET_TYPE] == "EXAFS")
                {
                    this.EDot       = "";
                    this.EDotDot    = "";

                    this.k0         = resSplit[1].Split()[OFFSET_K0];
                    this.k0Dot      = resSplit[1].Split()[OFFSET_K0DOT];
                    this.Scaling    = resSplit[1].Split()[OFFSET_SCALING];
                    this.TTA        = resSplit[1].Split()[OFFSET_TTA];
                    this.TTD        = resSplit[1].Split()[OFFSET_TTD];
                }
                else
                {
                    this.EDot       = resSplit[1].Split()[OFFSET_EDOT];
                    this.EDotDot    = resSplit[1].Split()[OFFSET_EDOTDOT];

                    this.k0         = "";
                    this.k0Dot      = "";
                    this.Scaling    = "";
                    this.TTA        = "";
                    this.TTD        = "";
                }

            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }
        
        
        private Int32 EvaluateWrite(ref string _res)
        {
            string[] resArr;
            

            try
            {
                resArr = _res.Split();

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "CREGION")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "WRITE")
                    return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }


        private Int32 EvaluateDelete(ref string _res)
        {
            string[] resArr;

            try
            {
                resArr = _res.Split();

                if (resArr.Length != RESPONSE_LENGTH_READ_S &&
                        resArr.Length != RESPONSE_LENGTH_READ_EXAFS)
                    return -1;

                if (resArr[OFFSET_RT].ToUpper() != "SUCCESS")
                    return -1;

                if (resArr[OFFSET_KEYWORD].ToUpper() != "CREGION")
                    return -1;

                if (resArr[OFFSET_COMMAND].ToUpper() != "DELETE")
                    return -1;

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





        private void MakeCRegionString(out string _cregionString)
        {
            _cregionString = "";
            _cregionString += this.Type;
            _cregionString += " " + this.CRegionName;
            _cregionString += " " + this.Element;
            _cregionString += " " + this.Edge;
            _cregionString += " " + this.Points;
            _cregionString += " " + this.EEdge;
            _cregionString += " " + this.E1;
            _cregionString += " " + this.E2;

            if (this.Type == "S")
            {
                _cregionString += " " + this.EDot;
                _cregionString += " " + this.EDotDot;
            }
            else if (this.Type == "EXAFS")
            {
                _cregionString += " " + this.k0;
                _cregionString += " " + this.k0Dot;
                _cregionString += " " + this.Scaling;
                _cregionString += " " + this.TTA;
                _cregionString += " " + this.TTD;
            }
        }





        #region Buttons
        //----------------------------------
        private void btnMake_Click(object sender, EventArgs e)
        {
            Int32 rt;
            double[][] trajectory;
            
            MakeCRegionString(out __req);
            __req = "CREGION MAKE " + __req;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);            
            //..................................

            rt = EvaluateMake(ref __res, out trajectory);
            if (rt > 0)
                PlotData(trajectory);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Int32 rt;

            rtbConsole.Clear();

            __req = "CREGION LIST";
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateList(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Int32 rt;


            __req = "CREGION READ " + this.CRegionName;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateRead(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            Int32 rt;

            MakeCRegionString(out __req);
            __req = "CREGION WRITE " + __req;


            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateWrite(ref __res);
            if (rt > 0)
            { }

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 rt;
            
            __req = "CREGION DELETE " + this.CRegionName;
            __res = "";

            //..................................
            rt = __SendFunc(this, ref __req, ref __res);
            //..................................

            rt = EvaluateDelete(ref __res);

            //..................................
            __FinalFunc(this, ref __req, ref __res);
            //..................................
        }



        //----------------------------------
        #endregion


    }
}
