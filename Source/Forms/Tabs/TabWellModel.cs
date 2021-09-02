using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace mview
{
    public partial class TabWellModel : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        readonly ChartModel model = null;
        readonly PlotModel plotModel = null;
        readonly PlotModel plotHisto = null;
        readonly PlotModel plotHistoTotal = null;

        TypeCondition activeCondition = TypeCondition.Relative;

        double[] firstCondition = new double[2] { 10, 10000};
        double[] secondCondition = new double[2] { 20, 50000 };

        readonly List<Vector> selectedVectors = new List<Vector>();

        public TabWellModel(EclipseProject ecl)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered", 
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, gridData, new object[] { true });

            model = new ChartModel(ecl);

            plotHisto = new PlotModel
            {
                DefaultFont = "Segoe UI",

                TitleFontSize = 10,
                DefaultFontSize = 10,
            };

            var categoryAxes = new OxyPlot.Axes.CategoryAxis {
                Position = AxisPosition.Left,
                TitleFont = "Segoe UI Semilight",
                AxisTitleDistance = 8 };

            categoryAxes.Title = "Relative Deviation";
            categoryAxes.Labels.Add("<10%");
            categoryAxes.Labels.Add("10-20%");
            categoryAxes.Labels.Add(">20%");

            plotHisto.Axes.Add(categoryAxes);

            plotHisto.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                TitleFont = "Segoe UI Semilight",
                Title = "Well Count"
            });

            
            plotView.Model = plotModel;

            boxChartMode.SelectedIndex = 0;
            boxCriteriaType.SelectedIndex = 0;
            //
        }

        public void UpdateSelectedProjects()
        {
            suspendEvents = true;

            List<string> dates = new List<string>();

            for (int iw = 0; iw < model.GetStepCount(); ++iw)
            {
                dates.Add(model.GetDateByStep(iw).ToString());
            }

            boxDepthMode.Items.Clear();
            boxDepthMode.Items.AddRange(dates.ToArray());

            if (boxDepthMode.Items.Count > 0)
                boxDepthMode.SelectedIndex = boxDepthMode.Items.Count - 1;

            suspendEvents = false;
        }

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            System.Diagnostics.Debug.WriteLine("Event Selected Wells");

            suspendEvents = true;

            selectedVectors.Clear();

            foreach(string wellname in data.names)
            {
                selectedVectors.Add(model.GetDataVector(wellname));
            }

            UpdateChart();

            suspendEvents = false;
        }


        void UpdateChart()
        {
            if (boxDepthMode.SelectedIndex == -1) return;
            if (boxChartMode.SelectedIndex == -1) return;

            plotModel.Series.Clear();
            plotModel.Annotations.Clear();
            plotHisto.Series.Clear();
            plotHistoTotal.Series.Clear();

            plotModel.Title = boxChartMode.Text.ToUpper();

            gridData.Rows.Clear();

            plotModel.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.None,
                MarkerType = MarkerType.Circle,
                MarkerFill = Color.Orange.ToOxyColor(),
                MarkerStroke = Color.Black.ToOxyColor(),
                MarkerSize = 3
            });

            int timeStep = boxDepthMode.SelectedIndex;
            string keyword = "W" + boxChartMode.Text;

            double maxValue = 0;
            double absValue = 0;
            double relValue = 0;

            int over20 = 0;
            int over10 = 0;
            int less10 = 0;
            int sum = 0;

            double sumOver20 = 0;
            double sumOver10 = 0;
            double sumLess10 = 0;

            foreach (Vector well in selectedVectors)
            {
                var simIndex = well.Data.FirstOrDefault(c => c.keyword == keyword).index;
                var simValue = model.GetParamAtIndex(simIndex, timeStep);
                var histIndex = well.Data.FirstOrDefault(c => c.keyword == keyword + "H").index;
                var histValue = model.GetParamAtIndex(histIndex, timeStep);

                if (histValue != 0.00)
                {
                    int row = gridData.Rows.Add();

                    gridData[0, row].Value = well.Name;
                    gridData[1, row].Value = simValue;
                    gridData[2, row].Value = histValue;

                    absValue = simValue - histValue;
                    relValue = 100 * (simValue - histValue) / histValue;

                    gridData[3, row].Value = absValue;
                    gridData[4, row].Value = relValue;

                    // Критерии

                    if (activeCondition == TypeCondition.Relative)
                    {
                        if (Math.Abs(relValue) <= firstCondition[0])
                        {
                            sumLess10 += histValue;
                            less10++;
                        }

                        if ((Math.Abs(relValue) > firstCondition[0]) && (Math.Abs(relValue) <= secondCondition[0]))
                        {
                            sumOver10 += histValue;
                            over10++;
                        }

                        if (Math.Abs(relValue) > secondCondition[0])
                        {
                            sumOver20 += histValue;
                            over20++;
                        }
                    }

                    if (activeCondition == TypeCondition.Absolute)
                    {
                        if (Math.Abs(absValue) <= firstCondition[1])
                        {
                            sumLess10 += histValue;
                            less10++;
                        }

                        if ((Math.Abs(absValue) > firstCondition[1]) && (Math.Abs(absValue) <= secondCondition[1]))
                        {
                            sumOver10 += histValue;
                            over10++;
                        }

                        if (Math.Abs(absValue) > secondCondition[1])
                        {
                            sumOver20 += histValue;
                            over20++;
                        }
                    }
                    //
                    sum = less10 + over10 + over20;

                    var pointAnnotation = new OxyPlot.Annotations.PointAnnotation
                    {
                        Fill = Color.Orange.ToOxyColor(),
                        StrokeThickness = 1,
                        Stroke = Color.Black.ToOxyColor(),
                        X = Convert.ToDouble(simValue),
                        Y = Convert.ToDouble(histValue),
                        Text = well.Name,
                        FontSize = 9
                    };

                    plotModel.Annotations.Add(pointAnnotation);
                }

                if (simValue > maxValue) maxValue = simValue;
                if (histValue > maxValue) maxValue = histValue;
            }

            if (sum > 0)
            {
                // Линия хорошей адаптации

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Red.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(0, 0));
                ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(maxValue, maxValue));

                // Линия по первому условию

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Green.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Green.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Blue.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Blue.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                if (activeCondition == TypeCondition.Relative)
                {
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(maxValue, (100 + firstCondition[0]) * 0.01 * maxValue));

                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(maxValue, (100 - firstCondition[0]) * 0.01 * maxValue));

                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(maxValue, (100 + secondCondition[0]) * 0.01 * maxValue));

                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(maxValue, (100 - secondCondition[0]) * 0.01 * maxValue));

                    plotHisto.Axes[0].Title = "Relative Deviation";
                    plotHistoTotal.Axes[0].Title = "Relative Deviation";

                    ((CategoryAxis)plotHisto.Axes[0]).ItemsSource = new[] { "<" + firstCondition[0] + "%", firstCondition[0] + "-" + secondCondition[0] + " %", ">" + secondCondition[0] + "%" };
                    ((CategoryAxis)plotHistoTotal.Axes[0]).ItemsSource = new[] { "<" + firstCondition[0] + "%", firstCondition[0] + "-" + secondCondition[0] + " %", ">" + secondCondition[0] + "%" };
                }

                if (activeCondition == TypeCondition.Absolute)
                {
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, firstCondition[1]));
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(maxValue, maxValue + firstCondition[1]));

                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, -firstCondition[1]));
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(maxValue, maxValue - firstCondition[1]));

                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, secondCondition[1]));
                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(maxValue, maxValue + secondCondition[1]));

                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, -secondCondition[1]));
                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(maxValue, maxValue - secondCondition[1]));

                    plotHisto.Axes[0].Title = "Absolute Deviation";
                    plotHistoTotal.Axes[0].Title = "Absolute Deviation";
                    ((CategoryAxis)plotHisto.Axes[0]).ItemsSource = new[] { "<" + firstCondition[1], firstCondition[1] + "-" + secondCondition[1], ">" + secondCondition[1] };
                    ((CategoryAxis)plotHistoTotal.Axes[0]).ItemsSource = new[] { "<" + firstCondition[1], firstCondition[1] + "-" + secondCondition[1], ">" + secondCondition[1] };
                }

                plotHisto.Series.Add(new OxyPlot.Series.BarSeries
                {
                    BaseValue = 0,
                    FillColor = OxyColor.FromArgb(255, 255, 120, 0),
                    LabelPlacement = LabelPlacement.Middle,
                    LabelFormatString = "{0}"
                });

                ((BarSeries)plotHisto.Series[0]).Items.Add(new BarItem { Value = less10 });
                ((BarSeries)plotHisto.Series[0]).Items.Add(new BarItem { Value = over10 });
                ((BarSeries)plotHisto.Series[0]).Items.Add(new BarItem { Value = over20 });


                plotHistoTotal.Series.Add(new OxyPlot.Series.BarSeries
                {
                    BaseValue = 0,
                    FillColor = OxyColor.FromArgb(255, 255, 120, 0),
                    LabelPlacement = LabelPlacement.Middle,
                    LabelFormatString = "{0:.00}"
                });

                ((BarSeries)plotHistoTotal.Series[0]).Items.Add(new BarItem { Value = sumLess10 });
                ((BarSeries)plotHistoTotal.Series[0]).Items.Add(new BarItem { Value = sumOver10 });
                ((BarSeries)plotHistoTotal.Series[0]).Items.Add(new BarItem { Value = sumOver20 });


            }
            plotModel.InvalidatePlot(true);
            plotHisto.InvalidatePlot(true);
            plotHistoTotal.InvalidatePlot(true);
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
            if (boxCriteriaType.SelectedIndex == 0)
            {
                activeCondition = TypeCondition.Relative;
            }

            if (boxCriteriaType.SelectedIndex == 1)
            {
                activeCondition = TypeCondition.Absolute;

                
            }

            UpdateChart();
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            model.UpdateECL(ecl);
        }
    }
}
