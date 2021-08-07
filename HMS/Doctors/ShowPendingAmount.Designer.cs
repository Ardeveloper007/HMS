
namespace HMS.Doctors
{
    partial class ShowPendingAmount
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
            Janus.Windows.GridEX.GridEXLayout grdCustomerPending_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.grdCustomerPending = new Janus.Windows.GridEX.GridEX();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSavevoucher = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlGrdBar1 = new grid.User_Conrtols.CtrlGrdBar();
            this.Doctors = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerPending)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 496);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1048, 464);
            this.panel4.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.grdCustomerPending);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1048, 397);
            this.panel6.TabIndex = 12;
            // 
            // grdCustomerPending
            // 
            this.grdCustomerPending.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            grdCustomerPending_DesignTimeLayout.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition /></RootTable></GridEXLayoutData>";
            this.grdCustomerPending.DesignTimeLayout = grdCustomerPending_DesignTimeLayout;
            this.grdCustomerPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomerPending.DynamicFiltering = true;
            this.grdCustomerPending.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCustomerPending.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCustomerPending.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdCustomerPending.GroupByBoxVisible = false;
            this.grdCustomerPending.Location = new System.Drawing.Point(0, 0);
            this.grdCustomerPending.Name = "grdCustomerPending";
            this.grdCustomerPending.RecordNavigator = true;
            this.grdCustomerPending.Size = new System.Drawing.Size(1048, 397);
            this.grdCustomerPending.TabIndex = 13;
            this.grdCustomerPending.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdCustomerPending.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdCustomerPending.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSavevoucher);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.todate);
            this.panel5.Controls.Add(this.fromdate);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1048, 67);
            this.panel5.TabIndex = 11;
            // 
            // btnSavevoucher
            // 
            this.btnSavevoucher.BackColor = System.Drawing.Color.Red;
            this.btnSavevoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavevoucher.ForeColor = System.Drawing.Color.White;
            this.btnSavevoucher.Location = new System.Drawing.Point(413, 36);
            this.btnSavevoucher.Name = "btnSavevoucher";
            this.btnSavevoucher.Size = new System.Drawing.Size(66, 21);
            this.btnSavevoucher.TabIndex = 5;
            this.btnSavevoucher.Text = "Save";
            this.btnSavevoucher.UseVisualStyleBackColor = false;
            this.btnSavevoucher.Click += new System.EventHandler(this.btnSavevoucher_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date From";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Red;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(341, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // todate
            // 
            this.todate.CustomFormat = "yyyy-MM-dd";
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todate.Location = new System.Drawing.Point(177, 36);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(158, 20);
            this.todate.TabIndex = 1;
            // 
            // fromdate
            // 
            this.fromdate.CustomFormat = "yyyy-MM-dd";
            this.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromdate.Location = new System.Drawing.Point(13, 36);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(158, 20);
            this.fromdate.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1048, 32);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Controls.Add(this.ctrlGrdBar1);
            this.panel3.Controls.Add(this.Doctors);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1048, 31);
            this.panel3.TabIndex = 0;
            // 
            // ctrlGrdBar1
            // 
            this.ctrlGrdBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctrlGrdBar1.FormName = null;
            this.ctrlGrdBar1.Location = new System.Drawing.Point(1010, 0);
            this.ctrlGrdBar1.MyGrid = null;
            this.ctrlGrdBar1.Name = "ctrlGrdBar1";
            this.ctrlGrdBar1.Size = new System.Drawing.Size(38, 31);
            this.ctrlGrdBar1.TabIndex = 11;
            // 
            // Doctors
            // 
            this.Doctors.AutoSize = true;
            this.Doctors.BackColor = System.Drawing.Color.Red;
            this.Doctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doctors.ForeColor = System.Drawing.Color.White;
            this.Doctors.Location = new System.Drawing.Point(10, 4);
            this.Doctors.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(193, 20);
            this.Doctors.TabIndex = 3;
            this.Doctors.Text = "Pending Amount Detail";
            // 
            // ShowPendingAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 496);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShowPendingAmount";
            this.Text = "ShowPendingAmount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowPendingAmount_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerPending)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private grid.User_Conrtols.CtrlGrdBar ctrlGrdBar1;
        private System.Windows.Forms.Label Doctors;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        internal Janus.Windows.GridEX.GridEX grdCustomerPending;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.Button btnSavevoucher;
    }
}