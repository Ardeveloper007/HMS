using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Sale
{
    public partial class frmSale : Form
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
        int PaymentId = 0;
        public frmSale( UserAccount getuser)
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
            dtGrid.Columns.Add("CatId");
            dtGrid.Columns.Add("Category");
            dtGrid.Columns.Add("ProId");
            dtGrid.Columns.Add("Product");
            dtGrid.Columns.Add("Qty",typeof(double));
            dtGrid.Columns.Add("Rate", typeof(double));
            dtGrid.Columns.Add("Saleprice", typeof(double));
            dtGrid.Columns.Add("Amount", typeof(double));
            dtGrid.Columns.Add("ExpiryDate");
            History();
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


        #endregion

        #region CRUD
        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
            GetCode();
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
                if (chkPostVoucher.Checked == true)
                {
                    GetAccFromconfig();
                    if (PaymentId > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Please Set Configuration First ...");
                        frmConfigurations frm = new frmConfigurations(user);
                        frm.Show();
                        return;
                    }
                }
                    GetCode();
                tbl_SaleMaster master = new tbl_SaleMaster();
               master.OrderNo=txtPO.Text.ToString();
                master.ManualBillNo = txtBillNo.Text;
                master.DocumentTypeId = 1;
                master.DocDate = DateTime.Now;
                master.SupplierCustomerId = Numerics.GetInt(ddlSupplierCustomer.Value);
                master.BillAmount = Numerics.GetDouble(txtTotal.Text);
                master.Remarks = "";
                master.Entry_Date = DateTime.Now;
                master.Modify_Date= DateTime.Now;
                master.Entry_User = user.Id;
                master.Modify_User = user.Id;
                master.Company_Id = user.CompanyId;
                master.Branch_Id = user.BranchId;
                master.tbl_SaleDetail = new List<tbl_SaleDetail>();
                foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                {
                    tbl_SaleDetail detail = new tbl_SaleDetail();
                    detail.SaleMaster_Id = master.Id;
                    detail.CategoryId = Numerics.GetInt(r.Cells["CatId"].Value);
                    detail.ItemId = Numerics.GetInt(r.Cells["ProId"].Value);
                    detail.ItemQty = Numerics.GetInt(r.Cells["Qty"].Value);
                    detail.ItemRate = Numerics.GetDouble(r.Cells["Rate"].Value);
                    detail.ItemAmount = Numerics.GetDouble(r.Cells["Amount"].Value);
                    detail.UnitRate = Numerics.GetDouble(r.Cells["SalePrice"].Value);
                    detail.ExpiryDate = Convert.ToDateTime(r.Cells["ExpiryDate"].Value);
                    detail.BillAmount = Numerics.GetDouble(txtTotal.Text);
                    detail.RemarksDetail = "";
                    master.tbl_SaleDetail.Add(detail);
                }
                db.tbl_SaleMaster.Add(master);
                db.SaveChanges();
                int scId = Numerics.GetInt(ddlSupplierCustomer.Value);
               
                var getMaxId = db.tbl_PurchaseMaster.OrderByDescending(x => x.Id).ToList();
                if (getMaxId.Count > 0)
                {
                    if (getMaxId[0].Id > checkid)
                    {
                        tblVoucherHead head = new tblVoucherHead();
                        head.DocumentType_Id = 5;
                        head.RefDocTypeId = 2;
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
                            vd.COA_Id = getAccountId[0].SaleAccount;
                            vd.Against_COA_Id = SPGLId;
                            vd.Comments = "Product Credit for Sale";
                            vd.DebitAmount = 0;
                            vd.CreditAmount = Numerics.GetDouble(r.Cells["Amount"].Value); ;
                            vd.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                            vd.ChequeNo = "";
                            head.tblVoucherDetails.Add(vd);

                            tblVoucherDetail vd1 = new tblVoucherDetail();
                            vd1.Voucher_Head_Id = head.Id;
                            vd1.Against_COA_Id = getAccountId[0].SaleAccount;
                            vd1.COA_Id = SPGLId;
                            vd1.Comments = "Cutomer Debit for sale";
                            vd1.CreditAmount = 0;
                            vd1.DebitAmount = Numerics.GetDouble(r.Cells["Amount"].Value);
                            vd1.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                            vd1.ChequeNo = "";
                            head.tblVoucherDetails.Add(vd1);
                        }
                        if(chkPostVoucher.Checked == true)
                        {
                            GetAccFromconfig();
                            if (PaymentId > 0)
                            {
                                tblVoucherDetail vd2 = new tblVoucherDetail();
                                vd2.Voucher_Head_Id = head.Id;
                                vd2.Against_COA_Id = PaymentId;
                                vd2.COA_Id = SPGLId;
                                vd2.Comments = "Amount Deduted From Supplier A/C from Sale";
                                vd2.DebitAmount = Numerics.GetDouble(txtPaid.Text);
                                vd2.CreditAmount = 0;
                                // vd2.Item_Id = Numerics.GetInt(r.Cells["ProId"].Value);
                                vd2.ChequeNo = "";
                                head.tblVoucherDetails.Add(vd2);

                                tblVoucherDetail vd3 = new tblVoucherDetail();
                                vd3.Voucher_Head_Id = head.Id;
                                vd3.COA_Id = PaymentId;
                                vd3.Against_COA_Id = SPGLId;
                                vd3.Comments = "Amount Added To Cash in Hand from Sale";
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
                            transaction.RefDocumentTypeId = 2;
                            transaction.RefDocIdNo = getMaxId[0].Id;
                            transaction.CategoryId = Numerics.GetInt(r.Cells["CatId"].Value);
                            transaction.ItemId = Numerics.GetInt(r.Cells["ProId"].Value);
                            transaction.QtyIn = 0;
                            transaction.QtyOut = Numerics.GetInt(r.Cells["Qty"].Value);
                            transaction.ItemRate = Numerics.GetDouble(r.Cells["Rate"].Value);
                            transaction.ExpiryDate = Convert.ToDateTime(r.Cells["ExpiryDate"].Value);
                            transaction.Remarks = "";
                            transaction.SupplierCustomerId = Numerics.GetInt(ddlSupplierCustomer.Value);
                            db.tbl_InventoryTransaction.Add(transaction);
                            db.SaveChanges();
                        }
                        
                        MessageBox.Show("Save Successfully");
                        if(chkIsPrintInvoice.Checked==true)
                        {
                            PrintInvoice();
                        }
                        ResetForm();
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

        private void GetCode()
        {
           
            try
            {
                int PONo = 0;
                var PO = db.tbl_SaleMaster.OrderByDescending(x => x.Id).ToList();
                if (PO.Count > 0)
                {
                    string purchaseNumber = PO[0].OrderNo.ToString();
                    int count = int.Parse(purchaseNumber.Trim(new Char[] { 'S', 'O', '-' })) + 1;
                    txtPO.Text = "SO-" + count;
                }
                else
                {
                    txtPO.Text = "SO-1";
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

        #region Double Click Event 

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetails() && ChkGrid())
                {
                    if (Numerics.GetDouble(txtunitPrice.Text) < Numerics.GetDouble(txtpurchase.Text))
                    {
                        MessageBox.Show("Sale Price Must be Greter from Purchase Price");
                        txtunitPrice.Text = "0";
                        txtunitPrice.Focus();
                        return;
                    }
                    dtGrid.Rows.Add
                        (
                        
                       Numerics.GetInt(ddlCategory.Value),
                        ddlCategory.Text,
                        Numerics.GetInt(ddlProduct.Value),
                        ddlProduct.Text,
                        Numerics.GetDouble(txtQty.Text),
                        Numerics.GetDouble(txtAmountPerPack.Text),
                        Numerics.GetDouble(txtunitPrice.Text),
                        Numerics.GetDouble(txtTotalAmount.Text),
                        Convert.ToDateTime(txtexpirydate.Value).ToString("dd-MMM-yyyy")
                        );
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
                txtremainqty.Text = string.Empty;
                txttotalAvailable.Text = string.Empty;
                //txtTotalQty.Text = string.Empty;
                ddlCategory.Focus();
                txtexpirydate.Value = System.DateTime.Now;
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
            grddetail.RootTable.Columns["Saleprice"].EditType = EditType.TextBox;
            grddetail.RootTable.Columns["Amount"].EditType = EditType.TextBox;
            grddetail.RootTable.Columns["ExpiryDate"].EditType = EditType.TextBox;

            grddetail.RootTable.Columns["Category"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Product"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Qty"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Rate"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Saleprice"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["Amount"].FilterEditType = FilterEditType.TextBox;
            grddetail.RootTable.Columns["ExpiryDate"].FilterEditType = FilterEditType.TextBox;

            grddetail.RootTable.Columns["Category"].Width = 200;
            grddetail.RootTable.Columns["Product"].Width = 350;
            //grddetail.RootTable.Columns["PackQty"].Width = 100;
            grddetail.RootTable.Columns["Rate"].Width = 100;
            grddetail.RootTable.Columns["Amount"].Width = 100;
            grddetail.RootTable.Columns["Saleprice"].Width = 100;
            grddetail.RootTable.Columns["ExpiryDate"].Width = 130;

            grddetail.RootTable.Columns["Qty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
            grddetail.RootTable.Columns["Amount"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;

            grddetail.RootTable.Columns.Add("Delete");
            grddetail.RootTable.Columns["Delete"].Key = "Delete";
            grddetail.RootTable.Columns["Delete"].Caption = "Delete";
            grddetail.RootTable.Columns["Delete"].ButtonDisplayMode = Janus.Windows.GridEX.CellButtonDisplayMode.Always;
            grddetail.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
            grddetail.RootTable.Columns["Delete"].ButtonText = "Delete";

            string sumof = this.grddetail.GetTotal(this.grddetail.RootTable.Columns["Amount"], Janus.Windows.GridEX.AggregateFunction.Sum).ToString();
            var aa = double.Parse(sumof);
            txtTotal.Text = Math.Round(aa).ToString();
            //ctrlGrdBar1_Load(null, null);
        }

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
                double packqty = Numerics.GetDouble(txtPackQty.Text);
                double packRate = Numerics.GetDouble(txtAmountPerPack.Text);
                if(packqty!=0 && packqty!=null && packqty>0 && packRate!=0 && packRate!=null && packRate>0)
                {
                    txtpurchase.Text = ( packRate / packqty).ToString();
                }
               else
                {
                    //MessageBox.Show("Something Wrong Please Try Again...");
                    return;
                }
                //double qty= Numerics.GetInt(txtQty.Text);
                //if(qty!=0 && qty !=null && qty>0 && Numerics.GetDouble(txtunitPrice.Text)!=0 && txtunitPrice.Text!=string.Empty && Numerics.GetDouble(txtunitPrice.Text)>0)
                //{
                //    txtTotalAmount.Text = Math.Round((qty * Numerics.GetDouble(txtunitPrice.Text)), 2).ToString();
                //}
                //else
                //{

                //    txtTotalAmount.Text = "";
                //    //MessageBox.Show("Something Wrong Please Try Again...");
                //    return;
                //}
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != string.Empty)
                {

                    if (Numerics.GetInt(txtQty.Text) <= Numerics.GetInt(txtremainqty.Text))
                    {
                        double qty = Numerics.GetInt(txtQty.Text);
                        if (qty != 0 && qty != null && qty > 0 && Numerics.GetDouble(txtunitPrice.Text) != 0 && txtunitPrice.Text != string.Empty && Numerics.GetDouble(txtunitPrice.Text) > 0)
                        {
                            txtTotalAmount.Text = Math.Round((qty * Numerics.GetDouble(txtunitPrice.Text)), 2).ToString();
                        }
                        else
                        {
                            txtTotalAmount.Text = "";
                            //MessageBox.Show("Something Wrong Please Try Again...");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Qty is Greater than Remaining qty");
                        return;
                    }
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
                    RateGet();
                    GetRemainingQty();
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

        public void RateGet()
        {
            try
            {
                if (ddlProduct.Text != string.Empty) 
                {
                    int CatId = Numerics.GetInt(ddlCategory.Value);
                    int PId = Numerics.GetInt(ddlProduct.Value);
                    var lastmonth = System.DateTime.Now.AddMonths(1);
                    var getprice = (from detail in db.tbl_PurchaseDetail
                                    join itemalo in db.tbl_Item_Allocation on detail.ItemId equals itemalo.Id
                                    join item in db.tbl_Item_Def on itemalo.Item_Id equals item.Id
                                    join inv in db.tbl_InventoryTransaction on detail.ItemId equals inv.ItemId 
                                    
                                    where detail.CategoryId==CatId && detail.ItemId==PId && detail.ExpiryDate> lastmonth
                                    select new
                                    {
                                        detail.ItemRate,item.PackQty

                                        }).ToList();

                    if (getprice.Count>0)
                    {
                        txtAmountPerPack.Text = getprice[0].ItemRate.ToString();
                        txtPackQty.Text = getprice[0].PackQty.ToString();
                        Calculations();
                    }
                    else
                    {
                        txtAmountPerPack.Text = "";
                        txtPackQty.Text = "";
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetRemainingQty()
        {
            try
            {
                if (ddlProduct.Text != string.Empty)
                {
                    int CatId = Numerics.GetInt(ddlCategory.Value);
                    int PId = Numerics.GetInt(ddlProduct.Value);
                    var oneMonth = System.DateTime.Now.AddMonths(1);
                    var getStock = db.GetExpiryWiseProductForSale(PId).Where(x=> x.ExpiryDate >= oneMonth).ToList();
                    if (getStock.Count > 0)
                    {
                        txtremainqty.Text = (Numerics.GetInt(getStock[0].AvailableQty)).ToString();
                        txtexpirydate.Value = Convert.ToDateTime(getStock[0].ExpiryDate);
                        txttotalAvailable.Text= getStock.Sum(x => x.AvailableQty).ToString();
                        Calculations();
                    }
                    else
                    {
                        txtAmountPerPack.Text = "";
                        txtPackQty.Text = "";
                        txtRemaining.Text = "0";

                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSale_KeyDown(object sender, KeyEventArgs e)
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


        public void History()
        {
            try
            {
                var history = (from h in db.tbl_SaleMaster
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
                var dbdetail = (from d in db.tbl_SaleDetail
                                join
c in db.tblCategories on d.CategoryId equals c.Id
                                join alo in db.tbl_Item_Allocation on d.ItemId equals alo.Id
                                join i in db.tbl_Item_Def on alo.Item_Id equals i.Id
                                where d.SaleMaster_Id==rId
                                select new
                                {
                                    d.ItemQty,
                                    d.ItemRate,
                                    d.ItemAmount,
                                    d.UnitRate,
                                    d.RemarksDetail,
                                    i.Item_Name,
                                    c.Category_Name

                                }).ToList();
                DataTable dtdetailhistory = new DataTable();
                dtdetailhistory.Columns.Add("Category");
                dtdetailhistory.Columns.Add("Product");
                //dtdetailhistory.Columns.Add("PackRate");
                dtdetailhistory.Columns.Add("Qty", typeof(double));
                dtdetailhistory.Columns.Add("UnitRate");
                dtdetailhistory.Columns.Add("Amount", typeof(double));
                for (int i = 0; i < dbdetail.Count; i++)
                {
                    dtdetailhistory.Rows.Add(dbdetail[i].Category_Name, dbdetail[i].Item_Name, dbdetail[i].ItemQty, dbdetail[i].UnitRate,
                        dbdetail[i].ItemAmount);
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
                grdHistoryDetail.RootTable.Columns["UnitRate"].EditType = EditType.NoEdit;
                grdHistoryDetail.RootTable.Columns["Category"].EditType = EditType.NoEdit;

                grdHistoryDetail.RootTable.Columns["Product"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Qty"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["UnitRate"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Amount"].FilterEditType = FilterEditType.TextBox;
                grdHistoryDetail.RootTable.Columns["Category"].FilterEditType = FilterEditType.TextBox;

                grdHistoryDetail.RootTable.Columns["Category"].Width = 200;
                grdHistoryDetail.RootTable.Columns["Product"].Width = 300;
                grdHistoryDetail.RootTable.Columns["Qty"].Width = 100;
                grdHistoryDetail.RootTable.Columns["UnitRate"].Width = 100;
                grdHistoryDetail.RootTable.Columns["Amount"].Width = 100;

                grdHistoryDetail.RootTable.Columns["Qty"].AggregateFunction = AggregateFunction.Sum;
                grdHistoryDetail.RootTable.Columns["Amount"].AggregateFunction = AggregateFunction.Sum;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ResetForm()
        {
            GetCode();
            ddlSupplierCustomer.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtPaid.Text = string.Empty;
            txtRemaining.Text = string.Empty;
            grddetail.ClearStructure();
            dtGrid.Clear();
            ResetDetails();
            History();
        }


        public void PrintInvoice()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }

        }
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var getcompany = (from c in db.tblCompanies
                              join
   u in db.AspNetUsers on c.Company_Id equals u.CompanyId
                              where u.Id == user.Id
                              select new { 
                              c.Name,c.Address,c.PhoneNo
                              }).ToList();
            //this prints the reciept
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString(getcompany[0].Name.PadLeft(20), new Font("Courier New", 15, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
            //graphic.DrawString("  Phone#: (055) 4551300", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight;
            graphic.DrawString("Mobile#:"+getcompany[0].PhoneNo, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(getcompany[0].Address, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight;
            //graphic.DrawString("      Gujranwala", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString("         SO#: " + txtPO.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(" Customer: " + ddlSupplierCustomer.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(" Date: " + System.DateTime.Now, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            string top = "Product".PadRight(10) + "Qty".PadLeft(5) + "Price".PadLeft(10)+ "Amount".PadLeft(10); ;
            graphic.DrawString(top, new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("--------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent
            foreach (Janus.Windows.GridEX.GridEXRow item in grddetail.GetRows())
            {
              
                //create the string to print on the reciept
              //  string productCompany = item.Cells["Category"].Value.ToString();
                string productDescription = item.Cells["Product"].Value.ToString();
                string productTotal = item.Cells["Qty"].Value.ToString();
                float productPrice = float.Parse(item.Cells["SalePrice"].Value.ToString());
                float Amount = float.Parse(item.Cells["Amount"].Value.ToString());
                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);
                if (productDescription.Contains("  -"))
                {
                    //string productLine = productDescription.Substring(0, 24);
                    string productLine =  productDescription.PadRight(5) + productTotal.PadLeft(5) + productPrice.ToString().PadLeft(10) + Amount.ToString().PadLeft(10);

                    graphic.DrawString(productLine, new Font("Courier New", 8), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    //string productLine = productDescription;
                    string productLine =  productDescription.PadRight(5) + productTotal.PadLeft(5) + productPrice.ToString().PadLeft(10) + Amount.ToString().PadLeft(10);

                    graphic.DrawString(productLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }
            //when we have drawn all of the items add the total
            offset = offset + 20; //make some room so that the total stands out.
            graphic.DrawString("Total to pay".PadRight(22) + txtTotal.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15; //make some room so that the total stands out.
            string Remaining = double.Parse(txtRemaining.Text).ToString();
            graphic.DrawString("Remaining".PadRight(22) + Remaining, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30;
            graphic.DrawString("Total Paid".PadRight(22) + txtPaid.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("--------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15; //make some room so that the total stands out.
            graphic.DrawString("Thank-you for visiting us,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("  Please come back soon!", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("--------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("     By Innovative Coterie", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("        0301-4005752", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtunitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != string.Empty && txtunitPrice.Text!=string.Empty)
                {
                    if (Numerics.GetInt(txtQty.Text) <= Numerics.GetInt(txtremainqty.Text))
                    {
                        
                        double qty = Numerics.GetInt(txtQty.Text);
                        if (qty != 0 && qty != null && qty > 0 && Numerics.GetDouble(txtunitPrice.Text) != 0 && txtunitPrice.Text != string.Empty && Numerics.GetDouble(txtunitPrice.Text) > 0)
                        {
                            txtTotalAmount.Text = Math.Round((qty * Numerics.GetDouble(txtunitPrice.Text)), 2).ToString();
                        }
                        else
                        {
                            txtTotalAmount.Text = "";
                            //MessageBox.Show("Something Wrong Please Try Again...");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Qty is Greater than Remaining qty");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
