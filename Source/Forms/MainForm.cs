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

        readonly List<ITabCommonForm> tabs = new List<ITabCommonForm>();

        bool suspendEvents = false;
        NameOptions namesType = NameOptions.Well;

        public MainForm()
        {
            InitializeComponent();

            suspendEvents = true;

            controlPanel = new ControlPanel(model);
            controlPanel.UpdateData += ControlPanelOnUpdateData;

            filterPanel = new FilterPanel(model);
            filterPanel.UpdateData += FilterPanelOnUpdateData;

            boxNameType.SelectedIndex = 2;

            suspendEvents = false;
        }

        private void FilterPanelOnUpdateData(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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

        

        private void ListNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            var names = new List<string>();

            foreach (object item in listNames.SelectedItems)
            {
                names.Add(item.ToString());
            }

            // Update Tabs

            foreach (ITabCommonForm item in tabs)
            {
                var data = new TabCommonData
                {
                    names = names,
                    type = namesType
                };

                item.UpdateFormData(data);
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

            tabs.Add(tabCharts);
            tabPage.Controls.Add(tabCharts);

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
    }

    public class TabCommonData
    {
        public List<string> names;
        public NameOptions type;
    }

    public interface ITabCommonForm
    {
        void UpdateFormData(TabCommonData data);
    }
}
