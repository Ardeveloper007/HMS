using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Reports
{
    public partial class MainPSPRSRReport : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-TCL4KTP;initial catalog=dbHostiptalERP;integrated security=True;");
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        DropDownBinding DDL = new DropDownBinding();
        UserAccount user = new UserAccount();
        DataTable dtGrid = new DataTable();

        public MainPSPRSRReport(UserAccount getuser)
        {
            InitializeComponent();
            user = getuser;
        }

        private void cmbPaidType_TextChanged(object sender, EventArgs e)
        {
            int OId = 0;
            DataTable dtreport = new DataTable();
            dtreport.Columns.Add("Order#");
            dtreport.Columns.Add("Date");
            dtreport.Columns.Add("Category");
            dtreport.Columns.Add("Product");
            dtreport.Columns.Add("PackQty",typeof(double));
            dtreport.Columns.Add("Qty",typeof(double));
            dtreport.Columns.Add("PackRate");
            dtreport.Columns.Add("Amount",typeof(double));
            dtreport.Columns.Add("SupplierCustomer");
          
            if (cmbPaidType.Text == "Purchase")
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(@"SELECT        h.Id, h.OrderNo, h.DocumentTypeId, h.DocDate, h.SupplierCustomerId, h.ManualBillNo, 
s.Profile_Name, s.Address, s.Contact_No, s.SupplierCustomerType, d.ItemQty, d.UnitRate, d.ItemRate, d.ItemAmount, i.Item_Name, 
                         i.PackQty, c.Category_Name, doc.Document_Type_Name, d.BillAmount
FROM            tbl_PurchaseMaster AS h INNER JOIN
                         tbl_PurchaseDetail AS d ON h.Id = d.PurchaseMaster_Id INNER JOIN
                         tblSupplierCustomer AS s ON h.SupplierCustomerId = s.Id INNER JOIN
                         tblCategory AS c ON d.CategoryId = c.Id INNER JOIN
                         tbl_Item_Allocation AS alo ON d.ItemId = alo.Id INNER JOIN
                         tbl_Item_Def AS i ON alo.Item_Id = i.Id INNER JOIN
                         tblDocumentType AS doc ON h.DocumentTypeId = doc.Id",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        dtreport.Rows.Add(dt.Rows[i]["OrderNo"], Convert.ToDateTime(dt.Rows[i]["DocDate"]).ToString("dd-MMM-yyyy"), dt.Rows[i]["Category_Name"], dt.Rows[i]["Item_Name"],
                            dt.Rows[i]["PackQty"], dt.Rows[i]["ItemQty"], dt.Rows[i]["ItemRate"], dt.Rows[i]["ItemAmount"],
                            dt.Rows[i]["Profile_Name"]);
                    }
                    grd.DataSource = dtreport;
                    grd.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grd.ClearStructure();
                }

                //var Getrecord = (from h in db.tbl_PurchaseMaster
                //                 join
                //                    d in db.tbl_PurchaseDetail on h.Id equals d.PurchaseMaster_Id
                //                 join
                //                    s in db.tblSupplierCustomers on h.SupplierCustomerId equals s.Id
                //                 join
                //                    c in db.tblCategories on d.CategoryId equals c.Id
                //                 join
                //                    alo in db.tbl_Item_Allocation on d.ItemId equals alo.Id
                //                 join
                //                    i in db.tbl_Item_Def on alo.Item_Id equals i.Id
                //                 where  h.Id == OId
                //                 select new
                //                 {
                //                     h.OrderNo,h.DocDate,h.BillAmount,d.ItemQty,d.ItemRate,d.ItemAmount,d.UnitRate,c.Category_Name,i.Item_Name,i.PackQty
                //                 }).ToList();

            }
            if (cmbPaidType.Text == "Sale")
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(@"SELECT        h.Id, h.OrderNo, h.DocumentTypeId, h.DocDate, h.SupplierCustomerId, h.ManualBillNo, 
s.Profile_Name, s.Address, s.Contact_No, s.SupplierCustomerType, d.ItemQty, d.UnitRate, d.ItemRate, d.ItemAmount, i.Item_Name, 
                         i.PackQty, c.Category_Name, doc.Document_Type_Name, d.BillAmount
FROM            tbl_SaleMaster AS h INNER JOIN
                         tbl_SaleDetail AS d ON h.Id = d.SaleMaster_Id INNER JOIN
                         tblSupplierCustomer AS s ON h.SupplierCustomerId = s.Id INNER JOIN
                         tblCategory AS c ON d.CategoryId = c.Id INNER JOIN
                         tbl_Item_Allocation AS alo ON d.ItemId = alo.Id INNER JOIN
                         tbl_Item_Def AS i ON alo.Item_Id = i.Id INNER JOIN
                         tblDocumentType AS doc ON h.DocumentTypeId = doc.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtreport.Rows.Add(dt.Rows[i]["OrderNo"], Convert.ToDateTime(dt.Rows[i]["DocDate"]).ToString("dd-MMM-yyyy"), dt.Rows[i]["Category_Name"], dt.Rows[i]["Item_Name"],
                            dt.Rows[i]["PackQty"], dt.Rows[i]["ItemQty"], dt.Rows[i]["ItemRate"], dt.Rows[i]["ItemAmount"],
                            dt.Rows[i]["Profile_Name"]);
                    }
                    grd.DataSource = dtreport;
                    grd.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grd.ClearStructure();
                }

            }
            if (cmbPaidType.Text == "Purchase Return")
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(@"SELECT        h.Id, h.OrderNo, h.DocumentTypeId, h.DocDate, h.SupplierCustomerId, h.ManualBillNo, s.Profile_Name, s.Address, s.Contact_No, s.SupplierCustomerType, d.ItemQty, d.ItemRate, d.ItemAmount, i.Item_Name, i.PackQty, 
                         c.Category_Name, doc.Document_Type_Name, d.BillAmount
FROM            tbl_PurchaseReturnMaster AS h INNER JOIN
                         tbl_PurchaseReturnDetail AS d ON h.Id = d.PurchaseReturnMaster_Id INNER JOIN
                         tblSupplierCustomer AS s ON h.SupplierCustomerId = s.Id INNER JOIN
                         tblCategory AS c ON d.CategoryId = c.Id INNER JOIN
                         tbl_Item_Allocation AS alo ON d.ItemId = alo.Id INNER JOIN
                         tbl_Item_Def AS i ON alo.Item_Id = i.Id INNER JOIN
                         tblDocumentType AS doc ON h.DocumentTypeId = doc.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtreport.Rows.Add(dt.Rows[i]["OrderNo"], Convert.ToDateTime(dt.Rows[i]["DocDate"]).ToString("dd-MMM-yyyy"), dt.Rows[i]["Category_Name"], dt.Rows[i]["Item_Name"],
                            dt.Rows[i]["PackQty"], dt.Rows[i]["ItemQty"], dt.Rows[i]["ItemRate"], dt.Rows[i]["ItemAmount"],
                            dt.Rows[i]["Profile_Name"]);
                    }
                    grd.DataSource = dtreport;
                    grd.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grd.ClearStructure();
                }

            }
            if (cmbPaidType.Text == "Sale Return")
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(@"SELECT        h.Id, h.OrderNo, h.DocumentTypeId, h.DocDate, h.SupplierCustomerId, h.ManualBillNo, s.Profile_Name, s.Address, s.Contact_No, s.SupplierCustomerType, d.ItemQty, d.ItemRate, d.ItemAmount, i.Item_Name, i.PackQty, 
                         c.Category_Name, doc.Document_Type_Name, d.BillAmount,d.UnitRate
FROM            tbl_SaleReturnMaster AS h INNER JOIN
                         tbl_SaleReturnDetail AS d ON h.Id = d.SaleReturnMaster_Id INNER JOIN
                         tblSupplierCustomer AS s ON h.SupplierCustomerId = s.Id INNER JOIN
                         tblCategory AS c ON d.CategoryId = c.Id INNER JOIN
                         tbl_Item_Allocation AS alo ON d.ItemId = alo.Id INNER JOIN
                         tbl_Item_Def AS i ON alo.Item_Id = i.Id INNER JOIN
                         tblDocumentType AS doc ON h.DocumentTypeId = doc.Id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtreport.Rows.Add(dt.Rows[i]["OrderNo"], Convert.ToDateTime(dt.Rows[i]["DocDate"]).ToString("dd-MMM-yyyy"), dt.Rows[i]["Category_Name"], dt.Rows[i]["Item_Name"],
                            dt.Rows[i]["PackQty"], dt.Rows[i]["ItemQty"], dt.Rows[i]["ItemRate"], dt.Rows[i]["ItemAmount"],
                            dt.Rows[i]["Profile_Name"]);
                    }
                    grd.DataSource = dtreport;
                    grd.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grd.ClearStructure();
                }
            }

        }

        public void GridSetting()
        {
            try
            {
                grd.RootTable.Columns["Order#"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["Date"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["Category"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["Product"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["PackRate"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["SupplierCustomer"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["PackQty"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["Qty"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grd.RootTable.Columns["Amount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grd.RootTable.Columns["Order#"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["Date"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["Category"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["Product"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["PackRate"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["SupplierCustomer"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["PackQty"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["Qty"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;
                grd.RootTable.Columns["Amount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit;

                grd.RootTable.Columns["PackQty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grd.RootTable.Columns["Qty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grd.RootTable.Columns["Amount"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;

                grd.RootTable.Columns["Order#"].Width = 100;
                grd.RootTable.Columns["Date"].Width = 100;
                grd.RootTable.Columns["Category"].Width = 300;
                grd.RootTable.Columns["Product"].Width = 300;
                grd.RootTable.Columns["PackRate"].Width = 100;
                grd.RootTable.Columns["SupplierCustomer"].Width = 300;
                grd.RootTable.Columns["PackQty"].Width = 100;
                grd.RootTable.Columns["Qty"].Width = 100;
                grd.RootTable.Columns["Amount"].Width = 100;



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MainPSPRSRReport_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
