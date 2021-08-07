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
    public partial class Voucher : Form
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
        tblVoucherHead head = new tblVoucherHead();
        int RecId = 0;
        public Voucher(UserAccount getuser)
        {
            InitializeComponent();
            user = getuser;
        }

        #region Load
        private void Voucher_Load(object sender, EventArgs e)
        {
            GetVouvherCode();
            CreditAccBind();
            DebitAccBind();
            ddlCreditAcc.Focus();
            GridHistory();
            dtGrid.Columns.Add("AccountId");
            dtGrid.Columns.Add("AccountTitle");
            dtGrid.Columns.Add("Comments");
            dtGrid.Columns.Add("AmountDr", typeof(double));
            dtGrid.Columns.Add("AmountCr", typeof(double));
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
            ctrlGrdBar1.mGridChooseFielder.Enabled = DoHaveFieldChooserRights;
            ctrlGrdBar1.mGridSaveLayouts.Enabled = DoHaveSaveLayoutRights;
            ctrlGrdBar1.mGridPrint.Enabled = DoHaveGridPrintRights;
            ctrlGrdBar1.mGridExport.Enabled = DoHaveGridExportRights;
            ctrlGrdBar1.GroupCollaps.Enabled = DoHaveGridGroupCollapseRights;
            ctrlGrdBar1.GroupExpand.Enabled = DoHaveGridGroupExpandRights;

        }
        #endregion


        #region Function
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
                    txtVoucherCode.Text = vouchercde.ToString();
                }
                else
                {
                    txtVoucherCode.Text = "100001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return vouchercde;
        }
        public void CreditAccBind()
        {
            try
            {
                var item = db.tblCOAs.Where(x=>x.IsActive==true).ToList();
                DataTable dtcreditAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtcreditAcc.Columns.Add("Id");
                    dtcreditAcc.Columns.Add("CreditAccount");
                    foreach (var a in item)
                    {

                        dtcreditAcc.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtcreditAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtcreditAcc, ddlCreditAcc, "Id", "CreditAccount", "Credit Account", false);
                    }
                    else
                    {
                        ddlCreditAcc.Text = string.Empty;
                        ddlCreditAcc.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DebitAccBind()
        {
            try
            {
                var item = db.tblCOAs.Where(x => x.IsActive == true).ToList();
                DataTable dtdebitAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtdebitAcc.Columns.Add("Id");
                    dtdebitAcc.Columns.Add("DebitAccount");
                    foreach (var a in item)
                    {

                        dtdebitAcc.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtdebitAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtdebitAcc, ddlDebitAcc, "Id", "DebitAccount", "Debit Account", false);
                    }
                    else
                    {
                        ddlDebitAcc.Text = string.Empty;
                        ddlDebitAcc.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ResetForm()
        {
            GetVouvherCode();
            CreditAccBind();
            DebitAccBind();
            txtVoucherAmount.Text = string.Empty;
            Save.Visible = true;
            btnUpdate.Visible = false;
            grddetail.ClearStructure();
            dtGrid.Clear();
            GridHistory();
            GetVouvherCode();
        }
        public void ResetDetail()
        {
            txtAmount.Text = string.Empty;
            txtCreditComment.Text = string.Empty;
            btnUpdateGridRecord.Visible = false;
            btnCleardetail.Visible = false;
            btnAdd.Visible = true;
            ddlCreditAcc.Focus();
            ddlCreditAcc.Text = string.Empty;
            ddlDebitAcc.Text = string.Empty;

        }



        #endregion

        #region Validation
        private bool FormValidation()
        {
            if (ddlDebitAcc.Text == string.Empty)
            {
                MessageBox.Show("Account Debit Field is Required");
                ddlDebitAcc.Focus();
                return false;
            }
            if (ddlCreditAcc.Text == string.Empty)
            {
                MessageBox.Show("Account Credit Field is Required");
                ddlCreditAcc.Focus();
                return false;
            }
            
            if (txtAmount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Amount Field is Required");
                txtVoucherAmount.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region CRUD
        private void New_Click(object sender, EventArgs e)
        {
            ResetForm();
            ResetDetail();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                //System.Data.Common.DbConnection conn = null;
                //System.Data.Common.DbTransaction transaction = null;
                //transaction = conn.BeginTransaction();
                foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                {
                    if (Numerics.GetDouble(r.Cells["AmountDr"].Value) > 0)
                    {
                        int AccountId = Numerics.GetInt(r.Cells["AccountId"].Value);
                        if (AccountId == 0)
                        {
                            MessageBox.Show("Please Select Debit Account Title First");
                            return;
                        }
                    }
                }
                foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                {
                    if (Numerics.GetDouble(r.Cells["AmountCr"].Value) > 0)
                    {
                        int AccountId = Numerics.GetInt(r.Cells["AccountId"].Value);
                        if (AccountId == 0)
                        {
                            MessageBox.Show("Please Select Credit Account Title First");
                            return;
                        }
                    }
                }
                head = new tblVoucherHead();
                head.Voucher_Code = Numerics.GetInt(txtVoucherCode.Text);
                head.DocumentType_Id = 5;
                head.RefDocTypeId = 0;
                head.RefDocNoId = 0;
                head.Voucher_Date = txtvoucherdate.Value;
                head.Voucher_Amount = Numerics.GetDouble(txtVoucherAmount.Text);
                head.RefrenceAccount = 0;
                head.AgainstAccount = 0;
                head.Entry_User = user.Id;
                head.Branch_Id = user.BranchId;
                head.Company_Id = user.CompanyId;
                head.tblVoucherDetails = new List<tblVoucherDetail>();
                foreach (Janus.Windows.GridEX.GridEXRow r in grddetail.GetRows())
                {
                    tblVoucherDetail detail = new tblVoucherDetail();
                    detail.Voucher_Head_Id = head.Id;
                    detail.COA_Id = Numerics.GetInt(r.Cells["AccountId"].Value);
                    detail.Comments = r.Cells["Comments"].Text.ToString();
                    detail.ChequeNo = "";
                    detail.DebitAmount = Numerics.GetDouble(r.Cells["AmountDr"].Value);
                    detail.CreditAmount = Numerics.GetDouble(r.Cells["AmountCr"].Value);
                    detail.Against_COA_Id = 0;
                    head.tblVoucherDetails.Add(detail);
                }
                var Debit = this.grddetail.GetTotal(grddetail.RootTable.Columns["AmountDr"], Janus.Windows.GridEX.AggregateFunction.Sum);
                var Credit = this.grddetail.GetTotal(grddetail.RootTable.Columns["AmountCr"], Janus.Windows.GridEX.AggregateFunction.Sum);
                double DebitAmount = Numerics.GetDouble(Debit);
                double CreditAmount = Numerics.GetDouble(Credit);
                if (CreditAmount != DebitAmount)
                {
                    MessageBox.Show("Debit & Credit side not equal");
                    return;
                }
                //if (RecId > 0)
                //{
                //    db.Entry(head).State = EntityState.Modified;
                //}
                //else
                //{
                //    db.tblVoucherHeads.Add(head);
                //}
                db.tblVoucherHeads.Add(head);
                db.SaveChanges();
                ResetForm();
                ResetDetail();
                MessageBox.Show("Save SuccessFully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GridHistory()
        {
            try
            {
                var history = (from h in db.tblVoucherHeads
                               join d in db.tblVoucherDetails on h.Id equals d.Voucher_Head_Id
                               join acc in db.tblCOAs on d.COA_Id equals acc.Id
                               join dt in db.tblDocumentTypes on h.DocumentType_Id equals dt.Id
                               where h.Branch_Id == user.BranchId
                               select new
                               {
                                   h.Id,
                                   h.Voucher_Code,
                                   h.Voucher_Date,
                                   h.Voucher_Amount
                                   ,
                                   d.COA_Id,
                                   d.DebitAmount,
                                   d.CreditAmount,
                                   d.Comments,
                                   acc.Account_Title,
                                   dt.Document_Type_Name
                               }).ToList();

                DataTable dthistory = new DataTable();
                dthistory.Columns.Add("Id");
                dthistory.Columns.Add("VoucherCode");
                dthistory.Columns.Add("VoucherDate");
                dthistory.Columns.Add("DocumentType");
                dthistory.Columns.Add("AccountTitle");
                dthistory.Columns.Add("CreditAmount");
                dthistory.Columns.Add("DebitAmount");
                dthistory.Columns.Add("Remarks");
                for (int i = 0; i < history.Count; i++)
                {
                    dthistory.Rows.Add(history[i].Id, history[i].Voucher_Code, Convert.ToDateTime(history[i].Voucher_Date).ToString("dd-MMM-yyyy"), history[i].Document_Type_Name, history[i].Account_Title
                        , history[i].CreditAmount, history[i].DebitAmount, history[i].Comments);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidation())
                {
                    return;
                }
                dtGrid.Rows.Add(ddlCreditAcc.Value, ddlCreditAcc.Text, txtCreditComment.Text.Trim(), 0, txtAmount.Text.Trim());
                dtGrid.Rows.Add(ddlDebitAcc.Value, ddlDebitAcc.Text, txtCreditComment.Text.Trim(), txtAmount.Text.Trim(), 0);
                grddetail.DataSource = dtGrid;
                grddetail.RetrieveStructure();
                ResetDetail();
                detailGridSetting();
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
      
        private void Voucher_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void grddetail_DoubleClick(object sender, EventArgs e)
        {

        }

       
        public void detailGridSetting()
        {
            try
            {
               
                grddetail.RootTable.Columns["AccountId"].Visible = false;
                grddetail.RootTable.Columns["AccountTitle"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grddetail.RootTable.Columns["Comments"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grddetail.RootTable.Columns["AmountDr"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grddetail.RootTable.Columns["AmountCr"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grddetail.RootTable.Columns["AccountTitle"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grddetail.RootTable.Columns["Comments"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grddetail.RootTable.Columns["AmountDr"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grddetail.RootTable.Columns["AmountCr"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grddetail.RootTable.Columns["AmountDr"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grddetail.RootTable.Columns["AmountCr"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;

                grddetail.RootTable.Columns["AmountDr"].FormatString ="0,0";
                grddetail.RootTable.Columns["AmountCr"].FormatString = "0,0";

                grddetail.RootTable.Columns["AmountDr"].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                grddetail.RootTable.Columns["AmountCr"].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;

                grddetail.RootTable.Columns["AccountTitle"].Width = 200;
                grddetail.RootTable.Columns["Comments"].Width = 300;
                grddetail.RootTable.Columns["AmountDr"].Width=100;
                grddetail.RootTable.Columns["AmountCr"].Width=100;


                txtVoucherAmount.Text = this.grddetail.GetTotal(grddetail.RootTable.Columns["AmountDr"], Janus.Windows.GridEX.AggregateFunction.Sum).ToString();

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
                grdHistory.RootTable.Columns["VoucherCode"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdHistory.RootTable.Columns["VoucherDate"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdHistory.RootTable.Columns["DocumentType"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdHistory.RootTable.Columns["AccountTitle"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdHistory.RootTable.Columns["CreditAmount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdHistory.RootTable.Columns["DebitAmount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdHistory.RootTable.Columns["Remarks"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdHistory.RootTable.Columns["VoucherCode"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdHistory.RootTable.Columns["VoucherDate"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdHistory.RootTable.Columns["DocumentType"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdHistory.RootTable.Columns["AccountTitle"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdHistory.RootTable.Columns["CreditAmount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdHistory.RootTable.Columns["DebitAmount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdHistory.RootTable.Columns["Remarks"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdHistory.RootTable.Columns["CreditAmount"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grdHistory.RootTable.Columns["DebitAmount"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;

                grdHistory.RootTable.Columns["CreditAmount"].FormatString = "0,0";
                grdHistory.RootTable.Columns["DebitAmount"].FormatString = "0,0";

                grdHistory.RootTable.Columns["DebitAmount"].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
                grdHistory.RootTable.Columns["CreditAmount"].TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;


                grdHistory.RootTable.Columns["VoucherCode"]. Width=100;
                grdHistory.RootTable.Columns["VoucherDate"]. Width=100;
                grdHistory.RootTable.Columns["DocumentType"].Width=150;
                grdHistory.RootTable.Columns["AccountTitle"].Width=250;
                grdHistory.RootTable.Columns["CreditAmount"].Width=100;
                grdHistory.RootTable.Columns["DebitAmount"].Width = 100;
                grdHistory.RootTable.Columns["Remarks"].Width = 300;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
