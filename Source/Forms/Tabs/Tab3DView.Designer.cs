
namespace mview
{
    partial class Tab3DView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Static ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Dynamic");
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkSnapChart = new System.Windows.Forms.CheckBox();
            this.checkFocusOn = new System.Windows.Forms.CheckBox();
            this.boxBubbleMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericBubbleScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMaxDefault = new System.Windows.Forms.Button();
            this.buttonMinDefault = new System.Windows.Forms.Button();
            this.checkNoFillColor = new System.Windows.Forms.CheckBox();
            this.textMaximum = new System.Windows.Forms.TextBox();
            this.textMinimum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkShowGridlines = new System.Windows.Forms.CheckBox();
            this.trackStratch = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericZScale = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCellValue = new System.Windows.Forms.Label();
            this.boxRestartDates = new System.Windows.Forms.ComboBox();
            this.panelOpenGL = new System.Windows.Forms.Panel();
            this.panelSnap = new System.Windows.Forms.Panel();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.tabSideControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxSlideX = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.boxSlideY = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.boxSlideZ = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBubbleScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).BeginInit();
            this.panelOpenGL.SuspendLayout();
            this.tabSideControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.checkSnapChart);
            this.panel1.Controls.Add(this.checkFocusOn);
            this.panel1.Controls.Add(this.boxBubbleMode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericBubbleScale);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonMaxDefault);
            this.panel1.Controls.Add(this.buttonMinDefault);
            this.panel1.Controls.Add(this.checkNoFillColor);
            this.panel1.Controls.Add(this.textMaximum);
            this.panel1.Controls.Add(this.textMinimum);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkShowGridlines);
            this.panel1.Controls.Add(this.trackStratch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericZScale);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 89);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkSnapChart
            // 
            this.checkSnapChart.AutoSize = true;
            this.checkSnapChart.Location = new System.Drawing.Point(709, 48);
            this.checkSnapChart.Name = "checkSnapChart";
            this.checkSnapChart.Size = new System.Drawing.Size(81, 17);
            this.checkSnapChart.TabIndex = 39;
            this.checkSnapChart.Text = "Snap chart";
            this.checkSnapChart.UseVisualStyleBackColor = true;
            this.checkSnapChart.CheckedChanged += new System.EventHandler(this.checkSnapChart_CheckedChanged);
            // 
            // checkFocusOn
            // 
            this.checkFocusOn.AutoSize = true;
            this.checkFocusOn.Location = new System.Drawing.Point(709, 13);
            this.checkFocusOn.Name = "checkFocusOn";
            this.checkFocusOn.Size = new System.Drawing.Size(82, 17);
            this.checkFocusOn.TabIndex = 38;
            this.checkFocusOn.Text = "Auto focus";
            this.checkFocusOn.UseVisualStyleBackColor = true;
            // 
            // boxBubbleMode
            // 
            this.boxBubbleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBubbleMode.FormattingEnabled = true;
            this.boxBubbleMode.IntegralHeight = false;
            this.boxBubbleMode.Items.AddRange(new object[] {
            "None",
            "Simulation",
            "History",
            "Diff LP Total",
            "Diff OP Total",
            "Diff GP Total",
            "Diff WI Total",
            "Diff Oil Rate",
            "Diff Liq Rate",
            "Diff Gas Rate",
            "Diff WCUT",
            "Diff BHP"});
            this.boxBubbleMode.Location = new System.Drawing.Point(573, 10);
            this.boxBubbleMode.Name = "boxBubbleMode";
            this.boxBubbleMode.Size = new System.Drawing.Size(110, 21);
            this.boxBubbleMode.TabIndex = 37;
            this.boxBubbleMode.SelectedIndexChanged += new System.EventHandler(this.boxBubbleMode_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(486, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Bubble scale";
            // 
            // numericBubbleScale
            // 
            this.numericBubbleScale.Location = new System.Drawing.Point(573, 49);
            this.numericBubbleScale.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericBubbleScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBubbleScale.Name = "numericBubbleScale";
            this.numericBubbleScale.Size = new System.Drawing.Size(62, 22);
            this.numericBubbleScale.TabIndex = 35;
            this.numericBubbleScale.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericBubbleScale.ValueChanged += new System.EventHandler(this.numericBubbleScale_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Bubble map";
            // 
            // buttonMaxDefault
            // 
            this.buttonMaxDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMaxDefault.Location = new System.Drawing.Point(138, 9);
            this.buttonMaxDefault.Name = "buttonMaxDefault";
            this.buttonMaxDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonMaxDefault.TabIndex = 33;
            this.buttonMaxDefault.Text = "D";
            this.buttonMaxDefault.UseVisualStyleBackColor = true;
            this.buttonMaxDefault.Click += new System.EventHandler(this.buttonMaxDefault_Click);
            // 
            // buttonMinDefault
            // 
            this.buttonMinDefault.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinDefault.Location = new System.Drawing.Point(138, 46);
            this.buttonMinDefault.Name = "buttonMinDefault";
            this.buttonMinDefault.Size = new System.Drawing.Size(24, 23);
            this.buttonMinDefault.TabIndex = 32;
            this.buttonMinDefault.Text = "D";
            this.buttonMinDefault.UseVisualStyleBackColor = true;
            this.buttonMinDefault.Click += new System.EventHandler(this.buttonMinDefault_Click);
            // 
            // checkNoFillColor
            // 
            this.checkNoFillColor.AutoSize = true;
            this.checkNoFillColor.Location = new System.Drawing.Point(382, 50);
            this.checkNoFillColor.Name = "checkNoFillColor";
            this.checkNoFillColor.Size = new System.Drawing.Size(86, 17);
            this.checkNoFillColor.TabIndex = 25;
            this.checkNoFillColor.Text = "No fill color";
            this.checkNoFillColor.UseVisualStyleBackColor = true;
            this.checkNoFillColor.CheckedChanged += new System.EventHandler(this.checkNoFillColor_CheckedChanged);
            // 
            // textMaximum
            // 
            this.textMaximum.Location = new System.Drawing.Point(70, 10);
            this.textMaximum.Name = "textMaximum";
            this.textMaximum.Size = new System.Drawing.Size(62, 22);
            this.textMaximum.TabIndex = 24;
            this.textMaximum.Text = "1.000";
            this.textMaximum.Validating += new System.ComponentModel.CancelEventHandler(this.textMaximum_Validating);
            // 
            // textMinimum
            // 
            this.textMinimum.Location = new System.Drawing.Point(70, 46);
            this.textMinimum.Name = "textMinimum";
            this.textMinimum.Size = new System.Drawing.Size(62, 22);
            this.textMinimum.TabIndex = 23;
            this.textMinimum.Text = "0.000";
            this.textMinimum.Validating += new System.ComponentModel.CancelEventHandler(this.textMinimum_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Maximum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Minimum";
            // 
            // checkShowGridlines
            // 
            this.checkShowGridlines.AutoSize = true;
            this.checkShowGridlines.Location = new System.Drawing.Point(382, 12);
            this.checkShowGridlines.Name = "checkShowGridlines";
            this.checkShowGridlines.Size = new System.Drawing.Size(75, 17);
            this.checkShowGridlines.TabIndex = 19;
            this.checkShowGridlines.Text = "Grid lines";
            this.checkShowGridlines.UseVisualStyleBackColor = true;
            this.checkShowGridlines.CheckedChanged += new System.EventHandler(this.checkShowGridlines_CheckedChanged);
            // 
            // trackStratch
            // 
            this.trackStratch.AutoSize = false;
            this.trackStratch.BackColor = System.Drawing.SystemColors.Window;
            this.trackStratch.Location = new System.Drawing.Point(243, 47);
            this.trackStratch.Maximum = 100;
            this.trackStratch.Name = "trackStratch";
            this.trackStratch.Size = new System.Drawing.Size(117, 22);
            this.trackStratch.TabIndex = 18;
            this.trackStratch.TickFrequency = 4;
            this.trackStratch.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackStratch.Value = 1;
            this.trackStratch.Scroll += new System.EventHandler(this.trackStratch_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Stratch";
            // 
            // numericZScale
            // 
            this.numericZScale.Location = new System.Drawing.Point(243, 11);
            this.numericZScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericZScale.Name = "numericZScale";
            this.numericZScale.Size = new System.Drawing.Size(62, 22);
            this.numericZScale.TabIndex = 16;
            this.numericZScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericZScale.ValueChanged += new System.EventHandler(this.numericZScale_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Z-Scale";
            // 
            // labelCellValue
            // 
            this.labelCellValue.AutoSize = true;
            this.labelCellValue.Location = new System.Drawing.Point(156, 98);
            this.labelCellValue.Name = "labelCellValue";
            this.labelCellValue.Size = new System.Drawing.Size(86, 13);
            this.labelCellValue.TabIndex = 19;
            this.labelCellValue.Text = "Cell[-1;-1;-1]=-1";
            // 
            // boxRestartDates
            // 
            this.boxRestartDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestartDates.FormattingEnabled = true;
            this.boxRestartDates.IntegralHeight = false;
            this.boxRestartDates.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxRestartDates.Location = new System.Drawing.Point(11, 199);
            this.boxRestartDates.Name = "boxRestartDates";
            this.boxRestartDates.Size = new System.Drawing.Size(139, 21);
            this.boxRestartDates.TabIndex = 13;
            this.boxRestartDates.SelectedIndexChanged += new System.EventHandler(this.boxRestartDates_SelectedIndexChanged);
            // 
            // panelOpenGL
            // 
            this.panelOpenGL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOpenGL.Controls.Add(this.panelSnap);
            this.panelOpenGL.Location = new System.Drawing.Point(156, 120);
            this.panelOpenGL.Name = "panelOpenGL";
            this.panelOpenGL.Size = new System.Drawing.Size(727, 511);
            this.panelOpenGL.TabIndex = 10;
            // 
            // panelSnap
            // 
            this.panelSnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSnap.Location = new System.Drawing.Point(333, 3);
            this.panelSnap.Name = "panelSnap";
            this.panelSnap.Size = new System.Drawing.Size(391, 296);
            this.panelSnap.TabIndex = 12;
            this.panelSnap.Visible = false;
            // 
            // treeProperties
            // 
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(11, 242);
            this.treeProperties.Name = "treeProperties";
            treeNode1.Name = "Узел0";
            treeNode1.Text = "Static ";
            treeNode2.Name = "Узел1";
            treeNode2.Text = "Dynamic";
            this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeProperties.Size = new System.Drawing.Size(139, 367);
            this.treeProperties.TabIndex = 11;
            this.treeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreePropertiesOnAfterSelect);
            // 
            // tabSideControl
            // 
            this.tabSideControl.Controls.Add(this.tabPage1);
            this.tabSideControl.Controls.Add(this.tabPage2);
            this.tabSideControl.Controls.Add(this.tabPage3);
            this.tabSideControl.ItemSize = new System.Drawing.Size(42, 18);
            this.tabSideControl.Location = new System.Drawing.Point(11, 98);
            this.tabSideControl.Name = "tabSideControl";
            this.tabSideControl.SelectedIndex = 0;
            this.tabSideControl.Size = new System.Drawing.Size(139, 85);
            this.tabSideControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabSideControl.TabIndex = 12;
            this.tabSideControl.SelectedIndexChanged += new System.EventHandler(this.TabSideControlOnSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxSlideX);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(131, 59);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "X(I)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boxSlideX
            // 
            this.boxSlideX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSlideX.FormattingEnabled = true;
            this.boxSlideX.IntegralHeight = false;
            this.boxSlideX.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxSlideX.Location = new System.Drawing.Point(18, 19);
            this.boxSlideX.Name = "boxSlideX";
            this.boxSlideX.Size = new System.Drawing.Size(91, 21);
            this.boxSlideX.TabIndex = 16;
            this.boxSlideX.SelectedIndexChanged += new System.EventHandler(this.boxSlideX_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.boxSlideY);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(131, 59);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Y(J)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // boxSlideY
            // 
            this.boxSlideY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSlideY.FormattingEnabled = true;
            this.boxSlideY.IntegralHeight = false;
            this.boxSlideY.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxSlideY.Location = new System.Drawing.Point(18, 19);
            this.boxSlideY.Name = "boxSlideY";
            this.boxSlideY.Size = new System.Drawing.Size(91, 21);
            this.boxSlideY.TabIndex = 15;
            this.boxSlideY.SelectedIndexChanged += new System.EventHandler(this.boxSlideY_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.boxSlideZ);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(131, 59);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Z(K)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // boxSlideZ
            // 
            this.boxSlideZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSlideZ.FormattingEnabled = true;
            this.boxSlideZ.IntegralHeight = false;
            this.boxSlideZ.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxSlideZ.Location = new System.Drawing.Point(18, 19);
            this.boxSlideZ.Name = "boxSlideZ";
            this.boxSlideZ.Size = new System.Drawing.Size(91, 21);
            this.boxSlideZ.TabIndex = 16;
            this.boxSlideZ.SelectedIndexChanged += new System.EventHandler(this.boxSlideZ_SelectedIndexChanged);
            // 
            // Tab2DView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.labelCellValue);
            this.Controls.Add(this.tabSideControl);
            this.Controls.Add(this.treeProperties);
            this.Controls.Add(this.panelOpenGL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boxRestartDates);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Tab2DView";
            this.Size = new System.Drawing.Size(886, 634);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBubbleScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).EndInit();
            this.panelOpenGL.ResumeLayout(false);
            this.tabSideControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelOpenGL;
        private System.Windows.Forms.TreeView treeProperties;
        private System.Windows.Forms.ComboBox boxRestartDates;
        private System.Windows.Forms.TabControl tabSideControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox boxSlideY;
        private System.Windows.Forms.ComboBox boxSlideZ;
        private System.Windows.Forms.ComboBox boxSlideX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericZScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackStratch;
        private System.Windows.Forms.Label labelCellValue;
        private System.Windows.Forms.CheckBox checkShowGridlines;
        private System.Windows.Forms.TextBox textMaximum;
        private System.Windows.Forms.TextBox textMinimum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkNoFillColor;
        private System.Windows.Forms.Button buttonMaxDefault;
        private System.Windows.Forms.Button buttonMinDefault;
        private System.Windows.Forms.ComboBox boxBubbleMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericBubbleScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelSnap;
        private System.Windows.Forms.CheckBox checkSnapChart;
        private System.Windows.Forms.CheckBox checkFocusOn;
    }
}
