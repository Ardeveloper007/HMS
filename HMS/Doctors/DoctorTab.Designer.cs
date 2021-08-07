
namespace HMS.Doctors
{
    partial class DoctorTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorTab));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewPending = new System.Windows.Forms.Button();
            this.lblPendingAmount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnViewDoctors = new System.Windows.Forms.Button();
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.OPD = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 366);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.btnViewPending);
            this.panel2.Controls.Add(this.lblPendingAmount);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(312, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 103);
            this.panel2.TabIndex = 4;
            // 
            // btnViewPending
            // 
            this.btnViewPending.Location = new System.Drawing.Point(100, 71);
            this.btnViewPending.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewPending.Name = "btnViewPending";
            this.btnViewPending.Size = new System.Drawing.Size(99, 22);
            this.btnViewPending.TabIndex = 3;
            this.btnViewPending.Text = "View Pending ";
            this.btnViewPending.UseVisualStyleBackColor = true;
            this.btnViewPending.Click += new System.EventHandler(this.btnViewPending_Click);
            // 
            // lblPendingAmount
            // 
            this.lblPendingAmount.AutoSize = true;
            this.lblPendingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingAmount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPendingAmount.Location = new System.Drawing.Point(95, 12);
            this.lblPendingAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPendingAmount.Name = "lblPendingAmount";
            this.lblPendingAmount.Size = new System.Drawing.Size(0, 26);
            this.lblPendingAmount.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(9, 12);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(76, 81);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Controls.Add(this.btnViewDoctors);
            this.panel4.Controls.Add(this.btnAddDoctor);
            this.panel4.Controls.Add(this.OPD);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(18, 23);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 103);
            this.panel4.TabIndex = 3;
            // 
            // btnViewDoctors
            // 
            this.btnViewDoctors.Location = new System.Drawing.Point(164, 72);
            this.btnViewDoctors.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewDoctors.Name = "btnViewDoctors";
            this.btnViewDoctors.Size = new System.Drawing.Size(69, 22);
            this.btnViewDoctors.TabIndex = 3;
            this.btnViewDoctors.Text = "View";
            this.btnViewDoctors.UseVisualStyleBackColor = true;
            this.btnViewDoctors.Click += new System.EventHandler(this.btnViewDoctors_Click);
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.Location = new System.Drawing.Point(94, 72);
            this.btnAddDoctor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(65, 22);
            this.btnAddDoctor.TabIndex = 2;
            this.btnAddDoctor.Text = "Add";
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);
            // 
            // OPD
            // 
            this.OPD.AutoSize = true;
            this.OPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPD.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OPD.Location = new System.Drawing.Point(89, 12);
            this.OPD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OPD.Name = "OPD";
            this.OPD.Size = new System.Drawing.Size(60, 26);
            this.OPD.TabIndex = 1;
            this.OPD.Text = "OPD";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(9, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(76, 81);
            this.panel5.TabIndex = 0;
            // 
            // DoctorTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DoctorTab";
            this.Text = "DoctorTab";
            this.Load += new System.EventHandler(this.DoctorTab_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnViewDoctors;
        private System.Windows.Forms.Button btnAddDoctor;
        private System.Windows.Forms.Label OPD;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewPending;
        private System.Windows.Forms.Label lblPendingAmount;
        private System.Windows.Forms.Panel panel3;
    }
}