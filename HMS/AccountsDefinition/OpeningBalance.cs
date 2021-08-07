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

namespace HMS.AccountsDefinition
{
    public partial class OpeningBalance : Form
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
        int RecId = 0;
        tblCOAOpeningBalance balance = new tblCOAOpeningBalance();
        UserAccount user = new UserAccount();

        public OpeningBalance(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        #region Load
        private void OpeningBalance_Load(object sender, EventArgs e)
        {
            BindAccount();
            GridBind();
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

        #region Combo Fill
        private void BindAccount()
        {
            try
            {
                DataTable dtCOa = new DataTable();
                dtCOa.Columns.Add("Id");
                dtCOa.Columns.Add("AccountTitle");
                
                var accountFormCoa = (from coa in db.tblCOAs
                                      join ob in db.tblCOAOpeningBalances on coa.Id equals ob.COA_Id
                                      orderby ob.Id
                                      select new
                                      {
                                          ob.Id,
                                          coa.Account_Title,
                                          
                                      }).ToList();
                
                dtCOa.Rows.Clear();
                foreach (var item in accountFormCoa)
                {
                    dtCOa.Rows.Add(item.Id, item.Account_Title);
                }
                if (dtCOa.Rows.Count > 0)
                {
                    DDL.BindDDL(dtCOa, cmbAccountTitle, "Id", "AccountTitle", "AccountTitle", false);
                }
                else
                {
                    cmbAccountTitle.Text = string.Empty;
                    cmbAccountTitle.DataSource = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        #endregion

        #region Validation and Reset 
        private bool FormValidation()
        {
            if (cmbAccountTitle.Text.Trim() == "")
            {
                MessageBox.Show("Title Field is Required");
                cmbAccountTitle.Focus();
                return false;
            }
            if (txtDebit.Text.Trim() == "" || txtCredit.Text.Trim() == "")
            {
                MessageBox.Show("Credit Or Debit Field is Required");
                return false;
            }
            return true;
        }
        private void ResetForm()
        {
            cmbAccountTitle.Text = string.Empty;
            txtCredit.Clear();
            txtDebit.Clear();
            GridBind();
            cmbAccountTitle.Focus();
            RecId = 0;
        }


        #endregion

        #region CRUD

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                BindAccount();
                GridBind();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                
                //balance.Id = RecId;
                balance.COA_Id = Numerics.GetInt(txtAcId.Text);
                balance.Credit = Numerics.GetDouble(txtCredit.Text);
                balance.Debit = Numerics.GetDouble(txtDebit.Text);
                balance.Entry_User = user.Id;
                balance.Entry_Date = DateTime.Now;
                balance.Modify_User = user.Id;
                balance.Modify_Date = DateTime.Now;
                //db.tblCOAOpeningBalances.Add(balance);

                db.Entry(balance).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Save Successfully");
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GridBind()
        {
            try
            {
                var grd = (from coa in db.tblCOAs
                                      join ob in db.tblCOAOpeningBalances on coa.Id equals ob.COA_Id
                                      orderby ob.Id
                                      select new
                                      {
                                          ob.Id,
                                          coa.Account_Code,
                                          coa.Account_Title,
                                          ob.Credit,
                                          ob.Debit,ob.Entry_Date,
                                          ob.Entry_User,

                                      }).ToList();
                DataTable dtgridBind = new DataTable();
                dtgridBind.Columns.Add("Id");
                dtgridBind.Columns.Add("AccountCode");
                dtgridBind.Columns.Add("AccountTitle");
                dtgridBind.Columns.Add("CreditAmount",typeof(double));
                dtgridBind.Columns.Add("DebitAmount", typeof(double));
                foreach (var item in grd)
                {
                    dtgridBind.Rows.Add(item.Id, item.Account_Code,item.Account_Title,item.Credit,item.Debit);
                }
                if(dtgridBind.Rows.Count>0)
                {
                    grdOpeningBalance.DataSource = dtgridBind;
                    grdOpeningBalance.RetrieveStructure();
                    GridSetting();
                }   
                else
                {
                    grdOpeningBalance.ClearStructure();
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
                grdOpeningBalance.RootTable.Columns["Id"].Visible = false;
                grdOpeningBalance.RootTable.Columns["AccountCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdOpeningBalance.RootTable.Columns["AccountTitle"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdOpeningBalance.RootTable.Columns["CreditAmount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdOpeningBalance.RootTable.Columns["DebitAmount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdOpeningBalance.RootTable.Columns["AccountCode"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdOpeningBalance.RootTable.Columns["AccountTitle"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdOpeningBalance.RootTable.Columns["CreditAmount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdOpeningBalance.RootTable.Columns["DebitAmount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdOpeningBalance.RootTable.Columns["AccountCode"].Width = 200;
                grdOpeningBalance.RootTable.Columns["AccountTitle"].Width = 200;
                grdOpeningBalance.RootTable.Columns["CreditAmount"].Width = 100;
                grdOpeningBalance.RootTable.Columns["DebitAmount"].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Double Click Event
        private void grdOpeningBalance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int getId = Numerics.GetInt(grdOpeningBalance.CurrentRow.Cells[0].Value);
                GetById(getId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetById(int Id)
        {
            try
            {
                balance = db.tblCOAOpeningBalances.Where(x => x.Id == Id).FirstOrDefault();
                if (balance != null)
                {
                    txtAcId.Text = balance.COA_Id.ToString();
                    txtDebit.Text = balance.Debit.ToString();
                    txtCredit.Text = balance.Credit.ToString();
                    cmbAccountTitle.Value = balance.Id;
                    RecId = Id;
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

        #region ShortCut Key
        private void OpeningBalance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == System.Windows.Forms.Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
                if (e.Control && e.KeyCode == Keys.U)
                {
                    btnUpdate_Click(null, null);
                }
                if (e.Control && e.KeyCode == Keys.N)
                {
                    btnNew_Click(null, null);
                }
                if (e.Control && e.KeyCode == Keys.E)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Text Changed Event
        private void txtDebit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCredit.Focused)
                {
                    txtCredit.Text = "";
                }
                else
                    txtCredit.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtCredit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtDebit.Focused)
                    txtDebit.Text = "";
                else
                    txtDebit.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Close
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



        #endregion

        #region Leave Event
        private void cmbAccountTitle_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbAccountTitle.Text != string.Empty.Trim())
                {
                    int accIdd = Numerics.GetInt(cmbAccountTitle.Value);
                    txtAcId.Text= accIdd.ToString(); 
                    RecId = accIdd;
                    GetById(accIdd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpdate_Click(null, null);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
