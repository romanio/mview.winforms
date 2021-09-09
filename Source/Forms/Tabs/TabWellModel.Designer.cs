﻿
namespace mview
{
    partial class TabWellModel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boxRestartDates = new System.Windows.Forms.ComboBox();
            this.checkShowValue = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxLumping = new System.Windows.Forms.ComboBox();
            this.boxDepthMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxChartMode = new System.Windows.Forms.ComboBox();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Column1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Wellname";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Simulated";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "History";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Difference";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "%";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.boxRestartDates);
            this.panel1.Controls.Add(this.checkShowValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.boxLumping);
            this.panel1.Controls.Add(this.boxDepthMode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.boxChartMode);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 89);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1OnPaint);
            // 
            // boxRestartDates
            // 
            this.boxRestartDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestartDates.FormattingEnabled = true;
            this.boxRestartDates.IntegralHeight = false;
            this.boxRestartDates.Items.AddRange(new object[] {
            "1 Chart",
            "4 Charts"});
            this.boxRestartDates.Location = new System.Drawing.Point(350, 51);
            this.boxRestartDates.Name = "boxRestartDates";
            this.boxRestartDates.Size = new System.Drawing.Size(135, 21);
            this.boxRestartDates.TabIndex = 41;
            // 
            // checkShowValue
            // 
            this.checkShowValue.AutoSize = true;
            this.checkShowValue.Location = new System.Drawing.Point(521, 15);
            this.checkShowValue.Name = "checkShowValue";
            this.checkShowValue.Size = new System.Drawing.Size(85, 17);
            this.checkShowValue.TabIndex = 40;
            this.checkShowValue.Text = "Show value";
            this.checkShowValue.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Depth axes ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lumping by";
            // 
            // boxLumping
            // 
            this.boxLumping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxLumping.FormattingEnabled = true;
            this.boxLumping.IntegralHeight = false;
            this.boxLumping.Items.AddRange(new object[] {
            "None",
            "K-VALUE",
            "EQLNUM",
            "PVTNUM",
            "SATNUM",
            "FIPNUM"});
            this.boxLumping.Location = new System.Drawing.Point(112, 48);
            this.boxLumping.Name = "boxLumping";
            this.boxLumping.Size = new System.Drawing.Size(123, 21);
            this.boxLumping.TabIndex = 5;
            this.boxLumping.SelectedIndexChanged += new System.EventHandler(this.BoxCriteriaTypeOnSelectedIndexChanged);
            // 
            // boxDepthMode
            // 
            this.boxDepthMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDepthMode.FormattingEnabled = true;
            this.boxDepthMode.IntegralHeight = false;
            this.boxDepthMode.Items.AddRange(new object[] {
            "Depth",
            "K-layer"});
            this.boxDepthMode.Location = new System.Drawing.Point(350, 13);
            this.boxDepthMode.Name = "boxDepthMode";
            this.boxDepthMode.Size = new System.Drawing.Size(135, 21);
            this.boxDepthMode.TabIndex = 3;
            this.boxDepthMode.SelectedIndexChanged += new System.EventHandler(this.BoxRestartDatesOnSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart mode";
            // 
            // boxChartMode
            // 
            this.boxChartMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxChartMode.FormattingEnabled = true;
            this.boxChartMode.IntegralHeight = false;
            this.boxChartMode.Items.AddRange(new object[] {
            "Pressure drop",
            "Liquid Production",
            "Oil Production",
            "Water Production",
            "Water Cut",
            "Productivity Index"});
            this.boxChartMode.Location = new System.Drawing.Point(112, 13);
            this.boxChartMode.Name = "boxChartMode";
            this.boxChartMode.Size = new System.Drawing.Size(123, 21);
            this.boxChartMode.TabIndex = 1;
            this.boxChartMode.SelectedIndexChanged += new System.EventHandler(this.BoxKeywordsOnSelectedIndexChanged);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.gridData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.gridData.Location = new System.Drawing.Point(398, 325);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowTemplate.Height = 18;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridData.Size = new System.Drawing.Size(390, 209);
            this.gridData.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridData, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.plotView, 0, 1);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 98);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 537);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // plotView
            // 
            this.plotView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plotView.Location = new System.Drawing.Point(0, 322);
            this.plotView.Margin = new System.Windows.Forms.Padding(0);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(395, 215);
            this.plotView.TabIndex = 4;
            this.plotView.Text = "plotView";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Date";
            // 
            // TabWellModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TabWellModel";
            this.Size = new System.Drawing.Size(797, 638);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox boxDepthMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxChartMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxLumping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkShowValue;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.ComboBox boxRestartDates;
        private System.Windows.Forms.Label label2;
    }
}