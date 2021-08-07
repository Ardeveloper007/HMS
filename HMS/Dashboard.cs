using HMS.Data;
using HMS.Doctors;
using HMS.Utills;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HMS
{
    public partial class Dashboard : Form
    {
        bool DoHaveOpenUserRightsForm = false;
        bool DoHaveOpenConfigurationForm= false;
        bool DoHaveOpenAccountsModule= false;
        bool DoHaveOpenMisc= false;
        bool DoHaveOpenInventory= false;
        bool DoHaveOpenOPD= false;
        bool DoHaveOpenInventoryReports= false;
        bool DoHaveOpenAccountsReports= false;
        bool DoHaveViewDoctors = false;
        bool DoHaveAddDoctors = false;

        //  GeneralClasses.License License = new GeneralClasses.License();
        dbHostiptalERPEntities db = new dbHostiptalERPEntities();
        UserAccount user = new UserAccount();
        public Dashboard(UserAccount getUser)
        {
            InitializeComponent();
            user = getUser;
           // this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }
        private void btnMenuButton_MouseHover(object sender, EventArgs e)
        {
            ContextMenuStrip1.Show(btnMenuButton, 0, btnMenuButton.Height);
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(btnReport, 0, btnReport.Height);
        }
        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            contextMenuStrip4.Show(btnRefresh, 0, btnRefresh.Height);
        }
        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
            login.BringToFront();
        }

        private void chartOfAccoiuntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsDefinition.AcfrmCOA coa= new AccountsDefinition.AcfrmCOA(user);
            coa.TopLevel = false;
            coa.AutoScroll = true;
            this.panel3.Controls.Add(coa);
            coa.Show();
        }

        private void openingBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsDefinition.OpeningBalance opening = new AccountsDefinition.OpeningBalance(user);
            opening.TopLevel = false;
            opening.AutoScroll = true;
            this.panel3.Controls.Add(opening);
            opening.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmDefineCategory  defineCategory= new Miscellaneous.frmDefineCategory(user);
            //defineCategory.TopLevel = false;
            //defineCategory.AutoScroll = true;
            //this.panel3.Controls.Add(defineCategory);
            defineCategory.Show();
        }

        private void btnProductBrand_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmAddItem addItem = new Miscellaneous.frmAddItem(user);
            //addItem.TopLevel = false;
            //addItem.AutoScroll = true;
            //this.panel3.Controls.Add(addItem);
            addItem.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Miscellaneous.ItemAllocation itemAllocation = new Miscellaneous.ItemAllocation(user);
            //this.Hide();
            itemAllocation.Show();
        }

      

        private void supplierCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Miscellaneous.frmSupplierCustomer supplierCustomer = new Miscellaneous.frmSupplierCustomer(user);
            //supplierCustomer.TopLevel = false;
            //supplierCustomer.AutoScroll = true;
            //this.panel3.Controls.Add(supplierCustomer);
            //supplierCustomer.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Purchase.frmPurchase purchase = new Purchase.frmPurchase(user);
            purchase.TopLevel = false;
            purchase.AutoScroll = true;
            this.panel3.Controls.Add(purchase);
            purchase.Show();
        }

        private void supplierCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmSupplierCustomer frmSupplier = new Miscellaneous.frmSupplierCustomer(user, "Supplier");
            frmSupplier.TopLevel = false;
            frmSupplier.AutoScroll = true;
            this.panel3.Controls.Add(frmSupplier);
            frmSupplier.Show();


        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Sale.frmSale sale = new Sale.frmSale(user);
            sale.TopLevel = false;
            sale.AutoScroll = true;
            this.panel3.Controls.Add(sale);
            sale.Show();
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase.frmPurchaseReturn purchaseReturn = new Purchase.frmPurchaseReturn(user);
            purchaseReturn.TopLevel = false;
            purchaseReturn.AutoScroll = true;
            this.panel3.Controls.Add(purchaseReturn);
            purchaseReturn.Show();
        }

        private void saleReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.frmSaleReturn saleReturn = new Sale.frmSaleReturn(user);
            saleReturn.TopLevel = false;
            saleReturn.AutoScroll = true;
            this.panel3.Controls.Add(saleReturn);
    
            saleReturn.Show();
        }

        private void accountTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsDefinition.Voucher voucher = new AccountsDefinition.Voucher(user);
            voucher.TopLevel = false;
            voucher.AutoScroll = true;
            this.panel3.Controls.Add(voucher);
  
            voucher.Show();
        }

        private void mainReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.MainPSPRSRReport report = new Reports.MainPSPRSRReport(user);
            report.TopLevel = false;
            report.AutoScroll = true;
            this.panel3.Controls.Add(report);
            report.Show();
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            Reports.StockReport report = new Reports.StockReport(user);
            report.TopLevel = false;
            report.AutoScroll = true;
            this.panel3.Controls.Add(report);
            report.Show();
        }

        private void btnReceiveableReport_Click(object sender, EventArgs e)
        {
            Reports.AccountReports reports = new Reports.AccountReports(user);
            Reports.StockReport report = new Reports.StockReport(user);
            reports.TopLevel = false;
            reports.AutoScroll = true;
            this.panel3.Controls.Add(reports);
            reports.Show();
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            BackUpDatabase backUp = new BackUpDatabase();
            backUp.Show();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigurations frm = new frmConfigurations(user);
            frm.Show();

        }

        private void oPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OPD.OPD OPD = new OPD.OPD(user,0);
            Reports.StockReport report = new Reports.StockReport(user);
            OPD.TopLevel = false;
            OPD.AutoScroll = true;
            this.panel3.Controls.Add(OPD);
            OPD.Show();
        }

        private void btnProfitLoss_Click(object sender, EventArgs e)
        {
            Reports.ItemWiseRevenueReport Page = new Reports.ItemWiseRevenueReport(user);
            Page.TopLevel = false;
            Page.AutoScroll = true;
            this.panel3.Controls.Add(Page);
            Page.Show();
        }

        private void doctorsOPDFinanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.DoctorWiseOPD Page = new Reports.DoctorWiseOPD(user);
            Page.TopLevel = false;
            Page.AutoScroll = true;
            this.panel3.Controls.Add(Page);
            Page.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmSupplierCustomer frmSupplier = new Miscellaneous.frmSupplierCustomer(user, "Supplier");
            frmSupplier.TopLevel = false;
            frmSupplier.AutoScroll = true;
            this.panel3.Controls.Add(frmSupplier);
            frmSupplier.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmSupplierCustomer frmSupplier = new Miscellaneous.frmSupplierCustomer(user, "Customer");
            frmSupplier.TopLevel = false;
            frmSupplier.AutoScroll = true;
            this.panel3.Controls.Add(frmSupplier);
            frmSupplier.Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmSupplierCustomer frmSupplier = new Miscellaneous.frmSupplierCustomer(user, "Doctor");
            frmSupplier.TopLevel = false;
            frmSupplier.AutoScroll = true;
            this.panel3.Controls.Add(frmSupplier);
            frmSupplier.Show();
        }

        private void btnViewDoctors_Click(object sender, EventArgs e)
        {
            DoctorsModal frm = new DoctorsModal(user);
            frm.Show();
        }

        private void userDefineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Miscellaneous.frmUserRights userRights = new Miscellaneous.frmUserRights(user);
            userRights.TopLevel = false;
            userRights.AutoScroll = true;
            this.panel3.Controls.Add(userRights);
            userRights.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var lstRights = db.Proc_GetUserRights_UserId(user.Id, this.Name, user.RoleName).ToList();
            if (lstRights != null)
            {
                var newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open UserRight").ToList();
                DoHaveOpenUserRightsForm = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open Configuration").ToList();
                DoHaveOpenConfigurationForm = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open Account Module").ToList();
                DoHaveOpenAccountsModule = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open Miscellaneous").ToList();
                DoHaveOpenMisc = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open Inventory").ToList();
                DoHaveOpenInventory = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open OPD ").ToList();
                DoHaveOpenOPD = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open Accounts Reports").ToList();
                DoHaveOpenAccountsReports = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Open Inventory Reports").ToList();
                DoHaveOpenInventoryReports = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "View Doctors").ToList();
                DoHaveViewDoctors = Convert.ToBoolean(newList[0].Value);
                newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Add Doctors").ToList();
                DoHaveAddDoctors = Convert.ToBoolean(newList[0].Value);
            }
            userDefineToolStripMenuItem.Enabled = DoHaveOpenUserRightsForm;
            configurationToolStripMenuItem.Enabled = DoHaveOpenConfigurationForm;
            btnMiscellaneous.Enabled = DoHaveOpenMisc;
            accountsToolStripMenuItem.Enabled = DoHaveOpenAccountsModule;
            inventoryToolStripMenuItem.Enabled = DoHaveOpenInventory;
            oPDToolStripMenuItem.Enabled = DoHaveOpenOPD;
            InventoryReport.Enabled = DoHaveOpenInventoryReports;
            accountReportsToolStripMenuItem.Enabled = DoHaveOpenAccountsReports;
            btnAddDoctor.Enabled = DoHaveAddDoctors;
            btnViewDoctors.Enabled = DoHaveViewDoctors;


        }
    
    
    }
}
