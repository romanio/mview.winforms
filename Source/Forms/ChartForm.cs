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
    public partial class ChartForm : DockContent
    {
        //
        private readonly MainFormModel model = null;
        private bool suspendEvents = false;

        public ChartForm(MainFormModel model)
        {
            InitializeComponent();

            this.model = model;

            suspendEvents = true;
            boxNameType.SelectedIndex = 2;
            suspendEvents = false;
        }

        public void UpdateFormData()
        {
            // Сохраним список текущих выделенных имен

            suspendEvents = true;

            var tmp_names = new List<string>();
            foreach (string item in listNames.SelectedItems)
            {
                tmp_names.Add(item);
            }

            listNames.Items.Clear();
            listNames.Sorted = checkSorted.Checked;

            var namesType = NameOptions.Well;

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

            listNames.Items.AddRange(model.GetNamesByType(namesType));

            // Востановим выделенные слова

            int index = -1;
            foreach (string item in tmp_names)
            {
                index = listNames.Items.IndexOf(item);

                if (index != -1)
                {
                    listNames.SetSelected(index, true);
                }
            }

            suspendEvents = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
          
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
    }
}
