
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
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.buttonProjects = new Krypton.Toolkit.KryptonButton();
            this.kryptonNavigator = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.labelWellgroups = new Krypton.Toolkit.KryptonLabel();
            this.labelAnnotations = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton8 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton7 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton6 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton5 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            this.listNames = new Krypton.Toolkit.KryptonListBox();
            this.buttonWellFilter = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton10 = new Krypton.Toolkit.KryptonButton();
            this.boxNameType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.checkSorted = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator)).BeginInit();
            this.kryptonNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxNameType)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 673);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.AllowFormChrome = Krypton.Toolkit.InheritBool.False;
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonPalette1.Common.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonPalette1.Common.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonPalette1.Common.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonPalette1.CustomisedKryptonPaletteFilePath = null;
            // 
            // buttonProjects
            // 
            this.buttonProjects.Location = new System.Drawing.Point(14, 12);
            this.buttonProjects.Name = "buttonProjects";
            this.buttonProjects.Palette = this.kryptonPalette1;
            this.buttonProjects.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.buttonProjects.Size = new System.Drawing.Size(104, 29);
            this.buttonProjects.TabIndex = 17;
            this.buttonProjects.Values.Text = "Projects";
            this.buttonProjects.Click += new System.EventHandler(this.OnButtonProjectClick);
            // 
            // kryptonNavigator
            // 
            this.kryptonNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonNavigator.Bar.BarMapExtraText = Krypton.Navigator.MapKryptonPageText.None;
            this.kryptonNavigator.Bar.BarMapImage = Krypton.Navigator.MapKryptonPageImage.Small;
            this.kryptonNavigator.Bar.BarMapText = Krypton.Navigator.MapKryptonPageText.TextTitle;
            this.kryptonNavigator.Bar.ItemMinimumSize = new System.Drawing.Size(80, 20);
            this.kryptonNavigator.Bar.ItemSizing = Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.kryptonNavigator.Bar.TabBorderStyle = Krypton.Toolkit.TabBorderStyle.DockEqual;
            this.kryptonNavigator.Bar.TabStyle = Krypton.Toolkit.TabStyle.StandardProfile;
            this.kryptonNavigator.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.Context;
            this.kryptonNavigator.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.RemovePageAndDispose;
            this.kryptonNavigator.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator.Button.ContextButtonAction = Krypton.Navigator.ContextButtonAction.SelectPage;
            this.kryptonNavigator.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator.Button.ContextMenuMapImage = Krypton.Navigator.MapKryptonPageImage.Small;
            this.kryptonNavigator.Button.ContextMenuMapText = Krypton.Navigator.MapKryptonPageText.TextTitle;
            this.kryptonNavigator.Button.NextButtonAction = Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
            this.kryptonNavigator.Button.NextButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator.Button.PreviousButtonAction = Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
            this.kryptonNavigator.Button.PreviousButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
            this.kryptonNavigator.Location = new System.Drawing.Point(136, 12);
            this.kryptonNavigator.Name = "kryptonNavigator";
            this.kryptonNavigator.NavigatorMode = Krypton.Navigator.NavigatorMode.BarTabGroup;
            this.kryptonNavigator.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage3,
            this.kryptonPage4});
            this.kryptonNavigator.SelectedIndex = 0;
            this.kryptonNavigator.Size = new System.Drawing.Size(740, 642);
            this.kryptonNavigator.TabIndex = 18;
            this.kryptonNavigator.Text = "kryptonNavigator";
            this.kryptonNavigator.SelectedPageChanged += new System.EventHandler(this.kryptonNavigator_SelectedPageChanged);
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.labelWellgroups);
            this.kryptonPage3.Controls.Add(this.labelAnnotations);
            this.kryptonPage3.Controls.Add(this.kryptonButton8);
            this.kryptonPage3.Controls.Add(this.kryptonButton7);
            this.kryptonPage3.Controls.Add(this.kryptonButton6);
            this.kryptonPage3.Controls.Add(this.kryptonButton5);
            this.kryptonPage3.Controls.Add(this.kryptonButton4);
            this.kryptonPage3.Controls.Add(this.kryptonButton3);
            this.kryptonPage3.Controls.Add(this.kryptonButton2);
            this.kryptonPage3.Controls.Add(this.kryptonButton1);
            this.kryptonPage3.Controls.Add(this.kryptonLabel2);
            this.kryptonPage3.Controls.Add(this.kryptonLabel1);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(738, 616);
            this.kryptonPage3.Text = "Main";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "946e6ac3a55643f3a8c7e5bb40ce3ccb";
            // 
            // labelWellgroups
            // 
            this.labelWellgroups.LabelStyle = Krypton.Toolkit.LabelStyle.ItalicControl;
            this.labelWellgroups.Location = new System.Drawing.Point(313, 342);
            this.labelWellgroups.Name = "labelWellgroups";
            this.labelWellgroups.Palette = this.kryptonPalette1;
            this.labelWellgroups.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.labelWellgroups.Size = new System.Drawing.Size(67, 19);
            this.labelWellgroups.TabIndex = 27;
            this.labelWellgroups.Values.Text = "Path : none";
            // 
            // labelAnnotations
            // 
            this.labelAnnotations.LabelStyle = Krypton.Toolkit.LabelStyle.ItalicControl;
            this.labelAnnotations.Location = new System.Drawing.Point(313, 286);
            this.labelAnnotations.Name = "labelAnnotations";
            this.labelAnnotations.Palette = this.kryptonPalette1;
            this.labelAnnotations.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.labelAnnotations.Size = new System.Drawing.Size(67, 19);
            this.labelAnnotations.TabIndex = 26;
            this.labelAnnotations.Values.Text = "Path : none";
            // 
            // kryptonButton8
            // 
            this.kryptonButton8.Location = new System.Drawing.Point(175, 342);
            this.kryptonButton8.Name = "kryptonButton8";
            this.kryptonButton8.Palette = this.kryptonPalette1;
            this.kryptonButton8.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton8.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton8.TabIndex = 25;
            this.kryptonButton8.Values.Text = "Well groups";
            // 
            // kryptonButton7
            // 
            this.kryptonButton7.Location = new System.Drawing.Point(175, 286);
            this.kryptonButton7.Name = "kryptonButton7";
            this.kryptonButton7.Palette = this.kryptonPalette1;
            this.kryptonButton7.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton7.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton7.TabIndex = 24;
            this.kryptonButton7.Values.Text = "Annotations";
            // 
            // kryptonButton6
            // 
            this.kryptonButton6.Location = new System.Drawing.Point(175, 203);
            this.kryptonButton6.Name = "kryptonButton6";
            this.kryptonButton6.Palette = this.kryptonPalette1;
            this.kryptonButton6.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton6.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton6.TabIndex = 23;
            this.kryptonButton6.Values.Text = "Export Excel";
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.Location = new System.Drawing.Point(296, 114);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.Palette = this.kryptonPalette1;
            this.kryptonButton5.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton5.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton5.TabIndex = 22;
            this.kryptonButton5.Values.Text = "Water Plot";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Location = new System.Drawing.Point(175, 114);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Palette = this.kryptonPalette1;
            this.kryptonButton4.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton4.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton4.TabIndex = 21;
            this.kryptonButton4.Values.Text = "Cross plots";
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(417, 51);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Palette = this.kryptonPalette1;
            this.kryptonButton3.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton3.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton3.TabIndex = 20;
            this.kryptonButton3.Values.Text = "3D View";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(296, 51);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Palette = this.kryptonPalette1;
            this.kryptonButton2.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton2.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton2.TabIndex = 19;
            this.kryptonButton2.Values.Text = "2D View";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(175, 51);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Palette = this.kryptonPalette1;
            this.kryptonButton1.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton1.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton1.TabIndex = 18;
            this.kryptonButton1.Values.Text = "Charts";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(34, 114);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Palette = this.kryptonPalette1;
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel2.Size = new System.Drawing.Size(96, 19);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "History Matching";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(34, 51);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Palette = this.kryptonPalette1;
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel1.Size = new System.Drawing.Size(106, 19);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Common functions";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(738, 425);
            this.kryptonPage4.Text = "Chart";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "f4d06dfaa7804b8ca483bbbede96e2b1";
            // 
            // listNames
            // 
            this.listNames.Location = new System.Drawing.Point(14, 58);
            this.listNames.Name = "listNames";
            this.listNames.Palette = this.kryptonPalette1;
            this.listNames.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.listNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listNames.Size = new System.Drawing.Size(104, 381);
            this.listNames.TabIndex = 19;
            // 
            // buttonWellFilter
            // 
            this.buttonWellFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonWellFilter.Location = new System.Drawing.Point(12, 569);
            this.buttonWellFilter.Name = "buttonWellFilter";
            this.buttonWellFilter.Palette = this.kryptonPalette1;
            this.buttonWellFilter.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.buttonWellFilter.Size = new System.Drawing.Size(104, 29);
            this.buttonWellFilter.TabIndex = 28;
            this.buttonWellFilter.Values.Text = "Well filter";
            // 
            // kryptonButton10
            // 
            this.kryptonButton10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonButton10.Location = new System.Drawing.Point(14, 615);
            this.kryptonButton10.Name = "kryptonButton10";
            this.kryptonButton10.Palette = this.kryptonPalette1;
            this.kryptonButton10.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonButton10.Size = new System.Drawing.Size(104, 29);
            this.kryptonButton10.TabIndex = 29;
            this.kryptonButton10.Values.Text = "Update";
            // 
            // boxNameType
            // 
            this.boxNameType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.boxNameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxNameType.DropDownWidth = 104;
            this.boxNameType.Items.AddRange(new object[] {
            "Field",
            "Group",
            "Well",
            "Completions",
            "Aquifer",
            "Region",
            "Other"});
            this.boxNameType.Location = new System.Drawing.Point(14, 520);
            this.boxNameType.Name = "boxNameType";
            this.boxNameType.Palette = this.kryptonPalette1;
            this.boxNameType.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.boxNameType.Size = new System.Drawing.Size(104, 20);
            this.boxNameType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.boxNameType.TabIndex = 30;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 495);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Palette = this.kryptonPalette1;
            this.kryptonLabel3.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.kryptonLabel3.Size = new System.Drawing.Size(34, 19);
            this.kryptonLabel3.TabIndex = 31;
            this.kryptonLabel3.Values.Text = "Type";
            // 
            // checkSorted
            // 
            this.checkSorted.Checked = true;
            this.checkSorted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSorted.Location = new System.Drawing.Point(14, 445);
            this.checkSorted.Name = "checkSorted";
            this.checkSorted.Palette = this.kryptonPalette1;
            this.checkSorted.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.checkSorted.Size = new System.Drawing.Size(92, 19);
            this.checkSorted.TabIndex = 32;
            this.checkSorted.Values.Text = "Sorted names";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 695);
            this.Controls.Add(this.checkSorted);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.boxNameType);
            this.Controls.Add(this.buttonWellFilter);
            this.Controls.Add(this.kryptonButton10);
            this.Controls.Add(this.listNames);
            this.Controls.Add(this.kryptonNavigator);
            this.Controls.Add(this.buttonProjects);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mView";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator)).EndInit();
            this.kryptonNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.kryptonPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxNameType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Krypton.Toolkit.KryptonButton buttonProjects;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private Krypton.Navigator.KryptonPage kryptonPage4;
        private Krypton.Toolkit.KryptonLabel labelWellgroups;
        private Krypton.Toolkit.KryptonLabel labelAnnotations;
        private Krypton.Toolkit.KryptonButton kryptonButton8;
        private Krypton.Toolkit.KryptonButton kryptonButton7;
        private Krypton.Toolkit.KryptonButton kryptonButton6;
        private Krypton.Toolkit.KryptonButton kryptonButton5;
        private Krypton.Toolkit.KryptonButton kryptonButton4;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonListBox listNames;
        private Krypton.Toolkit.KryptonButton buttonWellFilter;
        private Krypton.Toolkit.KryptonButton kryptonButton10;
        private Krypton.Toolkit.KryptonComboBox boxNameType;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonCheckBox checkSorted;
    }
}

