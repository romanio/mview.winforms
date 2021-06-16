
namespace mview
{
    partial class Tab2DView
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
            this.trackStratch = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericZScale = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.boxRestartDates = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelOpenGL = new System.Windows.Forms.Panel();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.tabSideControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxSlideX = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.boxSlideY = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.boxSlideZ = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).BeginInit();
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
            this.panel1.Controls.Add(this.trackStratch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericZScale);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.boxRestartDates);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 89);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // trackStratch
            // 
            this.trackStratch.AutoSize = false;
            this.trackStratch.BackColor = System.Drawing.SystemColors.Window;
            this.trackStratch.Location = new System.Drawing.Point(434, 12);
            this.trackStratch.Maximum = 100;
            this.trackStratch.Name = "trackStratch";
            this.trackStratch.Size = new System.Drawing.Size(179, 26);
            this.trackStratch.TabIndex = 18;
            this.trackStratch.TickFrequency = 4;
            this.trackStratch.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackStratch.Value = 1;
            this.trackStratch.Scroll += new System.EventHandler(this.trackStratch_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Stratch";
            // 
            // numericZScale
            // 
            this.numericZScale.Location = new System.Drawing.Point(270, 12);
            this.numericZScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericZScale.Name = "numericZScale";
            this.numericZScale.Size = new System.Drawing.Size(88, 22);
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
            this.label4.Location = new System.Drawing.Point(221, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Z-Scale";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(644, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // boxRestartDates
            // 
            this.boxRestartDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestartDates.FormattingEnabled = true;
            this.boxRestartDates.IntegralHeight = false;
            this.boxRestartDates.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxRestartDates.Location = new System.Drawing.Point(57, 13);
            this.boxRestartDates.Name = "boxRestartDates";
            this.boxRestartDates.Size = new System.Drawing.Size(139, 21);
            this.boxRestartDates.TabIndex = 13;
            this.boxRestartDates.SelectedIndexChanged += new System.EventHandler(this.boxRestartDates_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dates";
            // 
            // panelOpenGL
            // 
            this.panelOpenGL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOpenGL.Location = new System.Drawing.Point(156, 98);
            this.panelOpenGL.Name = "panelOpenGL";
            this.panelOpenGL.Size = new System.Drawing.Size(623, 582);
            this.panelOpenGL.TabIndex = 10;
            // 
            // treeProperties
            // 
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(8, 189);
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
            this.tabSideControl.Location = new System.Drawing.Point(8, 98);
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
            this.Controls.Add(this.tabSideControl);
            this.Controls.Add(this.treeProperties);
            this.Controls.Add(this.panelOpenGL);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Tab2DView";
            this.Size = new System.Drawing.Size(782, 683);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackStratch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZScale)).EndInit();
            this.tabSideControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelOpenGL;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeProperties;
        private System.Windows.Forms.ComboBox boxRestartDates;
        private System.Windows.Forms.Label label3;
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
    }
}
