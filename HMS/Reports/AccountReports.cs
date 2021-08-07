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
    public partial class AccountReports : Form
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-L47PLK0\\SQLEXPRESS;initial catalog=dbHostiptalERP;integrated security=True;");
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        DropDownBinding DDL = new DropDownBinding();
        UserAccount user = new UserAccount();
        DataTable dtGrid = new DataTable();
        public AccountReports(UserAccount getuser)
        {
            InitializeComponent();
            user = getuser;
        }

        private void AccountReports_Load(object sender, EventArgs e)
        {
            bindGrid(null);
        }
        private void bindGrid(int? Id)
        {
            grd.DataSource = db.GetReminingAmounts(Id).ToList();
            grd.RetrieveStructure();
        }
        private void cmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                var type = Convert.ToString(cmbType.Text);
                var sc = db.tblSupplierCustomers.Where(x => x.SupplierCustomerType == type && x.SupplierCustomerType != "Doctor").ToList();
                DataTable dtsc = new DataTable();
                dtsc.Columns.Add("Id");
                dtsc.Columns.Add("SupplierCustomer");
                if (sc.Count > 0)
                {
                    foreach (var item in sc)
                    {
                        dtsc.Rows.Add(item.GlAccount_Id, item.Profile_Name);
                    }
                    if (dtsc.Rows.Count > 0)
                    {
                        DDL.BindDDL(dtsc, cmbparty, "Id", "SupplierCustomer", "Supplier Customer", false);
                    }
                    else
                    {
                        cmbparty.Text = string.Empty;
                        cmbparty.DataSource = null;
                    }
                }
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

        private void cmbparty_Leave(object sender, EventArgs e)
        {
            int PartyId = Numerics.GetInt(cmbparty.Value);
            if (PartyId != 0)
            {
                bindGrid(PartyId);
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            bindGrid(null);
        }
    }
}
