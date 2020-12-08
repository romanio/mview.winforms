using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace mview
{
    public partial class ControlPanel : DockContent
    {
        private readonly MainFormModel model = null;
        public event EventHandler UpdateData;
        private bool suspendEvents = false;

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

            UpdateData(sender, e);
        }
    }
}
