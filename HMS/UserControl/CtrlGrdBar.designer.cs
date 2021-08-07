namespace grid.User_Conrtols
{
    partial class CtrlGrdBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlGrdBar));
            this.GridEXPrintDocument1 = new Janus.Windows.GridEX.GridEXPrintDocument();
            this.GridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.PrintPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGridControl = new System.Windows.Forms.ToolStripSplitButton();
            this.txtGridTitle = new System.Windows.Forms.ToolStripTextBox();
            this.mGridChooseFielder = new System.Windows.Forms.ToolStripMenuItem();
            this.mGridSaveLayouts = new System.Windows.Forms.ToolStripMenuItem();
            this.mGridPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mGridExport = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupCollaps = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.GridResizeColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridEXPrintDocument1
            // 
            this.GridEXPrintDocument1.FitColumns = Janus.Windows.GridEX.FitColumnsMode.Zooming;
            // 
            // PrintPreviewDialog1
            // 
            this.PrintPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.PrintPreviewDialog1.Document = this.GridEXPrintDocument1;
            this.PrintPreviewDialog1.Enabled = true;
            this.PrintPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintPreviewDialog1.Icon")));
            this.PrintPreviewDialog1.Name = "PrintPreviewDialog1";
            this.PrintPreviewDialog1.Visible = false;
            // 
            // PageSetupDialog1
            // 
            this.PageSetupDialog1.Document = this.GridEXPrintDocument1;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGridControl});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(200, 31);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnGridControl
            // 
            this.btnGridControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGridControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtGridTitle,
            this.mGridChooseFielder,
            this.mGridSaveLayouts,
            this.mGridPrint,
            this.mGridExport,
            this.GroupCollaps,
            this.GroupExpand,
            this.GridResizeColumnToolStripMenuItem});
            this.btnGridControl.Image = ((System.Drawing.Image)(resources.GetObject("btnGridControl.Image")));
            this.btnGridControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGridControl.Name = "btnGridControl";
            this.btnGridControl.Size = new System.Drawing.Size(39, 28);
            this.btnGridControl.Text = "Grid Control";
            // 
            // txtGridTitle
            // 
            this.txtGridTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtGridTitle.Name = "txtGridTitle";
            this.txtGridTitle.ReadOnly = true;
            this.txtGridTitle.Size = new System.Drawing.Size(100, 27);
            // 
            // mGridChooseFielder
            // 
            this.mGridChooseFielder.Image = ((System.Drawing.Image)(resources.GetObject("mGridChooseFielder.Image")));
            this.mGridChooseFielder.Name = "mGridChooseFielder";
            this.mGridChooseFielder.Size = new System.Drawing.Size(225, 26);
            this.mGridChooseFielder.Text = "Field Chooser";
            this.mGridChooseFielder.Click += new System.EventHandler(this.mGridChooseFielder_Click);
            // 
            // mGridSaveLayouts
            // 
            this.mGridSaveLayouts.Image = ((System.Drawing.Image)(resources.GetObject("mGridSaveLayouts.Image")));
            this.mGridSaveLayouts.Name = "mGridSaveLayouts";
            this.mGridSaveLayouts.Size = new System.Drawing.Size(225, 26);
            this.mGridSaveLayouts.Text = "Save Layout";
            this.mGridSaveLayouts.Click += new System.EventHandler(this.mGridSaveLayouts_Click);
            // 
            // mGridPrint
            // 
            this.mGridPrint.Image = ((System.Drawing.Image)(resources.GetObject("mGridPrint.Image")));
            this.mGridPrint.Name = "mGridPrint";
            this.mGridPrint.Size = new System.Drawing.Size(225, 26);
            this.mGridPrint.Text = "Print";
            this.mGridPrint.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // mGridExport
            // 
            this.mGridExport.Image = ((System.Drawing.Image)(resources.GetObject("mGridExport.Image")));
            this.mGridExport.Name = "mGridExport";
            this.mGridExport.Size = new System.Drawing.Size(225, 26);
            this.mGridExport.Text = "Export";
            this.mGridExport.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // GroupCollaps
            // 
            this.GroupCollaps.Image = ((System.Drawing.Image)(resources.GetObject("GroupCollaps.Image")));
            this.GroupCollaps.Name = "GroupCollaps";
            this.GroupCollaps.Size = new System.Drawing.Size(225, 26);
            this.GroupCollaps.Text = "Group Collapse";
            this.GroupCollaps.Click += new System.EventHandler(this.GroupCollaps_Click);
            // 
            // GroupExpand
            // 
            this.GroupExpand.Image = ((System.Drawing.Image)(resources.GetObject("GroupExpand.Image")));
            this.GroupExpand.Name = "GroupExpand";
            this.GroupExpand.Size = new System.Drawing.Size(225, 26);
            this.GroupExpand.Text = "Group Expand";
            this.GroupExpand.Click += new System.EventHandler(this.GroupExpand_Click);
            // 
            // GridResizeColumnToolStripMenuItem
            // 
            this.GridResizeColumnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GridResizeColumnToolStripMenuItem.Image")));
            this.GridResizeColumnToolStripMenuItem.Name = "GridResizeColumnToolStripMenuItem";
            this.GridResizeColumnToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.GridResizeColumnToolStripMenuItem.Text = "Auto Adjust Column";
            this.GridResizeColumnToolStripMenuItem.Click += new System.EventHandler(this.GridResizeColumnToolStripMenuItem_Click);
            // 
            // CtrlGrdBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CtrlGrdBar";
            this.Size = new System.Drawing.Size(200, 185);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Janus.Windows.GridEX.GridEXPrintDocument GridEXPrintDocument1;
        internal Janus.Windows.GridEX.Export.GridEXExporter GridEXExporter1;
        internal System.Windows.Forms.PrintPreviewDialog PrintPreviewDialog1;
        internal System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripSplitButton btnGridControl;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        internal System.Windows.Forms.ToolStripTextBox txtGridTitle;
        internal System.Windows.Forms.ToolStripMenuItem mGridChooseFielder;
        internal System.Windows.Forms.ToolStripMenuItem mGridSaveLayouts;
        internal System.Windows.Forms.ToolStripMenuItem mGridPrint;
        internal System.Windows.Forms.ToolStripMenuItem mGridExport;
        internal System.Windows.Forms.ToolStripMenuItem GroupCollaps;
        internal System.Windows.Forms.ToolStripMenuItem GroupExpand;
        internal System.Windows.Forms.ToolStripMenuItem GridResizeColumnToolStripMenuItem;
    }
}
