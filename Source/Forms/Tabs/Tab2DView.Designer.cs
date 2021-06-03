
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
            this.boxRestartDates = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.boxRestartDates);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 89);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // boxRestartDates
            // 
            this.boxRestartDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestartDates.FormattingEnabled = true;
            this.boxRestartDates.IntegralHeight = false;
            this.boxRestartDates.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxRestartDates.Location = new System.Drawing.Point(61, 14);
            this.boxRestartDates.Name = "boxRestartDates";
            this.boxRestartDates.Size = new System.Drawing.Size(155, 21);
            this.boxRestartDates.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Dates";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(469, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Drop ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(353, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.treeProperties.Location = new System.Drawing.Point(7, 189);
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
            // 
            // tabSideControl
            // 
            this.tabSideControl.Controls.Add(this.tabPage1);
            this.tabSideControl.Controls.Add(this.tabPage2);
            this.tabSideControl.Controls.Add(this.tabPage3);
            this.tabSideControl.ItemSize = new System.Drawing.Size(42, 18);
            this.tabSideControl.Location = new System.Drawing.Point(3, 98);
            this.tabSideControl.Name = "tabSideControl";
            this.tabSideControl.SelectedIndex = 0;
            this.tabSideControl.Size = new System.Drawing.Size(147, 85);
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
            this.tabPage1.Size = new System.Drawing.Size(139, 59);
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
            this.boxSlideX.Size = new System.Drawing.Size(103, 21);
            this.boxSlideX.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.boxSlideY);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(139, 59);
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
            this.boxSlideY.Size = new System.Drawing.Size(103, 21);
            this.boxSlideY.TabIndex = 15;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.boxSlideZ);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(139, 59);
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
            this.boxSlideZ.Size = new System.Drawing.Size(103, 21);
            this.boxSlideZ.TabIndex = 16;
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
            this.tabSideControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
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
    }
}
