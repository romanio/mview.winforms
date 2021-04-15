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
    public enum NameOptions
    {
        Aquifer,
        Block,
        Completion,
        Field,
        Group,
        LGBlock,
        LGCompletion,
        LGWell,
        Network,
        Region,
        RegionFlows,
        RegionComponent,
        WellSegment,
        Well,
        Other
    }

    public enum ChartsPosition
    {
        One,
        OnePlusTwo,
        OnePlusThree,
        Four
    }
    public partial class MainForm : Form
    {
        readonly MainFormModel model = new MainFormModel();
        readonly StylesPanel stylesPanel = null;
        readonly ControlPanel controlPanel = null;

        bool suspendEvents = false;
        NameOptions namesType = NameOptions.Well;

        public MainForm()
        {
            InitializeComponent();

            suspendEvents = true;

            stylesPanel = new StylesPanel();
            //stylesPanel.Up
          //  chartFiltersForm.UpdateData += ChartFiltersFormOnUpdateData;

            controlPanel = new ControlPanel(model);
            controlPanel.UpdateData += ControlPanelOnUpdateData;

            boxGroupMode.SelectedIndex = 0;
            boxChartsPositions.SelectedIndex = 1;
            boxNameType.SelectedIndex = 2;

            UpdateChartPositions();

            suspendEvents = false;
        }

        private void ControlPanelOnUpdateData(object sender, EventArgs e)
        {
            UpdateFormData();
        }

        void ModelsToolStripMenuItemOnClick(object sender, EventArgs e)
        {
            model.OpenNewModel();
            UpdateFormData();
        }

        public void UpdateFormData()
        {
            suspendEvents = true;

            var tmp_names = new List<string>();    // Сохраним список текущих выделенных имен
            foreach (string item in listNames.SelectedItems)
            {
                tmp_names.Add(item);
            }

            listNames.SuspendLayout();
            listNames.BeginUpdate();

            listNames.Items.Clear();
            listNames.Sorted = checkSorted.Checked;

            switch (boxNameType.SelectedIndex)
            {
                case 0:
                    namesType = NameOptions.Field;
                    break;
                case 1:
                    namesType = NameOptions.Group;
                    break;
                case 2:
                    namesType = NameOptions.Well;
                    break;
                case 3:
                    namesType = NameOptions.Completion;
                    break;
                case 4:
                    namesType = NameOptions.Aquifer;
                    break;
                case 5:
                    namesType = NameOptions.Region;
                    break;
                case 6:
                    namesType = NameOptions.Other;
                    break;
            }

            if (model.GetSelectedProjectIndex().Count > 0)
            {
                listNames.Items.AddRange(model.GetNamesByType(namesType));
                
                foreach (string item in tmp_names)
                {
                    int index = listNames.Items.IndexOf(item); // Востановим выделенные слова

                    if (index != -1)
                    {
                        listNames.SetSelected(index, true);
                    }
                }
            }

            listNames.ResumeLayout();
            listNames.EndUpdate();

            suspendEvents = false;
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
        }

        void UpdateChartSettings()
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

            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateSettings(data);
            }
        }

        private void ListNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            var names = new List<string>();

            foreach (object item in listNames.SelectedItems)
            {
                names.Add(item.ToString());
            }

            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateNames(names, namesType);
            }
        }
        private void BoxGroupModeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChartSettings();
        }

        private void BoxChartsPositionsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChartPositions();
        }


        private void ChartFiltersFormOnUpdateData(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void CheckSortedOnCheckedChanged(object sender, EventArgs e)
        {
            UpdateFormData();
        }

        private void BoxNameTypeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateFormData();
        }

        private void ButtonSeriesSettingsOnClick(object sender, EventArgs e)
        {
            stylesPanel.UpdateFormData(model.GetAllKeywords());
            stylesPanel.Show();
            stylesPanel.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controlPanel.UpdateFormData();
            controlPanel.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.LightSteelBlue, ButtonBorderStyle.Solid);
        }
    }
}
