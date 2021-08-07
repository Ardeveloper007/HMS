using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Reports
{
    public partial class StockReport : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-TCL4KTP;initial catalog=dbHostiptalERP;integrated security=True;");
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        DropDownBinding DDL = new DropDownBinding();
        UserAccount user = new UserAccount();
        DataTable dtGrid = new DataTable();
        public StockReport(UserAccount getuser)
        {
            InitializeComponent();
            user = getuser;
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            ReportBind();
        }
        public void ReportBind()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(@" SELECT  c.Category_Name, i.Item_Name, i.PackQty , (sum(t.QtyIn )- sum(t.QtyOut)) AS NetQty , (sum(t.QtyIn )- sum(t.QtyOut))/PackQty AS AvailPacQty,ItemRate,(ItemRate*((sum(t.QtyIn )- sum(t.QtyOut))/PackQty)) as TotalAmount

FROM            tbl_InventoryTransaction AS t INNER JOIN
                         tblCategory AS c ON t.CategoryId = c.Id INNER JOIN
                         tbl_Item_Allocation AS alo ON t.ItemId = alo.Id INNER JOIN
                         tbl_Item_Def AS i ON alo.Item_Id = i.Id

						 group by    t.ItemRate, c.Category_Name, i.Item_Name, i.PackQty", con);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Category");
                    dt.Columns.Add("Product");
                    dt.Columns.Add("PackQty", typeof(double));
                    dt.Columns.Add("NetQty", typeof(double));
                    dt.Columns.Add("AvailPackQty", typeof(double));
                    dt.Columns.Add("ItemRate", typeof(double));
                    dt.Columns.Add("TotalAmount", typeof(double));
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        dt.Rows.Add(dt1.Rows[i]["Category_Name"], dt1.Rows[i]["Item_Name"], dt1.Rows[i]["PackQty"], dt1.Rows[i]["NetQty"]
                            , dt1.Rows[i]["AvailPacQty"], dt1.Rows[i]["ItemRate"], dt1.Rows[i]["TotalAmount"]);
                    }
                    grdStockReport.DataSource = dt;
                    grdStockReport.RetrieveStructure();
                    grdStockReportSetting();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void grdStockReportSetting()
        {
            try
            {
                grdStockReport.RootTable.Columns["Category"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdStockReport.RootTable.Columns["Product"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdStockReport.RootTable.Columns["PackQty"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdStockReport.RootTable.Columns["NetQty"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdStockReport.RootTable.Columns["AvailPackQty"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdStockReport.RootTable.Columns["ItemRate"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdStockReport.RootTable.Columns["TotalAmount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;

                grdStockReport.RootTable.Columns["Category"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdStockReport.RootTable.Columns["Product"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdStockReport.RootTable.Columns["PackQty"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdStockReport.RootTable.Columns["NetQty"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdStockReport.RootTable.Columns["AvailPackQty"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdStockReport.RootTable.Columns["ItemRate"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdStockReport.RootTable.Columns["TotalAmount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdStockReport.RootTable.Columns["PackQty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grdStockReport.RootTable.Columns["NetQty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grdStockReport.RootTable.Columns["AvailPackQty"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grdStockReport.RootTable.Columns["ItemRate"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
                grdStockReport.RootTable.Columns["TotalAmount"].AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;

                grdStockReport.RootTable.Columns["Category"].Width = 200;
                grdStockReport.RootTable.Columns["Product"].Width = 200;
                grdStockReport.RootTable.Columns["PackQty"].Width = 90;
                grdStockReport.RootTable.Columns["AvailPackQty"].Width = 90;
                grdStockReport.RootTable.Columns["ItemRate"].Width = 90;
                grdStockReport.RootTable.Columns["TotalAmount"].Width = 90;

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

        private void btnnew_Click(object sender, EventArgs e)
        {
            ReportBind();
        }
    }
}
