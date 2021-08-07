using HMS.Data;
using HMS.Utills;
using Janus.Windows.GridEX;
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
    public partial class frmDefineCategory : Form
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
        UserAccount user = new UserAccount();
        tblCategory category = new tblCategory();
        public frmDefineCategory(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        #region Load
        private void frmDefineCategory_Load(object sender, EventArgs e)
        {
            
                gridBind();
                txtCategory.Focus();
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

        #region Validation and Form Reset
        private bool FormValidation()
        {
            if (txtCategory.Text.Trim() == "")
            {
                MessageBox.Show("Category Field is Required");
                txtCategory.Focus();
                return false;
            }

            return true;
        }
        private void ResetForm()
        {
            txtCategory.Text = string.Empty;
            gridBind();
            txtCategory.Focus();
            RecId = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            category = new tblCategory();
        }

        #endregion

        #region CRUD

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
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
                category.Category_Name = txtCategory.Text.Trim();
                category.Entry_Date = DateTime.Now;
                category.Entry_User = user.Id;
                if (RecId > 0)
                    db.Entry(category).State = EntityState.Modified;
                else
                {
                    db.tblCategories.Add(category);
                }

                db.SaveChanges();
                MessageBox.Show("Operation  Successfully Complete...");
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ResetForm();
            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave_Click(null, null);

                //if (!FormValidation())
                //{
                //    return;
                //}
                //DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.No)
                //{
                //    return;
                //}
                //tblCategory category = new tblCategory();
                //category.Id = RecId;
                //category.Category_Name = txtCategory.Text.Trim();
                //category.Entry_Date = DateTime.Now;
                //category.Entry_User = user.Id;
                //db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                ////object p = db.EntityState.Modify();
                ////db.tblCategories.Add(category);
                ////db.SaveChanges();
                //MessageBox.Show("Save Successfully");
                //ResetForm();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void gridBind()
        {
            try
            {
                var cat = db.tblCategories.ToList();
                DataTable dtcat = new DataTable();
                if (cat.Count > 0)
                {
                    dtcat.Columns.Add("Id");
                    dtcat.Columns.Add("Category");
                    foreach (var item in cat)
                    {
                        dtcat.Rows.Add(item.Id, item.Category_Name);
                    }

                    grdCategory.DataSource = dtcat;
                    grdCategory.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grdCategory.ClearStructure();
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
                grdCategory.RootTable.Columns["Id"].Visible = false;
                grdCategory.RootTable.Columns["Category"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCategory.RootTable.Columns["Category"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCategory.RootTable.Columns["Category"].Width = 250;

                grdCategory.RootTable.Columns.Add("Delete");
                grdCategory.RootTable.Columns["Delete"].Key = "Delete";
                grdCategory.RootTable.Columns["Delete"].Caption = "Delete";
                grdCategory.RootTable.Columns["Delete"].ButtonDisplayMode = Janus.Windows.GridEX.CellButtonDisplayMode.Always;
                grdCategory.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                grdCategory.RootTable.Columns["Delete"].ButtonText = "Delete";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Double Click  and Column Button click
        private void grdCategory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                RecId = Numerics.GetInt(grdCategory.CurrentRow.Cells[0].Value);
                category = db.tblCategories.Where(x => x.Id == RecId).FirstOrDefault();
                if (category != null)
                {
                    txtCategory.Text = category.Category_Name;
                    
                    if (DoHaveUpdateRights == true)
                    {
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("You can not Edit the Record...");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Some thing Wrong !!!");
                    ResetForm();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void grdCategory_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Delete?", "Confirm", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                if (e.Column.Key == "Delete")
                {
                    GridEXRow item = grdCategory.CurrentRow;
                    if (item != null && item.RowType == RowType.Record)
                    {
                        int id = int.Parse(item.Cells["Id"].Value.ToString());
                        var cat = db.tblCategories.FirstOrDefault(x => x.Id == id);
                        db.tblCategories.Remove(cat);
                        db.SaveChanges();
                        //Delete the row.
                        item.Delete();
                        MessageBox.Show("Record Deleted Successfully");

                    }
                    grdCategory.UpdateData();
                    gridBind();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region ShortCut Keys
        private void frmDefineCategory_KeyDown(object sender, KeyEventArgs e)
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

        #region Leave Event
        private void txtCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCategory.Text != string.Empty)
                {
                    var getcat = db.tblCategories.Where(x => x.Category_Name == txtCategory.Text.Trim()).ToList();
                    if (getcat.Count > 0)
                    {
                        MessageBox.Show("Already Exist! Please Try Again");
                        return;
                    }
                    else
                    {
                        btnSave_Click(null, null);
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
            Close();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmAddItem addItem = new frmAddItem(user);
            this.Hide();
            addItem.Show();
        }
    }
}

