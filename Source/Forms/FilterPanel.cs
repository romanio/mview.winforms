using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mview
{
    public partial class FilterPanel : Form
    {
        public event EventHandler UpdateData;
        private readonly WellFilterSettings wellFilterSettings = new WellFilterSettings();
        private bool suspendEvents = false;

        public FilterPanel()
        {
            InitializeComponent();
        }

        public void UpdateFormData()
        {
            suspendEvents = true;

            suspendEvents = false;
        }

        public string[] GetFilteredWellnames()
        {
            List<string> wellnames = new List<string>();

            foreach (string pad in listGroups.SelectedItems)
            {
                var wells = wellFilterSettings.GetNamesFromVGroup(pad);
                wellnames.AddRange(wells);
            }

            return wellnames.ToArray();
        }

        private void ListGroupsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            listWells.Items.Clear();

            foreach (string pad in listGroups.SelectedItems)
            {
                var wells = wellFilterSettings.GetNamesFromVGroup(pad);
                listWells.Items.AddRange(wells);
            }

            UpdateData?.Invoke(null, null);
        }

        private void ControlPanelOnFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        public string GetFilename()
        {
            return wellFilterSettings.filename;
        }

        public void LoadVirtualGroups()
        {
            wellFilterSettings.LoadFromFile();

            listGroups.Items.Clear();
            listGroups.Items.AddRange(wellFilterSettings.GetVirtualGroups());
            
        }

        private void ButtonSeriesSettingsOnClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listGroups.SelectedItem = null;
            UpdateData?.Invoke(null, null);
        }
    }
}
