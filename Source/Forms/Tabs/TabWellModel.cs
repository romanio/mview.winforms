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
        int selectedRow = -1;

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
                model.ReadWellData();
            }

            boxChartMode.SelectedIndex = 0;
            boxDepthMode.SelectedIndex = 0;
            boxLumping.SelectedIndex = 0;

            plotModel = new PlotModel
            {
                DefaultFont = "Segoe UI",
                DefaultFontSize = 10,
                TitleFontSize = 10,
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

        string wellname = null;

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            suspendEvents = true;

            if (data.selectedNames.Count > 0)
            {
                wellname = data.selectedNames[0];

                model.GetWellData(wellname);

                UpdateChart();
            }

            suspendEvents = false;
        }


        void UpdateChart()
        {
            if (model.WELL == null)
            {
                plotModel.Title = "not found";
                plotModel.InvalidatePlot(true);
                return;
            }

            plotModel.Title = model.WELL.WELLNAME;

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
                        gridData.Columns[4].HeaderText = "Liquid, m3/day";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Aqua;

                        DrawGraph((x) => x.WPR + x.OPR, model.MODI.LIQ);
                        break;

                    case 1: // Oil production
                        plotModel.Axes[0].Title = "Oil, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        gridData.Columns[4].HeaderText = "Oil, m3/day";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawGraph((x) => x.OPR, model.MODI.OIL);
                        break;

                    case 2: // Water production
                        plotModel.Axes[0].Title = "Water, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        gridData.Columns[4].HeaderText = "Water, m3/day";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.BlueViolet;

                        DrawGraph((x) => x.WPR, model.MODI.WATER);
                        break;

                    case 3: // Gas production
                        plotModel.Axes[0].Title = "Gas, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        gridData.Columns[4].HeaderText = "Gas, m3/day";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.BlueViolet;

                        DrawGraph((x) => x.GPR, model.MODI.GAS);
                        break;

                    case 4: // Water Cut
                        plotModel.Axes[0].Title = "Water Cut";
                        plotModel.Axes[1].Title = "Depth, m";
                        gridData.Columns[4].HeaderText = "Water Cut";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.CadetBlue;

                        DrawGraph((x) => x.WPR / (x.WPR + x.OPR), model.MODI.WCUT);
                        break;

                    case 5: // Connection Factor
                        plotModel.Axes[0].Title = "PI, m3/day/bar";
                        plotModel.Axes[1].Title = "Depth, m";
                        gridData.Columns[4].HeaderText = "PI, m3/day/bar";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawGraph((x) => (x.OPR + x.WPR) / (x.PRESS - x.Hw - model.WELL.WBHP), model.MODI.CPI);
                        break;
                }
                
            }
         }


        void DrawGraph(Func<ECL.COMPLDATA, double> get_value, double[] modi)
        {
            gridData.Rows.Clear();

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
                if (model.WELL.COMPLS[iw].STATUS != 1) continue;

                int row = gridData.Rows.Add();

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

                    gridData[0, row].Value = model.WELL.COMPLS[iw].I + 1;
                    gridData[1, row].Value = model.WELL.COMPLS[iw].J + 1;
                    gridData[2, row].Value = model.WELL.COMPLS[iw].K + 1;
                    gridData[3, row].Value = model.WELL.COMPLS[iw].LUMPNUM;
                    gridData[4, row].Value = value;
                    gridData[5, row].Value = iw;
                    gridData[6, row].Value = model.WELL.COMPLS[iw].WPIMULT;
                    gridData[7, row].Value = modi[iw];

                    ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));
                    ((RectangleBarSeries)plotModel.Series[1]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));

                    if (checkShowModiValue.Checked)
                    {
                        ((RectangleBarSeries)plotModel.Series[0]).Items.Last().Title = modi[iw].ToString("N2");
                    }

                }
            }

            plotModel.InvalidatePlot(true);
        }

        void DrawGraphSelection(int selectedRow)
        {
            if (((RectangleBarSeries)plotModel.Series[1]).Items.Count == 0) return;

            ((RectangleBarSeries)plotModel.Series[2]).Items.Clear();

            var top = ((RectangleBarSeries)plotModel.Series[1]).Items[selectedRow].Y0;
            var bottom = ((RectangleBarSeries)plotModel.Series[1]).Items[selectedRow].Y1;
            var value = ((RectangleBarSeries)plotModel.Series[1]).Items[selectedRow].X1;

           ((RectangleBarSeries)plotModel.Series[2]).Items.Add(new RectangleBarItem(0, top, value, bottom));

            plotModel.InvalidatePlot(true);
        }

        private void BoxKeywordsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        private void Panel1OnPaint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            //model.UpdateECL(ecl);
        }

        private void boxRestartDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            model.ReadRestart(boxRestartDates.SelectedIndex);
            model.ReadWellData();
            model.GetWellData(wellname);

            UpdateChart();
        }

        private void checkShowModiValue_CheckedChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        private void boxDepthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        private void checkRoll_CheckedChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChart();
        }

        private void boxLumping_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            gridData.Columns[3].HeaderText = boxLumping.Text;

            if (boxLumping.SelectedIndex == 1) // BY K-VALUE
            {
                for (int iw = 0; iw < model.WELL.COMPLNUM; ++iw)
                {
                    model.WELL.COMPLS[iw].LUMPNUM = model.WELL.COMPLS[iw].K;
                }
    
            }

            if (boxLumping.SelectedIndex == 0)
            {
                for (int iw = 0; iw < model.WELL.COMPLNUM; ++iw)
                {
                    model.WELL.COMPLS[iw].LUMPNUM = 0;
                }
            }

            if (boxLumping.SelectedIndex > 1)
            {
                model.UpdateLumping(boxLumping.Text);
            }

            UpdateChart();
        }

        private void gridData_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (suspendEvents) return;

            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                if (gridData.SelectedCells.Count > 0)
                {
                    int selectedRow = gridData.SelectedCells[0].RowIndex;
                    int index = Convert.ToInt32(gridData.Rows[selectedRow].Cells[5].Value);

                    DrawGraphSelection(index);
                }
            }
        }

    }
}
