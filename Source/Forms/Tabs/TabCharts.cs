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
    public enum ChartsPosition
    {
        One,
        OnePlusTwo,
        OnePlusThree,
        Four
    }

    public partial class TabCharts : UserControl, ITabObserver
    {
        readonly bool suspendEvents = false;
        readonly ChartModel model = null;
        readonly StylesPanel stylesPanel = null;

        public TabCharts(EclipseProject ecl)
        {
            InitializeComponent();

            this.model = new ChartModel(ecl);

            stylesPanel = new StylesPanel();
            stylesPanel.UpdateData += StylesPanelOnUpdateData;

            suspendEvents = true;

            boxGroupMode.SelectedIndex = 0;
            boxChartsPositions.SelectedIndex = 1;

            UpdateChartPositions();

            kryptonWorkspace1.ApplyGridPages(false, Orientation.Horizontal, 2);
            
            suspendEvents = false;
        }

        public void UpdateSelectedWells(TabSelectedWellsData data)
        {
            // Update Tabs

            /*
            foreach (Krypton.Navigator.KryptonPage item in kryptonWorkspace1.AllPages())
            {
                if (item.Controls[0] is ChartControl)
                {
                    (item.Controls[0] as ChartControl).UpdateNames(data.selectedNames, data.type);

                }
            }
            */

            //foreach (ChartControl item in tableLayoutPanel1.Controls)
            //{
            //    item.UpdateNames(data.selectedNames, data.type);
           // }
        }

        private void StylesPanelOnUpdateData(object sender, StyleSettings e)
        {
            UpdateChartSettings(e);
        }

        void UpdateChartPositions()
        {



            /*
            kryptonWorkspaceCell1.Pages.Clear();

            for (int iw = 0; iw < 4; ++iw)
            {
                var page = new Krypton.Navigator.KryptonPage();
                page.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });

                kryptonWorkspaceCell1.Pages.Add(page);
            }

            UpdateChartSettings(stylesPanel.GetStyleSettings());

         
            */
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

            data.ShowAnnotations = checkShowAnno.Checked;

            data.StyleSettings = style;


            

            // foreach (ChartControl item in tableLayoutPanel1.Controls)
            // {
            //     item
            // }
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

        private void CheckShowAnnoOnCheckedChanged(object sender, EventArgs e)
        {
            UpdateChartSettings(null);
        }

        public void UpdateSelectedProjects(EclipseProject ecl)
        {
            model.UpdateECL(ecl);
        }

        private void kryptonWorkspace1_WorkspaceCellAdding(object sender, Krypton.Workspace.WorkspaceCellEventArgs e)
        {
            e.Cell.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            e.Cell.NavigatorMode = Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
        }
    }
}
