
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonOpenNewModel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabCharts = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSeriesSettings = new System.Windows.Forms.Button();
            this.boxChartsPositions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxGroupMode = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkSorted = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listNames = new System.Windows.Forms.ListBox();
            this.boxNameType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabCharts.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ItemSize = new System.Drawing.Size(82, 18);
            this.tabControl1.Location = new System.Drawing.Point(96, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 107);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.buttonOpenNewModel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(581, 81);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MODEL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonOpenNewModel
            // 
            this.buttonOpenNewModel.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonOpenNewModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenNewModel.Image = global::mview.Properties.Resources.folder_add;
            this.buttonOpenNewModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenNewModel.Location = new System.Drawing.Point(6, 6);
            this.buttonOpenNewModel.Name = "buttonOpenNewModel";
            this.buttonOpenNewModel.Size = new System.Drawing.Size(100, 30);
            this.buttonOpenNewModel.TabIndex = 0;
            this.buttonOpenNewModel.Text = "Open ";
            this.buttonOpenNewModel.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(581, 81);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CHART";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabCharts);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabControl2.ItemSize = new System.Drawing.Size(82, 18);
            this.tabControl2.Location = new System.Drawing.Point(132, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(744, 658);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 5;
            // 
            // tabCharts
            // 
            this.tabCharts.BackColor = System.Drawing.Color.Transparent;
            this.tabCharts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabCharts.Controls.Add(this.tableLayoutPanel1);
            this.tabCharts.Controls.Add(this.panel1);
            this.tabCharts.Location = new System.Drawing.Point(4, 22);
            this.tabCharts.Margin = new System.Windows.Forms.Padding(0);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Size = new System.Drawing.Size(736, 632);
            this.tabCharts.TabIndex = 0;
            this.tabCharts.Text = "Charts";
            this.tabCharts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 98);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 531);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.buttonSeriesSettings);
            this.panel1.Controls.Add(this.boxChartsPositions);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boxGroupMode);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 89);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonSeriesSettings
            // 
            this.buttonSeriesSettings.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSeriesSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeriesSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSeriesSettings.Location = new System.Drawing.Point(8, 10);
            this.buttonSeriesSettings.Name = "buttonSeriesSettings";
            this.buttonSeriesSettings.Size = new System.Drawing.Size(100, 30);
            this.buttonSeriesSettings.TabIndex = 4;
            this.buttonSeriesSettings.Text = "Styles";
            this.buttonSeriesSettings.UseVisualStyleBackColor = true;
            this.buttonSeriesSettings.Click += new System.EventHandler(this.ButtonSeriesSettingsOnClick);
            // 
            // boxChartsPositions
            // 
            this.boxChartsPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxChartsPositions.FormattingEnabled = true;
            this.boxChartsPositions.IntegralHeight = false;
            this.boxChartsPositions.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxChartsPositions.Location = new System.Drawing.Point(169, 15);
            this.boxChartsPositions.Name = "boxChartsPositions";
            this.boxChartsPositions.Size = new System.Drawing.Size(101, 21);
            this.boxChartsPositions.TabIndex = 3;
            this.boxChartsPositions.SelectedIndexChanged += new System.EventHandler(this.BoxChartsPositionsOnSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Position";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grouping mode";
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
            this.boxGroupMode.Location = new System.Drawing.Point(371, 15);
            this.boxGroupMode.Name = "boxGroupMode";
            this.boxGroupMode.Size = new System.Drawing.Size(140, 21);
            this.boxGroupMode.TabIndex = 1;
            this.boxGroupMode.SelectedIndexChanged += new System.EventHandler(this.BoxGroupModeOnSelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.tabControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(736, 632);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "2D Map";
            // 
            // checkSorted
            // 
            this.checkSorted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSorted.AutoSize = true;
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
            this.label4.Location = new System.Drawing.Point(12, 559);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type";
            // 
            // listNames
            // 
            this.listNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listNames.FormattingEnabled = true;
            this.listNames.IntegralHeight = false;
            this.listNames.Location = new System.Drawing.Point(14, 60);
            this.listNames.Name = "listNames";
            this.listNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listNames.Size = new System.Drawing.Size(102, 383);
            this.listNames.TabIndex = 7;
            this.listNames.SelectedIndexChanged += new System.EventHandler(this.ListNamesOnSelectedIndexChanged);
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
            this.boxNameType.Location = new System.Drawing.Point(13, 575);
            this.boxNameType.Name = "boxNameType";
            this.boxNameType.Size = new System.Drawing.Size(104, 21);
            this.boxNameType.TabIndex = 6;
            this.boxNameType.SelectedIndexChanged += new System.EventHandler(this.BoxNameTypeOnSelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Projects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(8, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Groups";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(888, 695);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.checkSorted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listNames);
            this.Controls.Add(this.boxNameType);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mView";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabCharts.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonOpenNewModel;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabCharts;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox checkSorted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listNames;
        private System.Windows.Forms.ComboBox boxNameType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox boxChartsPositions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxGroupMode;
        private System.Windows.Forms.Button buttonSeriesSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
    }
}

