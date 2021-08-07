using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Miscellaneous
{
    public partial class frmSupplierCustomer : Form
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
        int RecId = 0;
        //tblSupplierCustomer customer = new tblSupplierCustomer();
        DropDownBinding DDL = new DropDownBinding();
        UserAccount user = new UserAccount();
        string UserType = string.Empty;
        public frmSupplierCustomer(UserAccount getuser, string Type)
        {
            InitializeComponent();
            user = getuser;
            UserType = Type;
        }
        #region Load
        private void frmSupplierCustomer_Load(object sender, EventArgs e)
        {
            //GLAccBind();
            GridFill();
            typesuppliercustomer();
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
            btnSave.Enabled = DoHaveSaveRight;
            //btnPrint.Enabled = DoHavePrintRights;
            btnUpdate.Enabled = DoHaveUpdateRights;
            ctrlGrdBar1.mGridChooseFielder.Enabled = DoHaveFieldChooserRights;
            ctrlGrdBar1.mGridSaveLayouts.Enabled = DoHaveSaveLayoutRights;
            ctrlGrdBar1.mGridPrint.Enabled = DoHaveGridPrintRights;
            ctrlGrdBar1.mGridExport.Enabled = DoHaveGridExportRights;
            ctrlGrdBar1.GroupCollaps.Enabled = DoHaveGridGroupCollapseRights;
            ctrlGrdBar1.GroupExpand.Enabled = DoHaveGridGroupExpandRights;
        }


        #endregion

        #region Combo fill
        //public void GLAccBind()
        //{
        //    try
        //    {
        //        var Acc = db.tblCOAs.ToList();
        //        DataTable dtPurchaseAcc = new DataTable();
        //        if (Acc.Count > 0)
        //        {
        //            dtPurchaseAcc.Columns.Add("Id");
        //            dtPurchaseAcc.Columns.Add("AccountTitle");
        //            foreach (var a in Acc)
        //            {
        //                dtPurchaseAcc.Rows.Add(a.Id, a.Account_Title);
        //            }
        //            if (dtPurchaseAcc.Rows.Count > 0)
        //            {
        //                DDL.BindDDL(dtPurchaseAcc, cmbGLAcccount, "Id", "AccountTitle", "Account Title", false);
        //            }
        //            else
        //            {
        //                cmbGLAcccount.Text = string.Empty;
        //                cmbGLAcccount.DataSource = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public void typesuppliercustomer()
        {
            try
            {
                DataTable dttype = new DataTable();
                dttype.Columns.Add("Id");
                dttype.Columns.Add("Type");

                dttype.Rows.Add(1,"Supplier");
                dttype.Rows.Add(2,"Customer");
                dttype.Rows.Add(3,"Doctor");
                if (dttype.Rows.Count > 0)
                {
                    DDL.BindDDL(dttype, cmbsupplierCustomerType, "Id", "Type", "Type", false);
                    if(UserType != string.Empty)
                    {
                        cmbsupplierCustomerType.Text = UserType;
                        cmbsupplierCustomerType.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Validation and Form Reset
        private bool FormValidation()
        {
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Full Name Field is Required");
                txtFullName.Focus();
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                MessageBox.Show("Contact # Name Field is Required");
                txtContactNo.Focus();
                return false;
            }
            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Address Field is Required");
                txtAddress.Focus();
                return false;
            }
            //if (cmbGLAcccount.Text.Trim() == "")
            //{
            //    MessageBox.Show("GL Acclount Field is Required");
            //    cmbGLAcccount.Focus();
            //    return false;
            //}
            return true;
        }
        private void ResetForm()
        {
            txtFullName.Text = string.Empty;
            txtFullName.Enabled = true;
            txtContactNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            //cmbGLAcccount.Text = string.Empty;
            cmbsupplierCustomerType.Text = string.Empty;
            GridFill();
            typesuppliercustomer();
            RecId = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            txtFullName.Focus();
        }

        #endregion

        #region CRUD

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int SubAccount = 0;
            string Extension = string.Empty;
            if (!FormValidation())
            {
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (UserType == "Supplier" || UserType == "Doctor")
            {
                if(UserType == "Supplier")
                {
                    Extension = "S-A/C";
                }
                else if(UserType == "Doctor")
                {
                    Extension = "Dr-A/C";
                }
                var obj = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Creditors Sub A/C");
                if (obj == null)
                {
                    MessageBox.Show("Please Select An Creditor Sub Account From Configration");
                    return;
                }
                else
                {
                    SubAccount = Numerics.GetInt(obj.Configration_Value);
                }
            }
            if (UserType == "Customer")
            {
                Extension = "C-A/C";
                var obj = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Debitors Sub A/C");
                if (obj == null)
                {
                    MessageBox.Show("Please Select An DEbitor Sub Account From Configration");
                    return;
                }
                else
                {
                    SubAccount = Numerics.GetInt(obj.Configration_Value);
                }
            }
            if (RecId == 0)
            {
                tblCOA cOA = new tblCOA();
                cOA.SubAccount_Id = Numerics.GetInt(SubAccount);
                cOA.Account_Code = GetCode(SubAccount);
                cOA.Account_Title = txtFullName.Text.Trim() + " " + Extension;
                cOA.Company_Id = user.CompanyId;
                cOA.Branch_Id = user.BranchId;
                cOA.Entry_Date = DateTime.Now;
                cOA.Entry_User = user.Id;
                cOA.Modify_Date = DateTime.Now;
                cOA.Modify_User = Numerics.GetInt(user.Id);
                cOA.IsActive = true;
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
                cOA.tblSupplierCustomers = new List<tblSupplierCustomer>();
                {
                    tblSupplierCustomer customer = new tblSupplierCustomer();
                    customer.Profile_Name = txtFullName.Text.Trim() + " " + Extension;
                    customer.Address = txtAddress.Text.Trim();
                    customer.Contact_No = txtContactNo.Text.Trim();
                    customer.GlAccount_Id = Numerics.GetInt(cOA.Id);
                    customer.SupplierCustomerType = cmbsupplierCustomerType.Text;
                    customer.Entry_User = user.Id;
                    customer.Entry_Date = DateTime.Now;
                    customer.Reporting_Title = txtFullName.Text.Trim();
                    customer.Company_Id = user.CompanyId;
                    customer.Branch_Id = user.BranchId;
                    customer.IsActive = true;
                    db.tblSupplierCustomers.Add(customer);
                }
                db.tblCOAs.Add(cOA);
                db.SaveChanges();
            }
            else
            {
                var customer = db.tblSupplierCustomers.FirstOrDefault(x=> x.Id == RecId);
               // customer.Profile_Name = txtFullName.Text.Trim() + " " + Extension;
                customer.Address = txtAddress.Text.Trim();
                customer.Contact_No = txtContactNo.Text.Trim();
                customer.SupplierCustomerType = cmbsupplierCustomerType.Text;
                customer.Entry_User = user.Id;
                customer.Entry_Date = DateTime.Now;
                customer.Reporting_Title = txtFullName.Text.Trim();
                customer.Company_Id = user.CompanyId;
                customer.Branch_Id = user.BranchId;
                customer.IsActive = true;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Operation Successfully Complete");
            ResetForm();


        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }
        public void GridFill()
        {
            try
            {
                var Getall = (from sc in db.tblSupplierCustomers
                              join acc in db.tblCOAs on sc.GlAccount_Id equals acc.Id
                              select new
                              {
                                  sc.Id,
                                  sc.Profile_Name,
                                  sc.Contact_No,
                                  sc.Address,
                                  sc.Company_Id,
                                  sc.Branch_Id,
                                  sc.GlAccount_Id,
                                  acc.Account_Title,
                                  sc.SupplierCustomerType
                              }).Where(x=> x.SupplierCustomerType == UserType).ToList();

                if(Getall.Count>0)
                {
                    DataTable dtgetAll = new DataTable();
                    dtgetAll.Columns.Add("Id");
                    dtgetAll.Columns.Add("ProfileName");
                    dtgetAll.Columns.Add("Contact#");
                    dtgetAll.Columns.Add("Address");
                    dtgetAll.Columns.Add("GLAccount");
                    dtgetAll.Columns.Add("TypeAccount");
                    foreach (var item in Getall)
                    {
                        dtgetAll.Rows.Add(item.Id, item.Profile_Name, item.Contact_No, item.Address, item.Account_Title,item.SupplierCustomerType);
                    }
                    grdCustomer.DataSource = dtgetAll;
                    grdCustomer.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grdCustomer.ClearStructure();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void  GridSetting()
        {
            try
            {
                grdCustomer.RootTable.Columns["ProfileName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["Contact#"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["Address"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["GLAccount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["Id"].Visible = false;

                grdCustomer.RootTable.Columns["ProfileName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomer.RootTable.Columns["Contact#"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomer.RootTable.Columns["Address"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomer.RootTable.Columns["GLAccount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdCustomer.RootTable.Columns["ProfileName"].Width = 200;
                grdCustomer.RootTable.Columns["Contact#"].Width = 150;
                grdCustomer.RootTable.Columns["Address"].Width = 300;
                grdCustomer.RootTable.Columns["GLAccount"].Width = 300;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Double Click Event
        private void grdCustomer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tblSupplierCustomer customer = new tblSupplierCustomer();
                RecId = Numerics.GetInt(grdCustomer.CurrentRow.Cells[0].Value);
                customer = db.tblSupplierCustomers.Where(x => x.Id == RecId).FirstOrDefault();
                if (customer != null)
                {
                    txtAddress.Text = customer.Address;
                    txtContactNo.Text = customer.Contact_No;
                    txtFullName.Text = customer.Profile_Name;
                    //cmbGLAcccount.Value = customer.GlAccount_Id;
                    cmbsupplierCustomerType.Text = customer.SupplierCustomerType;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    txtFullName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ShortCut Keys

        private void frmSupplierCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AccountsDefinition.AcfrmCOA cOA = new AccountsDefinition.AcfrmCOA(user);
            cOA.Show();
        }
        private int GetCode(int SubAccountId)
        {
            int PONo = 0;
            try
            {
                int code = Numerics.GetInt(SubAccountId);
                var PO = db.tblCOAs.OrderByDescending(x => x.Account_Code).Where(x => x.SubAccount_Id == code).ToList();
                var PAcc = db.tblSubAccounts.OrderByDescending(x => x.Parent_Account_Id).Where(x => x.Id == code).ToList();
                if (PO.Count > 0)
                {
                    string cmbcode = Numerics.GetString(PO[0].Account_Code.ToString());
                    PONo = Numerics.GetInt(cmbcode) + 1;
                }
                else
                {
                    int ParentAccountID = Numerics.GetInt(PAcc[0].Parent_Account_Id);
                    string cmbcode = Numerics.GetString(ParentAccountID.ToString() + "00" + Numerics.GetString(SubAccountId.ToString()));
                    PONo = Numerics.GetInt(cmbcode + "001");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return PONo;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
           // GLAccBind();
        }
    }
}
