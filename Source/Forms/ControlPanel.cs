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

        private void listBoxProjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            var indices = new List<int>();

            for (int it = 0; it < listBoxProjectNames.SelectedIndices.Count; ++it)
            {
               indices.Add(listBoxProjectNames.SelectedIndices[it]);
            }

            model.SetSelectedProjectIndex(indices);

            //
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

            lbProgressText.Text = "";
            progressBar.Value = 0;
            listBoxLog.Items.Add("OK");
            loadingFilename = null;

            UpdateFormData();
        }

        private void ModelOnUpdateLoadingProgress(object sender, EclipseLoadingArg e)
        {

            if (e.file != loadingFilename)
            {
                listBoxLog.Items.Add(e.file);
                loadingFilename = e.file;
            }

            lbProgressText.Text = e.keyword;
            progressBar.Value = (int)e.percent;

        }
    }
}
