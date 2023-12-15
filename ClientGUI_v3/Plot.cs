using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ClientGUI_v3
{
    public partial class Plot : Form
    {



        #region Variables
        //---------------------------------
        private Int32 __numberOfCurves = 2;
        private PointPairList[] __dataPointsArr;
        private LineItem[] __dataCurveArr;
        //---------------------------------
        string __title;
        string __xTitle;
        string __yTitle;
        bool __titleIsVisible;
        bool __xTitleIsVisible;
        bool __yTitleIsVisible;
        bool __showLegend;
        bool __showPoints;
        //---------------------------------
        #endregion



        #region Properties
        //---------------------------------
        public Int32 NumberOfCurves { get { return __numberOfCurves; } }
        //---------------------------------
        public string Title
        {
            get { return __title; }
            set
            {
                __title = value;
                zgcPlot.GraphPane.Title.Text = value;
                RefreshPlot();
            }
        }
        public string xTitle
        {
            get { return __xTitle; }
            set
            {
                __xTitle = value;
                zgcPlot.GraphPane.XAxis.Title.Text = value;
                RefreshPlot();
            }
        }
        public string yTitle
        {
            get { return __yTitle; }
            set
            {
                __yTitle = value;
                zgcPlot.GraphPane.XAxis.Title.Text = value;
                RefreshPlot();
            }
        }
        public bool TitleIsVisible
        {
            get { return __titleIsVisible; }
            set
            {
                __titleIsVisible = value;
                zgcPlot.GraphPane.Title.IsVisible = value;
                RefreshPlot();
            }
        }
        public bool xTitleIsVisible
        {
            get { return __xTitleIsVisible; }
            set
            {
                __xTitleIsVisible = value;
                zgcPlot.GraphPane.XAxis.Title.IsVisible = value;
                RefreshPlot();
            }
        }
        public bool yTitleIsVisible
        {
            get { return __yTitleIsVisible; }
            set
            {
                __yTitleIsVisible = value;
                zgcPlot.GraphPane.XAxis.Title.IsVisible = value;
                RefreshPlot();
            }
        }
        public bool ShowLegend
        {
            get { return __showLegend; }
            set
            {
                __showLegend = value;
                zgcPlot.GraphPane.Legend.IsVisible = value;
                RefreshPlot();
            }
        }
        public bool ShowPoints
        {
            get { return __showPoints; }
            set
            {
                __showPoints = value;
                for (Int32 i = 0; i < __numberOfCurves; i++)
                {
                    if(value)
                        __dataCurveArr[i].Symbol.Type = SymbolType.Circle;
                    else
                        __dataCurveArr[i].Symbol.Type = SymbolType.None;
                }
                RefreshPlot();
            }

        }
        //---------------------------------
        #endregion



        //==================================
        public Plot(Int32 _n)
        {

            if (_n < 0)
                __numberOfCurves = 1;
            else if (_n > 8)
                __numberOfCurves = 8;
            else
                __numberOfCurves = _n;

            InitializeComponent();

            zgcPlot.Location = new Point(0, 0);
            zgcPlot.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);


            this.Title = "";
            this.TitleIsVisible = false;

            this.xTitle = "";
            this.xTitleIsVisible = false;

            this.yTitle = "";
            this.yTitleIsVisible = false;

            __showLegend = false;
            __showPoints = true;

            InitPlot();
        }
        //==================================


        #region Private Methodd
        //---------------------------------
        private void InitPlot()
        {
            zgcPlot.GraphPane.Title.IsVisible = this.TitleIsVisible;
            zgcPlot.GraphPane.Title.Text = "";

            zgcPlot.GraphPane.XAxis.MajorGrid.IsVisible = true;
            zgcPlot.GraphPane.YAxis.MajorGrid.IsVisible = true;
            zgcPlot.GraphPane.XAxis.MajorGrid.Color = Color.Gray;
            zgcPlot.GraphPane.YAxis.MajorGrid.Color = Color.Gray;

            zgcPlot.GraphPane.XAxis.Title.Text = this.xTitle;
            zgcPlot.GraphPane.XAxis.Title.IsVisible = this.xTitleIsVisible;

            zgcPlot.GraphPane.YAxis.Title.Text = this.yTitle;
            zgcPlot.GraphPane.YAxis.Title.IsVisible = this.yTitleIsVisible;

            zgcPlot.GraphPane.Legend.IsVisible = false;

            __dataPointsArr = new PointPairList[__numberOfCurves];
            __dataCurveArr = new LineItem[__numberOfCurves];

            for (Int32 i = 0; i < __numberOfCurves; i++)
            {
                __dataPointsArr[i] = new PointPairList();
                __dataCurveArr[i] = zgcPlot.GraphPane.AddCurve(i.ToString(), __dataPointsArr[i], OmColors.ColorList[i % OmColors.ColorList.Length], SymbolType.Circle);                
                __dataCurveArr[i].Symbol.Fill = new Fill(OmColors.ColorList[i % OmColors.ColorList.Length]);
                __dataCurveArr[i].IsVisible = true;


                if (this.ShowPoints)
                    __dataCurveArr[i].Symbol.Type = SymbolType.Circle;
                else
                    __dataCurveArr[i].Symbol.Type = SymbolType.None;
            }

            RefreshPlot();
        }
        private void RefreshPlot()
        {
            zgcPlot.Invoke(new EventHandler(delegate
            {
                zgcPlot.AxisChange();
                zgcPlot.Refresh();                
            }));
        }
        //---------------------------------
        #endregion


        #region Public Methodd
        //---------------------------------
        public Int32 PlotData(Int32 _n, double[][] _data)
        {
            if (_n < 0 || _n > this.NumberOfCurves - 1)
                return -1;

            __dataPointsArr[_n].Clear();

            for (Int32 i = 0; i < _data[0].Length; i++)
            {
                __dataCurveArr[_n].AddPoint(_data[0][i], _data[1][i] );
            }

            RefreshPlot();
            return 1;
        }
        public void ClearPlot(Int32 _n)
        {
            __dataPointsArr[_n].Clear();
            RefreshPlot();
        }
        //---------------------------------
        #endregion


    }
}
