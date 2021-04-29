
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageControl = new System.Windows.Forms.TabPage();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonNewCharts = new System.Windows.Forms.Button();
            this.checkSorted = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listNames = new System.Windows.Forms.ListBox();
            this.boxNameType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonWellFilter = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.tabPageControl.SuspendLayout();
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
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPageControl);
            this.tabControl2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tabControl2.ItemSize = new System.Drawing.Size(82, 18);
            this.tabControl2.Location = new System.Drawing.Point(132, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(744, 658);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 5;
            // 
            // tabPageControl
            // 
            this.tabPageControl.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageControl.Controls.Add(this.buttonExportExcel);
            this.tabPageControl.Controls.Add(this.label1);
            this.tabPageControl.Controls.Add(this.button3);
            this.tabPageControl.Controls.Add(this.buttonNewCharts);
            this.tabPageControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageControl.Name = "tabPageControl";
            this.tabPageControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControl.Size = new System.Drawing.Size(736, 632);
            this.tabPageControl.TabIndex = 1;
            this.tabPageControl.Text = "Main";
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.buttonExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonExportExcel.Location = new System.Drawing.Point(168, 157);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(104, 29);
            this.buttonExportExcel.TabIndex = 16;
            this.buttonExportExcel.Text = "Export 2 Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = true;
            this.buttonExportExcel.Click += new System.EventHandler(this.ButtonExportExcelOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "History Matching";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(168, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 29);
            this.button3.TabIndex = 14;
            this.button3.Text = "Cross-plots";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonNewCharts
            // 
            this.buttonNewCharts.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.buttonNewCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewCharts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonNewCharts.Location = new System.Drawing.Point(168, 35);
            this.buttonNewCharts.Name = "buttonNewCharts";
            this.buttonNewCharts.Size = new System.Drawing.Size(104, 29);
            this.buttonNewCharts.TabIndex = 13;
            this.buttonNewCharts.Text = "Charts";
            this.buttonNewCharts.UseVisualStyleBackColor = true;
            this.buttonNewCharts.Click += new System.EventHandler(this.ButtonNewChartsOnClick);
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
            this.boxNameType.Location = new System.Drawing.Point(14, 505);
            this.boxNameType.Name = "boxNameType";
            this.boxNameType.Size = new System.Drawing.Size(104, 21);
            this.boxNameType.TabIndex = 6;
            this.boxNameType.SelectedIndexChanged += new System.EventHandler(this.BoxNameTypeOnSelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Projects";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(888, 695);
            this.Controls.Add(this.buttonWellFilter);
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
            this.tabControl2.ResumeLayout(false);
            this.tabPageControl.ResumeLayout(false);
            this.tabPageControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageControl;
        private System.Windows.Forms.CheckBox checkSorted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listNames;
        private System.Windows.Forms.ComboBox boxNameType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonNewCharts;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonWellFilter;
        private System.Windows.Forms.Button buttonExportExcel;
    }
}

