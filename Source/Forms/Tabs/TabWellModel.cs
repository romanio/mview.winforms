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
        //readonly ChartModel model = null;
        readonly PlotModel plotModel = null;
        readonly EclipseProject ecl;

        public TabWellModel(EclipseProject ecl)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered", 
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, gridData, new object[] { true });

            this.ecl = ecl;

            plotView.Model = plotModel;

            DefaultSetting();
            //
        }

        void DefaultSetting()
        {
            suspendEvents = true;

            var items = from item in ecl.RESTART.DATE
                        select item.ToString();

            boxRestartDates.Items.Clear();

            boxRestartDates.BeginUpdate();
            boxRestartDates.Items.AddRange(items.ToArray());

            if (boxRestartDates.Items.Count > 0)
            {
                boxRestartDates.SelectedIndex = boxRestartDates.Items.Count - 1;
                //model.ReadRestart(boxRestartDates.SelectedIndex);
            }

            boxChartMode.SelectedIndex = 0;
            boxDepthMode.SelectedIndex = 0;
            boxLumping.SelectedIndex = 0;

            suspendEvents = false;
        }


        public void UpdateSelectedProjects()
        {
            suspendEvents = true;

            List<string> dates = new List<string>();

            /*
            for (int iw = 0; iw < model.GetStepCount(); ++iw)
            {
                dates.Add(model.GetDateByStep(iw).ToString());
            }
            */

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

            UpdateChart();

            suspendEvents = false;
        }


        void UpdateChart()
        {
            if (boxDepthMode.SelectedIndex == -1) return;
            if (boxChartMode.SelectedIndex == -1) return;

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
    }
}
