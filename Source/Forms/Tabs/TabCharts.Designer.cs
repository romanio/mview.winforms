
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
            this.kryptonWorkspace1 = new Krypton.Workspace.KryptonWorkspace();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonWorkspaceCell1 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell2 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell3 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage5 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage6 = new Krypton.Navigator.KryptonPage();
            this.kryptonWorkspaceCell4 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonPage7 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage8 = new Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.boxChartsPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGroupMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspace1)).BeginInit();
            this.kryptonWorkspace1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).BeginInit();
            this.kryptonWorkspaceCell1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell2)).BeginInit();
            this.kryptonWorkspaceCell2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell3)).BeginInit();
            this.kryptonWorkspaceCell3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell4)).BeginInit();
            this.kryptonWorkspaceCell4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage8)).BeginInit();
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
            // kryptonWorkspace1
            // 
            this.kryptonWorkspace1.ActivePage = this.kryptonPage1;
            this.kryptonWorkspace1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonWorkspace1.ContainerBackStyle = Krypton.Toolkit.PaletteBackStyle.TabLowProfile;
            this.kryptonWorkspace1.Location = new System.Drawing.Point(3, 82);
            this.kryptonWorkspace1.Name = "kryptonWorkspace1";
            // 
            // 
            // 
            this.kryptonWorkspace1.Root.Children.AddRange(new System.ComponentModel.Component[] {
            this.kryptonWorkspaceCell1,
            this.kryptonWorkspaceCell2,
            this.kryptonWorkspaceCell3,
            this.kryptonWorkspaceCell4});
            this.kryptonWorkspace1.Root.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kryptonWorkspace1.Root.StarSize = "25*,25*";
            this.kryptonWorkspace1.Root.UniqueName = "bd5e18ce3b694df0bf781df132937ea8";
            this.kryptonWorkspace1.Root.WorkspaceControl = this.kryptonWorkspace1;
            this.kryptonWorkspace1.ShowMaximizeButton = false;
            this.kryptonWorkspace1.Size = new System.Drawing.Size(791, 534);
            this.kryptonWorkspace1.TabIndex = 9;
            this.kryptonWorkspace1.TabStop = true;
            // 
            // kryptonManager1
            // 
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office365Blue;
            this.kryptonPalette1.Common.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonPalette1.Common.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonPalette1.CustomisedKryptonPaletteFilePath = null;
            this.kryptonManager1.GlobalPalette = this.kryptonPalette1;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // kryptonWorkspaceCell1
            // 
            this.kryptonWorkspaceCell1.AllowPageDrag = true;
            this.kryptonWorkspaceCell1.AllowTabFocus = false;
            this.kryptonWorkspaceCell1.Name = "kryptonWorkspaceCell1";
            this.kryptonWorkspaceCell1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
            this.kryptonWorkspaceCell1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonWorkspaceCell1.SelectedIndex = 0;
            this.kryptonWorkspaceCell1.UniqueName = "aa467ab506ba4986838b15a37184b1c0";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(789, 100);
            this.kryptonPage1.Text = "kryptonPage1";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "841a649f594647e0847fcd442d81ce83";
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
            this.kryptonPage2.UniqueName = "4503bf543f0f46a58dac2099d2b7a65d";
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
            this.kryptonWorkspaceCell2.UniqueName = "77cbe298b1124f2db05ef8481eb564c1";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(789, 103);
            this.kryptonPage3.Text = "kryptonPage3";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "99b4e93b4e5642df8c528a830175dcfb";
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
            this.kryptonPage4.UniqueName = "d2b282ba6e354c5b8a1620a229717786";
            // 
            // kryptonWorkspaceCell3
            // 
            this.kryptonWorkspaceCell3.AllowPageDrag = true;
            this.kryptonWorkspaceCell3.AllowTabFocus = false;
            this.kryptonWorkspaceCell3.Name = "kryptonWorkspaceCell3";
            this.kryptonWorkspaceCell3.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage5,
            this.kryptonPage6});
            this.kryptonWorkspaceCell3.SelectedIndex = 0;
            this.kryptonWorkspaceCell3.UniqueName = "1dc4d331084a4181afb2897e9fc43747";
            // 
            // kryptonPage5
            // 
            this.kryptonPage5.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage5.Flags = 65534;
            this.kryptonPage5.LastVisibleSet = true;
            this.kryptonPage5.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage5.Name = "kryptonPage5";
            this.kryptonPage5.Size = new System.Drawing.Size(789, 103);
            this.kryptonPage5.Text = "kryptonPage5";
            this.kryptonPage5.ToolTipTitle = "Page ToolTip";
            this.kryptonPage5.UniqueName = "1115d6d66f1b4157a764fb35e1430299";
            // 
            // kryptonPage6
            // 
            this.kryptonPage6.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage6.Flags = 65534;
            this.kryptonPage6.LastVisibleSet = true;
            this.kryptonPage6.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage6.Name = "kryptonPage6";
            this.kryptonPage6.Size = new System.Drawing.Size(100, 100);
            this.kryptonPage6.Text = "kryptonPage6";
            this.kryptonPage6.ToolTipTitle = "Page ToolTip";
            this.kryptonPage6.UniqueName = "197c48439b004596b4d94019457b3754";
            // 
            // kryptonWorkspaceCell4
            // 
            this.kryptonWorkspaceCell4.AllowPageDrag = true;
            this.kryptonWorkspaceCell4.AllowTabFocus = false;
            this.kryptonWorkspaceCell4.Name = "kryptonWorkspaceCell4";
            this.kryptonWorkspaceCell4.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage7,
            this.kryptonPage8});
            this.kryptonWorkspaceCell4.SelectedIndex = 0;
            this.kryptonWorkspaceCell4.UniqueName = "a5202400df1f4d6181eb3bf214891144";
            // 
            // kryptonPage7
            // 
            this.kryptonPage7.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage7.Flags = 65534;
            this.kryptonPage7.LastVisibleSet = true;
            this.kryptonPage7.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage7.Name = "kryptonPage7";
            this.kryptonPage7.Size = new System.Drawing.Size(789, 103);
            this.kryptonPage7.Text = "kryptonPage7";
            this.kryptonPage7.ToolTipTitle = "Page ToolTip";
            this.kryptonPage7.UniqueName = "84d0e26862ed420ea065b0af5d92f381";
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
            this.kryptonPage8.UniqueName = "60001a9b47d743519cb761b7309df484";
            // 
            // TabCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkShowAnno);
            this.Controls.Add(this.kryptonWorkspace1);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).EndInit();
            this.kryptonWorkspaceCell1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell2)).EndInit();
            this.kryptonWorkspaceCell2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell3)).EndInit();
            this.kryptonWorkspaceCell3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell4)).EndInit();
            this.kryptonWorkspaceCell4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage8)).EndInit();
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
        private Krypton.Workspace.KryptonWorkspace kryptonWorkspace1;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell2;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private Krypton.Navigator.KryptonPage kryptonPage4;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell3;
        private Krypton.Navigator.KryptonPage kryptonPage5;
        private Krypton.Navigator.KryptonPage kryptonPage6;
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell4;
        private Krypton.Navigator.KryptonPage kryptonPage7;
        private Krypton.Navigator.KryptonPage kryptonPage8;
    }
}
