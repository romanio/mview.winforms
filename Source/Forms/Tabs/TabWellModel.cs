using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using OxyPlot.Legends;

namespace mview
{
    public partial class TabWellModel : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        bool IsLumped = false;

        PlotModel plotModel = null;
        WellModel model;

        public TabWellModel(EclipseProject ecl)
        {
            InitializeComponent();

            SetDoubleBuffering();

            model = new WellModel(ecl);

            DefaultSetting();
        }

        void DefaultSetting()
        {
            suspendEvents = true;

            boxRestartDates.Items.Clear();

            boxRestartDates.BeginUpdate();
            boxRestartDates.Items.AddRange(model.GetRestartDates());

            if (boxRestartDates.Items.Count > 0)
            {
                boxRestartDates.SelectedIndex = boxRestartDates.Items.Count - 1;
                model.ReadRestart(boxRestartDates.SelectedIndex);
            }

            boxChartMode.SelectedIndex = 0;
            boxDepthMode.SelectedIndex = 0;
            boxLumping.SelectedIndex = 0;

            plotModel = new PlotModel
            {
                DefaultFont = "Segoe UI",
                DefaultFontSize = 10,
            };

            plotModel.Legends.Add(new OxyPlot.Legends.Legend
            {
                LegendPosition =  LegendPosition.RightTop,
                LegendPlacement = LegendPlacement.Outside,
                LegendFontSize = 8,
                LegendBackground = OxyColors.White
            });

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Title = "Value",
                Position = AxisPosition.Bottom,
                StringFormat = "N1",
                MajorGridlineStyle = LineStyle.Dash
            });


            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Title = "Depth",
                Position = OxyPlot.Axes.AxisPosition.Left,
                EndPosition = 0,
                StartPosition = 1,
                AxisTitleDistance = 8,
                MajorGridlineStyle = LineStyle.Dash
            });


            plotView.Model = plotModel;

            suspendEvents = false;
        }

        public void SetDoubleBuffering()
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                gridData,
                new object[] { true });
        }

        public void UpdateSelectedProjects()
        {
            suspendEvents = true;

            suspendEvents = false;
        }

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            suspendEvents = true;

            if (data.selectedNames.Count > 0)
            {
                model.GetWellData(data.selectedNames[0]);

                UpdateChart();
            }

            suspendEvents = false;
        }


        void UpdateChart()
        {
            if (model.WELL == null) return;

            plotModel.Series.Clear();

            // 0 Series Fill Rectangle

            plotModel.Series.Add(new RectangleBarSeries
            {
                StrokeThickness = 0,
            });

            // 1 Series Border Rectangle

            plotModel.Series.Add(new RectangleBarSeries
            {
                StrokeThickness = 1,
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.Transparent
            });

            // 2 Selected Rectangle

            plotModel.Series.Add(new RectangleBarSeries
            {
                StrokeThickness = 2,
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.Transparent
            });


            if (IsLumped == false)
            {
                switch (boxChartMode.SelectedIndex)
                {
                    case 0: // Liquid production

                        plotModel.Axes[0].Title = "Liquid, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Aqua;

                        DrawGraph((x) => x.WPR + x.OPR, model.MODI.LIQ_LIST);
                        break;

                    case 1: // Oil production
                        plotModel.Axes[0].Title = "Oil, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawGraph((x) => x.OPR, model.MODI.OIL_LIST);
                        break;

                    case 2: // Water production
                        plotModel.Axes[0].Title = "Water, m3/day";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.BlueViolet;

                        DrawGraph((x) => x.WPR, model.MODI.WATER_LIST);
                        break;

                    case 3: // Water Cut
                        plotModel.Axes[0].Title = "Water Cut";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.CadetBlue;

                        DrawGraph((x) => x.WPR / (x.WPR + x.OPR), model.MODI.WCUT_LIST);
                        break;

                    case 4: // Connection Factor
                        plotModel.Axes[0].Title = "PI, m3/day/bar";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawGraph((x) => (x.OPR + x.WPR) / (x.PRESS - x.Hw - model.WELL.WBHP), model.MODI.CPI_LIST);
                        break;
                }
            }
            /*
else
{
    switch (boxChartMode.SelectedIndex)
    {
        case 0: // Pressure drop 

            plotModel.Axes[0].Title = "(P - Pw), bar";
            plotModel.Axes[1].Title = "Depth, m";

            ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.OrangeRed;
            //DrawLumpGraph((x) => x.PRESS - x.Hw - m_welldata.WBHP, PDD_LIST);

            break;

        case 1: // Liquid production

            plotModel.Axes[0].Title = "Liquid, m3/day";
            plotModel.Axes[1].Title = "Depth, m";
            ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Aqua;

            DrawLumpGraph(LUMP_LIQ_LIST, LUMP_M_LIQ_LIST);
            break;

        case 2: // Oil production
            plotModel.Axes[0].Title = "Oil, m3/day";
            plotModel.Axes[1].Title = "Depth, m";
            ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

            DrawLumpGraph(LUMP_OIL_LIST, LUMP_M_OIL_LIST);
            break;

        case 3: // Water production
            plotModel.Axes[0].Title = "Water, m3/day";
            ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.BlueViolet;

            DrawLumpGraph(LUMP_WATER_LIST, LUMP_M_WATER_LIST);
            break;

        case 4: // Water Cut
            plotModel.Axes[0].Title = "Water Cut";
            plotModel.Axes[1].Title = "Depth, m";
            ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.CadetBlue;

            DrawLumpGraph(LUMP_WCUT_LIST, LUMP_M_WCUT_LIST);
            break;

        case 5: // Connection Factor
            plotModel.Axes[0].Title = "PI, m3/day/bar";
            plotModel.Axes[1].Title = "Depth, m";
            ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

            //DrawGraph((x) => (x.OPR + x.WPR) / (x.PRESS - x.Hw - m_welldata.WBHP), CPI_LIST);
            break;
    }
}
*/
        }

        void DrawGraph(Func<ECL.COMPLDATA, double> get_value, double[] modi)
        {
            double top = 0;
            double bottom = 0;

            switch (boxDepthMode.SelectedIndex)
            {
                case 0: // Depth
                    plotModel.Axes[1].Title = "Depth, m";
                    break;
                case 1: // // K-value
                    plotModel.Axes[1].Title = "K";
                    break;
            }

            for (int iw = 0; iw < model.WELL.COMPLNUM; ++iw)
            {
                if (model.WELL.COMPLS[iw].STATUS == 0) continue;
                    
                double value = get_value(model.WELL.COMPLS[iw]);

                if (!Double.IsNaN(value))
                {
                    switch (boxDepthMode.SelectedIndex)
                    {
                        case 0: // Depth 
                            top = model.WELL.COMPLS[iw].TopAverage;
                            bottom = model.WELL.COMPLS[iw].BottomAverage;
                            break;
                        case 1: // K-value
                            top = (model.WELL.COMPLS[iw].K + 1) - 0.5;
                            bottom = (model.WELL.COMPLS[iw].K + 1) + 0.5;
                            break;
                    }

                    ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));
                    ((RectangleBarSeries)plotModel.Series[1]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));

                    if (checkShowModiValue.Checked)
                    {
                        ((RectangleBarSeries)plotModel.Series[1]).Items.Last().Title = modi[iw].ToString("N2");
                    }
                    /*
                    if (iw == SelectedCell)
                        ((RectangleBarSeries)plotModel.Series[2]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));
                    */
                }
            }

            plotModel.InvalidatePlot(true);
        }
               

        private void BoxKeywordsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        private void BoxRestartDatesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        private void Panel1OnPaint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }

        private void BoxCriteriaTypeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            //model.UpdateECL(ecl);
        }

        private void boxRestartDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            model.ReadWellData();

            UpdateChart();
        }

        private void checkShowModiValue_CheckedChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }
    }
}
