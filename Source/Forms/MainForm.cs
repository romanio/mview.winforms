using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace mview
{
    public partial class MainForm : Form
    {
        private readonly MainFormModel model = new MainFormModel();
        readonly ControlPanel controlPanel = null;
        readonly ChartForm chartForm = null;
        private bool suspendEvents = false;

        public MainForm()
        {
            InitializeComponent();

            dockPanel1.Theme = this.vS2015LightTheme1;
            visualStudioToolStripExtender1.SetStyle(statusStrip1, VisualStudioToolStripExtender.VsVersion.Vs2003, this.vS2015LightTheme1);

            suspendEvents = true;

            controlPanel = new ControlPanel(model);
            controlPanel.UpdateData += ControlPanelOnUpdateData;
            chartForm = new ChartForm(model);

            controlPanel.Show(dockPanel1, DockState.DockLeft);
            chartForm.Show(dockPanel1, DockState.Document);


            boxGroupMode.SelectedIndex = 0;
            boxChartsPositions.SelectedIndex = 0;

            suspendEvents = false;
        }

        private void ControlPanelOnUpdateData(object sender, EventArgs e)
        {
            // Изменение списка выбранных проектов, уведомляем зависимых

            chartForm.UpdateFormData();
        }

        private void buttonOpenNewModel_Click_1(object sender, EventArgs e)
        {
            model.OpenNewModel();

            controlPanel.UpdateFormData();
        }

        void UpdateChartPositions()
        {
            ChartsPosition position = new ChartsPosition();

            switch (boxChartsPositions.SelectedIndex)
            {
                case 0:
                    position = ChartsPosition.One;
                    break;
                case 1:
                    position = ChartsPosition.OnePlusTwo;
                    break;
                case 2:
                    position = ChartsPosition.OnePlusThree;
                    break;
                case 3:
                    position = ChartsPosition.Four;
                    break;
            }

            chartForm.SetChartsPosition(position);
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

            chartForm.SetChartSettings(data);
        }

        private void boxGroupMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChartSettings();
        }

        private void boxChartsPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateChartPositions();
        }
    }
}
