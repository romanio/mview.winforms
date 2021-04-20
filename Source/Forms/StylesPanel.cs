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
        public event EventHandler<StyleSettings> UpdateData;

        readonly StyleSettings styleSettings = new StyleSettings();

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
            boxAxisYStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));

            boxLegendPosition.Items.AddRange(Enum.GetNames(typeof(OxyPlot.Legends.LegendPosition)));
        }

        public void UpdateFormData(string[] keywords)
        {
            listKeywords.Items.Clear();
            listKeywords.Items.AddRange(keywords ?? new string[] { });

            if (listKeywords.Items.Count > 0)
            {
                listKeywords.SelectedIndex = 0;
            }

            boxAxisXStyle.SelectedIndex = boxAxisXStyle.FindString(styleSettings.axisXStyle.ToString());
            boxAxisYStyle.SelectedIndex = boxAxisYStyle.FindString(styleSettings.axisYStyle.ToString());

            numericAxisXWidth.Value = styleSettings.axisXWidth;
            numericAxisYWidth.Value = styleSettings.axisYWidth;

            boxLegendPosition.SelectedIndex = boxLegendPosition.FindString(styleSettings.LegendPosition.ToString());

            if (styleSettings.axisXColor == OxyPlot.OxyColor.Parse("None"))
            {
                ButtonAxisXColorDefaultOnClick(null, null);
            }
            else
            {
                buttonAxisXColor.BackColor = Color.FromArgb(
                    styleSettings.axisXColor.R,
                    styleSettings.axisXColor.G,
                    styleSettings.axisXColor.B);

                buttonAxisXColor.Text = "";
            }

            if (styleSettings.axisYColor == OxyPlot.OxyColor.Parse("None"))
            {
                ButtonAxisYColorDefaultOnClick(null, null);
            }
            else
            {
                buttonAxisYColor.BackColor = Color.FromArgb(
                    styleSettings.axisYColor.R,
                    styleSettings.axisYColor.G,
                    styleSettings.axisYColor.B);

                buttonAxisYColor.Text = "";
            }
        }

        public StyleSettings GetStyleSettings()
        {
            return styleSettings;
        }

        private void ChartFiltersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            styleSettings.SaveSettings();

            Hide();
            e.Cancel = true;
        }

        private void ListKeywordsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKeywords.SelectedIndex == -1) return;

            int index = styleSettings.GetIndex(listKeywords.SelectedItem.ToString());

            if (index == -1) // Default style
            {
                boxLineStyle.SelectedIndex = boxLineStyle.FindString("Solid");

                numericLineWidth.Value = 1;
                checkSmooth.Checked = false;
                boxMarkerStyle.SelectedIndex = boxMarkerStyle.FindString("Circle");
                numericMarkerSize.Value = 5;

                ButtonLineColorDefaultOnClick(null, null);
                ButtonMarkerBorderDefaultOnClick(null, null);
                ButtonMarkerFillDefaultOnClick(null, null);
            }
            else
            {
                var tmpStyle = styleSettings.GetStyle(index);

                boxLineStyle.SelectedIndex = boxLineStyle.FindString(tmpStyle.lineStyle.ToString());

                if (tmpStyle.lineColor == OxyPlot.OxyColor.Parse("None"))
                {
                    ButtonLineColorDefaultOnClick(null, null);
                }
                else
                {
                    buttonLineColor.BackColor = Color.FromArgb(
                    tmpStyle.lineColor.R,
                    tmpStyle.lineColor.G,
                    tmpStyle.lineColor.B);
                    
                    buttonLineColor.Text = "";
                }
                
                if (tmpStyle.markerColor == OxyPlot.OxyColor.Parse("None"))
                {
                    ButtonMarkerBorderDefaultOnClick(null, null);
                }
                else
                {
                    buttonMarkerBorderColor.BackColor = Color.FromArgb(
                    tmpStyle.markerColor.R,
                    tmpStyle.markerColor.G,
                    tmpStyle.markerColor.B); 
                    
                    buttonMarkerBorderColor.Text = "";
                }
                
                if (tmpStyle.markerFillColor == OxyPlot.OxyColor.Parse("None"))
                {
                    ButtonMarkerFillDefaultOnClick(null, null);
                }
                else
                {
                    buttonMarkerFill.BackColor = Color.FromArgb(
                    tmpStyle.markerFillColor.R,
                    tmpStyle.markerFillColor.G,
                    tmpStyle.markerFillColor.B); 
                    
                    buttonMarkerFill.Text = "";
                }
                
                numericMarkerSize.Value = tmpStyle.markerSize;
                numericLineWidth.Value = tmpStyle.lineWidth;
                checkSmooth.Checked = tmpStyle.lineSmooth;
                boxMarkerStyle.SelectedIndex = boxMarkerStyle.FindString(tmpStyle.markerType.ToString());
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

        private void ButtonAxisYColorOnClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonAxisYColor.BackColor = colorDialog.Color;
                buttonAxisYColor.Text = "";
            }
        }

        private void ButtonSeriesSettingsOnClick(object sender, EventArgs e)
        {
            styleSettings.LegendPosition = (OxyPlot.Legends.LegendPosition)Enum.Parse(typeof(OxyPlot.Legends.LegendPosition), boxLegendPosition.Text, true);

            styleSettings.axisXStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxAxisXStyle.Text, true);
            styleSettings.axisXWidth = Convert.ToInt32(numericAxisXWidth.Value);
            styleSettings.axisYStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxAxisYStyle.Text, true);
            styleSettings.axisYWidth = Convert.ToInt32(numericAxisYWidth.Value);

            if (buttonAxisXColor.Text != "(default)")
            {
                styleSettings.axisXColor = OxyPlot.OxyColor.FromRgb(
                    buttonAxisXColor.BackColor.R,
                    buttonAxisXColor.BackColor.G,
                    buttonAxisXColor.BackColor.B
                    );
            }
            else
            {
                styleSettings.axisXColor = OxyPlot.OxyColor.Parse("None"); ;
            }
           
            if (buttonAxisYColor.Text != "(default)")
            {
                styleSettings.axisYColor = OxyPlot.OxyColor.FromRgb(
                    buttonAxisYColor.BackColor.R,
                    buttonAxisYColor.BackColor.G,
                    buttonAxisYColor.BackColor.B
                    );
            }
            else
            {
                styleSettings.axisYColor = OxyPlot.OxyColor.Parse("None"); ;
            }
            
            if (listKeywords.SelectedItem == null) return;

                var seriesStyle = new SeriesStyle()
                {
                    name = listKeywords.SelectedItem.ToString(),
                    lineStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxLineStyle.Text, true),
                    lineWidth = Convert.ToInt32(numericLineWidth.Value),
                    lineSmooth = checkSmooth.Checked,
                    markerType = (OxyPlot.MarkerType)Enum.Parse(typeof(OxyPlot.MarkerType), boxMarkerStyle.Text, true),
                    markerSize = Convert.ToInt32(numericMarkerSize.Value),
                };

                if (buttonLineColor.Text != "(default)")
                {
                    seriesStyle.lineColor = OxyPlot.OxyColor.FromRgb(
                        buttonLineColor.BackColor.R,
                        buttonLineColor.BackColor.G,
                        buttonLineColor.BackColor.B
                        );
                }
                else
            {
                seriesStyle.lineColor = OxyPlot.OxyColor.Parse("None"); ;
            }

            if (buttonMarkerBorderColor.Text != "(default)")
            {
                seriesStyle.markerColor = OxyPlot.OxyColor.FromRgb(
                    buttonMarkerBorderColor.BackColor.R,
                    buttonMarkerBorderColor.BackColor.G,
                    buttonMarkerBorderColor.BackColor.B
                    );
            }
            else
            {
                seriesStyle.markerColor = OxyPlot.OxyColor.Parse("None"); ;
            }


            if (buttonMarkerFill.Text != "(default)")
            {
                seriesStyle.markerFillColor = OxyPlot.OxyColor.FromRgb(
                    buttonMarkerFill.BackColor.R,
                    buttonMarkerFill.BackColor.G,
                    buttonMarkerFill.BackColor.B
                    );
            }
            else
            {
                seriesStyle.markerFillColor = OxyPlot.OxyColor.Parse("None");
            }

            
            styleSettings.UpdateStyle(seriesStyle);

            UpdateData?.Invoke(sender, styleSettings);
        }
    }
}