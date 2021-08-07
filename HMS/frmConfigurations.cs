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

namespace HMS
{
    public partial class frmConfigurations : Form
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
        tblSystemConfigration tblSystem ;
        //int RecId;
        public frmConfigurations(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
        }

        private void frmConfigurations_Load(object sender, EventArgs e)
        {

            AccountsBinding();
            SubAccountsBinding();
            GetCashInHand();
            GetOPD();
            GetItemPurchaseAccount();
            GetItemSaleAccount();
            GetItemCGSAccount();
            GetOPDPercentage();
            GetCreditorsSubAccount();
            GetDebitorsSubAccount();
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
            //btnSave.Enabled = DoHaveSaveRight;
            ////btnPrint.Enabled = DoHavePrintRights;
            //btnUpdate.Enabled = DoHaveUpdateRights;
            //ctrlGrdBar1.mGridChooseFielder.Enabled = DoHaveFieldChooserRights;
            //ctrlGrdBar1.mGridSaveLayouts.Enabled = DoHaveSaveLayoutRights;
            //ctrlGrdBar1.mGridPrint.Enabled = DoHaveGridPrintRights;
            //ctrlGrdBar1.mGridExport.Enabled = DoHaveGridExportRights;
            //ctrlGrdBar1.GroupCollaps.Enabled = DoHaveGridGroupCollapseRights;
            //ctrlGrdBar1.GroupExpand.Enabled = DoHaveGridGroupExpandRights;
        }
        public void AccountsBinding()
        {
            try
            {
                var item = db.tblCOAs.ToList();
                DataTable dtAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtAcc.Columns.Add("Id");
                    dtAcc.Columns.Add("Account");
                    foreach (var a in item)
                    {
                        dtAcc.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtAcc, ddlAccount, "Id", "Account", "Select Account", false);
                        DDL.BindDDL(dtAcc, ddlOPD, "Id", "Account", "Select Account", false);
                        DDL.BindDDL(dtAcc, ddlItemPurchaseAccount, "Id", "Account", "Select Account", false);
                        DDL.BindDDL(dtAcc, ddlItemSaleAccount, "Id", "Account", "Select Account", false);
                        DDL.BindDDL(dtAcc, ddlItemCGS, "Id", "Account", "Select Account", false);
                    }
                    else
                    {
                        ddlAccount.Text = string.Empty;
                        ddlAccount.DataSource = null;
                        ddlOPD.Text = string.Empty;
                        ddlOPD.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SubAccountsBinding()
        {
            try
            {
                var item = db.tblSubAccounts.ToList();
                DataTable dtAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtAcc.Columns.Add("Id");
                    dtAcc.Columns.Add("Account");
                    foreach (var a in item)
                    {
                        dtAcc.Rows.Add(a.Id, a.SubAccount_Name);
                    }
                    if (dtAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtAcc, ddlCreditorsSubAccount, "Id", "Account", "Select Account", false);
                        DDL.BindDDL(dtAcc, ddlDebitorsSubAccount, "Id", "Account", "Select Account", false);
                    }
                    else
                    {
                        ddlAccount.Text = string.Empty;
                        ddlAccount.DataSource = null;
                        ddlOPD.Text = string.Empty;
                        ddlOPD.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                if(ddlAccount.Text==string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlAccount.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var  tblSystem = db.tblSystemConfigrations.Where(x=>x.Configration_Name == "Cash In Hand").FirstOrDefault();
                if(tblSystem != null)
                {
                    tblSystem.Configration_Name = "Cash In Hand";
                    tblSystem.Configration_Value = ddlAccount.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "Cash In Hand";
                    obj.Configration_Value = ddlAccount.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        public void GetCashInHand()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x=> x.Configration_Name == "Cash In Hand");
                if(get != null)
                {
                    ddlAccount.Value = get.Configration_Value;
                }
                else
                {
                    ddlAccount.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetOPD()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "OPD");
                if (get != null)
                {
                    ddlOPD.Value = get.Configration_Value;
                }
                else
                {
                    ddlOPD.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetItemPurchaseAccount()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Item Purchase A/C");
                if (get != null)
                {
                    ddlItemPurchaseAccount.Value = get.Configration_Value;
                }
                else
                {
                    ddlItemPurchaseAccount.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetItemSaleAccount()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Item Sale A/C");
                if (get != null)
                {
                    ddlItemSaleAccount.Value = get.Configration_Value;
                }
                else
                {
                    ddlItemSaleAccount.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetItemCGSAccount()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Item CGS A/C");
                if (get != null)
                {
                    ddlItemCGS.Value = get.Configration_Value;
                }
                else
                {
                    ddlItemCGS.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetOPDPercentage()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "OPD Percentage");
                if (get != null)
                {
                    txtOPDPercentage.Text = get.Configration_Value;
                }
                else
                {
                    ddlItemCGS.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetCreditorsSubAccount()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Creditors Sub A/C");
                if (get != null)
                {
                    ddlCreditorsSubAccount.Value = get.Configration_Value;
                }
                else
                {
                    ddlCreditorsSubAccount.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetDebitorsSubAccount()
        {
            try
            {
                var get = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "Debitors Sub A/C");
                if (get != null)
                {
                    ddlDebitorsSubAccount.Value = get.Configration_Value;
                }
                else
                {
                    ddlDebitorsSubAccount.Text = string.Empty;
                    //ddlAccount.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlOPD_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlOPD.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlOPD.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "OPD").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "OPD";
                    tblSystem.Configration_Value = ddlOPD.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "OPD";
                    obj.Configration_Value = ddlOPD.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlItemPurchaseAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemPurchaseAccount.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlItemPurchaseAccount.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "Item Purchase A/C").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "Item Purchase A/C";
                    tblSystem.Configration_Value = ddlItemPurchaseAccount.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "Item Purchase A/C";
                    obj.Configration_Value = ddlItemPurchaseAccount.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlItemSaleAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemSaleAccount.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlItemSaleAccount.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "Item Sale A/C").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "Item Sale A/C";
                    tblSystem.Configration_Value = ddlItemSaleAccount.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "Item Sale A/C";
                    obj.Configration_Value = ddlItemSaleAccount.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlItemCGS_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemCGS.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlItemCGS.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "Item CGS A/C").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "Item CGS A/C";
                    tblSystem.Configration_Value = ddlItemCGS.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "Item CGS A/C";
                    obj.Configration_Value = ddlItemCGS.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtOPDPercentage_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtOPDPercentage.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Value");
                    txtOPDPercentage.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "OPD Percentage").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "OPD Percentage";
                    tblSystem.Configration_Value = Numerics.GetInt(txtOPDPercentage.Text).ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "OPD Percentage";
                    obj.Configration_Value = Numerics.GetInt(txtOPDPercentage.Text).ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Percentage Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlCreditorsSubAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlCreditorsSubAccount.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlCreditorsSubAccount.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "Creditors Sub A/C").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "Creditors Sub A/C";
                    tblSystem.Configration_Value = ddlCreditorsSubAccount.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "Creditors Sub A/C";
                    obj.Configration_Value = ddlCreditorsSubAccount.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlDebitorsSubAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (ddlDebitorsSubAccount.Text == string.Empty)
                {
                    MessageBox.Show("Please Select Account");
                    ddlDebitorsSubAccount.Focus();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to Save?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                var tblSystem = db.tblSystemConfigrations.Where(x => x.Configration_Name == "Debitors Sub A/C").FirstOrDefault();
                if (tblSystem != null)
                {
                    tblSystem.Configration_Name = "Debitors Sub A/C";
                    tblSystem.Configration_Value = ddlDebitorsSubAccount.Value.ToString();
                    db.Entry(tblSystem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var obj = new tblSystemConfigration();
                    obj.Configration_Name = "Debitors Sub A/C";
                    obj.Configration_Value = ddlDebitorsSubAccount.Value.ToString();
                    db.tblSystemConfigrations.Add(obj);
                    db.SaveChanges();
                }
                MessageBox.Show("Account Updated Successfully...");
                //RecId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
