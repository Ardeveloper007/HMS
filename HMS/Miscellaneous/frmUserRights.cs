using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Miscellaneous
{
    public partial class frmUserRights : Form
    {
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        int RecId = 0;
        AspNetUser employee = null;
        DropDownBinding DDL = new DropDownBinding();
        UserAccount user = new UserAccount();
        public frmUserRights(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        private void frmUserRights_Load(object sender, EventArgs e)
        {
            RoleFill();
            Userbind();
        }
        #region Tab Control Index 0 Function

      
        public void RoleFill()
        {
            try
            {
                var roles = db.AspNetRoles.ToList();
                DataTable dtrole = new DataTable();
                if (roles.Count > 0)
                {
                    dtrole.Columns.Add("Id");
                    dtrole.Columns.Add("Role");

                    foreach (var item in roles)
                    {
                        dtrole.Rows.Add(item.Id, item.Name);
                    }
                    if (dtrole.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtrole, ddluserrole, "Id", "Role", "Role", false);
                    }
                    else
                    {
                        ddluserrole.Text = string.Empty;
                        ddluserrole.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void formRefresh()
        {
            try
            {
                employee = null;
                RecId = 0;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Text = string.Empty;
                ddluserrole.Text = string.Empty;
                txtFirstName.Focus();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                grduser.ClearStructure();
                Userbind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool FormValidation()
        {
            if (txtFirstName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("First Name Field Required");
                txtFirstName.Focus();
                return false;
            }
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("UserName Field Required");
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password Field Required");
                txtPassword.Focus();
                return false;
            }
            
            if (int.Parse(ddluserrole.ActiveRow.Cells[0].Value.ToString()) == 0)
            {
                MessageBox.Show("User Role Field Required");
                ddluserrole.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            formRefresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!FormValidation())
                {
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                if (RecId == 0)
                {
                    employee = new AspNetUser();
                }
                employee.FirstName = txtFirstName.Text.Trim();
                employee.LastName = txtLastName.Text.Trim();
                employee.Password = txtPassword.Text.Trim();
                employee.UserName = txtUsername.Text.Trim();
                employee.Role_Id = Numerics.GetInt(ddluserrole.Value);
                employee.BranchId = user.BranchId;
                employee.CompanyId = user.CompanyId;
                employee.Address = "";
                employee.PhoneNumber = "";
                if (chkboxIsActive.Checked)
                {
                    employee.IsActive = true;
                }
                else
                {
                    employee.IsActive = false;
                }
                if(RecId>0)
                {
                    db.Entry(employee).State = EntityState.Modified;
                }
                else
                {
                    db.AspNetUsers.Add(employee);
                }
                db.SaveChanges();
                MessageBox.Show("Operation  Successfully Complete...");
                formRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }
        public void Userbind()
        {
            try
            {
                var alluesr = (from u in db.AspNetUsers
                               join r in db.AspNetRoles on u.Role_Id equals r.Id
                               select new
                               {
                                   u.Id,
                                   u.FirstName,
                                   u.LastName,
                                   u.UserName,
                                   u.Password,
                                   u.IsActive,
                                   u.Role_Id,
                                   r.Name
                               }).ToList();
                DataTable dtuser = new DataTable();
                dtuser.Columns.Add("Id");
                dtuser.Columns.Add("First Name");
                dtuser.Columns.Add("Last Name");
                dtuser.Columns.Add("Username");
                dtuser.Columns.Add("Password");
                dtuser.Columns.Add("Role");
                dtuser.Columns.Add("IsActive");
                if (alluesr != null)
                {
                    foreach (var item in alluesr)
                    {
                        dtuser.Rows.Add(item.Id,item.FirstName,item.LastName,item.UserName,item.Password,item.Name,item.IsActive);
                    }
                    if(dtuser.Rows.Count>0)
                    {
                        grduser.DataSource = dtuser;
                        grduser.RetrieveStructure();
                        grduserhistory.DataSource = dtuser;
                        grduserhistory.RetrieveStructure();
                        GridSetting();
                        GridHistorySetting();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GridSetting()
        {
            try
            {
                grduser.RootTable.Columns["First Name"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduser.RootTable.Columns["Last Name"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduser.RootTable.Columns["Username"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduser.RootTable.Columns["Password"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduser.RootTable.Columns["Role"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduser.RootTable.Columns["IsActive"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduser.RootTable.Columns["Id"].Visible = false;

                grduser.RootTable.Columns["First Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduser.RootTable.Columns["Last Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduser.RootTable.Columns["Username"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduser.RootTable.Columns["Password"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduser.RootTable.Columns["Role"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduser.RootTable.Columns["IsActive"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grduser.RootTable.Columns["First Name"].Width = 200;
                grduser.RootTable.Columns["Last Name"].Width = 150;
                grduser.RootTable.Columns["Username"].Width = 200;
                grduser.RootTable.Columns["Password"].Width = 150;
                grduser.RootTable.Columns["Role"].Width = 200;

                grduser.RootTable.Columns["IsActive"].ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox;
                grduser.RootTable.Columns["IsActive"].CheckBoxTrueValue = "True";
                grduser.RootTable.Columns["IsActive"].CheckBoxFalseValue = "False";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GridHistorySetting()
        {
            try
            {
                grduserhistory.RootTable.Columns["First Name"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserhistory.RootTable.Columns["Last Name"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserhistory.RootTable.Columns["Username"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserhistory.RootTable.Columns["Password"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserhistory.RootTable.Columns["Role"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserhistory.RootTable.Columns["IsActive"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserhistory.RootTable.Columns["Id"].Visible = false;

                grduserhistory.RootTable.Columns["First Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserhistory.RootTable.Columns["Last Name"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserhistory.RootTable.Columns["Username"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserhistory.RootTable.Columns["Password"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserhistory.RootTable.Columns["Role"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserhistory.RootTable.Columns["IsActive"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grduserhistory.RootTable.Columns["First Name"].Width = 200;
                grduserhistory.RootTable.Columns["Last Name"].Width = 150;
                grduserhistory.RootTable.Columns["Username"].Width = 200;
                grduserhistory.RootTable.Columns["Password"].Width = 150;
                grduserhistory.RootTable.Columns["Role"].Width = 200;

                grduserhistory.RootTable.Columns["IsActive"].ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox;
                grduserhistory.RootTable.Columns["IsActive"].CheckBoxTrueValue = "True";
                grduserhistory.RootTable.Columns["IsActive"].CheckBoxFalseValue = "False";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grduser_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                employee  = new AspNetUser();
                RecId = Numerics.GetInt(grduser.CurrentRow.Cells[0].Value);
                employee = db.AspNetUsers.Where(x => x.Id == RecId).FirstOrDefault();
                if (employee != null)
                {
                    txtFirstName.Text = employee.FirstName;
                    txtLastName.Text = employee.LastName;
                    txtPassword.Text = employee.Password;
                    txtUsername.Text = employee.UserName;
                    ddluserrole.Value = employee.Role_Id;
                    if(employee.IsActive==true)
                    {
                        chkboxIsActive.Checked = true;
                    }
                    else
                    {
                        chkboxIsActive.Checked = false;
                    }

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    txtUsername.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmUserRights_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (tabControl1.TabIndex == 0)
                {
                    if (e.KeyData == System.Windows.Forms.Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    if (e.Control && e.KeyCode == Keys.N)
                    {
                        btnNew_Click(null, null);
                    }
                    if (e.Control && e.KeyCode == Keys.E)
                    {
                        this.Close();
                    }
                    if (btnSave.Visible == true)
                    {
                        if (e.Control && e.KeyCode == Keys.S)
                        {
                            btnSave_Click(null, null);
                        }
                    }
                    if (btnUpdate.Visible == true)
                    {
                        if (e.Control && e.KeyCode == Keys.U)
                        {
                            btnUpdate_Click(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                var validateuser = db.AspNetUsers.Where(x => x.UserName == txtUsername.Text.Trim()).ToList();
                if(validateuser!=null )
                {
                    MessageBox.Show("Username Already Exist Please Try Another Username...");
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        #endregion

        private void grduserhistory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                RecId = Numerics.GetInt(grduserhistory.CurrentRow.Cells[0].Value.ToString());
                var lst = db.Proc_tblUserRights_UserId(RecId).ToList();

                    DataTable dt = new DataTable();

                dt.Columns.Add("RightName");
                dt.Columns.Add("ScreenName");
                dt.Columns.Add("ScreenAlias");
                dt.Columns.Add("RightsID");
                dt.Columns.Add("ScreenID");
                dt.Columns.Add("Value");
                grduserRights.DataSource = null;
                dt.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    dt.Rows.Add(
                        lst[i].ScreenRightName,
                        lst[i].ScreenName,
                        lst[i].ScreenAlias,
                        lst[i].RightsID,
                        lst[i].ScreenID,
                        lst[i].Value
                        );
                }
                grduserRights.DataSource = dt;
                tabControl1.SelectedIndex = 2;
                grduserRights.RootTable.Columns["RightName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserRights.RootTable.Columns["ScreenName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserRights.RootTable.Columns["ScreenAlias"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserRights.RootTable.Columns["RightsID"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserRights.RootTable.Columns["ScreenID"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grduserRights.RootTable.Columns["Value"].EditType = Janus.Windows.GridEX.EditType.CheckBox;

                grduserRights.RootTable.Columns["RightName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserRights.RootTable.Columns["ScreenName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserRights.RootTable.Columns["ScreenAlias"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserRights.RootTable.Columns["RightsID"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserRights.RootTable.Columns["ScreenID"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grduserRights.RootTable.Columns["Value"].FilterEditType = Janus.Windows.GridEX.FilterEditType.CheckBox;


                grduserRights.RootTable.Columns["Value"].ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox;
                grduserRights.RootTable.Columns["Value"].CheckBoxTrueValue = "True";
                grduserRights.RootTable.Columns["Value"].CheckBoxFalseValue = "False";
                grduserRights.RootTable.Columns["Value"].UseHeaderSelector = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveRights_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 2)
                {
                    if (RecId != 0)
                    {
                        var delete = db.Proc_UserRights_DeleteByUserID(RecId);
                        foreach (Janus.Windows.GridEX.GridEXRow r in grduserRights.GetDataRows())
                        {
                            bool checkedrow = bool.Parse(r.Cells["Value"].Value.ToString());
                            if (checkedrow == true)
                            {
                                using (var yourContext = new dbHostiptalERPEntities())
                                {
                                    yourContext.Database
                                        .ExecuteSqlCommand("Proc_tblUserRights_Insert @UserId, @ScreenId, @RightId,@Value",
                                 new SqlParameter("@UserId", int.Parse(RecId.ToString())),
                                 new SqlParameter("@ScreenId", int.Parse(r.Cells["ScreenID"].Value.ToString())),
                                 new SqlParameter("@RightId", int.Parse(r.Cells["RightsID"].Value.ToString())),
                                 new SqlParameter("@Value", bool.Parse(r.Cells["Value"].Value.ToString())));
                                }
                            }
                        }
                       
                      
                      
                        MessageBox.Show("User Rights for has been updated Successfully!");
                        RecId = 0;
                        tabControl1.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                if (RecId == 0)
                {
                    MessageBox.Show("Select a User First");
                    tabControl1.SelectedIndex = 1;
                }
            }
            else
            {
                RecId = 0;
            }
        }

        private void grduserRights_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            grduserRights.UpdateData();
        }

        private void grduserRights_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            grduserRights.UpdateData();
        }

        
    }
}

