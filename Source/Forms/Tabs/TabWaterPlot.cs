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
    public partial class TabWaterPlot : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        readonly ChartModel model = null;
        readonly PlotModel plotModel = null;
        readonly List<Vector> selectedVectors = new List<Vector>();

        public TabWaterPlot(ChartModel model)
        {
            InitializeComponent();

            this.model = model;

            
            plotModel = new PlotModel
            {
                Title = "Water Diagnostic Plot",
                DefaultFont = "Segoe UI",
                TitleFontSize = 10,
                DefaultFontSize = 10
            };

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                TitleFont = "Segoe UI Semilight",
                Title = "Oil Production Total",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 1,
            });


            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                TitleFont = "Segoe UI Semilight",
                Title = "1 - WCUT",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 1,
                Minimum = 0, 
                Maximum = 1
            });

            plotModel.Legends.Add(new OxyPlot.Legends.Legend { LegendPosition = OxyPlot.Legends.LegendPosition.RightTop});

            plotView.Model = plotModel;

            boxCriteriaType.SelectedIndex = 0;
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
            
            suspendEvents = false;
        }

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            System.Diagnostics.Debug.WriteLine("Event Selected Wells");

            suspendEvents = true;

            selectedVectors.Clear();

            foreach(string wellname in data.selectedNames)
            {
                selectedVectors.Add(model.GetDataVector(wellname));
            }

            UpdateChart();

            suspendEvents = false;
        }


        void UpdateChart()
        {
            plotModel.Series.Clear();
            plotModel.Annotations.Clear();

            plotModel.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                MarkerType = MarkerType.Circle,
                MarkerStroke = OxyColors.Black,
                MarkerSize = 3,
                Title = "Simulated",
                TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
            });


            plotModel.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.Solid,
                MarkerType = MarkerType.Circle,
                MarkerStroke = OxyColors.Black,
                MarkerSize = 3,
                Title = "History",
                TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
            });

            int timeStep = model.GetStepCount();

            foreach (Vector well in selectedVectors)
            {
                var wwct = well.Data.FirstOrDefault(c => c.keyword == "WWCT").index;
                var wopt = well.Data.FirstOrDefault(c => c.keyword == "WOPT").index;
                var wwcth = well.Data.FirstOrDefault(c => c.keyword == "WWCTH").index;
                var wopth = well.Data.FirstOrDefault(c => c.keyword == "WOPTH").index;
                var wlpr = well.Data.FirstOrDefault(c => c.keyword == "WLPR").index;
                var wlprh = well.Data.FirstOrDefault(c => c.keyword == "WLPRH").index;

                for (int it = 0; it < timeStep; ++it)
                {
                    if (wlpr != 0)
                    {
                        if (model.GetParamAtIndex(wlpr, it) > 0)
                        {
                            ((LineSeries)plotModel.Series[0]).Points.Add(new DataPoint(model.GetParamAtIndex(wopt, it), 1 - model.GetParamAtIndex(wwct, it)));
                        }
                    }

                    if (wlprh != 0)
                    {
                        if (model.GetParamAtIndex(wlprh, it) > 0)
                        {
                            ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(model.GetParamAtIndex(wopth, it), 1 - model.GetParamAtIndex(wwcth, it)));
                        }
                    }
                }

                plotModel.Annotations.Clear();

                if (checkShowAnno.Checked)
                {
                    if (plotModel.Series.Count > 0)
                    {
                        for (int it = 0; it < selectedVectors.Count; ++it)
                        {
                            var tmpAnnotations = model.GetAnnotation(selectedVectors[it].Name);

                            if (tmpAnnotations != null)
                            {
                                var wopthData = model.GetDataTime(selectedVectors[it].Name, "WOPTH");
                                
                                foreach (AnnotationItem item in tmpAnnotations)
                                {
                                    var date = OxyPlot.Axes.DateTimeAxis.ToDouble(item.time);
                                    var res = wopthData.FirstOrDefault(c => c.X == date);
                                    var wcuth = ((LineSeries)plotModel.Series[1]).Points.FirstOrDefault(c => c.X == res.Y).Y;
                                    
                                    plotModel.Annotations.Add(new OxyPlot.Annotations.TextAnnotation
                                    {
                                        StrokeThickness = 0,
                                        TextPosition = new DataPoint(res.Y, wcuth),
                                        Font = "Segoe UI Semibold",
                                        TextRotation = -70,
                                        TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                                        Text = item.text
                                    });
                                }

                            }
                        }
                    }
                }
            }

                
            plotModel.InvalidatePlot(true);
        }

        private void Panel1OnPaint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }

        private void checkShowAnno_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }
    }
}
