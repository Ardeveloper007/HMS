using HMS.Data;
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
    public partial class DoctorTab : Form
    {
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        int GlAccountId = 0;
        int SupplierCustomerId = 0;
        UserAccount user = new UserAccount();
        public DoctorTab(int GlId, int SCId,UserAccount getuser)
        {
            GlAccountId = GlId;
            SupplierCustomerId = SCId;
            InitializeComponent();
            user = getuser;
        }

        public void PendingAmount()
        {
            try
            {
                if (SupplierCustomerId != 0)
                {
                    var getPendingAmount = db.tblOPDs.Where(x => x.Visited == false && x.Dr_Id == SupplierCustomerId).Select(x => x.Fees).Sum();
                    if (getPendingAmount != null && getPendingAmount!=0)
                    {
                        lblPendingAmount.Text = getPendingAmount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DoctorTab_Load(object sender, EventArgs e)
        {
            PendingAmount();
        }

        private void btnViewPending_Click(object sender, EventArgs e)
        {
            try
            {
                Doctors.ShowPendingAmount showPending = new ShowPendingAmount(GlAccountId,SupplierCustomerId,user);
                showPending.Show();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewDoctors_Click(object sender, EventArgs e)
        {
            try
            {
                if(SupplierCustomerId!=0)
                {
                    todayPendingOPDDoctorWise doctorWise = new todayPendingOPDDoctorWise(SupplierCustomerId);
                    doctorWise.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            Doctors.NewOrExisting existing = new NewOrExisting(SupplierCustomerId,GlAccountId,user);
            existing.Show();
            Close();
        }

        
    }
}
