using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Models;
using HMS.Utills;
using Janus.Windows.GridEX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.OPD
{
    public partial class OPD : Form
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
        tblVoucherHead head = new tblVoucherHead();
        int RecId = 0;
        int DrId = 0;
        public OPD(UserAccount getuser, int SCId)
        {
            DrId = SCId;
            InitializeComponent();
            user = getuser;
        }

        #region Load
        private void Voucher_Load(object sender, EventArgs e)
        {
            CreditAccBind();
            DebitAccBind();
            ddlCreditAcc.Focus();
            if(DrId>0)
            {
                ddlCreditAcc.Value = DrId;
                ddlCreditAcc.Enabled = false;
            }
            else
            {
                ddlCreditAcc.Enabled = true;
            }
            //getDrGrid(null);
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
            btnAdd.Enabled = DoHaveSaveRight;
            //btnPrint.Enabled = DoHavePrintRights;
            //btnUpdate.Enabled = DoHaveUpdateRights;
            ctrlGrdBar1.mGridChooseFielder.Enabled = DoHaveFieldChooserRights;
            ctrlGrdBar1.mGridSaveLayouts.Enabled = DoHaveSaveLayoutRights;
            ctrlGrdBar1.mGridPrint.Enabled = DoHaveGridPrintRights;
            ctrlGrdBar1.mGridExport.Enabled = DoHaveGridExportRights;
            ctrlGrdBar1.GroupCollaps.Enabled = DoHaveGridGroupCollapseRights;
            ctrlGrdBar1.GroupExpand.Enabled = DoHaveGridGroupExpandRights;

        }
        #endregion

        public int GetOPDPercentage()
        {
            int Percentage = 0;
            try
            {
                var getrec = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "OPD Percentage");
                if (getrec != null)
                {
                    Percentage = Numerics.GetInt(getrec.Configration_Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Percentage;
        }
        #region Function
        private int GetTokenCode()
        {
            int vouchercde = 0;
            try
            {
                int Dr = Numerics.GetInt(ddlCreditAcc.Value);
                var VC = db.tblOPDs.Where(x=> x.Dr_Id == Dr ).OrderByDescending(x => x.Id).ToList();
                if (VC.Count > 0)
                {
                    if (Convert.ToDateTime(VC[0].Datetime).ToString("yyyy-MMM-dd") == System.DateTime.Now.ToString("yyyy-MMM-dd"))
                    {
                        vouchercde = Numerics.GetInt(VC[0].Token_No);
                        vouchercde = vouchercde + 1;
                        txtToken.Text = vouchercde.ToString();
                    }
                    else
                    {
                        txtToken.Text = "1";
                    }
                }
                else
                {
                    txtToken.Text = "1";
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
                var item = db.tblSupplierCustomers.Where(x=>x.SupplierCustomerType== "Doctor").ToList();
                DataTable dtcreditAcc = new DataTable();
                if (item.Count > 0)
                {
                    dtcreditAcc.Columns.Add("Id");
                    dtcreditAcc.Columns.Add("Doctor");
                    foreach (var a in item)
                    {

                        dtcreditAcc.Rows.Add(a.Id, a.Reporting_Title);
                    }
                    if (dtcreditAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtcreditAcc, ddlCreditAcc, "Id", "Doctor", "Doctor", true);
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
                    dtdebitAcc.Columns.Add("Customers");
                    foreach (var a in item)
                    {

                        dtdebitAcc.Rows.Add(a.Id, a.Account_Title);
                    }
                    if (dtdebitAcc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtdebitAcc, ddlDebitAcc, "Id", "Customers", "Customers", true);
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
            if (DrId == 0)
            {
                CreditAccBind();
            }
            DebitAccBind();
            grddetail.ClearStructure();
            getDrGrid(null);
        }
        public void ResetDetail()
        {
            txtAmount.Text = string.Empty;
            btnAdd.Visible = true;
            ddlDebitAcc.Focus();
            //ddlCreditAcc.Text = string.Empty;
            ddlDebitAcc.Text = string.Empty;

        }



        #endregion

        #region Validation
        private bool FormValidation()
        {
            bool res = true;
            if (ddlDebitAcc.Text == string.Empty)
            {
                MessageBox.Show("Select a Customer");
                ddlDebitAcc.Focus();
                return res =  false;
            }
            if (ddlCreditAcc.Text == string.Empty)
            {
                MessageBox.Show("Select a Doctor");
                ddlCreditAcc.Focus();
                return res = false;
            }  
            if (Numerics.GetInt(txtAmount.Text) == 0)
            {
                MessageBox.Show("Add a Amount");
                txtAmount.Focus();
                return res = false;
            }
            return res;
        }

        #endregion

        #region CRUD
        private void New_Click(object sender, EventArgs e)
        {
            ResetForm();
            ResetDetail();
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
        private void getDrGrid(int? Dr)
        {
            List<GetOPD> list = new List<GetOPD>(); 
            if(Dr != null)
            {
                list = db.tblOPDs.Where(x => x.Dr_Id == Dr &&  x.Day == System.DateTime.Today).Select(x => new GetOPD
                {
                    Id = x.Id,
                    DrId = x.Dr_Id,
                    CustomerId = x.Customer_Id,
                    TokenNumber = x.Token_No,
                    DoctorName = x.tblSupplierCustomer.Reporting_Title,
                    CustomerName = x.tblCOA.Account_Title,
                    DateTime = x.Datetime,
                    Fees = x.Fees

                }).OrderByDescending(x => x.DateTime).ToList();
                grddetail.DataSource = list;
                grddetail.RetrieveStructure();
                detailGridSetting(grddetail);
            }
            else
            {
                list = db.tblOPDs.Select(x => new GetOPD
                {
                    Id = x.Id,
                    DrId = x.Dr_Id,
                    CustomerId = x.Customer_Id,
                    TokenNumber = x.Token_No,
                    DoctorName = x.tblSupplierCustomer.Reporting_Title,
                    CustomerName = x.tblCOA.Account_Title,
                    DateTime = x.Datetime,
                    Fees = x.Fees

                }).OrderByDescending(x => x.DateTime).ToList();
                grdHistory.DataSource = list;
                grdHistory.RetrieveStructure();
                detailGridSetting(grdHistory);
            }
            
        }
        public int GetCashInHandFromconfig()
        {
            int PaymentId = 0;
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
            return PaymentId;
        }
        public int GetOPDFromconfig()
        {
            int AccountId = 0;
            try
            {
                var getrec = db.tblSystemConfigrations.FirstOrDefault(x => x.Configration_Name == "OPD");
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
                              select new
                              {
                                  c.Name,
                                  c.Address,
                                  c.PhoneNo
                              }).ToList();
            //this prints the reciept
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            Font fontToke = new Font("Courier New", 60); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString(getcompany[0].Name.PadLeft(10), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
            //graphic.DrawString("  Phone#: (055) 4551300", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight;
            graphic.DrawString(" Mobile#:" + getcompany[0].PhoneNo, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(" Address:" + getcompany[0].Address, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)fontHeight;
            //graphic.DrawString("      Gujranwala", new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(" DR: " + ddlCreditAcc.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(" Customer: " + ddlDebitAcc.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString(" Date: " + System.DateTime.Now, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
             offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("--------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("  " + txtToken.Text, fontToke, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 60; //make the spacing consistent
            graphic.DrawString("--------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            //when we have drawn all of the items add the total
            offset = offset + 20;
            graphic.DrawString("Total Paid".PadRight(22) + txtAmount.Text, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidation())
                {
                    return;
                }
                if(GetCashInHandFromconfig() == 0)
                {
                    MessageBox.Show("Select Cash In Hand Account From Configrations");
                    return;
                }

                if (GetOPDFromconfig() == 0)
                {
                    MessageBox.Show("Select OPD Account From Configrations");
                    return;
                }
                if (GetOPDPercentage() == 0)
                {
                    MessageBox.Show("Enter OPD Percentage From Configrations");
                    return;
                }
                int dr = Numerics.GetInt(ddlCreditAcc.Value);
                int drAccount =0;
                var SupplierGLAccount = db.tblSupplierCustomers.FirstOrDefault(x => x.Id  == dr);
                if(SupplierGLAccount != null)
                {
                    drAccount = Convert.ToInt32(SupplierGLAccount.GlAccount_Id);
                }
                int OnePercent = Numerics.GetInt(txtAmount.Text) / 100;
                int DrPercentage = OnePercent * GetOPDPercentage();
                int CompanyPercentage = Numerics.GetInt(txtAmount.Text) - DrPercentage;
              
                int Customer = Numerics.GetInt(ddlDebitAcc.Value);
                //int OPDId = 0;
                tblOPD tblOPD = new tblOPD();
                tblOPD.Dr_Id = dr;
                tblOPD.Customer_Id = Customer;
                tblOPD.Fees = Numerics.GetInt(txtAmount.Text);
                tblOPD.Datetime = System.DateTime.Now;
                tblOPD.Token_No = Numerics.GetInt(txtToken.Text);
                tblOPD.Visited = false;
                tblOPD.Day = System.DateTime.Today;
                db.tblOPDs.Add(tblOPD);
                db.SaveChanges();
                //var OPD = db.tblOPDs.OrderByDescending(x => x.Id).ToList();
                //if(OPD.Count > 0) 
                //{
                //    OPDId = OPD[0].Id;
                //}
                //tblVoucherHead head = new tblVoucherHead();
                //head.DocumentType_Id = 5;
                //head.RefDocTypeId = 6;
                //head.RefDocNoId = OPDId;
                //head.Voucher_Code = GetVouvherCode();
                //head.Voucher_Date = DateTime.Now;
                //head.Voucher_Amount = Numerics.GetDouble(txtAmount.Text);
                //head.RefrenceAccount = Numerics.GetInt(ddlDebitAcc.Value);//Customer Account
                //head.AgainstAccount = drAccount; //Doctor Account
                //head.Entry_User = user.Id;
                //head.Branch_Id = user.BranchId;
                //head.Company_Id = user.CompanyId;
                //head.DoctorAmount = DrPercentage;

                //tblVoucherDetail vd2 = new tblVoucherDetail();
                //vd2.Voucher_Head_Id = head.Id;
                //vd2.Against_COA_Id = GetOPDFromconfig();
                //vd2.COA_Id = Numerics.GetInt(ddlDebitAcc.Value);
                //vd2.Comments = "Amount Deduted From Customer A/C from OPD";
                //vd2.DebitAmount = Numerics.GetDouble(txtAmount.Text);
                //vd2.CreditAmount = 0;
                //vd2.ChequeNo = "";
                //head.tblVoucherDetails.Add(vd2);

                //tblVoucherDetail vd3 = new tblVoucherDetail();
                //vd3.Voucher_Head_Id = head.Id;
                //vd3.COA_Id = GetOPDFromconfig();
                //vd3.Against_COA_Id = Numerics.GetInt(ddlDebitAcc.Value);//CustomerAccount
                //vd3.Comments = "Amount Added To OPD A/C from OPD";
                //vd3.CreditAmount = Numerics.GetDouble(txtAmount.Text);
                //vd3.DebitAmount = 0;
                //vd3.ChequeNo = "";
                //head.tblVoucherDetails.Add(vd3);
                //db.tblVoucherHeads.Add(head);

                //tblVoucherDetail vd4 = new tblVoucherDetail();
                //vd4.Voucher_Head_Id = head.Id;
                //vd4.COA_Id = GetCashInHandFromconfig();
                //vd4.Against_COA_Id = GetOPDFromconfig();
                //vd4.Comments = "Amount Added To Cash In Hand A/C from OPD";
                //vd4.CreditAmount = Numerics.GetDouble(txtAmount.Text);
                //vd4.DebitAmount = 0;
                //vd4.ChequeNo = "";
                //head.tblVoucherDetails.Add(vd4);
                //db.tblVoucherHeads.Add(head);

                //tblVoucherDetail vd5 = new tblVoucherDetail();
                //vd5.Voucher_Head_Id = head.Id;
                //vd5.Against_COA_Id = GetCashInHandFromconfig();
                //vd5.COA_Id = GetOPDFromconfig();
                //vd5.Comments = "Amount Deducted from OPD A/C from OPD";
                //vd5.DebitAmount = Numerics.GetDouble(txtAmount.Text);
                //vd5.CreditAmount = 0;
                //vd5.ChequeNo = "";
                //head.tblVoucherDetails.Add(vd5);

                //tblVoucherDetail vd6 = new tblVoucherDetail();
                //vd6.Voucher_Head_Id = head.Id;
                //vd6.COA_Id = GetCashInHandFromconfig();//Numerics.GetInt(ddlCreditAcc.Value);
                //vd6.Against_COA_Id = drAccount;//GetOPDFromconfig();
                //vd6.Comments = "Amount Added To Cash in Hand DR Part A/C from OPD";
                //vd6.CreditAmount = DrPercentage;
                //vd6.DebitAmount = 0;
                //vd6.ChequeNo = "";
                //head.tblVoucherDetails.Add(vd6);
                //db.tblVoucherHeads.Add(head);

                //tblVoucherDetail vd7 = new tblVoucherDetail();
                //vd7.Voucher_Head_Id = head.Id;
                //vd7.COA_Id = drAccount;// Numerics.GetInt(ddlCreditAcc.Value);
                //vd7.Against_COA_Id = GetCashInHandFromconfig();
                //vd7.Comments = "Amount Deducted from DR A/C and Added in Cash In Hand A/C from OPD";
                //vd7.DebitAmount = DrPercentage;
                //vd7.CreditAmount = 0;
                //vd7.ChequeNo = "";
                //head.tblVoucherDetails.Add(vd7);

                //db.tblVoucherHeads.Add(head);

                //db.SaveChanges();
                PrintInvoice();
                getDrGrid(dr);
                ddlCreditAcc.Value = 0;
                ddlDebitAcc.Value = 0;
                txtToken.Text = string.Empty;
                txtAmount.Text = string.Empty;
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
        public void detailGridSetting(Janus.Windows.GridEX.GridEX grid)
        {
            try
            {
                grid.RootTable.Columns["Id"].Visible = false;
                grid.RootTable.Columns["DrId"].Visible = false;
                grid.RootTable.Columns["CustomerId"].Visible = false;
                grid.RootTable.Columns["Fees"].FormatString ="0,0";
                if(grid == grddetail)
                {
                    grid.RootTable.Columns.Add("Delete");
                    grid.RootTable.Columns["Delete"].Key = "Delete";
                    grid.RootTable.Columns["Delete"].Caption = "Delete";
                    grid.RootTable.Columns["Delete"].ButtonDisplayMode = Janus.Windows.GridEX.CellButtonDisplayMode.Always;
                    grid.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                    grid.RootTable.Columns["Delete"].ButtonText = "Delete";
                    grid.RootTable.Columns["Delete"].Width = 70;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ddlCreditAcc_Leave(object sender, EventArgs e)
        {
            int Dr = Numerics.GetInt(ddlCreditAcc.Value);
            getDrGrid(Dr);
            GetTokenCode();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                getDrGrid(null);
            }
        }

        private void grddetail_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "Delete")
                {
                    int Id = 0;
                    GridEXRow item = grddetail.CurrentRow;
                    if (item != null && item.RowType == RowType.Record)
                    {
                        Id = Numerics.GetInt(item.Cells["Id"].Value.ToString());
                        var obj = db.tblOPDs.FirstOrDefault(x => x.Id == Id);
                        if(obj!= null)
                        {
                            db.tblOPDs.Remove(obj);
                            db.SaveChanges();
                            MessageBox.Show("Record Delete Successfully!");
                            int Dr = Numerics.GetInt(ddlCreditAcc.Value);
                            getDrGrid(Dr);
                            GetTokenCode();
                        }
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
