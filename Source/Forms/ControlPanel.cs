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
        private readonly MainFormModel model = null;
        public event EventHandler UpdateData;
        private bool suspendEvents = false;
        string loadingFilename = null;

        public ControlPanel(MainFormModel model)
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

            foreach (int index in model.GetSelectedProjectIndex())
            {
                listBoxProjectNames.SelectedIndex = index;
            }

            listBoxProjectNames.ResumeLayout();
            
            suspendEvents = false;

            UpdateData(null, null);
        }

        private void ListBoxProjectNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            var indices = new List<int>();

            for (int it = 0; it < listBoxProjectNames.SelectedIndices.Count; ++it)
            {
               indices.Add(listBoxProjectNames.SelectedIndices[it]);
            }

            model.SetSelectedProjectIndex(indices);


            UpdateData(null, null);
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void buttonSeriesSettings_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
            model.UpdateLoadingProgress += ModelOnUpdateLoadingProgress;
            model.OpenNewModel();

            ResetProgressBar();

            UpdateFormData();
        }

        private void ModelOnUpdateLoadingProgress(object sender, BinaryReaderArg e)
        {
            if (e.filename != loadingFilename)
            {
                listBoxLog.Items.Add(System.IO.Path.GetFileName(e.filename) + " (" + FormatBytes(e.length) + ")");
                loadingFilename = e.filename;
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }

            progressBar.Value = (int)(100 * e.position / e.length);

        }

        void ResetProgressBar()
        {
            progressBar.Value = 100;
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
