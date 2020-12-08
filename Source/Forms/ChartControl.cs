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

namespace mview.Source.Forms
{
    public partial class ChartControl : UserControl
    {
        private PlotModel plotModel = null;

        public ChartControl()
        {
            InitializeComponent();

            plotModel = new PlotModel
            {
                Title = "(No wells yet)",
                DefaultFont = "Segoe UI",

                TitleFontSize = 12,
                //OxyPlot.Legends. LegendFontSize = 10,
                // LegendPosition = chartController.LegendPosition,

                DefaultFontSize = 11
            };

            plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                StringFormat = "dd.MM.yyyy",
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 2,
                MajorGridlineColor = OxyColors.GreenYellow
            });

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineThickness = 2,
                MajorGridlineColor = OxyColors.GreenYellow
            });

            plotView.Model = plotModel;
        }
    }
}
