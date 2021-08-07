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
    public partial class frmAddItem : Form
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

        public frmAddItem(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        #region Load
        private void frmAddItem_Load(object sender, EventArgs e)
        {
            CategoryFill();
            GridFillItem();
            cmbCategory.Focus();
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
            btnAdd.Enabled = DoHaveSaveRight;
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

        public void CategoryFill()
        {
            try
            {
                var cat = db.tblCategories.ToList();
                DataTable dtcat = new DataTable();
                if(cat.Count>0)
                {
                    dtcat.Columns.Add("Id");
                    dtcat.Columns.Add("Category");

                    foreach (var item in cat)
                    {
                        dtcat.Rows.Add(item.Id, item.Category_Name);
                    }
                    if (dtcat.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtcat, cmbCategory, "Id", "Category", "Category", false);
                    }
                    else
                    {
                        cmbCategory.Text = string.Empty;
                        cmbCategory.DataSource = null;
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
            if (cmbCategory.Text.Trim() == "")
            {
                MessageBox.Show("Category Field is Required");
                cmbCategory.Focus();
                return false;
            }
            if (txtItemName.Text.Trim() == "")
            {
                MessageBox.Show("Item Name Field is Required");
                txtItemName.Focus();
                return false;
            }
            if (txtPackQty.Text.Trim() == "" )
            {
                MessageBox.Show("Pack qty Field is Required");
                txtPackQty.Focus();
                return false;
            }
            return true;
        }
        private void ResetForm()
        {
            txtItemName.Text = string.Empty;
            txtPackQty.Text = string.Empty;
            cmbCategory.Text = string.Empty;
            GridFillItem();
            btnUpdate.Visible = false;
            RecId = 0;
            btnSave.Visible = true;
            btnSave.Text = "Save";
            cmbCategory.Focus();
        }





        #endregion

        #region CRUD

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        public int GetItemPurchaseAccount()
        {
            int AccountId = 0;
            try
            {
                var getrec = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Item Purchase A/C");
                if (getrec != null)
                {
                    AccountId = Numerics.GetInt(getrec.Configration_Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return AccountId;
        }
        public int GetItemSaleAccount()
        {
            int AccountId = 0;
            try
            {
                var getrec = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Item Sale A/C");
                if (getrec != null)
                {
                    AccountId = Numerics.GetInt(getrec.Configration_Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return AccountId;
        }
        public int GetItemCGSAccount()
        {
            int AccountId = 0;
            try
            {
                var getrec = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Item CGS A/C");
                if (getrec != null)
                {
                    AccountId = Numerics.GetInt(getrec.Configration_Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return AccountId;
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
             
                def.Category_Id = Numerics.GetInt(cmbCategory.Value);
                def.Item_Name = txtItemName.Text;
                def.PackQty = Numerics.GetInt(txtPackQty.Text);
                def.Entry_Date = DateTime.Now;
                if (RecId > 0)
                {
                    db.Entry(def).State = EntityState.Modified;
                    db.SaveChanges();
                    var tbl_Item_Allocation = db.tbl_Item_Allocation.FirstOrDefault(x => x.Item_Id == RecId);
                    if (tbl_Item_Allocation != null)
                    {
                        tbl_Item_Allocation.PurchaseAccount = GetItemPurchaseAccount();
                        tbl_Item_Allocation.SaleAccount = GetItemSaleAccount();
                        tbl_Item_Allocation.COGSGLAC = GetItemCGSAccount();
                        db.Entry(tbl_Item_Allocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.tbl_Item_Def.Add(def);
                    db.SaveChanges();
                    var maxId = db.tbl_Item_Def.OrderByDescending(u => u.Id).FirstOrDefault();
                    var obj = new tbl_Item_Allocation();
                    obj.Item_Id = maxId.Id;
                    obj.PurchaseAccount = GetItemPurchaseAccount();
                    obj.SaleAccount = GetItemSaleAccount();
                    obj.COGSGLAC = GetItemCGSAccount();
                    db.tbl_Item_Allocation.Add(obj);
                    db.SaveChanges();
                }
            
                if (RecId > 0)
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Save Successfully");
                }
                ResetForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave_Click(null,null);
        }
        public  void GridFillItem()
        {
            try
            { 
                int cId = user.CompanyId;
                var grdfill = (from item in db.tbl_Item_Def
                               join cate in db.tblCategories on item.Category_Id equals cate.Id

                               select new
                               {
                                   item.Id,
                                   item.Item_Name,
                                   item.PackQty,
                                   item.Category_Id,
                                   item.Entry_Date,
                                   cate.Category_Name,

                               }).ToList();
                DataTable dtgrd = new DataTable();
                if(grdfill.Count>0)
                {
                    dtgrd.Columns.Add("Id");
                    dtgrd.Columns.Add("Category");
                    dtgrd.Columns.Add("ItemName");
                    dtgrd.Columns.Add("PackQty");

                    foreach (var item in grdfill)
                    {
                        dtgrd.Rows.Add(item.Id, item.Category_Name, item.Item_Name,item.PackQty);
                    }
                    grdItem.DataSource = dtgrd;
                    grdItem.RetrieveStructure();
                    gridsetting();
                }
                else
                {
                    grdItem.ClearStructure();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void gridsetting()
        {
            try
            {
                grdItem.RootTable.Columns["Id"].Visible = false;
                grdItem.RootTable.Columns["Category"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdItem.RootTable.Columns["ItemName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdItem.RootTable.Columns["PackQty"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdItem.RootTable.Columns["Category"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdItem.RootTable.Columns["ItemName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdItem.RootTable.Columns["PackQty"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdItem.RootTable.Columns["Category"].Width = 150;
                grdItem.RootTable.Columns["ItemName"].Width = 250;
                grdItem.RootTable.Columns["PackQty"].Width = 100;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Double Click 
        private void grdItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                RecId = Numerics.GetInt(grdItem.CurrentRow.Cells[0].Value);
                def = db.tbl_Item_Def.Where(x => x.Id == RecId).FirstOrDefault();
                txtItemName.Text = def.Item_Name;
                txtPackQty.Text = def.PackQty.ToString();
                cmbCategory.Value = def.Category_Id;
                if(DoHaveUpdateRights==true)
                {
                    btnUpdate.Enabled = DoHaveUpdateRights;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region ShortCut Keys
        private void frmAddItem_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAllocationItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.ItemAllocation allocation = new ItemAllocation(user);
            this.Hide();
            allocation.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmDefineCategory category = new frmDefineCategory(user);
            this.Hide();
            category.Show();
        }
    }
}
