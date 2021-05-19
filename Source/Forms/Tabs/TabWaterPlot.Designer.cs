
namespace mview
{
    partial class TabWaterPlot
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkShowAnno = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxCriteriaType = new System.Windows.Forms.ComboBox();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.checkShowAnno);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.boxCriteriaType);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 89);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1OnPaint);
            // 
            // checkShowAnno
            // 
            this.checkShowAnno.AutoSize = true;
            this.checkShowAnno.Location = new System.Drawing.Point(244, 14);
            this.checkShowAnno.Name = "checkShowAnno";
            this.checkShowAnno.Size = new System.Drawing.Size(121, 17);
            this.checkShowAnno.TabIndex = 10;
            this.checkShowAnno.Text = "Show annotations";
            this.checkShowAnno.UseVisualStyleBackColor = true;
            this.checkShowAnno.CheckedChanged += new System.EventHandler(this.checkShowAnno_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type Plot";
            // 
            // boxCriteriaType
            // 
            this.boxCriteriaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCriteriaType.FormattingEnabled = true;
            this.boxCriteriaType.IntegralHeight = false;
            this.boxCriteriaType.Items.AddRange(new object[] {
            "Lysenko"});
            this.boxCriteriaType.Location = new System.Drawing.Point(89, 12);
            this.boxCriteriaType.Name = "boxCriteriaType";
            this.boxCriteriaType.Size = new System.Drawing.Size(122, 21);
            this.boxCriteriaType.TabIndex = 5;
            // 
            // plotView
            // 
            this.plotView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Location = new System.Drawing.Point(3, 95);
            this.plotView.Margin = new System.Windows.Forms.Padding(0);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(791, 543);
            this.plotView.TabIndex = 4;
            this.plotView.Text = "plotView";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // TabWaterPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.plotView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TabWaterPlot";
            this.Size = new System.Drawing.Size(797, 638);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.CheckBox checkShowAnno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxCriteriaType;
    }
}
