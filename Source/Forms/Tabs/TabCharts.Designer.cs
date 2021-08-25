
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
            this.components = new System.ComponentModel.Container();
            this.checkShowAnno = new Krypton.Toolkit.KryptonCheckBox();
            this.buttonSeriesSettings = new Krypton.Toolkit.KryptonButton();
            this.boxChartsPositions = new Krypton.Toolkit.KryptonComboBox();
            this.label2 = new Krypton.Toolkit.KryptonLabel();
            this.label1 = new Krypton.Toolkit.KryptonLabel();
            this.boxGroupMode = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonWorkspace1 = new Krypton.Workspace.KryptonWorkspace();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell1 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell2 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.boxChartsPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGroupMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspace1)).BeginInit();
            this.kryptonWorkspace1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).BeginInit();
            this.kryptonWorkspaceCell1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell2)).BeginInit();
            this.kryptonWorkspaceCell2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.SuspendLayout();
            // 
            // checkShowAnno
            // 
            this.checkShowAnno.Location = new System.Drawing.Point(446, 20);
            this.checkShowAnno.Name = "checkShowAnno";
            this.checkShowAnno.Size = new System.Drawing.Size(121, 20);
            this.checkShowAnno.TabIndex = 5;
            this.checkShowAnno.Values.Text = "Show annotations";
            this.checkShowAnno.CheckedChanged += new System.EventHandler(this.CheckShowAnnoOnCheckedChanged);
            // 
            // buttonSeriesSettings
            // 
            this.buttonSeriesSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSeriesSettings.Location = new System.Drawing.Point(630, 20);
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
            this.boxChartsPositions.Location = new System.Drawing.Point(79, 19);
            this.boxChartsPositions.Name = "boxChartsPositions";
            this.boxChartsPositions.Size = new System.Drawing.Size(101, 21);
            this.boxChartsPositions.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.boxChartsPositions.TabIndex = 3;
            this.boxChartsPositions.SelectedIndexChanged += new System.EventHandler(this.BoxChartsPositionsOnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Values.Text = "Position";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(203, 20);
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
            this.boxGroupMode.Location = new System.Drawing.Point(306, 19);
            this.boxGroupMode.Name = "boxGroupMode";
            this.boxGroupMode.Size = new System.Drawing.Size(122, 21);
            this.boxGroupMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.boxGroupMode.TabIndex = 1;
            this.boxGroupMode.SelectedIndexChanged += new System.EventHandler(this.BoxGroupModeOnSelectedIndexChanged);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kryptonPalette1;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office365Blue;
            this.kryptonPalette1.Common.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonPalette1.Common.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonPalette1.CustomisedKryptonPaletteFilePath = null;
            // 
            // kryptonWorkspace1
            // 
            this.kryptonWorkspace1.ActivePage = this.kryptonPage1;
            this.kryptonWorkspace1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonWorkspace1.Location = new System.Drawing.Point(3, 72);
            this.kryptonWorkspace1.Name = "kryptonWorkspace1";
            // 
            // 
            // 
            this.kryptonWorkspace1.Root.Children.AddRange(new System.ComponentModel.Component[] {
            this.kryptonWorkspaceCell1,
            this.kryptonWorkspaceCell2});
            this.kryptonWorkspace1.Root.UniqueName = "7f7ff3c5bb2d4c2d9e980e283ce4f5f0";
            this.kryptonWorkspace1.Root.WorkspaceControl = this.kryptonWorkspace1;
            this.kryptonWorkspace1.SeparatorStyle = Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonWorkspace1.Size = new System.Drawing.Size(791, 563);
            this.kryptonWorkspace1.TabIndex = 6;
            this.kryptonWorkspace1.TabStop = true;
            this.kryptonWorkspace1.WorkspaceCellAdding += new System.EventHandler<Krypton.Workspace.WorkspaceCellEventArgs>(this.kryptonWorkspace1_WorkspaceCellAdding);
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(391, 493);
            this.kryptonPage1.Text = "kryptonPage1";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "44deaea325d34b12bdf9486acc9d4bf5";
            // 
            // kryptonWorkspaceCell1
            // 
            this.kryptonWorkspaceCell1.AllowPageDrag = true;
            this.kryptonWorkspaceCell1.AllowTabFocus = false;
            this.kryptonWorkspaceCell1.Name = "kryptonWorkspaceCell1";
            this.kryptonWorkspaceCell1.NavigatorMode = Krypton.Navigator.NavigatorMode.HeaderGroupTab;
            this.kryptonWorkspaceCell1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonWorkspaceCell1.SelectedIndex = 0;
            this.kryptonWorkspaceCell1.UniqueName = "495a0fdf6af94848987075f4bbfa97d7";
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
            this.kryptonPage2.UniqueName = "90d1cbb2c138405f8ef48080db86b50f";
            // 
            // kryptonWorkspaceCell2
            // 
            this.kryptonWorkspaceCell2.AllowPageDrag = true;
            this.kryptonWorkspaceCell2.AllowTabFocus = false;
            this.kryptonWorkspaceCell2.Name = "kryptonWorkspaceCell2";
            this.kryptonWorkspaceCell2.NavigatorMode = Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
            this.kryptonWorkspaceCell2.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage3,
            this.kryptonPage4});
            this.kryptonWorkspaceCell2.SelectedIndex = 0;
            this.kryptonWorkspaceCell2.UniqueName = "4341b5b56aa44e9c9072f6d2509db9cf";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(391, 534);
            this.kryptonPage3.Text = "kryptonPage3";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "aa3cf9ce9f8e4c67b7310bd49ec201f8";
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
            this.kryptonPage4.UniqueName = "ed425903b12747788b36e67d18bcd194";
            // 
            // TabCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.kryptonWorkspace1);
            this.Controls.Add(this.checkShowAnno);
            this.Controls.Add(this.buttonSeriesSettings);
            this.Controls.Add(this.boxChartsPositions);
            this.Controls.Add(this.boxGroupMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TabCharts";
            this.Size = new System.Drawing.Size(797, 638);
            ((System.ComponentModel.ISupportInitialize)(this.boxChartsPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGroupMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspace1)).EndInit();
            this.kryptonWorkspace1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).EndInit();
            this.kryptonWorkspaceCell1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell2)).EndInit();
            this.kryptonWorkspaceCell2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonButton buttonSeriesSettings;
        private Krypton.Toolkit.KryptonComboBox boxChartsPositions;
        private Krypton.Toolkit.KryptonLabel label2;
        private Krypton.Toolkit.KryptonLabel label1;
        private Krypton.Toolkit.KryptonComboBox boxGroupMode;
        private Krypton.Toolkit.KryptonCheckBox checkShowAnno;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private Krypton.Workspace.KryptonWorkspace kryptonWorkspace1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell2;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private Krypton.Navigator.KryptonPage kryptonPage4;
    }
}
