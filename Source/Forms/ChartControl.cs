﻿using System;
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

namespace mview
{
    public partial class ChartControl : UserControl
    {
        private readonly PlotModel plotModel = null;
        private readonly ChartModel model = null;
        private bool suspendEvents = false;
        private List<string> selectedNames = null;
        private List<string> selectedKeywords = null;
        private int[] selectedIndex = null;
        private readonly ChartSettings settings = null;


        public ChartControl(ChartModel model)
        {
            InitializeComponent();

            this.model = model;

            plotModel = new PlotModel
            {
                Title = "(No wells)",
                DefaultFont = "Segoe UI",
                TitleFontSize = 10,
                DefaultFontSize = 10,
            };

            plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                StringFormat = "dd.MM.yyyy",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 1,
            });

      
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 1,
            });

            plotModel.Legends.Add(new OxyPlot.Legends.Legend { LegendPosition = OxyPlot.Legends.LegendPosition.LeftTop });
            plotView.Model = plotModel;

            settings = new ChartSettings { GroupingMode = GroupingMode.Normal };
        }

        public void UpdateSettings(ChartSettings data)
        {
            settings.GroupingMode = data.GroupingMode;

            if (data.StyleSettings != null)
                settings.StyleSettings = data.StyleSettings;
            
            settings.ShowAnnotations = data.ShowAnnotations;

            UpdateChartAndTable();
        }

        public void UpdateNames(List<string> names, NameOptions type)
        {
            if (names.Count == 0) return;

            suspendEvents = true;
            selectedNames = names;
            selectedKeywords = new List<string>();

            var tmp_names = new List<string>();
            foreach (string item in listKeywords.SelectedItems)
            {
                tmp_names.Add(item);
            }

            listKeywords.SuspendLayout();
            
            listKeywords.Items.Clear();
            listKeywords.Items.AddRange(model.GetKeywords(names[0], type));

            // Востановим выделенные слова

            foreach (string item in tmp_names)
            {
                int index = listKeywords.Items.IndexOf(item);

                if (index != -1)
                {
                    listKeywords.SetSelected(index, true);
                    selectedKeywords.Add(item);
                }
            }

            listKeywords.ResumeLayout();

            suspendEvents = false;
            
            UpdateChartAndTable();
        }

        void UpdateChartAndTable()
        {
            if (selectedKeywords == null) return;
            if (selectedNames == null) return;

            // Заглавие графика

            StringBuilder titleName = new StringBuilder();

            for (int iw = 0; iw < selectedNames.Count - 1; ++iw)
                titleName.Append(selectedNames[iw] + ", ");

            titleName.Append(selectedNames.Last());

            plotModel.Title = titleName.ToString();

            // Обновить таблицы

            gridData.ColumnCount = selectedNames.Count * selectedKeywords.Count + 1;
            gridData.Columns[0].HeaderText = "Date";
            gridData.RowCount = model.GetStepCount();

            gridData.VirtualMode = false;

            int index = 1;
            selectedIndex = new int[selectedNames.Count * selectedKeywords.Count];
            List<string> selectedUnits = new List<string>();

            for (int it = 0; it < selectedNames.Count; ++it)
            {
                var vector = model.GetDataVector(selectedNames[it]);

                if (vector != null)
                {
                    for (int iw = 0; iw < selectedKeywords.Count; ++iw)
                    {
                        var data = vector.Data.FirstOrDefault(c => c.keyword == listKeywords.SelectedItems[iw].ToString());
                        selectedIndex[index - 1] = data.index;
                        selectedUnits.Add(data.unit);
                        gridData.Columns[index++].HeaderText = vector.Name + "\n" + data.keyword + "\n" + data.unit;
                    }
                }
            }

            gridData.VirtualMode = true;

            // Размерность оси Y

            if (selectedUnits.Count > 0)
            {
                selectedUnits = selectedUnits.Distinct().ToList();

                StringBuilder axisYName = new StringBuilder();

                for (int iw = 0; iw < selectedUnits.Count - 1; ++iw)
                {
                    if (selectedUnits[iw] != "")
                    {
                        axisYName.Append(selectedUnits[iw] + ", ");
                    }
                }

                axisYName.Append(selectedUnits.Last());

                plotModel.Axes[1].Title = axisYName.ToString();
            }

            // Обновить графики

            plotModel.Series.Clear();

            plotModel.Legends.Clear();
            plotModel.Legends.Add(new OxyPlot.Legends.Legend { LegendPosition = settings.StyleSettings.LegendPosition });


            plotModel.Axes[0].MajorGridlineStyle = settings.StyleSettings.axisXStyle;
            plotModel.Axes[0].MajorGridlineThickness = settings.StyleSettings.axisXWidth;


            if (settings.StyleSettings.axisXColor != OxyPlot.OxyColor.Parse("None"))
            {

                plotModel.Axes[0].MajorGridlineColor = OxyColor.FromRgb(
                    settings.StyleSettings.axisXColor.R,
                    settings.StyleSettings.axisXColor.G,
                    settings.StyleSettings.axisXColor.B);
            };

            plotModel.Axes[1].MajorGridlineStyle = settings.StyleSettings.axisYStyle;
            plotModel.Axes[1].MajorGridlineThickness = settings.StyleSettings.axisYWidth;

            if (settings.StyleSettings.axisYColor != OxyPlot.OxyColor.Parse("None"))
            {
                plotModel.Axes[1].MajorGridlineColor = OxyColor.FromRgb(
                    settings.StyleSettings.axisYColor.R,
                    settings.StyleSettings.axisYColor.G,
                    settings.StyleSettings.axisYColor.B);
            }

            //foreach (int projectIndex in selectedProjects)
            //{
                for (int iw = 0; iw < selectedKeywords.Count; ++iw)
                {
                    var fullData = new List<List<OxyPlot.DataPoint>>();

                    for (int it = 0; it < selectedNames.Count; ++it)
                    {
                        fullData.Add(model.GetDataTime(selectedNames[it], selectedKeywords[iw]));
                    }

                    // Обычный режим, отображается все графики как отдельные линии

                    if (settings.GroupingMode == GroupingMode.Normal)
                    {
                        for (int it = 0; it < selectedNames.Count; ++it)
                        {
                            var series = LineSeriesStyle(selectedKeywords[iw]);
                            series.Title = selectedKeywords[iw].ToString();
                            series.Points.AddRange(fullData[it]);

                            plotModel.Series.Add(series);
                        }
                    }

                    // Суммирование, отображается один график как сумма

                    if (settings.GroupingMode == GroupingMode.Sum)
                    {
                        List<DataPoint> sumValue = new List<DataPoint>();

                        for (int it = 0; it < model.GetStepCount(); ++it)
                        {
                            double value = 0;

                            for (int iq = 0; iq < fullData.Count; ++iq)
                            {
                                value += fullData[iq][it].Y;
                            }

                            sumValue.Add(new DataPoint(fullData[0][it].X, value));
                        }

                        var series = LineSeriesStyle(selectedKeywords[iw]);
                        series.Title = selectedKeywords[iw].ToString() + ".sum";
                        series.Points.AddRange(sumValue);

                        plotModel.Series.Add(series);

                        }

                    // Осреднение, отображается один график как среднее

                    if (settings.GroupingMode == GroupingMode.Average)
                    {
                        List<DataPoint> avValue = new List<DataPoint>();

                        for (int it = 0; it < model.GetStepCount(); ++it)
                        {
                            double value = 0;
                            double count = 0;

                            for (int iq = 0; iq < fullData.Count; ++iq)
                            {
                                if (fullData[iq][it].Y != 0)
                                {
                                    value += fullData[iq][it].Y;
                                    count++; 
                                }
                            }

                            avValue.Add(new DataPoint(fullData[0][it].X, count > 0 ? value / count : 0 ));
                        }

                        var series = LineSeriesStyle(selectedKeywords[iw]);
                        series.Title = selectedKeywords[iw].ToString() + ".av";
                        series.Points.AddRange(avValue);

                        plotModel.Series.Add(series);
                    }

                    // Средневзвешенное по жидкости, отображается один график

                    if (settings.GroupingMode == GroupingMode.AverageByLiquid)
                    {
                        // Собираем имя вектора жидкости
                        StringBuilder liquidName = new StringBuilder();

                        liquidName.Append(selectedKeywords[iw].Substring(0, 1));
                        liquidName.Append("LPR");

                        if (selectedKeywords[iw].EndsWith("H"))
                            liquidName.Append("H");

                        var oprData = new List<List<OxyPlot.DataPoint>>();

                        for (int it = 0; it < selectedNames.Count; ++it)
                        {
                            oprData.Add(model.GetDataTime(selectedNames[it], liquidName.ToString()));
                        }

                        List<DataPoint> avValue = new List<DataPoint>();

                        for (int it = 0; it < model.GetStepCount(); ++it)
                        {
                            double value = 0;
                            double sumLiq = 0;

                            for (int iq = 0; iq < fullData.Count; ++iq)
                            {
                                if (fullData[iq][it].Y != 0)
                                {
                                    value += fullData[iq][it].Y * oprData[iq][it].Y;
                                    sumLiq += oprData[iq][it].Y;
                                }
                            }

                            avValue.Add(new DataPoint(fullData[0][it].X, sumLiq > 0 ? value / sumLiq : 0));
                        }

                        var series = LineSeriesStyle(selectedKeywords[iw]);
                        series.Title = selectedKeywords[iw].ToString() + ".avliq";

                        series.Points.AddRange(avValue);

                        plotModel.Series.Add(series);
                    }
                }
        // }


            plotModel.Annotations.Clear();

            if (settings.ShowAnnotations)
            {
                if (plotModel.Series.Count > 0)
                {

                    for (int it = 0; it < selectedNames.Count; ++it)
                    {
                        var tmpAnnotations = model.GetAnnotation(selectedNames[it]);

                        if (tmpAnnotations != null)
                        {
                            foreach (AnnotationItem item in tmpAnnotations)
                            {
                                var date = OxyPlot.Axes.DateTimeAxis.ToDouble(item.time);
                                var res = ((LineSeries)plotModel.Series[0]).Points.FirstOrDefault(c => c.X == date);


                                plotModel.Annotations.Add(new OxyPlot.Annotations.TextAnnotation
                                {
                                    StrokeThickness = 0,
                                    TextPosition = new DataPoint(date, res.Y),
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

            plotModel.Axes[0].Reset();
            plotModel.Axes[1].Reset();
            plotModel.InvalidatePlot(true);
        }

        LineSeries LineSeriesStyle(string style)
        {
            LineSeries series = new LineSeries
            {
                TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
            };

            var tmpStyle = settings.StyleSettings.GetStyle(style);
            
            if (tmpStyle != null)
            {
                series.LineStyle = tmpStyle.lineStyle;
                series.StrokeThickness = tmpStyle.lineWidth;
                series.MarkerType = tmpStyle.markerType;
                series.MarkerSize = tmpStyle.markerSize;


                if (tmpStyle.markerFillColor != OxyPlot.OxyColor.Parse("None"))
                {
                    series.MarkerFill = tmpStyle.markerFillColor;
                }

                if (tmpStyle.lineColor != OxyPlot.OxyColor.Parse("None"))
                {
                    series.Color = tmpStyle.lineColor;
                }

                if (tmpStyle.markerColor != OxyPlot.OxyColor.Parse("None"))
                {
                    series.MarkerStroke = tmpStyle.markerColor;
                }
            }

            return series;
        }

        private void ListKeywordsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            selectedKeywords = new List<string>();

            foreach (object item in listKeywords.SelectedItems)
            {
                selectedKeywords.Add(item.ToString());
            }

            UpdateChartAndTable();
        }

        private void gridData_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.Value = model.GetDateByStep(e.RowIndex).ToString();
            else
                e.Value = model.GetParamAtIndex(selectedIndex[e.ColumnIndex - 1], e.RowIndex);
        }
    }


    public enum GroupingMode
    {
        Normal,
        Sum,
        Average,
        AverageByLiquid
    }

    public class ChartSettings
    {
        public GroupingMode GroupingMode;
        public StyleSettings StyleSettings;
        public bool ShowAnnotations;
    }
}
