
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.lbProgressText = new System.Windows.Forms.Label();
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
            this.listBoxProjectNames.Size = new System.Drawing.Size(377, 128);
            this.listBoxProjectNames.TabIndex = 0;
            this.listBoxProjectNames.SelectedIndexChanged += new System.EventHandler(this.listBoxProjectNames_SelectedIndexChanged);
            // 
            // buttonSeriesSettings
            // 
            this.buttonSeriesSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSeriesSettings.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSeriesSettings.FlatAppearance.BorderSize = 2;
            this.buttonSeriesSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeriesSettings.Image = global::mview.Properties.Resources.folder_add;
            this.buttonSeriesSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSeriesSettings.Location = new System.Drawing.Point(409, 12);
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
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(409, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 165);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(499, 24);
            this.progressBar.TabIndex = 7;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Items.AddRange(new object[] {
            ",,,^.^,,,"});
            this.listBoxLog.Location = new System.Drawing.Point(10, 208);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(499, 147);
            this.listBoxLog.TabIndex = 8;
            // 
            // lbProgressText
            // 
            this.lbProgressText.AutoSize = true;
            this.lbProgressText.BackColor = System.Drawing.Color.Transparent;
            this.lbProgressText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProgressText.Location = new System.Drawing.Point(242, 170);
            this.lbProgressText.Name = "lbProgressText";
            this.lbProgressText.Size = new System.Drawing.Size(0, 13);
            this.lbProgressText.TabIndex = 9;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 370);
            this.Controls.Add(this.lbProgressText);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSeriesSettings);
            this.Controls.Add(this.listBoxProjectNames);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProjectNames;
        private System.Windows.Forms.Button buttonSeriesSettings;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.ListBox listBoxLog;
        public System.Windows.Forms.Label lbProgressText;
    }
}