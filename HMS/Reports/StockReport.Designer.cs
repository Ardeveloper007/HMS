
namespace HMS.Reports
{
    partial class StockReport
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
            Janus.Windows.GridEX.GridEXLayout grdStockReport_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdStockReport = new Janus.Windows.GridEX.GridEX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnnew = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ctrlGrdBar1 = new grid.User_Conrtols.CtrlGrdBar();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockReport)).BeginInit();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 554);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdStockReport);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1067, 520);
            this.panel3.TabIndex = 1;
            // 
            // grdStockReport
            // 
            this.grdStockReport.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdStockReport.BackColor = System.Drawing.Color.White;
            grdStockReport_DesignTimeLayout.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition /></RootTable></GridEXLayoutData>";
            this.grdStockReport.DesignTimeLayout = grdStockReport_DesignTimeLayout;
            this.grdStockReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockReport.DynamicFiltering = true;
            this.grdStockReport.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdStockReport.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdStockReport.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdStockReport.GroupByBoxVisible = false;
            this.grdStockReport.Location = new System.Drawing.Point(0, 0);
            this.grdStockReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdStockReport.Name = "grdStockReport";
            this.grdStockReport.RecordNavigator = true;
            this.grdStockReport.Size = new System.Drawing.Size(1067, 520);
            this.grdStockReport.TabIndex = 50;
            this.grdStockReport.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdStockReport.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdStockReport.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctrlGrdBar1);
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 34);
            this.panel2.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(1027, 0);
            this.btnclose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(40, 34);
            this.btnclose.TabIndex = 8;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnnew,
            this.btnPrint,
            this.toolStripSeparator});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1067, 34);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(169, 31);
            this.toolStripButton1.Text = "Stock Report     ";
            // 
            // btnnew
            // 
            this.btnnew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.Image = ((System.Drawing.Image)(resources.GetObject("btnnew.Image")));
            this.btnnew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(63, 31);
            this.btnnew.Text = "&New";
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(29, 31);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 34);
            // 
            // ctrlGrdBar1
            // 
            this.ctrlGrdBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctrlGrdBar1.FormName = this;
            this.ctrlGrdBar1.Location = new System.Drawing.Point(969, 0);
            this.ctrlGrdBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlGrdBar1.MyGrid = this.grdStockReport;
            this.ctrlGrdBar1.Name = "ctrlGrdBar1";
            this.ctrlGrdBar1.Size = new System.Drawing.Size(58, 34);
            this.ctrlGrdBar1.TabIndex = 10;
            // 
            // StockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StockReport";
            this.Text = "StockReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStockReport)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnnew;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.Panel panel3;
        internal Janus.Windows.GridEX.GridEX grdStockReport;
        private System.Windows.Forms.Button btnclose;
        private grid.User_Conrtols.CtrlGrdBar ctrlGrdBar1;
    }
}