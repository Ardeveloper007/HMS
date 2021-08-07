
namespace HMS.Doctors
{
    partial class DoctorsModal
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
            Janus.Windows.GridEX.GridEXLayout grdCustomer_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdCustomer = new Janus.Windows.GridEX.GridEX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Doctors = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 479);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdCustomer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 441);
            this.panel3.TabIndex = 2;
            // 
            // grdCustomer
            // 
            this.grdCustomer.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            grdCustomer_DesignTimeLayout.LayoutString = "<GridEXLayoutData><RootTable><GroupCondition /></RootTable></GridEXLayoutData>";
            this.grdCustomer.DesignTimeLayout = grdCustomer_DesignTimeLayout;
            this.grdCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomer.DynamicFiltering = true;
            this.grdCustomer.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCustomer.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdCustomer.GroupByBoxVisible = false;
            this.grdCustomer.Location = new System.Drawing.Point(0, 0);
            this.grdCustomer.Name = "grdCustomer";
            this.grdCustomer.RecordNavigator = true;
            this.grdCustomer.Size = new System.Drawing.Size(524, 441);
            this.grdCustomer.TabIndex = 8;
            this.grdCustomer.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdCustomer.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdCustomer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdCustomer.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCustomer_ColumnButtonClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.Doctors);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 38);
            this.panel2.TabIndex = 1;
            // 
            // Doctors
            // 
            this.Doctors.AutoSize = true;
            this.Doctors.BackColor = System.Drawing.Color.Red;
            this.Doctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doctors.ForeColor = System.Drawing.Color.White;
            this.Doctors.Location = new System.Drawing.Point(9, 10);
            this.Doctors.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(72, 20);
            this.Doctors.TabIndex = 2;
            this.Doctors.Text = "Doctors";
            // 
            // DoctorsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 479);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DoctorsModal";
            this.Text = "DoctorsModal";
            this.Load += new System.EventHandler(this.DoctorsModal_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Doctors;
        private System.Windows.Forms.Panel panel3;
        internal Janus.Windows.GridEX.GridEX grdCustomer;
    }
}