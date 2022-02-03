using System;
using System.Linq;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace mview
{
    public partial class ControlPanel : KryptonForm
    {
        private readonly ProjectManager pm = null;
        public event EventHandler UpdateData;
        private bool suspendEvents = false;

        public ControlPanel(ProjectManager pm)
        {
            InitializeComponent();
            this.pm = pm;
        }

        public void UpdateFormData()
        {
            listBoxProjectNames.Items.Clear();
            listBoxProjectNames.Items.AddRange(pm.GetProjectNames().ToArray<object>());

            suspendEvents = true;

            listBoxProjectNames.SelectedIndex = pm.SelectedIndex;

            suspendEvents = false;
        }

        private void ControlPanelOnFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void ModelOnUpdateLoadingProgress(object sender, BinaryReaderArg e)
        {
            listBoxLog.Items.Add(System.IO.Path.GetFileName(e.filename));
            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();

            pm.OpenECLProject(ModelOnUpdateLoadingProgress);

            UpdateFormData();

            UpdateData(null, null);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            pm.DeleteSelectedProject();

            UpdateFormData();
        }

        private void listBoxProjectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suspendEvents) return;

            pm.SelectedIndex = listBoxProjectNames.SelectedIndex;

            UpdateData(null, null);
        }
    }
}
