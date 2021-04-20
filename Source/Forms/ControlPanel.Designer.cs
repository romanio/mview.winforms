
namespace mview
{
    partial class ControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.listBoxProjectNames = new System.Windows.Forms.ListBox();
            this.buttonSeriesSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxProjectNames
            // 
            this.listBoxProjectNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxProjectNames.FormattingEnabled = true;
            this.listBoxProjectNames.IntegralHeight = false;
            this.listBoxProjectNames.Location = new System.Drawing.Point(12, 12);
            this.listBoxProjectNames.Name = "listBoxProjectNames";
            this.listBoxProjectNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxProjectNames.Size = new System.Drawing.Size(322, 128);
            this.listBoxProjectNames.TabIndex = 0;
            this.listBoxProjectNames.SelectedIndexChanged += new System.EventHandler(this.ListBoxProjectNamesOnSelectedIndexChanged);
            // 
            // buttonSeriesSettings
            // 
            this.buttonSeriesSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSeriesSettings.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSeriesSettings.FlatAppearance.BorderSize = 2;
            this.buttonSeriesSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeriesSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSeriesSettings.Location = new System.Drawing.Point(354, 12);
            this.buttonSeriesSettings.Name = "buttonSeriesSettings";
            this.buttonSeriesSettings.Size = new System.Drawing.Size(100, 30);
            this.buttonSeriesSettings.TabIndex = 5;
            this.buttonSeriesSettings.Text = "Open";
            this.buttonSeriesSettings.UseVisualStyleBackColor = true;
            this.buttonSeriesSettings.Click += new System.EventHandler(this.buttonSeriesSettings_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(354, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Items.AddRange(new object[] {
            ",,,^.^,,,"});
            this.listBoxLog.Location = new System.Drawing.Point(12, 170);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(444, 95);
            this.listBoxLog.TabIndex = 8;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(468, 286);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSeriesSettings);
            this.Controls.Add(this.listBoxProjectNames);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProjectNames;
        private System.Windows.Forms.Button buttonSeriesSettings;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox listBoxLog;
    }
}