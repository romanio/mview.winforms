
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
            this.components = new System.ComponentModel.Container();
            this.buttonOpen = new Krypton.Toolkit.KryptonButton();
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.buttonDelete = new Krypton.Toolkit.KryptonButton();
            this.listBoxProjectNames = new Krypton.Toolkit.KryptonListBox();
            this.listBoxLog = new Krypton.Toolkit.KryptonListBox();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(12, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Palette = this.kryptonPalette1;
            this.buttonOpen.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.buttonOpen.Size = new System.Drawing.Size(104, 29);
            this.buttonOpen.TabIndex = 19;
            this.buttonOpen.Values.Text = "Open";
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonPalette1.CustomisedKryptonPaletteFilePath = null;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 111);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Palette = this.kryptonPalette1;
            this.buttonDelete.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.buttonDelete.Size = new System.Drawing.Size(104, 29);
            this.buttonDelete.TabIndex = 20;
            this.buttonDelete.Values.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxProjectNames
            // 
            this.listBoxProjectNames.Location = new System.Drawing.Point(132, 12);
            this.listBoxProjectNames.Name = "listBoxProjectNames";
            this.listBoxProjectNames.Palette = this.kryptonPalette1;
            this.listBoxProjectNames.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.listBoxProjectNames.Size = new System.Drawing.Size(272, 128);
            this.listBoxProjectNames.TabIndex = 21;
            this.listBoxProjectNames.SelectedIndexChanged += new System.EventHandler(this.listBoxProjectNames_SelectedIndexChanged);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Location = new System.Drawing.Point(12, 164);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Palette = this.kryptonPalette1;
            this.listBoxLog.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
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
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
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
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}