using HMS.Utills;
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
    public partial class NewOrExisting : Form
    {
        int GlAccountId = 0;
        int SupplierCustomerId = 0;
        UserAccount user = new UserAccount();
        public NewOrExisting(int SCId, int GlId, UserAccount getuser)
        {
            GlAccountId = GlId;
            SupplierCustomerId = SCId;
            InitializeComponent();
            user = getuser;
        }

        private void NewOrExisting_Load(object sender, EventArgs e)
        {
            

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            OPD.OPD pD = new OPD.OPD(user, SupplierCustomerId);
           
            pD.Show();
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmSupplierCustomer customer = new Miscellaneous.frmSupplierCustomer(user, "Customer");
            customer.Show();
            Close();
        }
    }
}
