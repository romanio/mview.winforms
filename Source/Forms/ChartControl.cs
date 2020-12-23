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

namespace mview
{
    public partial class ChartControl : UserControl
    {
        private PlotModel plotModel = null;
        private readonly MainFormModel model = null;
        private bool suspendEvents = false;
        private List<string> selectedNames = null;
        private List<string> selectedKeywords = null;
        private List<int> selectedProjects = null;
        private int[] selectedIndex = null;
        private ChartSettings settings = null;


        public ChartControl(MainFormModel model)
        {
            InitializeComponent();

            //
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, gridData, new object[] { true });
            //


            this.model = model;

            plotModel = new PlotModel
            {
                Title = "(No wells yet)",
                DefaultFont = "Segoe UI",

                TitleFontSize = 13,
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

            plotView.Model = plotModel;

            settings = new ChartSettings { GroupingMode = GroupingMode.Normal };
        }

        public void UpdateSettings(ChartSettings data)
        {
            settings = data;

            UpdateChartAndTable();
        }

        public void UpdateNames(List<string> names, NameOptions type)
        {
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

            int index = -1;

            foreach (string item in tmp_names)
            {
                index = listKeywords.Items.IndexOf(item);

                if (index != -1)
                {
                    listKeywords.SetSelected(index, true);
                    selectedKeywords.Add(item);
                }
            }

  
            listKeywords.ResumeLayout();

            suspendEvents = false;

            // Индексы выбранных проектов

            selectedProjects = model.GetSelectedProjectIndex();
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
            gridData.RowCount = model.GetStepCount(selectedProjects[0]);

            gridData.VirtualMode = false;

            int index = 1;
            selectedIndex = new int[selectedNames.Count * selectedKeywords.Count];
            List<string> selectedUnits = new List<string>();

            for (int it = 0; it < selectedNames.Count; ++it)
            {
                var vector = model.GetDataVector(selectedNames[it]);

                for (int iw = 0; iw < selectedKeywords.Count; ++iw)
                {
                    var data = vector.Data.FirstOrDefault(c => c.keyword == listKeywords.SelectedItems[iw].ToString());
                    selectedIndex[index - 1] = data.index;
                    selectedUnits.Add(data.unit);
                    gridData.Columns[index++].HeaderText = vector.Name + "\n" + data.keyword + "\n" + data.unit;
                }
            }

            gridData.VirtualMode = true;

            // Размерность оси Y

            if (selectedUnits.Count > 0)
            {
                selectedUnits = selectedUnits.Distinct().ToList();

                StringBuilder axisYName = new StringBuilder();

                for (int iw = 0; iw < selectedUnits.Count - 1; ++iw)
                    axisYName.Append(selectedUnits[iw] + ", ");

                axisYName.Append(selectedUnits.Last());

                plotModel.Axes[1].Title = axisYName.ToString();
            }

            // Обновить графики

            plotModel.Series.Clear();

            foreach(int projectIndex in selectedProjects)
            {
                for (int iw = 0; iw < selectedKeywords.Count; ++iw)
                {
                    // Для выбранного имени вектора, требутеся собрать данные по всем именам

                    var fullData = new List<List<OxyPlot.DataPoint>>();

                    for (int it = 0; it < selectedNames.Count; ++it)
                    {
                        fullData.Add(model.GetDataTime(projectIndex, selectedNames[it], selectedKeywords[iw]));
                    }

                    // Для разных режимов отображения, графики разные

                    // Обычный режим, отображается все графики как отдельные линии

                    if (settings.GroupingMode == GroupingMode.Normal)
                    {
                        for (int it = 0; it < selectedNames.Count; ++it)
                        {
                            var series = new LineSeries
                            {
                                Title = selectedNames[it].ToString(),
                                LineStyle = LineStyle.Solid,
                                StrokeThickness = 1,
                                MarkerType = MarkerType.Circle,
                                MarkerStroke = OxyColors.Black,
                                MarkerFill = OxyColors.Transparent,
                                MarkerSize = 3,
                                TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
                            };

                            series.Points.AddRange(fullData[it]);

                            plotModel.Series.Add(series);
                        }
                    }

                    // Суммирование, отображается один график как сумма

                    if (settings.GroupingMode == GroupingMode.Sum)
                    {
                        List<DataPoint> sumValue = new List<DataPoint>();

                        for (int it = 0; it < model.GetStepCount(projectIndex); ++it)
                        {
                            double value = 0;

                            for (int iq = 0; iq < fullData.Count; ++iq)
                            {
                                value += fullData[iq][it].Y;
                            }

                            sumValue.Add(new DataPoint(fullData[0][it].X, value));
                        }

                        var series = new LineSeries
                        {
                            Title = selectedKeywords[iw].ToString() + ".sum",
                            LineStyle = LineStyle.Solid,
                            StrokeThickness = 1,
                            MarkerType = MarkerType.Circle,
                            MarkerStroke = OxyColors.Black,
                            MarkerFill = OxyColors.Transparent,
                            MarkerSize = 3,
                            TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
                        };

                        series.Points.AddRange(sumValue);

                        plotModel.Series.Add(series);

                        }

                    // Осреднение, отображается один график как среднее

                    if (settings.GroupingMode == GroupingMode.Average)
                    {
                        List<DataPoint> avValue = new List<DataPoint>();

                        for (int it = 0; it < model.GetStepCount(projectIndex); ++it)
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

                        var series = new LineSeries
                        {
                            Title = selectedKeywords[iw].ToString() + ".av",
                            LineStyle = LineStyle.Solid,
                            StrokeThickness = 1,
                            MarkerType = MarkerType.Circle,
                            MarkerStroke = OxyColors.Black,
                            MarkerFill = OxyColors.Transparent,
                            MarkerSize = 3,
                            TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
                        };

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
                            oprData.Add(model.GetDataTime(projectIndex, selectedNames[it], liquidName.ToString()));
                        }

                        List<DataPoint> avValue = new List<DataPoint>();

                        for (int it = 0; it < model.GetStepCount(projectIndex); ++it)
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

                        var series = new LineSeries
                        {
                            Title = selectedKeywords[iw].ToString() + ".avbyliq",
                            LineStyle = LineStyle.Solid,
                            StrokeThickness = 1,
                            MarkerType = MarkerType.Circle,
                            MarkerStroke = OxyColors.Black,
                            MarkerFill = OxyColors.Transparent,
                            MarkerSize = 3,
                            TrackerFormatString = "{0} \n{4:0.##} {3}\n{2}"
                        };

                        series.Points.AddRange(avValue);

                        plotModel.Series.Add(series);
                    }
                }
            }

            plotModel.Axes[0].Reset();
            plotModel.Axes[1].Reset();
            plotModel.InvalidatePlot(true);

        }

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
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
                e.Value = model.GetDateByStep(e.RowIndex).ToString(); //.ToShortDateString();
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
    }
}
