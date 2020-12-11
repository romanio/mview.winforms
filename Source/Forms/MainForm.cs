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
    public partial class MainForm : Form
    {
        private readonly MainFormModel model = new MainFormModel();
        readonly ControlPanel controlPanel = null;
        readonly ChartForm chartForm = null;

        public MainForm()
        {
            InitializeComponent();

            dockPanel1.Theme = this.vS2013BlueTheme1;
            visualStudioToolStripExtender1.SetStyle(statusStrip1, VisualStudioToolStripExtender.VsVersion.Vs2013, this.vS2013BlueTheme1);

            controlPanel = new ControlPanel(model);
            controlPanel.UpdateData += ControlPanelOnUpdateData;
            chartForm = new ChartForm(model);

            controlPanel.Show(dockPanel1, DockState.DockLeft);
            chartForm.Show(dockPanel1, DockState.Document);
        }

        private void ControlPanelOnUpdateData(object sender, EventArgs e)
        {
            // Изменение списка выбранных проектов, уведомляем зависимых

            chartForm.UpdateFormData();
        }

        private void buttonOpenNewModel_Click_1(object sender, EventArgs e)
        {
            model.OpenNewModel();

            controlPanel.UpdateFormData();
        }
    }
}
