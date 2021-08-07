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

namespace HMS.Doctors
{
    public partial class ShowPendingAmount : Form
    {
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        int GlAccountId = 0;
        int DrId = 0;
        UserAccount user = new UserAccount();
        

        public ShowPendingAmount(int GlId, int SCId,UserAccount getuser)
        {
            GlAccountId = GlId;//SupplierCustomer Gl Id
            DrId = SCId;//Doctor Id
            InitializeComponent();
            user = getuser;
        }

        private void ShowPendingAmount_Load(object sender, EventArgs e)
        {
            getPendingCustomer();
        }

        public void getPendingCustomer()
        {
            try
            {
                if (DrId != 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id");
                    dt.Columns.Add("Date");
                    dt.Columns.Add("PatientName");
                    dt.Columns.Add("PatientGLId");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Contact#");
                    dt.Columns.Add("Fee");
                    dt.Columns.Add("Token#");
                    dt.Columns.Add("Doctor");
                    dt.Columns.Add("DoctorGLID");
                    var getdetail = db.GetPendingDetail_OPD_DateWise(fromdate.Value,todate.Value, DrId).ToList();
                    if(getdetail!=null && getdetail.Count!=0)
                    {
                        for(int i=0;i<getdetail.Count;i++)
                        {
                            dt.Rows.Add(getdetail[i].Id, Convert.ToDateTime(getdetail[i].Datetime).ToString("dd-MMM-yyyy"), getdetail[i].Profile_Name,
                                getdetail[i].GlAccount_Id,getdetail[i].Address,
                                getdetail[i].Contact_No, getdetail[i].Fees, getdetail[i].Token_No, getdetail[i].DoctorName, getdetail[i].DoctorGLID);
                        }
                        grdCustomerPending.DataSource = dt;
                        grdCustomerPending.RetrieveStructure();
                        GridSetting();
                    }
                    else
                    {
                        grdCustomerPending.ClearStructure();
                    }
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
                grdCustomerPending.RootTable.Columns["Date"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomerPending.RootTable.Columns["PatientName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomerPending.RootTable.Columns["Address"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomerPending.RootTable.Columns["Contact#"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomerPending.RootTable.Columns["Fee"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomerPending.RootTable.Columns["Token#"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomerPending.RootTable.Columns["Doctor"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdCustomerPending.RootTable.Columns["Date"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomerPending.RootTable.Columns["PatientName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomerPending.RootTable.Columns["Address"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomerPending.RootTable.Columns["Contact#"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomerPending.RootTable.Columns["Fee"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomerPending.RootTable.Columns["Token#"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomerPending.RootTable.Columns["Doctor"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdCustomerPending.RootTable.Columns["Id"].Visible = false;
                grdCustomerPending.RootTable.Columns["PatientGLId"].Visible = false;
                grdCustomerPending.RootTable.Columns["DoctorGLID"].Visible = false;

                grdCustomerPending.RootTable.Columns["Date"].Width = 100;
                grdCustomerPending.RootTable.Columns["PatientName"].Width = 200;
                grdCustomerPending.RootTable.Columns["Address"].Width = 300;
                grdCustomerPending.RootTable.Columns["Contact#"].Width = 150;
                grdCustomerPending.RootTable.Columns["Fee"].Width = 100;
                grdCustomerPending.RootTable.Columns["Token#"].Width = 100;
                grdCustomerPending.RootTable.Columns["Doctor"].Width = 300;

                grdCustomerPending.RootTable.Columns.Add("Select");
                grdCustomerPending.RootTable.Columns["Select"].ActAsSelector = true;
                grdCustomerPending.RootTable.Columns["Select"].UseHeaderSelector = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getPendingCustomer();
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
        private void btnSavevoucher_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(grdCustomerPending.GetCheckedRows().Count().ToString()) > 0)
                {
                    foreach (Janus.Windows.GridEX.GridEXRow r in grdCustomerPending.GetCheckedRows())
                    {
                        double OnePercent = Numerics.GetDouble(r.Cells["Fee"].Value) / 100;
                        double DrAmount = OnePercent * GetOPDPercentage();
                        double CompanyAmount = Numerics.GetDouble(r.Cells["Fee"].Value) - DrAmount;

                        tblVoucherHead head = new tblVoucherHead();
                        head.DocumentType_Id = 5;
                        head.RefDocTypeId = 6;
                        head.RefDocNoId = Numerics.GetInt(r.Cells["Id"].Value);
                        head.Voucher_Code = GetVouvherCode();
                        head.Voucher_Date = DateTime.Now;
                        head.Voucher_Amount = Numerics.GetDouble(r.Cells["Fee"].Value);
                        head.RefrenceAccount = Numerics.GetInt(r.Cells["PatientGLId"].Value);//Customer GL ID
                        head.AgainstAccount = Numerics.GetInt(r.Cells["DoctorGLID"].Value); //Doctor GLID
                        head.Entry_User = user.Id;
                        head.Branch_Id = user.BranchId;
                        head.Company_Id = user.CompanyId;
                        head.DoctorAmount = DrAmount;

                        //Cash in Hand Debit
                        tblVoucherDetail vd1 = new tblVoucherDetail();
                        vd1.Voucher_Head_Id = head.Id;
                        vd1.Against_COA_Id = GetCashInHandFromconfig();
                        vd1.COA_Id = Numerics.GetInt(r.Cells["PatientGLId"].Value);//Customer GL ID
                        vd1.Comments = "Amount Deduted From Customer A/C from OPD";
                        vd1.DebitAmount = 0;
                        vd1.CreditAmount = Numerics.GetDouble(r.Cells["Fee"].Value);
                        vd1.ChequeNo = "";
                        head.tblVoucherDetails.Add(vd1);

                        //Customer Credit
                        tblVoucherDetail vd2 = new tblVoucherDetail();
                        vd2.Voucher_Head_Id = head.Id;
                        vd2.Against_COA_Id = Numerics.GetInt(r.Cells["PatientGLId"].Value);
                        vd2.COA_Id = GetCashInHandFromconfig();// Customer GLID
                        vd2.Comments = "Amount Deduted From Customer A/C from OPD";
                        vd2.DebitAmount = Numerics.GetDouble(r.Cells["Fee"].Value);
                        vd2.CreditAmount = 0;
                        vd2.ChequeNo = "";
                        head.tblVoucherDetails.Add(vd2);


                        //Doctor Debit
                        tblVoucherDetail vd3 = new tblVoucherDetail();
                        vd3.Voucher_Head_Id = head.Id;
                        vd3.COA_Id = GetCashInHandFromconfig();
                        vd3.Against_COA_Id = Numerics.GetInt(r.Cells["DoctorGLID"].Value); //Doctor GlID
                        vd3.Comments = "Amount Added To OPD A/C from OPD";
                        vd3.CreditAmount = DrAmount;
                        vd3.DebitAmount = 0;
                        vd3.ChequeNo = "";
                        head.tblVoucherDetails.Add(vd3);
                        db.tblVoucherHeads.Add(head);

                        //cash in hand credit
                        tblVoucherDetail vd4 = new tblVoucherDetail();
                        vd4.Voucher_Head_Id = head.Id;
                        vd4.COA_Id = Numerics.GetInt(r.Cells["DoctorGLID"].Value);
                        vd4.Against_COA_Id = GetCashInHandFromconfig();  //Doctor GlID
                        vd4.Comments = "Amount Added To OPD A/C from OPD";
                        vd4.CreditAmount = 0;
                        vd4.DebitAmount = DrAmount;
                        vd4.ChequeNo = "";
                        head.tblVoucherDetails.Add(vd4);
                        db.tblVoucherHeads.Add(head);


                        //Cash in hand Credit
                        tblVoucherDetail vd5 = new tblVoucherDetail();
                        vd5.Voucher_Head_Id = head.Id;
                        vd5.COA_Id = GetCashInHandFromconfig();
                        vd5.Against_COA_Id = GetOPDFromconfig();//CustomerAccount
                        vd5.Comments = "Amount Added To OPD A/C from OPD";
                        vd5.CreditAmount = CompanyAmount;
                        vd5.DebitAmount = 0;
                        vd5.ChequeNo = "";
                        head.tblVoucherDetails.Add(vd5);
                        db.tblVoucherHeads.Add(head);



                        //OPD Debit
                        tblVoucherDetail vd6 = new tblVoucherDetail();
                        vd6.Voucher_Head_Id = head.Id;
                        vd6.COA_Id = GetOPDFromconfig();
                        vd6.Against_COA_Id = GetCashInHandFromconfig(); ;//CustomerAccount
                        vd6.Comments = "Amount Added To OPD A/C from OPD";
                        vd6.CreditAmount = 0;
                        vd6.DebitAmount = CompanyAmount;
                        vd6.ChequeNo = "";
                        head.tblVoucherDetails.Add(vd6);
                        db.tblVoucherHeads.Add(head);
                        db.SaveChanges();
                        int cIS = Numerics.GetInt(r.Cells["Id"].Value);
                        tblOPD OPD = new tblOPD();
                        OPD = db.tblOPDs.Where(x => x.Id == cIS).FirstOrDefault();

                        OPD.Visited = true;
                        db.Entry(OPD).State = EntityState.Modified;
                        db.SaveChanges();


                    }

                    getPendingCustomer();
                }
                else
                {
                    MessageBox.Show("Select Patient from Grid");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
