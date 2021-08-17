
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
            this.kryptonWorkspaceCell1 = new Krypton.Workspace.KryptonWorkspaceCell();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.boxChartsPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGroupMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspace1)).BeginInit();
            this.kryptonWorkspace1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonWorkspaceCell1)).BeginInit();
            this.kryptonWorkspaceCell1.SuspendLayout();
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
            this.buttonSeriesSettings.Location = new System.Drawing.Point(621, 19);
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
            this.kryptonWorkspace1.ActivePage = null;
            this.kryptonWorkspace1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonWorkspace1.Location = new System.Drawing.Point(3, 76);
            this.kryptonWorkspace1.Name = "kryptonWorkspace1";
            this.kryptonWorkspace1.PaletteMode = Krypton.Toolkit.PaletteMode.Office2010Silver;
            // 
            // 
            // 
            this.kryptonWorkspace1.Root.Children.AddRange(new System.ComponentModel.Component[] {
            this.kryptonWorkspaceCell1});
            this.kryptonWorkspace1.Root.StarSize = "25*,25*";
            this.kryptonWorkspace1.Root.UniqueName = "bd5e18ce3b694df0bf781df132937ea8";
            this.kryptonWorkspace1.Root.WorkspaceControl = this.kryptonWorkspace1;
            this.kryptonWorkspace1.Size = new System.Drawing.Size(791, 559);
            this.kryptonWorkspace1.TabIndex = 9;
            this.kryptonWorkspace1.TabStop = true;
            // 
            // kryptonWorkspaceCell1
            // 
            this.kryptonWorkspaceCell1.AllowPageDrag = true;
            this.kryptonWorkspaceCell1.AllowTabFocus = false;
            this.kryptonWorkspaceCell1.Bar.BarMapText = Krypton.Navigator.MapKryptonPageText.None;
            this.kryptonWorkspaceCell1.Bar.TabBorderStyle = Krypton.Toolkit.TabBorderStyle.OneNote;
            this.kryptonWorkspaceCell1.Bar.TabStyle = Krypton.Toolkit.TabStyle.LowProfile;
            this.kryptonWorkspaceCell1.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonWorkspaceCell1.Name = "kryptonWorkspaceCell1";
            this.kryptonWorkspaceCell1.UniqueName = "8f5f9e8403e04dbd811b77ad0ee27ebb";
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
        private Krypton.Workspace.KryptonWorkspaceCell kryptonWorkspaceCell1;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
    }
}
