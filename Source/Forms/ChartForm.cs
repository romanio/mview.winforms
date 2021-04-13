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
        private NameOptions namesType = NameOptions.Well;
        
        public ChartForm(MainFormModel model)
        {
            InitializeComponent();

            this.model = model;

        }

        public void SetChartFilter(ChartFilterSettings data)
        {
            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateFilters(data);
            }
        }

        public void SetChartSettings(ChartSettings data)
        {
            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateSettings(data);
            }
        }

        public void SetChartsPosition(ChartsPosition position)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            if (position == ChartsPosition.One)
            {
                tableLayoutPanel1.RowCount = 1;
                tableLayoutPanel1.ColumnCount = 1;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
            }

            if (position == ChartsPosition.OnePlusTwo)
            {
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.ColumnCount = 2;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.SetColumnSpan(tableLayoutPanel1.Controls[0], 2);
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
            }

            if (position == ChartsPosition.OnePlusThree)
            {
                tableLayoutPanel1.RowCount = 3;
                tableLayoutPanel1.ColumnCount = 2;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33));

                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.SetRowSpan(tableLayoutPanel1.Controls[0], 3);
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
            }

            if (position == ChartsPosition.Four)
            {
                tableLayoutPanel1.RowCount = 2;
                tableLayoutPanel1.ColumnCount = 2;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
                tableLayoutPanel1.Controls.Add(new ChartControl(model) { Dock = DockStyle.Fill });
            }

            UpdateFormData();
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

            listNames.ResumeLayout();
            listNames.EndUpdate();

            suspendEvents = false;

        }


 
        private void listNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var names = new List<string>();
        
            foreach (object item in listNames.SelectedItems)
            {
                names.Add(item.ToString());
            }

            foreach (ChartControl item in tableLayoutPanel1.Controls)
            {
                item.UpdateNames(names, namesType);
            }
        }
    }


}
