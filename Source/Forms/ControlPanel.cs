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
    public partial class ControlPanel : Form
    {
        private readonly ChartModel model = null;
        public event EventHandler UpdateData;
        private bool suspendEvents = false;

        public ControlPanel(ChartModel model)
        {
            InitializeComponent();

            this.model = model;
        }

        public void UpdateFormData()
        {
            listBoxProjectNames.Items.Clear();
            listBoxProjectNames.Items.AddRange(model.GetProjectNames().ToArray<object>());

            listBoxProjectNames.SuspendLayout();

            suspendEvents = true;

            listBoxProjectNames.SelectedIndex = model.GetSelectedProjectIndex();

            listBoxProjectNames.ResumeLayout();
            
            suspendEvents = false;
        }

        private void ListBoxProjectNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            model.SetSelectedProject(listBoxProjectNames.SelectedIndex);

            UpdateData(null, null);
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void ButtonSeriesSettingsOnClick(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();

            model.UpdateLoadingProgress += ModelOnUpdateLoadingProgress;
            model.OpenNewModel();

            UpdateFormData();

            UpdateData(null, null);
        }

        private void ModelOnUpdateLoadingProgress(object sender, BinaryReaderArg e)
        {
            listBoxLog.Items.Add(System.IO.Path.GetFileName(e.filename));
            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
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
