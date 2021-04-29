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
    enum TypeCondition
    {
        Relative,
        Absolute
    }

    public partial class TabCrossplots : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        readonly MainFormModel model = null;
        readonly PlotModel plotModel = null;
        readonly PlotModel plotHisto = null;

        TypeCondition ActiveCondition = TypeCondition.Relative;
        double firstCondition = 10;
        double secondCondition = 20;



        readonly List<Vector> selectedVectors = new List<Vector>();

        public TabCrossplots(MainFormModel model)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered", 
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, gridData, new object[] { true });

            this.model = model;

            plotHisto = new PlotModel
            {
                DefaultFont = "Segoe UI",
                TitleFontSize = 10,
                DefaultFontSize = 10,
            };

            var categoryAxes = new OxyPlot.Axes.CategoryAxis { Position = AxisPosition.Left, AxisTitleDistance = 8 };

            categoryAxes.Title = "Relative Deviation";
            categoryAxes.Labels.Add("<10%");
            categoryAxes.Labels.Add("10-20%");
            categoryAxes.Labels.Add(">20%");

            plotHisto.Axes.Add(categoryAxes);

            plotHisto.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                AxisTitleDistance = 8,
                Title = "Well Count"
            });

            plotView1.Model = plotHisto;

            plotModel = new PlotModel
            {
                Title = "(No keyword)",
                DefaultFont = "Segoe UI",
                TitleFontSize = 10,
                DefaultFontSize = 10
            };

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Simualted",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 1,
            });


            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Historical",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 1,
            });

            plotView.Model = plotModel;

            boxKeywords.SelectedIndex = 0;
            //
        }

        public void UpdateSelectedProjects()
        {
            System.Diagnostics.Debug.WriteLine("Event Selected Projects");

            suspendEvents = true;

            List<string> dates = new List<string>();

            if (model.GetProjectNames().Count > 0) // Only first selected project
            {
                for (int iw = 0; iw < model.GetStepCount(); ++iw)
                {
                    dates.Add(model.GetDateByStep(iw).ToString());
                }

            }

            boxRestartDates.Items.Clear();
            boxRestartDates.Items.AddRange(dates.ToArray());

            if (boxRestartDates.Items.Count > 0)
                boxRestartDates.SelectedIndex = boxRestartDates.Items.Count - 1;

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
            if (boxRestartDates.SelectedIndex == -1) return;
            if (boxKeywords.SelectedIndex == -1) return;

            plotModel.Series.Clear();
            plotModel.Annotations.Clear();
            plotHisto.Series.Clear();

            plotModel.Title = boxKeywords.Text.ToUpper();

            gridData.Rows.Clear();

            plotModel.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.None,
                MarkerType = MarkerType.Circle,
                MarkerFill = Color.Orange.ToOxyColor(),
                MarkerStroke = Color.Black.ToOxyColor(),
                MarkerSize = 3
            });

            int timeStep = boxRestartDates.SelectedIndex;
            string keyword = "W" + boxKeywords.Text;

            double maxValue = 0;
            double absValue = 0;
            double relValue = 0;

            int over20 = 0;
            int over10 = 0;
            int less10 = 0;
            int sum = 0;

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

                    if (ActiveCondition == TypeCondition.Relative)
                    {
                        if (Math.Abs(relValue) <= firstCondition) less10++;
                        if ((Math.Abs(relValue) > firstCondition) && (Math.Abs(relValue) <= secondCondition)) over10++;
                        if (Math.Abs(relValue) > secondCondition) over20++;
                    }

                    if (ActiveCondition == TypeCondition.Absolute)
                    {
                        if (Math.Abs(absValue) <= firstCondition) less10++;
                        if ((Math.Abs(absValue) > firstCondition) && (Math.Abs(absValue) <= secondCondition)) over10++;
                        if (Math.Abs(absValue) > secondCondition) over20++;
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

                if (ActiveCondition == TypeCondition.Relative)
                {
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(maxValue, (100 + firstCondition) * 0.01 * maxValue));

                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(maxValue, (100 - firstCondition) * 0.01 * maxValue));

                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(maxValue, (100 + secondCondition) * 0.01 * maxValue));

                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(maxValue, (100 - secondCondition) * 0.01 * maxValue));

                    plotHisto.Axes[0].Title = "Relative Deviation";
                    
                    ((CategoryAxis)plotHisto.Axes[0]).ItemsSource = new[] { "<" + firstCondition + "%", firstCondition + "-" + secondCondition + " %", ">" + secondCondition + "%" };
                }

                if (ActiveCondition == TypeCondition.Absolute)
                {
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, firstCondition));
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(maxValue, maxValue + firstCondition));

                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, -firstCondition));
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(maxValue, maxValue - firstCondition));

                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, secondCondition));
                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(maxValue, maxValue + secondCondition));

                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, -secondCondition));
                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(maxValue, maxValue - secondCondition));

                    plotHisto.Axes[0].Title = "Absolute Deviation";
                    ((CategoryAxis)plotHisto.Axes[0]).ItemsSource = new[] { "<" + firstCondition, firstCondition + "-" + secondCondition, ">" + secondCondition };
                }

                plotHisto.Series.Add(new OxyPlot.Series.BarSeries
                {
                    BaseValue = 1,
                    FillColor = OxyColor.FromArgb(255, 255, 120, 0),
                    LabelPlacement = LabelPlacement.Middle,
                    LabelFormatString = "{0}"
                });

                ((BarSeries)plotHisto.Series[0]).Items.Add(new BarItem { Value = less10 });
                ((BarSeries)plotHisto.Series[0]).Items.Add(new BarItem { Value = over10 });
                ((BarSeries)plotHisto.Series[0]).Items.Add(new BarItem { Value = over20 });


            }
            plotModel.InvalidatePlot(true);
            plotHisto.InvalidatePlot(true);

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


    }
}
