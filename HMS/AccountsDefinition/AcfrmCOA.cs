using HMS.Utills;
using HMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectricShopPOS.GeneralClasses;
using System.Data.Entity;

namespace HMS.AccountsDefinition
{
    public partial class AcfrmCOA : Form
    {
        bool DoHaveSaveRight = false;
        bool DoHavePrintRights = false;
        bool DoHaveUpdateRights = false;
        bool DoHaveFieldChooserRights = false;
        bool DoHaveSaveLayoutRights = false;
        bool DoHaveGridPrintRights = false;
        bool DoHaveGridExportRights = false;
        bool DoHaveGridGroupExpandRights = false;
        bool DoHaveGridGroupCollapseRights = false;
        bool DoHaveReportExportRights = false;
        bool DoHaveReportPrintRights = false;
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        DropDownBinding DDL = new DropDownBinding();
        tblSubAccount tblSub = new tblSubAccount();
        tblCOA cOA = new tblCOA();
        int RecId = 0;
    
        UserAccount user = new UserAccount();
        public AcfrmCOA(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        #region Load
        private void AcfrmCOA_Load(object sender, EventArgs e)
        {

            BindParentAccount();
            var lstRights = db.Proc_GetUserRights_UserId(user.Id, this.Name, user.RoleName).ToList();
            if (lstRights != null)
            {
                var newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Save").ToList();
                DoHaveSaveRight = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Print").ToList();
                DoHavePrintRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Update").ToList();
                DoHaveUpdateRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Field Chooser").ToList();
                DoHaveFieldChooserRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Save Layout").ToList();
                DoHaveSaveLayoutRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Grid Print").ToList();
                DoHaveGridPrintRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Grid Export").ToList();
                DoHaveGridExportRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Group Collapse").ToList();
                DoHaveGridGroupCollapseRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Group Expand").ToList();
                DoHaveGridGroupExpandRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Report Export").ToList();
                DoHaveReportExportRights = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Report Print").ToList();
                DoHaveReportPrintRights = Convert.ToBoolean(newList[0].Value);
            }
            Save.Enabled = DoHaveSaveRight;
            //btnPrint.Enabled = DoHavePrintRights;
            btnUpdate.Enabled = DoHaveUpdateRights;
            //ctrlGrdBar1.mGridChooseFielder.Enabled = DoHaveFieldChooserRights;
            //ctrlGrdBar1.mGridSaveLayouts.Enabled = DoHaveSaveLayoutRights;
            //ctrlGrdBar1.mGridPrint.Enabled = DoHaveGridPrintRights;
            //ctrlGrdBar1.mGridExport.Enabled = DoHaveGridExportRights;
            //ctrlGrdBar1.GroupCollaps.Enabled = DoHaveGridGroupCollapseRights;
            //ctrlGrdBar1.GroupExpand.Enabled = DoHaveGridGroupExpandRights;
        }

        #endregion

        #region Validation
        private bool FormValidation()
        {
            if (ddlParenetAccount.Text.Trim() == "")
            {
                MessageBox.Show("ParentAccount Field is Required");
                ddlParenetAccount.Focus();
                return false;
            }
            if (ddlSubAccount.Text.Trim() == "")
            {
                MessageBox.Show("SubAccount Filed is Required");
                ddlSubAccount.Focus();
                return false;
            }
            return true;
        }
        #endregion
     
        #region Combo FIll
        private void BindParentAccount()
        {
            try
            {
                DataTable dtParent = new DataTable();
                dtParent.Columns.Add("Id");
                dtParent.Columns.Add("ParentAccount");
                var PAcc = db.tblParentAccounts.ToList();
                dtParent.Rows.Clear();
                foreach (var item in PAcc)
                {
                    dtParent.Rows.Add(item.Id, item.Parent_Account);
                }
                if (dtParent.Rows.Count > 0)
                {
                    DDL.BindDDL(dtParent, ddlParenetAccount, "Id", "ParentAccount", "Parent Account", true);
                    //ddlParenetAccount.Rows[0].Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindSubAccount()
        {
            try
            {
                DataTable dtSubAccount = new DataTable();
                dtSubAccount.Columns.Add("Id");
                dtSubAccount.Columns.Add("SubAccount");
                int ParentAcc = Numerics.GetInt(ddlParenetAccount.Value);
                var SubAccount = db.tblSubAccounts.Where(x => x.Parent_Account_Id == ParentAcc).OrderByDescending(x => x.Id).ToList();
                dtSubAccount.Rows.Clear();
                foreach (var item in SubAccount)
                {
                    dtSubAccount.Rows.Add(item.Id, item.SubAccount_Name);
                }
                if (dtSubAccount.Rows.Count > 0)
                {
                    DDL.BindDDL(dtSubAccount, ddlSubAccount, "Id", "SubAccount", "Sub-Account", true);
                    //ddlSubAccount.Rows[0].Activate();
                }
                else
                {
                    ddlSubAccount.Text = string.Empty;
                    ddlSubAccount.DataSource = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ddlParenetAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                BindSubAccount();
                ddlSubAccount.Enabled = true;
                GridParentBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Refresh
        public void refreshForm()
        {
            try
            {
                ddlParenetAccount.Text = string.Empty;
                ddlSubAccount.Text = string.Empty;
                ddlSubAccount.DataSource = null;
                txtAccountTitle.Text = string.Empty;
                //GridParentBind();
                grdDetail.ClearStructure();
                grdsubAccount.ClearStructure();
                ddlParenetAccount.Focus();
                ddlSubAccount.Enabled = false;
                txtAccountTitle.Enabled = true;
                Save.Text = "Save";
                RecId = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region CRUD
        private void New_Click(object sender, EventArgs e)
        {
            try
            {
                refreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                FormValidation();
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                if (ddlSubAccount.Text != string.Empty.Trim() && txtAccountTitle.Text.Trim() == string.Empty)
                {
                    int subacc = Numerics.GetInt(ddlSubAccount.Value);
                    var chkExist = db.tblSubAccounts.Where(x => x.Id == subacc).ToList();
                    if(chkExist.Count>0)
                    {
                        MessageBox.Show("Already exist Please Try Again...");
                        return;
                    }
                    if (RecId == 0)
                    {
                        tblSub = new tblSubAccount();
                    }
                    tblSub.SubAccount_Name = ddlSubAccount.Text.Trim();
                    tblSub.Parent_Account_Id = Numerics.GetInt(ddlParenetAccount.Value);
                    tblSub.Company_Id = user.CompanyId;
                    tblSub.Branch_Id = user.BranchId;
                    tblSub.Entry_Date = DateTime.Now;
                    tblSub.Entry_User = user.Id;
                    tblSub.Modify_Date = DateTime.Now;
                    tblSub.Modify_User = user.Id;
                    if (RecId > 0)
                        db.Entry(tblSub).State = EntityState.Modified;
                    else
                    {
                        db.tblSubAccounts.Add(tblSub);
                    }

                    db.SaveChanges();
                    MessageBox.Show("Operation Successfully Complete");
                    refreshForm();
                }
                if (ddlParenetAccount.Text != string.Empty.Trim() && ddlSubAccount.Text != string.Empty.Trim() && txtAccountTitle.Text != string.Empty.Trim())
                {
                    if (txtAccountTitle.Text == string.Empty)
                    {
                        MessageBox.Show("Account Title Field Required");
                        txtAccountTitle.Focus();
                        return;
                    }
                    if (RecId == 0)
                    {
                        cOA = new tblCOA();
                    }
                    cOA.SubAccount_Id = Numerics.GetInt(ddlSubAccount.Value);
                    cOA.Account_Code = GetCode();
                    cOA.Account_Title = txtAccountTitle.Text.Trim();
                    if (chkIsActive.Checked == true)
                    {
                        cOA.IsActive = true;
                    }
                    else
                    {
                        cOA.IsActive = false;
                    }
                    cOA.Company_Id = user.CompanyId;
                    cOA.Branch_Id = user.BranchId;
                    cOA.Entry_Date = DateTime.Now;
                    cOA.Entry_User = user.Id;
                    cOA.Modify_Date = DateTime.Now;
                    cOA.Modify_User = Numerics.GetInt(user.Id);
                    cOA.tblCOAOpeningBalances = new List<tblCOAOpeningBalance>();
                    {
                        tblCOAOpeningBalance openingBalance = new tblCOAOpeningBalance();
                        openingBalance.COA_Id = cOA.Id;
                        openingBalance.Credit = 0;
                        openingBalance.Debit = 0;
                        openingBalance.Company_Id = user.CompanyId;
                        openingBalance.Branch_Id = user.BranchId;
                        openingBalance.Entry_Date = DateTime.Now;
                        openingBalance.Entry_User = user.Id;
                        
                        db.tblCOAOpeningBalances.Add(openingBalance);
                    }

                    if (RecId > 0)
                        db.Entry(cOA).State = EntityState.Modified;
                    else
                    {
                        db.tblCOAs.Add(cOA);
                    }
                    
                    db.SaveChanges();
                    MessageBox.Show("Operation Successfully Complete");
                    refreshForm();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                refreshForm();
            }
        }
        private int GetCode()
        {
            int PONo = 0;
            try
            {
                int code = Numerics.GetInt(ddlSubAccount.Value);
                var PO = db.tblCOAs.OrderByDescending(x => x.Account_Code).Where(x => x.SubAccount_Id == code).ToList();
                var PAcc = db.tblSubAccounts.OrderByDescending(x => x.Parent_Account_Id).Where(x => x.Id == code).ToList();
                if (PO.Count > 0)
                {
                    string cmbcode = Numerics.GetString(PO[0].Account_Code.ToString());
                    PONo =Numerics.GetInt(cmbcode) + 1;
                }
                else
                {
                        int ParentAccountID = Numerics.GetInt(PAcc[0].Parent_Account_Id);
                        string cmbcode = Numerics.GetString(ParentAccountID.ToString() + "00"+ Numerics.GetString(ddlSubAccount.Value.ToString()));
                        PONo = Numerics.GetInt(cmbcode + "001");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return PONo;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Save_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GridParentBind()
        {
            try
            {
                DataTable dtsubAccGrid = new DataTable();
                dtsubAccGrid.Columns.Add("ID");
                dtsubAccGrid.Columns.Add("SubAccount");
                dtsubAccGrid.Columns.Add("ParentAccount");
                int PAccID = Numerics.GetInt(ddlParenetAccount.Value);
                var SubAccount = db.tblSubAccounts.Where(x => x.Parent_Account_Id == PAccID).OrderByDescending(x => x.Id).ToList();
                dtsubAccGrid.Rows.Clear();
                foreach (var item in SubAccount)
                {
                    dtsubAccGrid.Rows.Add(item.Id, item.SubAccount_Name, item.tblParentAccount.Parent_Account);
                }
                if (dtsubAccGrid.Rows.Count > 0)
                {
                    grdsubAccount.DataSource = dtsubAccGrid;
                    grdsubAccount.RetrieveStructure();
                    SubAccountSetting();
                }
                else
                {
                    grdsubAccount.ClearStructure();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SubAccountSetting()
        {
            try
            {
                grdsubAccount.RootTable.Columns["SubAccount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdsubAccount.RootTable.Columns["ParentAccount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdsubAccount.RootTable.Columns["SubAccount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdsubAccount.RootTable.Columns["ParentAccount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdsubAccount.RootTable.Columns["SubAccount"].Width = 200;
                grdsubAccount.RootTable.Columns["ParentAccount"].Width = 100;

                grdsubAccount.RootTable.Columns["ID"].Visible = false;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Grid Click 
        private void grdsubAccount_Click(object sender, EventArgs e)
        {
            try
            {
                int SUbID = Numerics.GetInt(grdsubAccount.CurrentRow.Cells[0].Value);
                var coa = db.tblCOAs.Where(x => x.SubAccount_Id == SUbID);
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("ID");
                dtDetail.Columns.Add("AccountCode");
                dtDetail.Columns.Add("AccountTitle");
                dtDetail.Columns.Add("Date");
                dtDetail.Columns.Add("IsActive");
                dtDetail.Rows.Clear();
                foreach (var item in coa)
                {
                    dtDetail.Rows.Add(item.Id,item.Account_Code, item.Account_Title, Convert.ToDateTime(item.Entry_Date).ToString("dd-MMM-yyyy"),item.IsActive);
                }
                if (dtDetail.Rows.Count > 0)
                {
                    grdDetail.DataSource = dtDetail;
                    grdDetail.RetrieveStructure();
                    DetailAccountSetting();
                }
                else
                {
                    grdDetail.ClearStructure();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DetailAccountSetting()
        {
            try
            {
                grdDetail.RootTable.Columns["AccountTitle"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdDetail.RootTable.Columns["AccountCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdDetail.RootTable.Columns["Date"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdDetail.RootTable.Columns["IsActive"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdDetail.RootTable.Columns["AccountTitle"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdDetail.RootTable.Columns["AccountCode"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdDetail.RootTable.Columns["Date"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdDetail.RootTable.Columns["IsActive"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdDetail.RootTable.Columns["AccountTitle"].Width = 300;
                grdDetail.RootTable.Columns["AccountCode"].Width = 100;
                grdDetail.RootTable.Columns["Date"].Width = 100;
                grdDetail.RootTable.Columns["IsActive"].Width = 100;

                grdDetail.RootTable.Columns["IsActive"].ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox;
                grdDetail.RootTable.Columns["IsActive"].CheckBoxTrueValue = true;
                grdDetail.RootTable.Columns["IsActive"].CheckBoxFalseValue = false;

                grdDetail.RootTable.Columns["IsActive"].CheckBoxTrueValue = true;

                grdDetail.RootTable.Columns["ID"].Visible = false;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Double Click Event
        private void grdDetail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                RecId = Numerics.GetInt(grdDetail.CurrentRow.Cells[0].Value);
                cOA = db.tblCOAs.Where(x => x.Id == RecId).FirstOrDefault();
                if (cOA!=null)
                {
                    int getParentAccountId = Numerics.GetInt(cOA.SubAccount_Id);
                    var ParentAccId = db.tblSubAccounts.Where(x => x.Id == getParentAccountId).ToList();
                    if (ParentAccId.Count > 0)
                    {
                        
                        ddlParenetAccount.Value = Numerics.GetInt(ParentAccId[0].Parent_Account_Id);
                        ddlSubAccount.Value = Numerics.GetInt(cOA.SubAccount_Id);
                        txtAccountTitle.Text = cOA.Account_Title;
                        chkIsActive.Checked = Numerics.GetBool(cOA.IsActive);
                        txtAccountCode.Text = cOA.Account_Code.ToString();
                    }

                }
                else
                {
                    MessageBox.Show("Record Not Found");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        
        #region Shortcut Keys
        private void AcfrmCOA_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == System.Windows.Forms.Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
                if (e.Control && e.KeyCode == Keys.N)
                {
                    New_Click(null, null);
                }
                if (e.Control && e.KeyCode == Keys.E)
                {
                    this.Close();
                }
                if (Save.Visible == true)
                {
                    if (e.Control && e.KeyCode == Keys.S)
                    {
                        Save_Click(null, null);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void btnclose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdsubAccount_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                RecId = 0;
                RecId = Numerics.GetInt(grdsubAccount.CurrentRow.Cells[0].Value);
                tblSub = db.tblSubAccounts.Where(x => x.Id == RecId).FirstOrDefault();
                if(tblSub != null)
                {
                   
                    ddlParenetAccount.Value = tblSub.Parent_Account_Id;
                    ddlSubAccount.Value = tblSub.Id;
                    txtAccountTitle.Text = string.Empty;
                    txtAccountTitle.Enabled = false;
                    Save.Text = "Update";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
 