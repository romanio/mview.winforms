using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class TabCharts : UserControl, ITabObserver
    {
        bool suspendEvents = false;
        MainFormModel model = null;
        readonly StylesPanel stylesPanel = null;

        public TabCharts(MainFormModel model)
        {
            InitializeComponent();

            this.model = model;

            stylesPanel = new StylesPanel();
            stylesPanel.UpdateData += StylesPanelOnUpdateData;


            suspendEvents = true;

            boxGroupMode.SelectedIndex = 0;
            boxChartsPositions.SelectedIndex = 1;

            UpdateChartPositions();

            suspendEvents = false;
        }

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            // Update Tabs

            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateNames(data.selectedNames, data.type);
            }
        }

        public void UpdateSelectedProjects()
        {
            // None
        }


        private void StylesPanelOnUpdateData(object sender, StyleSettings e)
        {
            UpdateChartSettings(e);
        }

        void UpdateChartPositions()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();


            switch (boxChartsPositions.SelectedIndex)
            {
                case 0:
                    tableLayoutPanel1.RowCount = 1;
                    tableLayoutPanel1.ColumnCount = 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                    break;
                case 1:
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                    tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                    break;
            }

            UpdateChartSettings(stylesPanel.GetStyleSettings());
        }



        void UpdateChartSettings(StyleSettings style)
        {
            var data = new ChartSettings();

            switch (boxGroupMode.SelectedIndex)
            {
                case 0:
                    data.GroupingMode = GroupingMode.Normal;
                    break;
                case 1:
                    data.GroupingMode = GroupingMode.Sum;
                    break;
                case 2:
                    data.GroupingMode = GroupingMode.Average;
                    break;
                case 3:
                    data.GroupingMode = GroupingMode.AverageByLiquid;
                    break;
            }

            data.StyleSettings = style;

            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateSettings(data);
            }
        }

        private void BoxGroupModeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChartSettings(null);
        }

        private void BoxChartsPositionsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChartPositions();
        }

        private void ButtonSeriesSettingsOnClick(object sender, EventArgs e)
        {
            stylesPanel.UpdateFormData(model.GetAllKeywords());
            stylesPanel.Show();
            stylesPanel.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }


    }
}
