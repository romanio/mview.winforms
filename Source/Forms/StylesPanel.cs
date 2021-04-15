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
    public partial class StylesPanel : Form
    {
        public event EventHandler UpdateData;

        StyleSettings styleSettings = new StyleSettings();

        public StylesPanel()
        {
            InitializeComponent();

            styleSettings.LoadSettings();

            boxLineStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
            boxLineStyle.SelectedIndex = 0;

            boxMarkerStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.MarkerType)));
            boxMarkerStyle.Items.Remove("Custom");
            boxMarkerStyle.SelectedIndex = 0;

            boxAxisXStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
          //  boxAxisXStyle.SelectedIndex = boxAxisXStyle.FindString(chartController.AxisXStyle.ToString());

           // numericAxisXWidth.Value = chartController.AxisXWidth;
           // numericAxisYWidth.Value = chartController.AxisYWidth;

            boxAxisYStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
          //  boxAxisYStyle.SelectedIndex = boxAxisYStyle.FindString(chartController.AxisYStyle.ToString());

            boxLegendPosition.Items.AddRange(Enum.GetNames(typeof(OxyPlot.Legends.LegendPosition)));
          //  boxLegendPosition.SelectedIndex = boxLegendPosition.FindString(chartController.LegendPosition.ToString());

            //
            /*
            if (chartController.AxisXColor.Name == "0")
            {
                buttonAxisXColorDefault_Click(null, null);
            }
            else
            {
                buttonAxisXColor.BackColor = chartController.AxisXColor;
                buttonAxisXColor.Text = "";
            }

            if (chartController.AxisYColor.Name == "0")
            {
                buttonAxisYColorDefault_Click(null, null);
            }
            else
            {
                buttonAxisYColor.BackColor = chartController.AxisYColor;
                buttonAxisYColor.Text = "";
            }
            */
        }

        public void UpdateFormData(string[] keywords)
        {
            listKeywords.Items.Clear();
            listKeywords.Items.AddRange(keywords??new string[] { });

            if (listKeywords.Items.Count > 0)
            {
                listKeywords.SelectedIndex = 0;
            }

        }


        private void ChartFiltersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            styleSettings.SaveSettings();
            e.Cancel = true;
        }

        private void StylesPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            styleSettings.SaveSettings();
        }

        private void ListKeywordsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKeywords.SelectedIndex == -1) return;

            int index = styleSettings.GetIndex(listKeywords.SelectedItem.ToString());

            if (index == -1) // Default style
            {
                boxLineStyle.SelectedIndex = boxLineStyle.FindString("Solid");
                //buttonLineColorDefault_Click(null, null);

                numericLineWidth.Value = 1;
                checkSmooth.Checked = false;
                boxMarkerStyle.SelectedIndex = boxMarkerStyle.FindString("Circle");
                numericMarkerSize.Value = 5;

                //buttonMarkerBorderDefault_Click(null, null);
                //buttonMarkerFillDefault_Click(null, null);
            }
        }

        private void ButtonAxisXColorDefaultOnClick(object sender, EventArgs e)
        {
            buttonAxisXColor.Text = "(default)";
            buttonAxisXColor.BackColor = SystemColors.Control;
            buttonAxisXColor.UseVisualStyleBackColor = true;
        }

        private void ButtonAxisYColorDefaultOnClick(object sender, EventArgs e)
        {
            buttonAxisYColor.Text = "(default)";
            buttonAxisYColor.BackColor = SystemColors.Control;
            buttonAxisYColor.UseVisualStyleBackColor = true;
        }

        private void ButtonLineColorDefaultOnClick(object sender, EventArgs e)
        {
            buttonLineColor.Text = "(default)";
            buttonLineColor.BackColor = SystemColors.Control;
            buttonLineColor.UseVisualStyleBackColor = true;
        }

        private void ButtonMarkerBorderDefaultOnClick(object sender, EventArgs e)
        {
            buttonMarkerBorderColor.Text = "(default)";
            buttonMarkerBorderColor.BackColor = SystemColors.Control;
            buttonMarkerBorderColor.UseVisualStyleBackColor = true;
        }

        private void ButtonMarkerFillDefaultOnClick(object sender, EventArgs e)
        {
            buttonMarkerFill.Text = "(default)";
            buttonMarkerFill.BackColor = SystemColors.Control;
            buttonMarkerFill.UseVisualStyleBackColor = true;

        }

        private void ButtonLineColorOnClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonLineColor.BackColor = colorDialog.Color;
                buttonLineColor.Text = "";
            }
        }

        private void ButtonMarkerBorderColorOnClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonMarkerBorderColor.BackColor = colorDialog.Color;
                buttonMarkerBorderColor.Text = "";
            }
        }

        private void ButtonMarkerFillOnClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonMarkerFill.BackColor = colorDialog.Color;
                buttonMarkerFill.Text = "";
            }
        }

        private void ButtonAxisXColorOnClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonAxisXColor.BackColor = colorDialog.Color;
                buttonAxisXColor.Text = "";
            }
        }
    }
}
