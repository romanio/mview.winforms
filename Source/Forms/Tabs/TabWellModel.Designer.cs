
namespace mview
{
    partial class TabWellModel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.checkRoll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxRestartDates = new System.Windows.Forms.ComboBox();
            this.checkShowModiValue = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxLumping = new System.Windows.Forms.ComboBox();
            this.boxDepthMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxChartMode = new System.Windows.Forms.ComboBox();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelGOR = new System.Windows.Forms.Label();
            this.labelWCUT = new System.Windows.Forms.Label();
            this.labelBHP = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelGPR = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelWPR = new System.Windows.Forms.Label();
            this.labelOPR = new System.Windows.Forms.Label();
            this.labelLPR = new System.Windows.Forms.Label();
            this.labelGPRtext = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.checkRoll);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.boxRestartDates);
            this.panel1.Controls.Add(this.checkShowModiValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.boxLumping);
            this.panel1.Controls.Add(this.boxDepthMode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boxChartMode);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 89);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1OnPaint);
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.button8.Location = new System.Drawing.Point(640, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(104, 29);
            this.button8.TabIndex = 44;
            this.button8.Text = "Adjust BHP";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkRoll
            // 
            this.checkRoll.AutoSize = true;
            this.checkRoll.Location = new System.Drawing.Point(524, 17);
            this.checkRoll.Name = "checkRoll";
            this.checkRoll.Size = new System.Drawing.Size(88, 17);
            this.checkRoll.TabIndex = 43;
            this.checkRoll.Text = "Roll lumped";
            this.checkRoll.UseVisualStyleBackColor = true;
            this.checkRoll.CheckedChanged += new System.EventHandler(this.checkRoll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Date";
            // 
            // boxRestartDates
            // 
            this.boxRestartDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestartDates.FormattingEnabled = true;
            this.boxRestartDates.IntegralHeight = false;
            this.boxRestartDates.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxRestartDates.Location = new System.Drawing.Point(112, 48);
            this.boxRestartDates.Name = "boxRestartDates";
            this.boxRestartDates.Size = new System.Drawing.Size(123, 21);
            this.boxRestartDates.TabIndex = 41;
            this.boxRestartDates.SelectedIndexChanged += new System.EventHandler(this.boxRestartDates_SelectedIndexChanged);
            // 
            // checkShowModiValue
            // 
            this.checkShowModiValue.AutoSize = true;
            this.checkShowModiValue.Location = new System.Drawing.Point(524, 51);
            this.checkShowModiValue.Name = "checkShowModiValue";
            this.checkShowModiValue.Size = new System.Drawing.Size(85, 17);
            this.checkShowModiValue.TabIndex = 40;
            this.checkShowModiValue.Text = "Show value";
            this.checkShowModiValue.UseVisualStyleBackColor = true;
            this.checkShowModiValue.CheckedChanged += new System.EventHandler(this.checkShowModiValue_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Depth axes ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lumping by";
            // 
            // boxLumping
            // 
            this.boxLumping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxLumping.FormattingEnabled = true;
            this.boxLumping.IntegralHeight = false;
            this.boxLumping.Items.AddRange(new object[] {
            "None",
            "K-VALUE",
            "EQLNUM",
            "PVTNUM",
            "SATNUM",
            "FIPNUM"});
            this.boxLumping.Location = new System.Drawing.Point(350, 13);
            this.boxLumping.Name = "boxLumping";
            this.boxLumping.Size = new System.Drawing.Size(142, 21);
            this.boxLumping.TabIndex = 5;
            this.boxLumping.SelectedIndexChanged += new System.EventHandler(this.boxLumping_SelectedIndexChanged);
            // 
            // boxDepthMode
            // 
            this.boxDepthMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDepthMode.FormattingEnabled = true;
            this.boxDepthMode.IntegralHeight = false;
            this.boxDepthMode.Items.AddRange(new object[] {
            "Depth",
            "K-layer"});
            this.boxDepthMode.Location = new System.Drawing.Point(350, 48);
            this.boxDepthMode.Name = "boxDepthMode";
            this.boxDepthMode.Size = new System.Drawing.Size(142, 21);
            this.boxDepthMode.TabIndex = 3;
            this.boxDepthMode.SelectedIndexChanged += new System.EventHandler(this.boxDepthMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart mode";
            // 
            // boxChartMode
            // 
            this.boxChartMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxChartMode.FormattingEnabled = true;
            this.boxChartMode.IntegralHeight = false;
            this.boxChartMode.Items.AddRange(new object[] {
            "Liquid Production",
            "Oil Production",
            "Water Production",
            "Gas Production",
            "Water Cut",
            "Productivity Index"});
            this.boxChartMode.Location = new System.Drawing.Point(112, 13);
            this.boxChartMode.Name = "boxChartMode";
            this.boxChartMode.Size = new System.Drawing.Size(123, 21);
            this.boxChartMode.TabIndex = 1;
            this.boxChartMode.SelectedIndexChanged += new System.EventHandler(this.BoxKeywordsOnSelectedIndexChanged);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.gridData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.J,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7});
            this.gridData.Location = new System.Drawing.Point(3, 140);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowTemplate.Height = 18;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridData.Size = new System.Drawing.Size(386, 394);
            this.gridData.TabIndex = 5;
            this.gridData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellEndEdit);
            this.gridData.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.gridData_CellStateChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "I";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // J
            // 
            this.J.HeaderText = "J";
            this.J.Name = "J";
            this.J.ReadOnly = true;
            this.J.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "K";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Lump";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "index";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Mult";
            this.Column6.Name = "Column6";
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Value";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 60;
            // 
            // plotView
            // 
            this.plotView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Location = new System.Drawing.Point(0, 0);
            this.plotView.Margin = new System.Windows.Forms.Padding(0);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(385, 537);
            this.plotView.TabIndex = 4;
            this.plotView.Text = "plotView";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 98);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.plotView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.labelGOR);
            this.splitContainer1.Panel2.Controls.Add(this.labelWCUT);
            this.splitContainer1.Panel2.Controls.Add(this.labelBHP);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.labelGPR);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.labelWPR);
            this.splitContainer1.Panel2.Controls.Add(this.labelOPR);
            this.splitContainer1.Panel2.Controls.Add(this.labelLPR);
            this.splitContainer1.Panel2.Controls.Add(this.labelGPRtext);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.gridData);
            this.splitContainer1.Size = new System.Drawing.Size(791, 537);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(303, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "History / Sim";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(141, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "History / Sim";
            // 
            // labelGOR
            // 
            this.labelGOR.AutoSize = true;
            this.labelGOR.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGOR.Location = new System.Drawing.Point(303, 86);
            this.labelGOR.Name = "labelGOR";
            this.labelGOR.Size = new System.Drawing.Size(66, 13);
            this.labelGOR.TabIndex = 20;
            this.labelGOR.Text = "23.2 / 24.54";
            // 
            // labelWCUT
            // 
            this.labelWCUT.AutoSize = true;
            this.labelWCUT.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWCUT.Location = new System.Drawing.Point(303, 63);
            this.labelWCUT.Name = "labelWCUT";
            this.labelWCUT.Size = new System.Drawing.Size(66, 13);
            this.labelWCUT.TabIndex = 19;
            this.labelWCUT.Text = "23.2 / 24.54";
            // 
            // labelBHP
            // 
            this.labelBHP.AutoSize = true;
            this.labelBHP.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBHP.Location = new System.Drawing.Point(303, 41);
            this.labelBHP.Name = "labelBHP";
            this.labelBHP.Size = new System.Drawing.Size(66, 13);
            this.labelBHP.TabIndex = 18;
            this.labelBHP.Text = "23.2 / 24.54";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(237, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "GOR";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(237, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "WCUT";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(237, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "BHP, bar";
            // 
            // labelGPR
            // 
            this.labelGPR.AutoSize = true;
            this.labelGPR.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGPR.Location = new System.Drawing.Point(141, 108);
            this.labelGPR.Name = "labelGPR";
            this.labelGPR.Size = new System.Drawing.Size(66, 13);
            this.labelGPR.TabIndex = 14;
            this.labelGPR.Text = "2322 / 3342";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Liquid rate, m3/day";
            // 
            // labelWPR
            // 
            this.labelWPR.AutoSize = true;
            this.labelWPR.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWPR.Location = new System.Drawing.Point(141, 86);
            this.labelWPR.Name = "labelWPR";
            this.labelWPR.Size = new System.Drawing.Size(66, 13);
            this.labelWPR.TabIndex = 12;
            this.labelWPR.Text = "2322 / 3342";
            // 
            // labelOPR
            // 
            this.labelOPR.AutoSize = true;
            this.labelOPR.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOPR.Location = new System.Drawing.Point(141, 63);
            this.labelOPR.Name = "labelOPR";
            this.labelOPR.Size = new System.Drawing.Size(60, 13);
            this.labelOPR.TabIndex = 11;
            this.labelOPR.Text = "23.2 / 24.2";
            // 
            // labelLPR
            // 
            this.labelLPR.AutoSize = true;
            this.labelLPR.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLPR.Location = new System.Drawing.Point(141, 41);
            this.labelLPR.Name = "labelLPR";
            this.labelLPR.Size = new System.Drawing.Size(66, 13);
            this.labelLPR.TabIndex = 10;
            this.labelLPR.Text = "23.2 / 24.54";
            // 
            // labelGPRtext
            // 
            this.labelGPRtext.AutoSize = true;
            this.labelGPRtext.Location = new System.Drawing.Point(17, 108);
            this.labelGPRtext.Name = "labelGPRtext";
            this.labelGPRtext.Size = new System.Drawing.Size(92, 13);
            this.labelGPRtext.TabIndex = 9;
            this.labelGPRtext.Text = "Gas rate, m3/day";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Water rate, m3/day";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Oil rate, m3/day";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(17, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Flows";
            // 
            // TabWellModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TabWellModel";
            this.Size = new System.Drawing.Size(797, 638);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox boxDepthMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxChartMode;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxLumping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkShowModiValue;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.ComboBox boxRestartDates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelGPRtext;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkRoll;
        private System.Windows.Forms.Label labelWPR;
        private System.Windows.Forms.Label labelOPR;
        private System.Windows.Forms.Label labelLPR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label labelGOR;
        private System.Windows.Forms.Label labelWCUT;
        private System.Windows.Forms.Label labelBHP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelGPR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button8;
    }
}
