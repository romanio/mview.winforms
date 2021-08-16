
namespace mview
{
    partial class TabCharts
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
            this.panel1 = new Krypton.Toolkit.KryptonPanel();
            this.checkShowAnno = new Krypton.Toolkit.KryptonCheckBox();
            this.buttonSeriesSettings = new Krypton.Toolkit.KryptonButton();
            this.boxChartsPositions = new Krypton.Toolkit.KryptonComboBox();
            this.label2 = new Krypton.Toolkit.KryptonLabel();
            this.label1 = new Krypton.Toolkit.KryptonLabel();
            this.boxGroupMode = new Krypton.Toolkit.KryptonComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonWorkspace1 = new Krypton.Workspace.KryptonWorkspace();
            this.kryptonWorkspaceSequence2 = new Krypton.Workspace.KryptonWorkspaceSequence();
            this.kryptonWorkspaceSequence3 = new Krypton.Workspace.KryptonWorkspaceSequence();
            this.kryptonWorkspaceSequence4 = new Krypton.Workspace.KryptonWorkspaceSequence();
            this.kryptonWorkspaceCell5 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage7 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage8 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell1 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell2 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxChartsPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGroupMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspace1)).BeginInit();
            this.kryptonWorkspace1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell5)).BeginInit();
            this.kryptonWorkspaceCell5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).BeginInit();
            this.kryptonWorkspaceCell1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell2)).BeginInit();
            this.kryptonWorkspaceCell2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.checkShowAnno);
            this.panel1.Controls.Add(this.buttonSeriesSettings);
            this.panel1.Controls.Add(this.boxChartsPositions);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boxGroupMode);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 89);
            this.panel1.TabIndex = 7;
            // 
            // checkShowAnno
            // 
            this.checkShowAnno.Location = new System.Drawing.Point(444, 18);
            this.checkShowAnno.Name = "checkShowAnno";
            this.checkShowAnno.Size = new System.Drawing.Size(121, 20);
            this.checkShowAnno.TabIndex = 5;
            this.checkShowAnno.Values.Text = "Show annotations";
            this.checkShowAnno.CheckedChanged += new System.EventHandler(this.CheckShowAnnoOnCheckedChanged);
            // 
            // buttonSeriesSettings
            // 
            this.buttonSeriesSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSeriesSettings.Location = new System.Drawing.Point(620, 16);
            this.buttonSeriesSettings.Name = "buttonSeriesSettings";
            this.buttonSeriesSettings.Size = new System.Drawing.Size(100, 30);
            this.buttonSeriesSettings.TabIndex = 4;
            this.buttonSeriesSettings.Values.Text = "Styles";
            this.buttonSeriesSettings.Click += new System.EventHandler(this.ButtonSeriesSettingsOnClick);
            // 
            // boxChartsPositions
            // 
            this.boxChartsPositions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.boxChartsPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxChartsPositions.DropDownWidth = 101;
            this.boxChartsPositions.FormattingEnabled = true;
            this.boxChartsPositions.IntegralHeight = false;
            this.boxChartsPositions.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxChartsPositions.Location = new System.Drawing.Point(78, 16);
            this.boxChartsPositions.Name = "boxChartsPositions";
            this.boxChartsPositions.Size = new System.Drawing.Size(101, 21);
            this.boxChartsPositions.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.boxChartsPositions.TabIndex = 3;
            this.boxChartsPositions.SelectedIndexChanged += new System.EventHandler(this.BoxChartsPositionsOnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Values.Text = "Position";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(202, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Grouping mode";
            // 
            // boxGroupMode
            // 
            this.boxGroupMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.boxGroupMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxGroupMode.DropDownWidth = 122;
            this.boxGroupMode.FormattingEnabled = true;
            this.boxGroupMode.IntegralHeight = false;
            this.boxGroupMode.Items.AddRange(new object[] {
            "Normal",
            "Sum",
            "Average",
            "Average by Liquid"});
            this.boxGroupMode.Location = new System.Drawing.Point(305, 17);
            this.boxGroupMode.Name = "boxGroupMode";
            this.boxGroupMode.Size = new System.Drawing.Size(122, 21);
            this.boxGroupMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.boxGroupMode.TabIndex = 1;
            this.boxGroupMode.SelectedIndexChanged += new System.EventHandler(this.BoxGroupModeOnSelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(541, 491);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 144);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // kryptonWorkspace1
            // 
            this.kryptonWorkspace1.ActivePage = this.kryptonPage7;
            this.kryptonWorkspace1.Location = new System.Drawing.Point(11, 111);
            this.kryptonWorkspace1.Name = "kryptonWorkspace1";
            // 
            // 
            // 
            this.kryptonWorkspace1.Root.Children.AddRange(new System.ComponentModel.Component[] {
            this.kryptonWorkspaceCell5,
            this.kryptonWorkspaceCell2,
            this.kryptonWorkspaceCell1});
            this.kryptonWorkspace1.Root.StarSize = "25*,25*";
            this.kryptonWorkspace1.Root.UniqueName = "bd5e18ce3b694df0bf781df132937ea8";
            this.kryptonWorkspace1.Root.WorkspaceControl = this.kryptonWorkspace1;
            this.kryptonWorkspace1.Size = new System.Drawing.Size(771, 357);
            this.kryptonWorkspace1.TabIndex = 9;
            this.kryptonWorkspace1.TabStop = true;
            // 
            // kryptonWorkspaceSequence2
            // 
            this.kryptonWorkspaceSequence2.Children.AddRange(new System.ComponentModel.Component[] {
            this.kryptonWorkspaceSequence3});
            this.kryptonWorkspaceSequence2.UniqueName = "3d16cefedecc4d0ca27630259a8f8285";
            this.kryptonWorkspaceSequence2.WorkspaceControl = null;
            // 
            // kryptonWorkspaceSequence3
            // 
            this.kryptonWorkspaceSequence3.UniqueName = "11883cedfe504a7bb928ed551e316021";
            this.kryptonWorkspaceSequence3.WorkspaceControl = null;
            // 
            // kryptonWorkspaceSequence4
            // 
            this.kryptonWorkspaceSequence4.UniqueName = "dcac5cb6ec3d46dcabf8d9c033aecb9e";
            this.kryptonWorkspaceSequence4.WorkspaceControl = null;
            // 
            // kryptonWorkspaceCell5
            // 
            this.kryptonWorkspaceCell5.AllowPageDrag = true;
            this.kryptonWorkspaceCell5.AllowTabFocus = false;
            this.kryptonWorkspaceCell5.Name = "kryptonWorkspaceCell5";
            this.kryptonWorkspaceCell5.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage7,
            this.kryptonPage8});
            this.kryptonWorkspaceCell5.SelectedIndex = 0;
            this.kryptonWorkspaceCell5.UniqueName = "60c668fa5eaa4fdb90460956cfff3a0e";
            // 
            // kryptonPage7
            // 
            this.kryptonPage7.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage7.Flags = 65534;
            this.kryptonPage7.LastVisibleSet = true;
            this.kryptonPage7.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage7.Name = "kryptonPage7";
            this.kryptonPage7.Size = new System.Drawing.Size(251, 330);
            this.kryptonPage7.Text = "kryptonPage7";
            this.kryptonPage7.ToolTipTitle = "Page ToolTip";
            this.kryptonPage7.UniqueName = "eddf0f70147e4335a4e506b0190eb477";
            // 
            // kryptonPage8
            // 
            this.kryptonPage8.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage8.Flags = 65534;
            this.kryptonPage8.LastVisibleSet = true;
            this.kryptonPage8.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage8.Name = "kryptonPage8";
            this.kryptonPage8.Size = new System.Drawing.Size(100, 100);
            this.kryptonPage8.Text = "kryptonPage8";
            this.kryptonPage8.ToolTipTitle = "Page ToolTip";
            this.kryptonPage8.UniqueName = "1a7aef55af7840e0b4671d6155f3ef32";
            // 
            // kryptonWorkspaceCell1
            // 
            this.kryptonWorkspaceCell1.AllowPageDrag = true;
            this.kryptonWorkspaceCell1.AllowTabFocus = false;
            this.kryptonWorkspaceCell1.Name = "kryptonWorkspaceCell1";
            this.kryptonWorkspaceCell1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonWorkspaceCell1.SelectedIndex = 0;
            this.kryptonWorkspaceCell1.UniqueName = "ec7da7e36bd4425585bf15fdce8a5f16";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(252, 330);
            this.kryptonPage1.Text = "kryptonPage1";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "877a1f582acb42b8ad1a80ec2dad5f4d";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(100, 100);
            this.kryptonPage2.Text = "kryptonPage2";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "72c7ca90f6bc484da3af65b53eb08729";
            // 
            // kryptonWorkspaceCell2
            // 
            this.kryptonWorkspaceCell2.AllowPageDrag = true;
            this.kryptonWorkspaceCell2.AllowTabFocus = false;
            this.kryptonWorkspaceCell2.Name = "kryptonWorkspaceCell2";
            this.kryptonWorkspaceCell2.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage3,
            this.kryptonPage4});
            this.kryptonWorkspaceCell2.SelectedIndex = 0;
            this.kryptonWorkspaceCell2.UniqueName = "bbe9b5670b31449fb8162c1db9a8fe6f";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(252, 330);
            this.kryptonPage3.Text = "kryptonPage3";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "0d05c89e33be4a34bfc02ae7bd2058f5";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(100, 100);
            this.kryptonPage4.Text = "kryptonPage4";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "57889ac112584fa29a5d96533ff05fd7";
            // 
            // TabCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.kryptonWorkspace1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TabCharts";
            this.Size = new System.Drawing.Size(797, 638);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxChartsPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGroupMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspace1)).EndInit();
            this.kryptonWorkspace1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell5)).EndInit();
            this.kryptonWorkspaceCell5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).EndInit();
            this.kryptonWorkspaceCell1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell2)).EndInit();
            this.kryptonWorkspaceCell2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel panel1;
        private Krypton.Toolkit.KryptonButton buttonSeriesSettings;
        private Krypton.Toolkit.KryptonComboBox boxChartsPositions;
        private Krypton.Toolkit.KryptonLabel label2;
        private Krypton.Toolkit.KryptonLabel label1;
        private Krypton.Toolkit.KryptonComboBox boxGroupMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Krypton.Toolkit.KryptonCheckBox checkShowAnno;
        private Krypton.Workspace.KryptonWorkspace kryptonWorkspace1;
        private Krypton.Workspace.KryptonWorkspaceSequence kryptonWorkspaceSequence2;
        private Krypton.Workspace.KryptonWorkspaceSequence kryptonWorkspaceSequence3;
        private Krypton.Workspace.KryptonWorkspaceSequence kryptonWorkspaceSequence4;
        private Krypton.Navigator.KryptonPage kryptonPage7;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell5;
        private Krypton.Navigator.KryptonPage kryptonPage8;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell2;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private Krypton.Navigator.KryptonPage kryptonPage4;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
    }
}
