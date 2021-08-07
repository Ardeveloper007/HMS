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
    public partial class ItemAllocation : Form
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
        tbl_Item_Def def = new tbl_Item_Def();
        DropDownBinding DDL = new DropDownBinding();
        UserAccount user = new UserAccount();
        tbl_Item_Allocation item_Allocation = new tbl_Item_Allocation();
        public ItemAllocation(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        #region Load
        private void ItemAllocation_Load(object sender, EventArgs e)
        {
            ItemBind();
            PurchaseAccBind();
            SaleAccBind();
            CgsAccBind();
            GridFill();
            cmbItem.Focus();
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

        #region Combo FIll
        public void ItemBind()
        {
            try
            {
                var item = db.tbl_Item_Def.ToList();
                DataTable dtitem = new DataTable();
                if(item.Count>0)
                {
                    dtitem.Columns.Add("Id");
                    dtitem.Columns.Add("ItemName");
                    foreach (var a in item)
                    {

                        dtitem.Rows.Add(a.Id, a.Item_Name);
                    }
                    if(dtitem.Rows.Count>0)
                    {
                        DDL.BindDDL(dtitem, cmbItem, "Id", "ItemName", "Item Name", false);
                    }
                    else
                    {
                        cmbItem.Text = string.Empty;
                        cmbItem.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
        public void PurchaseAccBind()
        {
            try
            {
                var item = db.tblCOAs.ToList();
                DataTable dtPurchaseAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtPurchaseAcc.Columns.Add("Id");
                    dtPurchaseAcc.Columns.Add("PurchaseAccount");
                    foreach (var a in item)
                    {

                        dtPurchaseAcc.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtPurchaseAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtPurchaseAcc, cmbPurchaseAccount, "Id", "PurchaseAccount", "Purchase Account", false);
                    }
                    else
                    {
                        cmbPurchaseAccount.Text = string.Empty;
                        cmbPurchaseAccount.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SaleAccBind()
        {
            try
            {
                var item = db.tblCOAs.ToList();
                DataTable dtSaleAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtSaleAcc.Columns.Add("Id");
                    dtSaleAcc.Columns.Add("SaleAccount");
                    foreach (var a in item)
                    {

                        dtSaleAcc.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtSaleAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtSaleAcc, cmbSaleAccount, "Id", "SaleAccount", "Sale Account", false);
                    }
                    else
                    {
                        cmbSaleAccount.Text = string.Empty;
                        cmbSaleAccount.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CgsAccBind()
        {
            try
            {
                var item = db.tblCOAs.ToList();
                DataTable dtcgs = new DataTable();
                if (item.Count > 0)
                {
                    dtcgs.Columns.Add("Id");
                    dtcgs.Columns.Add("COGSAccount");
                    foreach (var a in item)
                    {

                        dtcgs.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtcgs.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtcgs, cmbCOGSAccount, "Id", "COGSAccount", "COGS Account", false);
                    }
                    else
                    {
                        cmbCOGSAccount.Text = string.Empty;
                        cmbCOGSAccount.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Validation and Reset Form

        private bool FormValidation()
        {
            if (cmbItem.Text.Trim() == "")
            {
                MessageBox.Show("Item Field is Required");
                cmbItem.Focus();
                return false;
            }
            if (cmbPurchaseAccount.Text.Trim() == "")
            {
                MessageBox.Show("Purchase Acccount Field is Required");
                cmbPurchaseAccount.Focus();
                return false;
            }
            if (cmbSaleAccount.Text.Trim() == "")
            {
                MessageBox.Show("Sale Account Field is Required");
                cmbSaleAccount.Focus();
                return false;
            }
            if (cmbCOGSAccount.Text.Trim() == "")
            {
                MessageBox.Show("CGS Account Field is Required");
                cmbCOGSAccount.Focus();
                return false;
            }
            return true;
        }

        public void FormReset()
        {
            cmbItem.Text = string.Empty;
            cmbPurchaseAccount.Text = string.Empty;
            cmbSaleAccount.Text = string.Empty;
            cmbCOGSAccount.Text = string.Empty;
            RecId = 0;
            item_Allocation = new tbl_Item_Allocation();
            GridFill();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            cmbItem.Focus();
        }
        #endregion

        #region CRUD
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormReset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidation())
                {
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                item_Allocation.Item_Id = Numerics.GetInt(cmbItem.Value);
                item_Allocation.PurchaseAccount = Numerics.GetInt(cmbPurchaseAccount.Value);
                item_Allocation.SaleAccount = Numerics.GetInt(cmbSaleAccount.Value);
                item_Allocation.COGSGLAC = Numerics.GetInt(cmbCOGSAccount.Value);
                if (RecId > 0)
                {
                    db.Entry(item_Allocation).State = EntityState.Modified;
                }
                else
                {
                    db.tbl_Item_Allocation.Add(item_Allocation);
                }

                db.SaveChanges();
                MessageBox.Show("Operation Perform Successfully...");
                FormReset();
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GridFill()
        {
            try
            {
                var allocationitem= (from alo in db.tbl_Item_Allocation
                                     join item in db.tbl_Item_Def on alo.Item_Id equals item.Id
                                     join coapurchase in db.tblCOAs on  alo.PurchaseAccount equals coapurchase.Id
                                     join coasale in db.tblCOAs on alo.SaleAccount equals coasale.Id
                                     join coaCGS in db.tblCOAs on alo.COGSGLAC equals coaCGS.Id
                                     select new
                                     {
                                         alo.Id,alo.Item_Id,alo.PurchaseAccount,alo.SaleAccount,alo.COGSGLAC,
                                         item.Item_Name,coapurchase.Account_Title,
                                          saleAccountTitle=coasale.Account_Title,
                                         cgsAccountTitle=coaCGS.Account_Title

                                     }).ToList();
                DataTable dtgrid = new DataTable();
                if(allocationitem.Count>0)
                {
                    dtgrid.Columns.Add("Id");
                    dtgrid.Columns.Add("Item");
                    dtgrid.Columns.Add("PurchaseAcc");
                    dtgrid.Columns.Add("SaleAccount");
                    dtgrid.Columns.Add("CGSAccount");

                    foreach (var r in allocationitem)
                    {
                        dtgrid.Rows.Add(r.Id, r.Item_Name, r.Account_Title, r.saleAccountTitle, r.cgsAccountTitle);
                    }
                    grdAllocationItem.DataSource = dtgrid;
                    grdAllocationItem.RetrieveStructure();
                    GridSetting();
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
                grdAllocationItem.RootTable.Columns["Item"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdAllocationItem.RootTable.Columns["PurchaseAcc"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdAllocationItem.RootTable.Columns["SaleAccount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdAllocationItem.RootTable.Columns["CGSAccount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdAllocationItem.RootTable.Columns["Id"].Visible = false;
                grdAllocationItem.RootTable.Columns["Item"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdAllocationItem.RootTable.Columns["PurchaseAcc"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdAllocationItem.RootTable.Columns["SaleAccount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdAllocationItem.RootTable.Columns["CGSAccount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdAllocationItem.RootTable.Columns["Item"].Width = 300;
                grdAllocationItem.RootTable.Columns["PurchaseAcc"].Width = 300;
                grdAllocationItem.RootTable.Columns["SaleAccount"].Width = 300; 
                grdAllocationItem.RootTable.Columns["CGSAccount"].Width = 300;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion

        #region Double click Event and Columns Button Click 
        private void grdAllocationItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                item_Allocation = new tbl_Item_Allocation();
                RecId = Numerics.GetInt(grdAllocationItem.CurrentRow.Cells[0].Value);
                item_Allocation = db.tbl_Item_Allocation.Where(x => x.Id == RecId).FirstOrDefault();
                if (item_Allocation != null)
                {
                    cmbItem.Value = item_Allocation.Item_Id;
                    cmbPurchaseAccount.Value = item_Allocation.PurchaseAccount;
                    cmbSaleAccount.Value = item_Allocation.SaleAccount;
                    cmbCOGSAccount.Value = item_Allocation.COGSGLAC;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    cmbItem.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region ShortCut Keys 

        #endregion


        #region Move To Item Form

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmAddItem addItem = new frmAddItem(user);
            this.Hide();
            addItem.Show();
        }

        #endregion

        private void ItemAllocation_KeyDown(object sender, KeyEventArgs e)
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
    }
}
