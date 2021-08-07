using HMS.Data;
using HMS.Utills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace HMS
{
    public partial class Login : Form
    {
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        UserAccount user = new UserAccount();
        public Login()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusername.Text != string.Empty && txtpassword.Text != string.Empty)
                {
                    var getuser = db.Proc_UserLogin(txtusername.Text.ToLower().Trim() ,txtpassword.Text.Trim()).ToList();

                    if (getuser.Count > 0)
                    {
                        tblActivityLog tblActivityLogs = new tblActivityLog();
                        tblActivityLogs.Date = System.DateTime.Now;
                        tblActivityLogs.Datetime = System.DateTime.Now;
                        tblActivityLogs.User_Id = getuser[0].Id;
                        tblActivityLogs.Activity = "Login";
                        tblActivityLogs.Screen_Name = "Login";
                        db.tblActivityLogs.Add(tblActivityLogs);
                        db.SaveChanges();
                        user.Id = Numerics.GetInt(getuser[0].Id);
                        user.FirstName = getuser[0].FirstName;
                        user.LastName = getuser[0].LastName;
                        user.Role_Id = getuser[0].Role_Id.ToString();
                        user.RoleName = getuser[0].Name;
                        user.UserName = getuser[0].UserName;
                        user.Password = getuser[0].Password;
                        user.BranchId = Numerics.GetInt(getuser[0].BranchId);
                        user.CompanyId = Numerics.GetInt(getuser[0].CompanyId);
                        //user.BranchName = getuser[0].tblBranches.Branch_Name;
                        this.Hide();
                        Dashboard Dashboard = new Dashboard(user);
                        Dashboard.Show();
                        Dashboard.BringToFront();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Username and Password");
                    txtusername.Focus();
                    return;
                }
               
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtusername.Text = string.Empty;
                txtpassword.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
           
        }
    }
}
