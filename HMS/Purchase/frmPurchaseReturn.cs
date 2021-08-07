using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Purchase
{
    public partial class frmPurchaseReturn : Form
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
        UserAccount user = new UserAccount();
        DataTable dtGrid = new DataTable();
        int updateDetailIndex;
        int PaymentId = 0;
        public frmPurchaseReturn( UserAccount getuser)
        {
            InitializeComponent();
            user = getuser;
        }

        #region Load
        private void frmPurchase_Load(object sender, EventArgs e)
        {
            suppliercustomerFill();
            CategoryFill();
            GetCode();
            ddlCategory.Focus();
            orderNoBind();
            History();
            dtGrid.Columns.Add("CatId");
            dtGrid.Columns.Add("Category");
            dtGrid.Columns.Add("ProId");
            dtGrid.Columns.Add("Product");
            dtGrid.Columns.Add("PackQty", typeof(double));
            dtGrid.Columns.Add("Qty", typeof(double));
            dtGrid.Columns.Add("NetQty", typeof(double));
            dtGrid.Columns.Add("Rate", typeof(double));
            dtGrid.Columns.Add("Amount", typeof(double));
            dtGrid.Columns.Add("ExpiryDate");
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
        public void suppliercustomerFill()
        {
            try
            {
                var sc = db.tblSupplierCustomers.ToList();
                if (chkCustomers.Checked == true && chkSuppliers.Checked == true)
                {

                }
                else
                {
                    if (chkCustomers.Checked == true)
                    {
                        sc = sc.Where(x => x.SupplierCustomerType == "Customer").ToList();
                    }
                    if (chkSuppliers.Checked == true)
                    {
                        sc = sc.Where(x => x.SupplierCustomerType == "Supplier").ToList();
                    }
                }
                DataTable dtsc = new DataTable();
                dtsc.Columns.Add("Id");
                dtsc.Columns.Add("SupplierCustomer");
                if(sc.Count>0)
                {
                    foreach (var item in sc)
                    {
                        dtsc.Rows.Add(item.Id, item.Profile_Name);
                    }
                    if(dtsc.Rows.Count>0)
                    {
                        DDL.BindDDL(dtsc, ddlSupplierCustomer, "Id", "SupplierCustomer", "Supplier Customer", false);
                    }
                    else
                    {
                        ddlSupplierCustomer.Text = string.Empty;
                        ddlSupplierCustomer.DataSource = null;
                    }
                }
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CategoryFill()
        {
            try
            {
                var cat = db.tblCategories.ToList();
                DataTable dtcat = new DataTable();
                dtcat.Columns.Add("Id");
                dtcat.Columns.Add("Category");
                if (cat.Count > 0)
                {
                    foreach (var item in cat)
                    {
                        dtcat.Rows.Add(item.Id, item.Category_Name);
                    }
                    if (dtcat.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtcat, ddlCategory, "Id", "Category", "Category", false);
                    }
                    else
                    {
                        ddlCategory.Text = string.Empty;
                        ddlCategory.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ProductFill()
        {
            try
            {
                if (ddlCategory.Text != string.Empty)
                {
                    ddlProduct.Text = string.Empty;
                    int catId = Numerics.GetInt(ddlCategory.Value);
                    var pro = (from itemalo in db.tbl_Item_Allocation
                               join item in db.tbl_Item_Def on itemalo.Item_Id equals item.Id
                               where item.Category_Id == catId
                               select new
                               {
                                   item.Category_Id,
                                   itemalo.Id,
                                   item.Item_Name,
                               }).ToList();

                    DataTable dtpro = new DataTable();
                    dtpro.Columns.Add("Id");
                    dtpro.Columns.Add("Category");
                    if (pro.Count > 0)
                    {
                        foreach (var item in pro)
                        {
                            dtpro.Rows.Add(item.Id, item.Item_Name);
                        }
                        if (dtpro.Rows.Count > 0)
                        {
                            DDL.BindDDL(dtpro, ddlProduct, "Id", "Category", "Category", false);
                        }
                        else
                        {
                            ddlProduct.Text = string.Empty;
                            ddlProduct.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ddlCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlCategory.Text != string.Empty.Trim())
                {
                    ProductFill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void orderNoBind()
        {
            try
            {
                var cat = db.tbl_PurchaseMaster.ToList();
                DataTable dtcat = new DataTable();
                dtcat.Columns.Add("Id");
                dtcat.Columns.Add("OrderNo");
                if (cat.Count > 0)
                {
                    foreach (var item in cat)
                    {
                        dtcat.Rows.Add(item.Id, item.OrderNo);
                    }
                    if (dtcat.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtcat, ddlOrderNo, "Id", "OrderNo", "OrderNo", false);
                    }
                    else
                    {
                        ddlOrderNo.Text = string.Empty;
                        ddlOrderNo.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetAccFromconfig()
        {
            try
            {
                var getrec = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Cash In Hand");
                if (getrec != null)
                {
                    PaymentId = Numerics.GetInt(getrec.Configration_Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Validation and Reset
        protected bool ValidateDetails()
        {
            bool validate = true;
            try
            {
                if (Numerics.GetInt(ddlCategory.Value) == 0)
                {
                    MessageBox.Show("Select A Category First");
                    ddlCategory.Focus();
                    return false;
                }
                if (Numerics.GetInt(ddlProduct.Value) == 0)
                {
                    MessageBox.Show("Select A Product First");
                    ddlProduct.Focus();
                    return false;
                }
                if (Numerics.GetDouble(txtQty.Text) == 0)
                {
                    MessageBox.Show("Enter Qty First");
                    txtQty.Focus();
                    return false;
                }
                if (Numerics.GetDouble(txtAmountPerPack.Text) == 0)
                {
                    MessageBox.Show("Enter Qty Per Pack First");
                    txtAmountPerPack.Focus();
                    return false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return validate;
        }
        public void ResetDetails()
        {
            try
            {
                ddlCategory.Text = string.Empty;
                ddlProduct.Text = string.Empty;
                ddlProduct.DataSource = null;
                txtPackQty.Text = string.Empty;
                txtQty.Text = string.Empty;
                txtAmountPerPack.Text = string.Empty;
                txtTotalAmount.Text = string.Empty;
                txtunitPrice.Text = string.Empty;
                txtTotalQty.Text = string.Empty;
                ddlCategory.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void ResetForm()
        {
            try
            {
                txtPO.Text = string.Empty;
                txtBillNo.Text = string.Empty;
                ddlSupplierCustomer.Text = string.Empty;
                txtPaid.Text = string.Empty;
                txtRemaining.Text = string.Empty;
                txtTotal.Text = string.Empty;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                grddetail.ClearStructure();
                dtGrid.Clear();
                History();
                GetCode();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region CRUD
        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
            ResetDetails();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                int k = Numerics.GetInt(ddlSupplierCustomer.Value);
                int checkid = 0;
               int SPGLId = 0;
                var SPG = db.tblSupplierCustomers.Where(x => x.Id == k).ToList();
                if(SPG.Count > 0)
                {
                    SPGLId = Numerics.GetInt(SPG[0].GlAccount_Id);
                }
                //var chkID= db.tbl_PurchaseMaster.OrderByDescending(x => x.Id).ToList();
                //if (chkID.Count > 0)
                //{
                //   checkid = chkID[0].Id;
                //}
                //else
                //{
                //    checkid = 0;
                //}
                GetCode();
                tbl_PurchaseReturnMaster master = new tbl_PurchaseReturnMaster();
               master.OrderNo=txtPO.Text.ToString();
                master.ManualBillNo = txtBillNo.Text;
                master.DocumentTypeId = 3;
                master.DocDate = DateTime.Now;
                master.SupplierCustomerId = Numerics.GetInt(ddlSupplierCustomer.Value);
                master.BillAmount = Numerics.GetDouble(txtTotal.Text);
                master.Remarks = "";
                master.Entry_Date = DateTime.Now;
                master.Modify_Date= DateTime.Now;
                master.Entry_User = user.Id;
                master.Modify_User = Numerics.GetInt(user.Id);
                master.Company_Id = user.CompanyId;
                master.Branch_Id = user.BranchId;
                master.tbl_PurchaseReturnDetail = new List<tbl_PurchaseReturnDetail>();
                foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                {
                    tbl_PurchaseReturnDetail detail = new tbl_PurchaseReturnDetail();
                    detail.PurchaseReturnMaster_Id = master.Id;
                    detail.CategoryId = Numerics.GetInt(r.Cells["CatId"].Value);
                    detail.ItemId = Numerics.GetInt(r.Cells["ProId"].Value);
                    detail.ItemQty = Numerics.GetInt(r.Cells["Qty"].Value);
                    detail.PackQty = Numerics.GetInt(r.Cells["PackQty"].Value);
                    detail.ItemRate = Numerics.GetDouble(r.Cells["Rate"].Value);
                    detail.ItemAmount = Numerics.GetDouble(r.Cells["Amount"].Value);
                    detail.ExpiryDate = Convert.ToDateTime(r.Cells["ExpiryDate"].Value);
                    detail.NetQty = Convert.ToInt32(r.Cells["NetQty"].Value);
                    detail.BillAmount = Numerics.GetDouble(txtTotal.Text);
                    detail.RemarksDetail = "";
                    detail.UnitRate = 0;
                    master.tbl_PurchaseReturnDetail.Add(detail);
                }
                db.tbl_PurchaseReturnMaster.Add(master);
                db.SaveChanges();
                int scId = Numerics.GetInt(ddlSupplierCustomer.Value);
               
                var getMaxId = db.tbl_PurchaseReturnMaster.OrderByDescending(x => x.Id).ToList();
                if (getMaxId.Count > 0)
                {
                    if (getMaxId[0].Id > checkid)
                    {
                        tblVoucherHead head = new tblVoucherHead();
                        head.DocumentType_Id = 5;
                        head.RefDocTypeId = 3;
                        head.RefDocNoId = getMaxId[0].Id;
                        head.Voucher_Code = GetVouvherCode();
                        head.Voucher_Date = DateTime.Now;
                        head.Voucher_Amount = Numerics.GetDouble(txtTotal.Text);
                        head.RefrenceAccount = SPGLId;
                        head.AgainstAccount = 0;
                        head.Entry_User = user.Id;
                        head.Branch_Id = user.BranchId;
                        head.Company_Id = user.CompanyId;
                        head.tblVoucherDetails = new List<tblVoucherDetail>();
                        foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                        {
                            tblVoucherDetail vd = new tblVoucherDetail();
                            int p = Numerics.GetInt(r.Cells["ProId"].Value);
                            var getAccountId = db.tbl_Item_Allocation.Where(x => x.Id == p).ToList();
                            vd.Voucher_Head_Id = head.Id;
                            vd.COA_Id = getAccountId[0].PurchaseAccount;
                            vd.Against_COA_Id = SPGLId;
                            vd.Comments = "supplier Debit for PurchaseReturn";
                            vd.DebitAmount = 0;
                            vd.CreditAmount = Numerics.GetDouble(r.Cells["Amount"].Value); ;
                            vd.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                            vd.ChequeNo = "";
                            head.tblVoucherDetails.Add(vd);

                            tblVoucherDetail vd1 = new tblVoucherDetail();
                            vd1.Voucher_Head_Id = head.Id;
                            vd1.Against_COA_Id = getAccountId[0].PurchaseAccount;
                            vd1.COA_Id = SPGLId;
                            vd1.Comments = "Item Credit for PurchaseReturn";
                            vd1.CreditAmount = 0;
                            vd1.DebitAmount = Numerics.GetDouble(r.Cells["Amount"].Value); ;
                            vd1.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                            vd1.ChequeNo = "";
                            head.tblVoucherDetails.Add(vd1);
                        }
                        if (chkPostVoucher.Checked == true)
                        {
                            GetAccFromconfig();
                            if (PaymentId > 0)
                            {
                                tblVoucherDetail vd2 = new tblVoucherDetail();
                                vd2.Voucher_Head_Id = head.Id;
                                vd2.Against_COA_Id = PaymentId;
                                vd2.COA_Id = SPGLId;
                                vd2.Comments = "Amount Deduted From Supplier A/C from Purchase Return";
                                vd2.DebitAmount = Numerics.GetDouble(txtPaid.Text);
                                vd2.CreditAmount = 0;
                                // vd2.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                                vd2.ChequeNo = "";
                                head.tblVoucherDetails.Add(vd2);

                                tblVoucherDetail vd3 = new tblVoucherDetail();
                                vd3.Voucher_Head_Id = head.Id;
                                vd3.COA_Id = PaymentId;
                                vd3.Against_COA_Id = SPGLId;
                                vd3.Comments = "Amount Added To Cash in Hand from Purchase Return";
                                vd3.DebitAmount = 0;
                                vd3.CreditAmount = Numerics.GetDouble(txtPaid.Text);
                                // vd2.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                                vd3.ChequeNo = "";
                                head.tblVoucherDetails.Add(vd3);
                            }
                            else
                            {
                                MessageBox.Show("Please Set Configuration First ...");
                                frmConfigurations frm = new frmConfigurations(user);
                                frm.Show();
                                return;
                            }

                        }
                        db.tblVoucherHeads.Add(head);
                        db.SaveChanges();
                        foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                        {
                            tbl_InventoryTransaction transaction = new tbl_InventoryTransaction();
                            transaction.DocDate = txtDate.Value;
                            transaction.RefDocumentTypeId = 3;
                            transaction.RefDocIdNo = getMaxId[0].Id;
                            transaction.CategoryId = Numerics.GetInt(r.Cells["CatId"].Value);
                            transaction.ItemId = Numerics.GetInt(r.Cells["ProId"].Value);
                            transaction.QtyIn = 0;
                            transaction.QtyOut = Numerics.GetInt(r.Cells["NetQty"].Value);
                            transaction.ItemRate = Numerics.GetDouble(r.Cells["Rate"].Value);
                            transaction.ExpiryDate = Convert.ToDateTime(r.Cells["ExpiryDate"].Value);
                            transaction.Remarks = "";
                            transaction.SupplierCustomerId = Numerics.GetInt(ddlSupplierCustomer.Value);
                            db.tbl_InventoryTransaction.Add(transaction);
                            db.SaveChanges();
                        }
                        MessageBox.Show("Saved Successfully");
                        ResetForm();
                        ResetDetails();
                    }
                    else
                    {
                        MessageBox.Show("Something Wrong");
                        return;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetails() && ChkGrid())
                {
                    dtGrid.Rows.Add
                        (
                        Numerics.GetInt(ddlCategory.Value),
                        ddlCategory.Text,
                        Numerics.GetInt(ddlProduct.Value),
                        ddlProduct.Text,
                        Numerics.GetDouble(txtPackQty.Text),
                        Numerics.GetDouble(txtQty.Text),
                        Numerics.GetDouble(txtTotalQty.Text),
                        Numerics.GetDouble(txtAmountPerPack.Text),
                        Numerics.GetDouble(txtTotalAmount.Text),
                        Convert.ToDateTime(txtexpirydate.Value).ToString("dd-MMM-yyyy")
                        ) ;
                    ResetDetails();
                    grddetail.DataSource = dtGrid;
                    grddetail.RetrieveStructure();
                    grdSettings();
                    GetAmountalculations();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetCode()
        {
           
            try
            {
                int PONo = 0;
                var PO = db.tbl_PurchaseReturnMaster.OrderByDescending(x => x.Id).ToList();
                if (PO.Count > 0)
                {
                    string purchaseNumber = PO[0].OrderNo.ToString();
                    int count = int.Parse(purchaseNumber.Trim(new Char[] { 'P', 'R', '-' })) + 1;
                    txtPO.Text = "PR-" + count;
                }
                else
                {
                    txtPO.Text = "PR-1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetVouvherCode()
        {
            int vouchercde = 0;
            try
            {
               
                var VC = db.tblVoucherHeads.OrderByDescending(x => x.Id).ToList();
                if (VC.Count > 0)
                {
                     vouchercde = Numerics.GetInt(VC[0].Voucher_Code);
                     vouchercde = vouchercde + 1;
                }
                else
                {
                    vouchercde = 1001;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return vouchercde;
        }


        #endregion

        #region Short Cut Keys 

        #endregion

        #region Move and Close Form 
        private void btnItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmAddItem frmAdd = new Miscellaneous.frmAddItem(user);
            frmAdd.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Funcions
        private bool ChkGrid()
        {
            try
            {
                GridEXRow item = grddetail.CurrentRow;
                if (item != null && item.RowType == RowType.Record)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        if (Numerics.GetInt(ddlProduct.Value) == Numerics.GetInt(item.Cells["ProId"].Value))
                        {
                            MessageBox.Show("Product Is Already in the Grid");
                            return false;
                        }
                    }
                }

            }
            catch
            {
                return true;
            }
            return true;
        }

        protected void GetAmountalculations()
        {
            try
            {
                //txtTotal.Text = Numerics.GetDouble(this.grddetail.GetTotal(grddetail.RootTable.Columns["TotalAmount"], Janus.Windows.GridEX.AggregateFunction.Sum)).ToString();
                double Total = Numerics.GetDouble(txtTotal.Text);
                double Paid = Numerics.GetDouble(txtPaid.Text);
                if (Total < Paid)
                {
                    MessageBox.Show("Paid Amount Should be Less then Total Amount");
                    txtPaid.Focus();
                    return;
                }
                double Remaining = Total - Paid;
                txtRemaining.Text = Remaining.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void Calculations()
        {
            try
            {
                double Qty = Numerics.GetDouble(txtQty.Text);
                double TotalQty = Qty * Numerics.GetInt(txtPackQty.Text);
                txtTotalQty.Text = TotalQty.ToString();
                double AmountPerPack = Numerics.GetDouble(txtAmountPerPack.Text);
                double TotalAmount = Qty * AmountPerPack;
                txtTotalAmount.Text = TotalAmount.ToString();
                double unitPrice = Math.Round((TotalAmount / TotalQty), 2);
                txtunitPrice.Text = unitPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void grdSettings()
        {
            grddetail.RootTable.Columns["CatId"].Visible = false;
            grddetail.RootTable.Columns["ProId"].Visible = false;

            grddetail.RootTable.Columns["Category"].EditType = EditType.NoEdit;
            grddetail.RootTable.Columns["Product"].EditType = EditType.NoEdit;
            grddetail.RootTable.Columns["Qty"].EditType = EditType.TextBox;
            grddetail.RootTable.Columns["Rate"].EditType = EditType.TextBox;
            grddetail.RootTable.Columns["Amount"].EditType = EditType.TextBox;
            grddetail.RootTable.Columns["ExpiryDate"].EditType = EditType.TextBox;

            grddetail.RootTable.Columns["Category"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Product"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Qty"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Rate"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Amount"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["ExpiryDate"].FilterEditType = FilterEditType.TextBox;

            grddetail.RootTable.Columns["Category"].Width = 200;
            grddetail.RootTable.Columns["Product"].Width = 350;
            //grddetail.RootTable.Columns["PackQty"].Width = 100;
            grddetail.RootTable.Columns["Rate"].Width = 100;
            grddetail.RootTable.Columns["Amount"].Width = 100;
            //grddetail.RootTable.Columns["NetQty"].Width = 100;
            grddetail.RootTable.Columns["ExpiryDate"].Width = 130;

            grddetail.RootTable.Columns["Qty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
            grddetail.RootTable.Columns["Amount"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;

            string sumof = this.grddetail.GetTotal(this.grddetail.RootTable.Columns["Amount"], Janus.Windows.GridEX.AggregateFunction.Sum).ToString();
            var aa = double.Parse(sumof);
            txtTotal.Text = Math.Round(aa).ToString();
            //ctrlGrdBar1_Load(null, null);
        }

       
        #endregion

        #region Leave Text change and DoubleClick
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != string.Empty)
                {
                    Calculations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAmountPerPack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != string.Empty)
                {
                    Calculations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlProduct.Text != string.Empty)
                {
                    int Pid = Numerics.GetInt(ddlProduct.Value);
                    var itm = (from itemalo in db.tbl_Item_Allocation
                               join item in db.tbl_Item_Def on itemalo.Item_Id equals item.Id
                               where itemalo.Id == Pid
                               select new
                               {
                                   item.PackQty
                               }).ToList();
                    if (itm.Count > 0)
                    {
                        txtPackQty.Text = itm[0].PackQty.ToString();
                    }
                    else
                    {
                        txtPackQty.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetAmountalculations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #region Change Event
        private void chkSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            suppliercustomerFill();
        }

        private void chkCustomers_CheckedChanged(object sender, EventArgs e)
        {
            suppliercustomerFill();
        }
        #endregion

        private void ddlOrderNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlOrderNo.Text != string.Empty)
                {
                    int OId = Numerics.GetInt(ddlOrderNo.Value);
                    var PODetail = (from h in db.tbl_PurchaseMaster
                                    join d in db.tbl_PurchaseDetail on h.Id equals d.PurchaseMaster_Id
                                    join c in db.tblCategories on d.CategoryId equals c.Id
                                    join p in db.tbl_Item_Allocation on d.ItemId equals p.Id
                                    join i in db.tbl_Item_Def on p.Item_Id equals i.Id
                                    where h.Id == OId
                                    select new
                                    {
                                        h.Id,
                                        h.OrderNo,
                                        h.DocumentTypeId,
                                        h.DocDate,
                                        h.SupplierCustomerId,
                                        h.ManualBillNo,
                                        h.BillAmount,
                                        h.Remarks,
                                        h.Entry_Date,
                                        h.Modify_Date,
                                        h.Entry_User,
                                        h.Modify_User,
                                        h.Company_Id,
                                        h.Branch_Id,
                                        d.PurchaseMaster_Id,
                                        d.CategoryId,
                                        d.ItemId,
                                        d.ItemQty,
                                        d.ItemRate,
                                        d.ItemAmount,
                                        d.PackQty,
                                        d.NetQty,
                                        d.UnitRate,
                                        d.RemarksDetail,
                                        d.ExpiryDate,
                                        c.Category_Name,
                                        i.Item_Name
                                    }).ToList();

                    if (PODetail.Count > 0)
                    {
                        //txtPO.Text = PODetail[0].OrderNo.ToString();
                        txtBillNo.Text = PODetail[0].ManualBillNo.ToString();
                        ddlSupplierCustomer.Value = PODetail[0].SupplierCustomerId;
                        txtTotal.Text = PODetail[0].BillAmount.ToString();
                        for (int i = 0; i < PODetail.Count; i++)
                        {
                            dtGrid.Rows.Add
                            (
                            //    dtGrid.Columns.Add("CatId");
                            //dtGrid.Columns.Add("Category");
                            //dtGrid.Columns.Add("ProId");
                            //dtGrid.Columns.Add("Product");
                            //dtGrid.Columns.Add("PackQty", typeof(double));
                            //dtGrid.Columns.Add("Qty", typeof(double));
                            //dtGrid.Columns.Add("NetQty", typeof(double));
                            //dtGrid.Columns.Add("Rate", typeof(double));
                            //dtGrid.Columns.Add("Amount", typeof(double));
                            //dtGrid.Columns.Add("ExpiryDate");
                            PODetail[i].CategoryId,
                            PODetail[i].Category_Name,
                            PODetail[i].ItemId,
                           PODetail[i].Item_Name,
                            PODetail[i].PackQty.ToString(),
                                PODetail[i].ItemQty.ToString(),
                            PODetail[i].NetQty.ToString(),
                           PODetail[i].ItemRate.ToString(),
                           PODetail[i].ItemAmount.ToString(),
                          Convert.ToDateTime(PODetail[i].ExpiryDate).ToString("dd-MMM-yyyy")
                            );
                        }
                        ResetDetails();
                        grddetail.DataSource = dtGrid;
                        grddetail.RetrieveStructure();
                        grdSettings();
                        GetAmountalculations();
                        grddetail.RootTable.Columns.Add("Delete");
                        grddetail.RootTable.Columns["Delete"].Key = "Delete";
                        grddetail.RootTable.Columns["Delete"].Caption = "Delete";
                        grddetail.RootTable.Columns["Delete"].ButtonDisplayMode = Janus.Windows.GridEX.CellButtonDisplayMode.Always;
                        grddetail.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                        grddetail.RootTable.Columns["Delete"].ButtonText = "Delete";
                        grddetail.RootTable.Columns["Delete"].Width = 70;
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Order No");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grddetail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridEXRow item = grddetail.CurrentRow;
                if (item != null)
                {
                    updateDetailIndex = item.RowIndex;
                    ddlCategory.Value = item.Cells["CatId"].Value;
                    ddlCategory_Leave(null, null);
                    ddlProduct.Value = item.Cells["ProId"].Value;
                    ddlProduct_Leave(null, null);
                    updateDetailIndex = item.RowIndex;
                    txtQty.Text = item.Cells["Qty"].Text.ToString();
                    txtAmountPerPack.Text = item.Cells["Rate"].Text.ToString();
                    txtTotalAmount.Text = item.Cells["Amount"].Text.ToString();
                    txtexpirydate.Value = Convert.ToDateTime(item.Cells["ExpiryDate"].Value);
                    btnUpdateGridRecord.Visible = true;
                    btnAdd.Visible = false;
                    btnCleardetail.Visible = true;
                    Calculations();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUpdateGridRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateDetails())
                {
                    return;
                }

                dtGrid.Rows[updateDetailIndex]["CatId"] = ddlCategory.Value;
                dtGrid.Rows[updateDetailIndex]["Category"] = ddlCategory.Text;
                dtGrid.Rows[updateDetailIndex]["ProId"] = ddlProduct.Value;
                dtGrid.Rows[updateDetailIndex]["Product"] = ddlProduct.Text;
                dtGrid.Rows[updateDetailIndex]["Qty"] = txtQty.Text;
                dtGrid.Rows[updateDetailIndex]["Rate"] = txtAmountPerPack.Text;
                dtGrid.Rows[updateDetailIndex]["Amount"] = txtTotalAmount.Text;
                dtGrid.Rows[updateDetailIndex]["NetQty"] = txtTotalQty.Text;


                btnUpdateGridRecord.Visible = false;
                btnCleardetail.Visible = false;
                btnAdd.Visible = true;
                grdSettings();
                ResetDetails();
                string sumof = this.grddetail.GetTotal(this.grddetail.RootTable.Columns["Amount"], Janus.Windows.GridEX.AggregateFunction.Sum).ToString();
                var aa = double.Parse(sumof);
                txtTotal.Text = Math.Round(aa).ToString();
                txtPaid.Text = "0";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        #endregion

        private void btnCleardetail_Click(object sender, EventArgs e)
        {
            btnUpdateGridRecord.Visible = false;
            btnCleardetail.Visible = false;
            btnAdd.Visible = true;
            //grdSettings();
            ResetDetails();
        }

        private void grddetail_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            try
            {
                GridEXRow item = grddetail.CurrentRow;
                if (item != null && item.RowType == RowType.Record)
                {
                    item.Delete();
                    txtTotal.Text = string.Empty;
                    txtRemaining.Text = string.Empty;
                }
                grddetail.UpdateData();
                grdSettings();
                if (txtTotal.Text == "0")
                {
                    txtPaid.Text = "0";
                    txtRemaining.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void History()
        {
            try
            {
                var history = (from h in db.tbl_PurchaseReturnMaster
                               join s in db.tblSupplierCustomers on h.SupplierCustomerId equals s.Id
                               select new
                               {
                                   h.Id,
                                   h.OrderNo,
                                   h.DocumentTypeId,
                                   h.DocDate,
                                   h.SupplierCustomerId,
                                   h.ManualBillNo,
                                   h.BillAmount,
                                   h.Remarks,
                                   h.Entry_Date,
                                   h.Modify_Date,
                                   h.Entry_User,
                                   h.Modify_User,
                                   h.Company_Id,
                                   h.Branch_Id,
                                   s.Profile_Name
                               }).ToList();

                DataTable dthistory = new DataTable();
                dthistory.Columns.Add("Id");
                dthistory.Columns.Add("OrderNo");
                dthistory.Columns.Add("Date");
                dthistory.Columns.Add("SupplierCustomer");
                dthistory.Columns.Add("BillAmount", typeof(double));
                for (int i = 0; i < history.Count; i++)
                {
                    dthistory.Rows.Add(history[i].Id, history[i].OrderNo, Convert.ToDateTime(history[i].DocDate).ToString("dd-MMM-yyyy"), history[i].Profile_Name, history[i].BillAmount);
                }
                grdHistory.DataSource = dthistory;
                grdHistory.RetrieveStructure();
                HistoryGridSetting();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void HistoryGridSetting()
        {
            try
            {
                grdHistory.RootTable.Columns["Id"].Visible = false;

                grdHistory.RootTable.Columns["OrderNo"].EditType = EditType.NoEdit;
                grdHistory.RootTable.Columns["Date"].EditType = EditType.NoEdit;
                grdHistory.RootTable.Columns["SupplierCustomer"].EditType = EditType.NoEdit;
                grdHistory.RootTable.Columns["BillAmount"].EditType = EditType.NoEdit;

                grdHistory.RootTable.Columns["OrderNo"].FilterEditType = FilterEditType.NoEdit;
                grdHistory.RootTable.Columns["Date"].FilterEditType = FilterEditType.NoEdit;
                grdHistory.RootTable.Columns["SupplierCustomer"].FilterEditType = FilterEditType.NoEdit;
                grdHistory.RootTable.Columns["BillAmount"].FilterEditType = FilterEditType.NoEdit;

                grdHistory.RootTable.Columns["OrderNo"].Width = 100;
                grdHistory.RootTable.Columns["Date"].Width = 100;
                grdHistory.RootTable.Columns["SupplierCustomer"].Width = 300;
                grdHistory.RootTable.Columns["BillAmount"].Width = 100;
                grdHistory.RootTable.Columns["BillAmount"].AggregateFunction = AggregateFunction.Sum;

                grdHistory.RootTable.Columns.Add("Detail");
                grdHistory.RootTable.Columns["Detail"].Key = "Detail";
                grdHistory.RootTable.Columns["Detail"].Caption = "Detail";
                grdHistory.RootTable.Columns["Detail"].ButtonDisplayMode = Janus.Windows.GridEX.CellButtonDisplayMode.Always;
                grdHistory.RootTable.Columns["Detail"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                grdHistory.RootTable.Columns["Detail"].ButtonText = "Detail";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdHistory_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            try
            {
                int rId = Numerics.GetInt(grdHistory.CurrentRow.Cells[0].Value);
                var dbdetail = (from d in db.tbl_PurchaseReturnDetail
                                join
c in db.tblCategories on d.CategoryId equals c.Id
                                join alo in db.tbl_Item_Allocation on d.ItemId equals alo.Id
                                join i in db.tbl_Item_Def on alo.Item_Id equals i.Id
                                where d.PurchaseReturnMaster_Id == rId
                                select new
                                {
                                    d.ItemQty,
                                    d.ItemRate,
                                    d.ItemAmount,
                                    d.RemarksDetail,
                                    i.Item_Name,
                                    c.Category_Name

                                }).ToList();
                DataTable dtdetailhistory = new DataTable();
                dtdetailhistory.Columns.Add("Category");
                dtdetailhistory.Columns.Add("Product");
                dtdetailhistory.Columns.Add("Qty", typeof(double));
                dtdetailhistory.Columns.Add("Rate");
                dtdetailhistory.Columns.Add("Amount", typeof(double));
                for (int i = 0; i < dbdetail.Count; i++)
                {
                    dtdetailhistory.Rows.Add(dbdetail[i].Category_Name, dbdetail[i].Item_Name, dbdetail[i].ItemQty, dbdetail[i].ItemRate, dbdetail[i].ItemAmount);
                }
                grdHistoryDetail.DataSource = dtdetailhistory;
                grdHistoryDetail.RetrieveStructure();
                HistorydetailSetting();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void HistorydetailSetting()
        {
            try
            {
                grdHistoryDetail.RootTable.Columns["Amount"].EditType = EditType.NoEdit;
                grdHistoryDetail.RootTable.Columns["Product"].EditType = EditType.NoEdit;
                grdHistoryDetail.RootTable.Columns["Qty"].EditType = EditType.NoEdit;
                grdHistoryDetail.RootTable.Columns["Rate"].EditType = EditType.NoEdit;
                grdHistoryDetail.RootTable.Columns["Category"].EditType = EditType.NoEdit;

                grdHistoryDetail.RootTable.Columns["Product"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Qty"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Rate"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Amount"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Category"].FilterEditType = FilterEditType.TextBox;

                grdHistoryDetail.RootTable.Columns["Category"].Width = 200;
                grdHistoryDetail.RootTable.Columns["Product"].Width = 300;
                grdHistoryDetail.RootTable.Columns["Qty"].Width = 100;
                grdHistoryDetail.RootTable.Columns["Rate"].Width = 100;
                grdHistoryDetail.RootTable.Columns["Amount"].Width = 100;

                grdHistoryDetail.RootTable.Columns["Qty"].AggregateFunction = AggregateFunction.Sum;
                grdHistoryDetail.RootTable.Columns["Amount"].AggregateFunction = AggregateFunction.Sum;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPurchaseReturn_KeyDown(object sender, KeyEventArgs e)
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
                        //btnUpdate_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
