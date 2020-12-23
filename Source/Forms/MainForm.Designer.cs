
namespace mview
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.visualStudioToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.vS2013DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013DarkTheme();
            this.vS2013BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonOpenNewModel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.boxGroupMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.boxChartsPositions = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(890, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dockPanel1.Location = new System.Drawing.Point(0, 115);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(890, 542);
            this.dockPanel1.TabIndex = 3;
            // 
            // visualStudioToolStripExtender1
            // 
            this.visualStudioToolStripExtender1.DefaultRenderer = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 18);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 110);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.buttonOpenNewModel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(872, 65);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MODEL";
            // 
            // buttonOpenNewModel
            // 
            this.buttonOpenNewModel.Image = global::mview.Properties.Resources.folder_add;
            this.buttonOpenNewModel.Location = new System.Drawing.Point(4, 3);
            this.buttonOpenNewModel.Name = "buttonOpenNewModel";
            this.buttonOpenNewModel.Size = new System.Drawing.Size(56, 42);
            this.buttonOpenNewModel.TabIndex = 0;
            this.buttonOpenNewModel.Text = "Open";
            this.buttonOpenNewModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonOpenNewModel.UseVisualStyleBackColor = true;
            this.buttonOpenNewModel.Click += new System.EventHandler(this.buttonOpenNewModel_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.boxChartsPositions);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.boxGroupMode);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 84);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CHART";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Charts positions";
            // 
            // boxGroupMode
            // 
            this.boxGroupMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxGroupMode.FormattingEnabled = true;
            this.boxGroupMode.IntegralHeight = false;
            this.boxGroupMode.Items.AddRange(new object[] {
            "Normal",
            "Sum",
            "Average",
            "Average by Liquid"});
            this.boxGroupMode.Location = new System.Drawing.Point(96, 11);
            this.boxGroupMode.Name = "boxGroupMode";
            this.boxGroupMode.Size = new System.Drawing.Size(124, 21);
            this.boxGroupMode.TabIndex = 1;
            this.boxGroupMode.SelectedIndexChanged += new System.EventHandler(this.boxGroupMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grouping mode";
            // 
            // boxChartsPositions
            // 
            this.boxChartsPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxChartsPositions.FormattingEnabled = true;
            this.boxChartsPositions.IntegralHeight = false;
            this.boxChartsPositions.Items.AddRange(new object[] {
            "1",
            "1+2",
            "1+3",
            "4"});
            this.boxChartsPositions.Location = new System.Drawing.Point(96, 41);
            this.boxChartsPositions.Name = "boxChartsPositions";
            this.boxChartsPositions.Size = new System.Drawing.Size(75, 21);
            this.boxChartsPositions.TabIndex = 3;
            this.boxChartsPositions.SelectedIndexChanged += new System.EventHandler(this.boxChartsPositions_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 679);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.Text = "mView";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender1;
        private WeifenLuo.WinFormsUI.Docking.VS2013DarkTheme vS2013DarkTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme vS2013BlueTheme1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonOpenNewModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxGroupMode;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxChartsPositions;
    }
}

