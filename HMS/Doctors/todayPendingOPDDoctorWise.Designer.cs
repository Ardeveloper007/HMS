
namespace HMS.Doctors
{
    partial class todayPendingOPDDoctorWise
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Doctors = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdCustomerPending = new Janus.Windows.GridEX.GridEX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerPending)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.Doctors);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1142, 35);
            this.panel2.TabIndex = 0;
            // 
            // Doctors
            // 
            this.Doctors.AutoSize = true;
            this.Doctors.BackColor = System.Drawing.Color.Red;
            this.Doctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doctors.ForeColor = System.Drawing.Color.White;
            this.Doctors.Location = new System.Drawing.Point(11, 9);
            this.Doctors.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(119, 20);
            this.Doctors.TabIndex = 4;
            this.Doctors.Text = "Today Patient";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdCustomerPending);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1142, 415);
            this.panel3.TabIndex = 1;
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
            this.grdCustomerPending.Size = new System.Drawing.Size(1142, 415);
            this.grdCustomerPending.TabIndex = 14;
            this.grdCustomerPending.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdCustomerPending.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdCustomerPending.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // todayPendingOPDDoctorWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 450);
            this.Controls.Add(this.panel1);
            this.Name = "todayPendingOPDDoctorWise";
            this.Text = "todayPendingOPDDoctorWise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.todayPendingOPDDoctorWise_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomerPending)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Doctors;
        private System.Windows.Forms.Panel panel3;
        internal Janus.Windows.GridEX.GridEX grdCustomerPending;
    }
}