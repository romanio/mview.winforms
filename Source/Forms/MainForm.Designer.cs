
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
            this.checkSorted = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxNameType = new System.Windows.Forms.ComboBox();
            this.buttonWellFilter = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.buttonProjects = new Krypton.Toolkit.KryptonButton();
            this.kryptonNavigator = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton5 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton6 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton7 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton8 = new Krypton.Toolkit.KryptonButton();
            this.labelAnnotations = new Krypton.Toolkit.KryptonLabel();
            this.labelWellgroups = new Krypton.Toolkit.KryptonLabel();
            this.listNames = new Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator)).BeginInit();
            this.kryptonNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
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
            // checkSorted
            // 
            this.checkSorted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSorted.AutoSize = true;
            this.checkSorted.Checked = true;
            this.checkSorted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSorted.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.checkSorted.FlatAppearance.BorderSize = 2;
            this.checkSorted.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.checkSorted.Location = new System.Drawing.Point(14, 457);
            this.checkSorted.Name = "checkSorted";
            this.checkSorted.Size = new System.Drawing.Size(96, 17);
            this.checkSorted.TabIndex = 9;
            this.checkSorted.Text = "Sorted names";
            this.checkSorted.UseVisualStyleBackColor = true;
            this.checkSorted.CheckedChanged += new System.EventHandler(this.CheckSortedOnCheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type";
            // 
            // boxNameType
            // 
            this.boxNameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boxNameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxNameType.FormattingEnabled = true;
            this.boxNameType.IntegralHeight = false;
            this.boxNameType.Items.AddRange(new object[] {
            "Field",
            "Group",
            "Well",
            "Completions",
            "Aquifer",
            "Region",
            "Other"});
            this.boxNameType.Location = new System.Drawing.Point(14, 505);
            this.boxNameType.Name = "boxNameType";
            this.boxNameType.Size = new System.Drawing.Size(104, 21);
            this.boxNameType.TabIndex = 6;
            this.boxNameType.SelectedIndexChanged += new System.EventHandler(this.BoxNameTypeOnSelectedIndexChanged);
            // 
            // buttonWellFilter
            // 
            this.buttonWellFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonWellFilter.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.buttonWellFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWellFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWellFilter.Location = new System.Drawing.Point(14, 559);
            this.buttonWellFilter.Name = "buttonWellFilter";
            this.buttonWellFilter.Size = new System.Drawing.Size(104, 29);
            this.buttonWellFilter.TabIndex = 14;
            this.buttonWellFilter.Text = "Well Filter";
            this.buttonWellFilter.UseVisualStyleBackColor = true;
            this.buttonWellFilter.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(14, 625);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 29);
            this.button6.TabIndex = 15;
            this.button6.Text = "Update";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.AllowFormChrome = Krypton.Toolkit.InheritBool.False;
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.SparklePurple;
            this.kryptonPalette1.Common.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.kryptonNavigator.Bar.ItemMinimumSize = new System.Drawing.Size(80, 20);
            this.kryptonNavigator.Bar.ItemSizing = Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.kryptonNavigator.Bar.TabBorderStyle = Krypton.Toolkit.TabBorderStyle.DockEqual;
            this.kryptonNavigator.Bar.TabStyle = Krypton.Toolkit.TabStyle.StandardProfile;
            this.kryptonNavigator.Location = new System.Drawing.Point(136, 12);
            this.kryptonNavigator.Name = "kryptonNavigator";
            this.kryptonNavigator.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage3,
            this.kryptonPage4});
            this.kryptonNavigator.Palette = this.kryptonPalette1;
            this.kryptonNavigator.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
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
            this.kryptonPage3.Size = new System.Drawing.Size(738, 618);
            this.kryptonPage3.Text = "Main";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "946e6ac3a55643f3a8c7e5bb40ce3ccb";
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
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(34, 51);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(115, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Common functions";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(34, 114);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "History Matching";
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
            // labelAnnotations
            // 
            this.labelAnnotations.LabelStyle = Krypton.Toolkit.LabelStyle.ItalicControl;
            this.labelAnnotations.Location = new System.Drawing.Point(313, 286);
            this.labelAnnotations.Name = "labelAnnotations";
            this.labelAnnotations.Size = new System.Drawing.Size(71, 20);
            this.labelAnnotations.TabIndex = 26;
            this.labelAnnotations.Values.Text = "Path : none";
            // 
            // labelWellgroups
            // 
            this.labelWellgroups.LabelStyle = Krypton.Toolkit.LabelStyle.ItalicControl;
            this.labelWellgroups.Location = new System.Drawing.Point(313, 342);
            this.labelWellgroups.Name = "labelWellgroups";
            this.labelWellgroups.Size = new System.Drawing.Size(71, 20);
            this.labelWellgroups.TabIndex = 27;
            this.labelWellgroups.Values.Text = "Path : none";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 695);
            this.Controls.Add(this.listNames);
            this.Controls.Add(this.kryptonNavigator);
            this.Controls.Add(this.buttonProjects);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonWellFilter);
            this.Controls.Add(this.checkSorted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxNameType);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MainForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mView";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator)).EndInit();
            this.kryptonNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.kryptonPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox checkSorted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox boxNameType;
        private System.Windows.Forms.Button buttonWellFilter;
        private System.Windows.Forms.Button button6;
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
    }
}

