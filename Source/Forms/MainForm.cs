using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

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

    public partial class MainForm : KryptonForm
    {
        readonly ProjectManager pm = new ProjectManager();
        readonly ControlPanel controlPanel = null;
        readonly FilterPanel filterPanel = null;

        NameOptions namesType = NameOptions.Well;

        bool suspendEvents = false;

        public MainForm()
        {
            InitializeComponent();

            suspendEvents = true;

            controlPanel = new ControlPanel(pm);
            controlPanel.UpdateData += ControlPanelOnUpdateData;

            filterPanel = new FilterPanel();
            filterPanel.UpdateData += FilterPanelOnUpdateData;

            boxNameType.SelectedIndex = 2;

            kryptonNavigator.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.ShowDisabled;

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

            if (pm.SelectedIndex > -1)
            {
                if (namesType == NameOptions.Well)
                {
                    var filteredWellnames = filterPanel.GetFilteredWellnames();
                    var allWellnames = GetNamesByType(namesType);

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
                    listNames.Items.AddRange(GetNamesByType(namesType));
                }

                foreach (string item in tmpNames)
                {
                    int index = listNames.Items.IndexOf(item); // Востановим выделенные слова

                    if (index != -1)
                    {
                        listNames.SetSelected(index, true);
                    }
                }

                labelAnnotations.Text = pm.ECL.userAnnotations.filename;
            }

            listNames.ResumeLayout();
            listNames.EndUpdate();

            suspendEvents = false;
        }

        string[] GetNamesByType(NameOptions type)
        {
            return pm.ECL.VECTORS.Where(c => c.Type == type).Select(c => c.Name).ToArray();
        }

        void EventUpdateSelectedProject()
        {
            // Update Tabs

            foreach (Krypton.Navigator.KryptonPage item in kryptonNavigator.Pages)
            {
                if (item.Controls[0] is ITabObserver)
                {
                    (item.Controls[0] as ITabObserver).UpdateSelectedProjects(pm.ECL);
                }
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

            foreach(Krypton.Navigator.KryptonPage item in kryptonNavigator.Pages)
            {
                if (item.Controls[0] is ITabObserver)
                {
                    var data = new TabSelectedWellsData
                    {
                        selectedNames = selectedNames,
                        type = namesType,
                        names = names
                    };

                    (item.Controls[0] as ITabObserver).UpdateSelectedWells(data);
                }
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            filterPanel.UpdateFormData();
            filterPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tabCrossplot = new TabCrossplots(pm.ECL)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "Crossplots"
            };

            tabPage.Controls.Add(tabCrossplot);

            tabCrossplot.UpdateSelectedProjects(); // NTR
            EventUpdateSelectedWells();

            //tabControl2.TabPages.Add(tabPage);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var tabWaterPlot = new TabWaterPlot(pm.ECL)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "Water Plot"
            };

            tabPage.Controls.Add(tabWaterPlot);

            tabWaterPlot.UpdateSelectedProjects(); // NTR
            EventUpdateSelectedWells();

            //tabControl2.TabPages.Add(tabPage);
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            pm.ECL.userAnnotations.LoadUserFunctions();
            labelAnnotations.Text = pm.ECL.userAnnotations.filename;
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            var tab2DView = new Tab2DView(pm.ECL)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "2D View"
            };

            tabPage.Controls.Add(tab2DView);

            EventUpdateSelectedWells();

            //tabControl2.TabPages.Add(tabPage);

            tab2DView.AfterInitCall();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            filterPanel.LoadVirtualGroups();
            labelWellgroups.Text = filterPanel.GetFilename();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            /*
            pm.UpdateSelectedProject();
            
            EventUpdateSelectedWells();
        */
        }

        private void OnButtonProjectClick(object sender, EventArgs e)
        {
            controlPanel.UpdateFormData();
            controlPanel.Show();
            controlPanel.Focus();
        }

        private void kryptonNavigator_SelectedPageChanged(object sender, EventArgs e)
        {
            if (kryptonNavigator.SelectedIndex == 0)
            {
                kryptonNavigator.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.ShowDisabled;
            }
            else
            {
                kryptonNavigator.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.ShowEnabled;
            }
        }

        private void listNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventUpdateSelectedWells();
        }

        private void checkSorted_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormData();
        }

        private void boxNameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            UpdateFormData();
        }

        private void buttonExcelExportOnClick(object sender, EventArgs e)
        {
            ExcelWork excel = new ExcelWork();
            excel.ExportToExcel(pm.ECL);
        }

        void CreatePage(Control item, string caption)
        {
            var tabPage = new Krypton.Navigator.KryptonPage
            {
                Text = caption
            };

            tabPage.Controls.Add(item);

            kryptonNavigator.Pages.Add(tabPage);

            EventUpdateSelectedWells();
        }

        private void buttonCharts_Click(object sender, EventArgs e)
        {
            CreatePage(new TabCharts(pm.ECL) { Dock = DockStyle.Fill }, "Charts");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var tabWellModel = new TabWellModel(pm.ECL)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "Well Model"
            };

            tabObservers.Add(tabWellModel);
            tabPage.Controls.Add(tabWellModel);

            tabWellModel.UpdateSelectedProjects(); // NTR
            EventUpdateSelectedWells();

            tabControl2.TabPages.Add(tabPage);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var tab3DView = new Tab3DView(pm.ECL)
            {
                Dock = DockStyle.Fill
            };


            var tabPage = new TabPage
            {
                Text = "3D View"
            };

            tabObservers.Add(tab3DView);
            tabPage.Controls.Add(tab3DView);

            EventUpdateSelectedWells();

            tabControl2.TabPages.Add(tabPage);

            tab3DView.AfterInitCall();
        }
    }
}
