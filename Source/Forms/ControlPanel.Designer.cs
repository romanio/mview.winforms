
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
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(104, 29);
            this.buttonOpen.TabIndex = 19;
            this.buttonOpen.Values.Text = "Open";
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 111);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(104, 29);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Values.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxProjectNames
            // 
            this.listBoxProjectNames.Location = new System.Drawing.Point(132, 12);
            this.listBoxProjectNames.Name = "listBoxProjectNames";
            this.listBoxProjectNames.Size = new System.Drawing.Size(272, 128);
            this.listBoxProjectNames.TabIndex = 21;
            this.listBoxProjectNames.SelectedIndexChanged += new System.EventHandler(this.listBoxProjectNames_SelectedIndexChanged);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Location = new System.Drawing.Point(12, 164);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(390, 235);
            this.listBoxLog.TabIndex = 22;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(414, 411);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.listBoxProjectNames);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonOpen);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanelOnFormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private Krypton.Toolkit.KryptonButton buttonOpen;
        private Krypton.Toolkit.KryptonButton buttonDelete;
        private Krypton.Toolkit.KryptonListBox listBoxProjectNames;
        private Krypton.Toolkit.KryptonListBox listBoxLog;


    }
}