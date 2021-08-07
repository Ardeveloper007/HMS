//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
using HMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class BackUpDatabase : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L47PLK0\SQLEXPRESS;Initial Catalog=dbHostiptalERP;Integrated Security=true;");

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbHostiptalERPEntities1"].ConnectionString.ToString());
        //dbHostiptalERPEntities1 con = new dbHostiptalERPEntities1();
        public BackUpDatabase()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            lblPercent.Visible = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(Application.ExecutablePath + @"\..\BackUp") == false)
            {
                System.IO.Directory.CreateDirectory(Application.ExecutablePath + @"\..\BackUp");
            }
            string Folderpath = Application.ExecutablePath + @"\..\BackUp";
            Cursor.Current = Cursors.Default;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(con.ConnectionString);
                builder.InitialCatalog = "master";
                builder.Password.ToString();
                SqlConnection con1 = new  SqlConnection(builder.ConnectionString.ToString());
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                progressBar1.Value = 0;

                lblPercent.Visible = true;
                //string path = string.Empty;
                //path = @"E:\";
                string dbbackup = con.Database.ToString();
                
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                }
                con.Open();
                string dbmappath = Folderpath +"\\"+ dbbackup + '-' + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                SqlCommand command = new SqlCommand(@"BACKUP DATABASE [" + dbbackup + "] TO DISK='" + dbmappath + " .bak '", con1);
                command.CommandTimeout = 600;
                command.ExecuteNonQuery();
                con.Close();
                backgroundWorker1.RunWorkerAsync();
                progressBar1.Show();
                btnBackup.Visible = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               
                for (int i = 1; i <= 100; i++)
                {
                    // lblPercent.Visible = true;
                    Thread.Sleep(50);
                    backgroundWorker1.WorkerReportsProgress = true;
                   
                    backgroundWorker1.ReportProgress(i);

                }
                if (lblPercent.Text == "100%")
                {
                   
                    MessageBox.Show("Backup successfully", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
           
            lblPercent.Text = e.ProgressPercentage.ToString() + "%";
        }
        private void BackUpDatabase_Load(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
