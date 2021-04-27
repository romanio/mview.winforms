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
    public partial class FilterPanel : Form
    {
        private readonly MainFormModel model = null;
        public event EventHandler UpdateData;
        private bool suspendEvents = false;
        string loadingFilename = null;

        public FilterPanel(MainFormModel model)
        {
            InitializeComponent();

            this.model = model;
        }

        public void UpdateFormData()
        {
            listGroups.Items.Clear();
            listGroups.Items.AddRange(model.GetProjectNames().ToArray<object>());

            listGroups.SuspendLayout();

            suspendEvents = true;

            foreach (int index in model.GetSelectedProjectIndex())
            {
                listGroups.SelectedIndex = index;
            }

            listGroups.ResumeLayout();
            
            suspendEvents = false;

            UpdateData(null, null);
        }

        private void ListBoxProjectNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            var indices = new List<int>();

            for (int it = 0; it < listGroups.SelectedIndices.Count; ++it)
            {
               indices.Add(listGroups.SelectedIndices[it]);
            }

            model.SetSelectedProjectIndex(indices);


            UpdateData(null, null);
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
        void ResetProgressBar()
        {
            loadingFilename = null;
        }

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.DeleteSelectedProject();

            UpdateFormData();
        }
    }
}
