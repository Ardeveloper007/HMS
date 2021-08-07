using HMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Doctors
{
    public partial class todayPendingOPDDoctorWise : Form
    {
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        int SupplierCustomerId = 0;
        public todayPendingOPDDoctorWise(int SCId)
        {
            SupplierCustomerId = SCId;
            InitializeComponent();
        }

        private void todayPendingOPDDoctorWise_Load(object sender, EventArgs e)
        {
            getPendingCustomer();
            
        }
        public void getPendingCustomer()
        {
            try
            {
                if (SupplierCustomerId != 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id");
                    dt.Columns.Add("Date");
                    dt.Columns.Add("PatientName");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Contact#");
                    dt.Columns.Add("Fee");
                    dt.Columns.Add("Token#");
                    dt.Columns.Add("Doctor");
                    var getdetail = db.GetPendingDetail_OPD_DoctorWise(DateTime.Now, SupplierCustomerId).ToList();
                    if (getdetail != null && getdetail.Count != 0)
                    {
                        for (int i = 0; i < getdetail.Count; i++)
                        {
                            dt.Rows.Add(getdetail[i].Id, Convert.ToDateTime(getdetail[i].Datetime).ToString("dd-MMM-yyyy"), getdetail[i].Profile_Name, getdetail[i].Address,
                                getdetail[i].Contact_No, getdetail[i].Fees, getdetail[i].Token_No, getdetail[i].DoctorName);
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

                grdCustomerPending.RootTable.Columns["Date"].Width = 100;
                grdCustomerPending.RootTable.Columns["PatientName"].Width = 200;
                grdCustomerPending.RootTable.Columns["Address"].Width = 300;
                grdCustomerPending.RootTable.Columns["Contact#"].Width = 150;
                grdCustomerPending.RootTable.Columns["Fee"].Width = 100;
                grdCustomerPending.RootTable.Columns["Token#"].Width = 100;
                grdCustomerPending.RootTable.Columns["Doctor"].Width = 300;
                //grdCustomerPending.RootTable.Columns.Add("Select");
                //grdCustomerPending.RootTable.Columns["Select"].ActAsSelector = true;
                //grdCustomerPending.RootTable.Columns["Select"].UseHeaderSelector = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
