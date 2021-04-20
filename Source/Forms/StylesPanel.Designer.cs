
namespace mview
{
    partial class StylesPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StylesPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.listKeywords = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxLegendPosition = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonAxisYColorDefault = new System.Windows.Forms.Button();
            this.buttonAxisYColor = new System.Windows.Forms.Button();
            this.buttonAxisXColorDefault = new System.Windows.Forms.Button();
            this.buttonAxisXColor = new System.Windows.Forms.Button();
            this.numericAxisYWidth = new System.Windows.Forms.NumericUpDown();
            this.numericAxisXWidth = new System.Windows.Forms.NumericUpDown();
            this.boxAxisYStyle = new System.Windows.Forms.ComboBox();
            this.boxAxisXStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonMarkerFillDefault = new System.Windows.Forms.Button();
            this.buttonMarkerBorderDefault = new System.Windows.Forms.Button();
            this.buttonLineColorDefault = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkSmooth = new System.Windows.Forms.CheckBox();
            this.numericMarkerSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonMarkerFill = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonMarkerBorderColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonLineColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.boxMarkerStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxLineStyle = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonSeriesSettings = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAxisYWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAxisXWidth)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMarkerSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Axis X";
            // 
            // listKeywords
            // 
            this.listKeywords.FormattingEnabled = true;
            this.listKeywords.IntegralHeight = false;
            this.listKeywords.Location = new System.Drawing.Point(15, 17);
            this.listKeywords.Name = "listKeywords";
            this.listKeywords.Size = new System.Drawing.Size(92, 361);
            this.listKeywords.Sorted = true;
            this.listKeywords.TabIndex = 0;
            this.listKeywords.SelectedIndexChanged += new System.EventHandler(this.ListKeywordsOnSelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(82, 18);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(359, 423);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxLegendPosition);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.buttonAxisYColorDefault);
            this.tabPage1.Controls.Add(this.buttonAxisYColor);
            this.tabPage1.Controls.Add(this.buttonAxisXColorDefault);
            this.tabPage1.Controls.Add(this.buttonAxisXColor);
            this.tabPage1.Controls.Add(this.numericAxisYWidth);
            this.tabPage1.Controls.Add(this.numericAxisXWidth);
            this.tabPage1.Controls.Add(this.boxAxisYStyle);
            this.tabPage1.Controls.Add(this.boxAxisXStyle);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(351, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Charts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boxLegendPosition
            // 
            this.boxLegendPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxLegendPosition.FormattingEnabled = true;
            this.boxLegendPosition.IntegralHeight = false;
            this.boxLegendPosition.Location = new System.Drawing.Point(177, 302);
            this.boxLegendPosition.Name = "boxLegendPosition";
            this.boxLegendPosition.Size = new System.Drawing.Size(106, 21);
            this.boxLegendPosition.TabIndex = 35;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(44, 305);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Legend Position";
            // 
            // buttonAxisYColorDefault
            // 
            this.buttonAxisYColorDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAxisYColorDefault.Location = new System.Drawing.Point(259, 247);
            this.buttonAxisYColorDefault.Name = "buttonAxisYColorDefault";
            this.buttonAxisYColorDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonAxisYColorDefault.TabIndex = 33;
            this.buttonAxisYColorDefault.Text = "D";
            this.buttonAxisYColorDefault.UseVisualStyleBackColor = true;
            this.buttonAxisYColorDefault.Click += new System.EventHandler(this.ButtonAxisYColorDefaultOnClick);
            // 
            // buttonAxisYColor
            // 
            this.buttonAxisYColor.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAxisYColor.Location = new System.Drawing.Point(177, 247);
            this.buttonAxisYColor.Name = "buttonAxisYColor";
            this.buttonAxisYColor.Size = new System.Drawing.Size(81, 23);
            this.buttonAxisYColor.TabIndex = 32;
            this.buttonAxisYColor.Text = "(default)";
            this.buttonAxisYColor.UseVisualStyleBackColor = true;
            this.buttonAxisYColor.Click += new System.EventHandler(this.ButtonAxisYColorOnClick);
            // 
            // buttonAxisXColorDefault
            // 
            this.buttonAxisXColorDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAxisXColorDefault.Location = new System.Drawing.Point(259, 109);
            this.buttonAxisXColorDefault.Name = "buttonAxisXColorDefault";
            this.buttonAxisXColorDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonAxisXColorDefault.TabIndex = 31;
            this.buttonAxisXColorDefault.Text = "D";
            this.buttonAxisXColorDefault.UseVisualStyleBackColor = true;
            this.buttonAxisXColorDefault.Click += new System.EventHandler(this.ButtonAxisXColorDefaultOnClick);
            // 
            // buttonAxisXColor
            // 
            this.buttonAxisXColor.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAxisXColor.Location = new System.Drawing.Point(177, 109);
            this.buttonAxisXColor.Name = "buttonAxisXColor";
            this.buttonAxisXColor.Size = new System.Drawing.Size(81, 23);
            this.buttonAxisXColor.TabIndex = 30;
            this.buttonAxisXColor.Text = "(default)";
            this.buttonAxisXColor.UseVisualStyleBackColor = true;
            this.buttonAxisXColor.Click += new System.EventHandler(this.ButtonAxisXColorOnClick);
            // 
            // numericAxisYWidth
            // 
            this.numericAxisYWidth.Location = new System.Drawing.Point(177, 220);
            this.numericAxisYWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAxisYWidth.Name = "numericAxisYWidth";
            this.numericAxisYWidth.Size = new System.Drawing.Size(106, 22);
            this.numericAxisYWidth.TabIndex = 26;
            this.numericAxisYWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericAxisXWidth
            // 
            this.numericAxisXWidth.Location = new System.Drawing.Point(177, 82);
            this.numericAxisXWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAxisXWidth.Name = "numericAxisXWidth";
            this.numericAxisXWidth.Size = new System.Drawing.Size(106, 22);
            this.numericAxisXWidth.TabIndex = 25;
            this.numericAxisXWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // boxAxisYStyle
            // 
            this.boxAxisYStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAxisYStyle.FormattingEnabled = true;
            this.boxAxisYStyle.IntegralHeight = false;
            this.boxAxisYStyle.Location = new System.Drawing.Point(177, 190);
            this.boxAxisYStyle.Name = "boxAxisYStyle";
            this.boxAxisYStyle.Size = new System.Drawing.Size(106, 21);
            this.boxAxisYStyle.TabIndex = 24;
            // 
            // boxAxisXStyle
            // 
            this.boxAxisXStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxAxisXStyle.FormattingEnabled = true;
            this.boxAxisXStyle.IntegralHeight = false;
            this.boxAxisXStyle.Location = new System.Drawing.Point(177, 52);
            this.boxAxisXStyle.Name = "boxAxisXStyle";
            this.boxAxisXStyle.Size = new System.Drawing.Size(106, 21);
            this.boxAxisXStyle.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "GridLine Color";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "GridLine Width";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 193);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "GridLine Style";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(44, 158);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Axis Y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "GridLine Color";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "GridLine Width";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "GridLine Style";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonMarkerFillDefault);
            this.tabPage2.Controls.Add(this.buttonMarkerBorderDefault);
            this.tabPage2.Controls.Add(this.buttonLineColorDefault);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.checkSmooth);
            this.tabPage2.Controls.Add(this.numericMarkerSize);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.numericLineWidth);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.buttonMarkerFill);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.buttonMarkerBorderColor);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.buttonLineColor);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.boxMarkerStyle);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.boxLineStyle);
            this.tabPage2.Controls.Add(this.listKeywords);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(351, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Series";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonMarkerFillDefault
            // 
            this.buttonMarkerFillDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMarkerFillDefault.Location = new System.Drawing.Point(294, 265);
            this.buttonMarkerFillDefault.Name = "buttonMarkerFillDefault";
            this.buttonMarkerFillDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonMarkerFillDefault.TabIndex = 31;
            this.buttonMarkerFillDefault.Text = "D";
            this.buttonMarkerFillDefault.UseVisualStyleBackColor = true;
            this.buttonMarkerFillDefault.Click += new System.EventHandler(this.ButtonMarkerFillDefaultOnClick);
            // 
            // buttonMarkerBorderDefault
            // 
            this.buttonMarkerBorderDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMarkerBorderDefault.Location = new System.Drawing.Point(294, 236);
            this.buttonMarkerBorderDefault.Name = "buttonMarkerBorderDefault";
            this.buttonMarkerBorderDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonMarkerBorderDefault.TabIndex = 30;
            this.buttonMarkerBorderDefault.Text = "D";
            this.buttonMarkerBorderDefault.UseVisualStyleBackColor = true;
            this.buttonMarkerBorderDefault.Click += new System.EventHandler(this.ButtonMarkerBorderDefaultOnClick);
            // 
            // buttonLineColorDefault
            // 
            this.buttonLineColorDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLineColorDefault.Location = new System.Drawing.Point(294, 55);
            this.buttonLineColorDefault.Name = "buttonLineColorDefault";
            this.buttonLineColorDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonLineColorDefault.TabIndex = 29;
            this.buttonLineColorDefault.Text = "D";
            this.buttonLineColorDefault.UseVisualStyleBackColor = true;
            this.buttonLineColorDefault.Click += new System.EventHandler(this.ButtonLineColorDefaultOnClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Smooth line";
            // 
            // checkSmooth
            // 
            this.checkSmooth.AutoSize = true;
            this.checkSmooth.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkSmooth.Location = new System.Drawing.Point(212, 117);
            this.checkSmooth.Name = "checkSmooth";
            this.checkSmooth.Size = new System.Drawing.Size(80, 17);
            this.checkSmooth.TabIndex = 26;
            this.checkSmooth.Text = "Yes, please";
            this.checkSmooth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkSmooth.UseVisualStyleBackColor = true;
            // 
            // numericMarkerSize
            // 
            this.numericMarkerSize.Location = new System.Drawing.Point(212, 193);
            this.numericMarkerSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMarkerSize.Name = "numericMarkerSize";
            this.numericMarkerSize.Size = new System.Drawing.Size(106, 22);
            this.numericMarkerSize.TabIndex = 25;
            this.numericMarkerSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(126, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Marker size";
            // 
            // numericLineWidth
            // 
            this.numericLineWidth.Location = new System.Drawing.Point(212, 86);
            this.numericLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLineWidth.Name = "numericLineWidth";
            this.numericLineWidth.Size = new System.Drawing.Size(106, 22);
            this.numericLineWidth.TabIndex = 23;
            this.numericLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Line width";
            // 
            // buttonMarkerFill
            // 
            this.buttonMarkerFill.Location = new System.Drawing.Point(212, 265);
            this.buttonMarkerFill.Name = "buttonMarkerFill";
            this.buttonMarkerFill.Size = new System.Drawing.Size(81, 23);
            this.buttonMarkerFill.TabIndex = 21;
            this.buttonMarkerFill.Text = "(default)";
            this.buttonMarkerFill.UseVisualStyleBackColor = true;
            this.buttonMarkerFill.Click += new System.EventHandler(this.ButtonMarkerFillOnClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Marker fill";
            // 
            // buttonMarkerBorderColor
            // 
            this.buttonMarkerBorderColor.Location = new System.Drawing.Point(212, 236);
            this.buttonMarkerBorderColor.Name = "buttonMarkerBorderColor";
            this.buttonMarkerBorderColor.Size = new System.Drawing.Size(81, 23);
            this.buttonMarkerBorderColor.TabIndex = 19;
            this.buttonMarkerBorderColor.Text = "(default)";
            this.buttonMarkerBorderColor.UseVisualStyleBackColor = true;
            this.buttonMarkerBorderColor.Click += new System.EventHandler(this.ButtonMarkerBorderColorOnClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Marker border";
            // 
            // buttonLineColor
            // 
            this.buttonLineColor.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLineColor.Location = new System.Drawing.Point(212, 55);
            this.buttonLineColor.Name = "buttonLineColor";
            this.buttonLineColor.Size = new System.Drawing.Size(81, 23);
            this.buttonLineColor.TabIndex = 17;
            this.buttonLineColor.Text = "(default)";
            this.buttonLineColor.UseVisualStyleBackColor = true;
            this.buttonLineColor.Click += new System.EventHandler(this.ButtonLineColorOnClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Line color";
            // 
            // boxMarkerStyle
            // 
            this.boxMarkerStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMarkerStyle.FormattingEnabled = true;
            this.boxMarkerStyle.IntegralHeight = false;
            this.boxMarkerStyle.Location = new System.Drawing.Point(212, 166);
            this.boxMarkerStyle.Name = "boxMarkerStyle";
            this.boxMarkerStyle.Size = new System.Drawing.Size(106, 21);
            this.boxMarkerStyle.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Marker style";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Line style";
            // 
            // boxLineStyle
            // 
            this.boxLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxLineStyle.FormattingEnabled = true;
            this.boxLineStyle.IntegralHeight = false;
            this.boxLineStyle.Location = new System.Drawing.Point(212, 28);
            this.boxLineStyle.Name = "boxLineStyle";
            this.boxLineStyle.Size = new System.Drawing.Size(106, 21);
            this.boxLineStyle.TabIndex = 12;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // buttonSeriesSettings
            // 
            this.buttonSeriesSettings.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSeriesSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeriesSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSeriesSettings.Location = new System.Drawing.Point(267, 441);
            this.buttonSeriesSettings.Name = "buttonSeriesSettings";
            this.buttonSeriesSettings.Size = new System.Drawing.Size(100, 30);
            this.buttonSeriesSettings.TabIndex = 29;
            this.buttonSeriesSettings.Text = "Apply Style";
            this.buttonSeriesSettings.UseVisualStyleBackColor = true;
            this.buttonSeriesSettings.Click += new System.EventHandler(this.ButtonSeriesSettingsOnClick);
            // 
            // StylesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(382, 480);
            this.Controls.Add(this.buttonSeriesSettings);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StylesPanel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Styles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartFiltersForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAxisYWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAxisXWidth)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMarkerSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLineWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listKeywords;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxLineStyle;
        private System.Windows.Forms.ComboBox boxMarkerStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLineColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonMarkerBorderColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonMarkerFill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericLineWidth;
        private System.Windows.Forms.NumericUpDown numericMarkerSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkSmooth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonLineColorDefault;
        private System.Windows.Forms.Button buttonMarkerFillDefault;
        private System.Windows.Forms.Button buttonMarkerBorderDefault;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox boxAxisXStyle;
        private System.Windows.Forms.ComboBox boxAxisYStyle;
        private System.Windows.Forms.NumericUpDown numericAxisYWidth;
        private System.Windows.Forms.NumericUpDown numericAxisXWidth;
        private System.Windows.Forms.Button buttonAxisYColorDefault;
        private System.Windows.Forms.Button buttonAxisYColor;
        private System.Windows.Forms.Button buttonAxisXColorDefault;
        private System.Windows.Forms.Button buttonAxisXColor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox boxLegendPosition;
        private System.Windows.Forms.Button buttonSeriesSettings;
    }
}