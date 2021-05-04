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
        readonly ControlPanel controlPanel = null;
        readonly FilterPanel filterPanel = null;
        
        readonly List<ITabObserver> tabObservers = new List<ITabObserver>();

        NameOptions namesType = NameOptions.Well;
        bool suspendEvents = false;

        public MainForm()
        {
            InitializeComponent();

            suspendEvents = true;

            controlPanel = new ControlPanel(model);
            controlPanel.UpdateData += ControlPanelOnUpdateData;

            filterPanel = new FilterPanel();
            filterPanel.UpdateData += FilterPanelOnUpdateData;

            boxNameType.SelectedIndex = 2;

            suspendEvents = false;
        }

        private void FilterPanelOnUpdateData(object sender, EventArgs e)
        {
            if (filterPanel.GetFilteredWellnames().Length == 0)
            {
                buttonWellFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            }
            else
            {
                buttonWellFilter.ForeColor = System.Drawing.Color.Red;
            }
                    
            UpdateFormData();


            EventUpdateSelectedWells();
        }

        private void ControlPanelOnUpdateData(object sender, EventArgs e)
        {
            EventUpdateSelectedProject();

            UpdateFormData();

            EventUpdateSelectedWells();
        }

        public void UpdateFormData()
        {
            suspendEvents = true;

            var tmpNames = new List<string>();    // Сохраним список текущих выделенных имен
            foreach (string item in listNames.SelectedItems)
            {
                tmpNames.Add(item);
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
                if (namesType == NameOptions.Well)
                {
                    var filteredWellnames = filterPanel.GetFilteredWellnames();
                    var allWellnames = model.GetNamesByType(namesType);

                    if (filteredWellnames.Length == 0)
                    {
                        listNames.Items.AddRange(allWellnames);
                    }
                    else
                    {
                        var wellnames = new List<string>();

                        foreach (string wellname in filteredWellnames)
                        {
                            if (Array.IndexOf(allWellnames, wellname) != -1)
                            {
                                wellnames.Add(wellname);
                            }
                        }

                        listNames.Items.AddRange(wellnames.ToArray());
                    }
                }
                else
                {
                    listNames.Items.AddRange(model.GetNamesByType(namesType));
                }

                foreach (string item in tmpNames)
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

        private void ListNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            EventUpdateSelectedWells();
        }

        void EventUpdateSelectedProject()
        {
            // Update Tabs

            foreach (ITabObserver item in tabObservers)
            {
                item.UpdateSelectedProjects();
            }
        }

        void EventUpdateSelectedWells()
        {
            var selectedNames = new List<string>();
            var names = new List<string>();

            foreach (object item in listNames.SelectedItems)
            {
                selectedNames.Add(item.ToString());
            }

            foreach (object item in listNames.Items)
            {
                names.Add(item.ToString());
            }

            // Update Tabs

            foreach (ITabObserver item in tabObservers)
            {
                var data = new TabSelectedWellsData
                {
                    selectedNames = selectedNames,
                    type = namesType,
                    names = names
                };

                item.UpdateSelectedWells(data);
            }
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


        private void button1_Click(object sender, EventArgs e)
        {
            controlPanel.UpdateFormData();
            controlPanel.Show();

        }

        private void ButtonNewChartsOnClick(object sender, EventArgs e)
        {
            var tabCharts = new TabCharts(model)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "Charts"
            };

            tabObservers.Add(tabCharts);
            tabPage.Controls.Add(tabCharts);

            EventUpdateSelectedWells();


            tabControl2.TabPages.Add(tabPage);
        }

        private void ButtonExportExcelOnClick(object sender, EventArgs e)
        {
            model.ExportToExcel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filterPanel.UpdateFormData();
            filterPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tabCrossplot = new TabCrossplots(model)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "Crossplots"
            };

            tabObservers.Add(tabCrossplot);
            tabPage.Controls.Add(tabCrossplot);

            tabCrossplot.UpdateSelectedProjects();
            EventUpdateSelectedWells();

            tabControl2.TabPages.Add(tabPage);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var tabWaterPlot = new TabWaterPlot(model)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "Water Plot"
            };

            tabObservers.Add(tabWaterPlot);
            tabPage.Controls.Add(tabWaterPlot);

            tabWaterPlot.UpdateSelectedProjects();
            EventUpdateSelectedWells();

            tabControl2.TabPages.Add(tabPage);
        }

        private void button4_Click(object sender, EventArgs e)
        {

                model.OpenUserAnnotation();
        }
    }
}
