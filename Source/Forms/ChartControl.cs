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

                TitleFontSize = 12,
                DefaultFontSize = 11
            };

            plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                StringFormat = "dd.MM.yyyy",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 2,
            });

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 2,
            });

            plotView.Model = plotModel;
        }

        public void UpdateNames(List<string> names, NameOptions type)
        {
            suspendEvents = true;

            selectedNames = names;

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
            gridData.RowCount = model.GetStepCount();
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

                    for (int it = 0; it < selectedNames.Count; ++it)
                    {
                        var series = new LineSeries
                        {
                            LineStyle = LineStyle.Solid,
                            StrokeThickness = 1,
                            MarkerType = MarkerType.Circle,
                            MarkerSize = 3
                        };

                        series.Points.AddRange(fullData[it]);

                        plotModel.Series.Add(series);
                    }
                }
            }

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
}
