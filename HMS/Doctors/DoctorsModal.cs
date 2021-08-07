using ElectricShopPOS.GeneralClasses;
using HMS.Data;
using HMS.Utills;
using Janus.Windows.GridEX;
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
    public partial class DoctorsModal : Form
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
        public DoctorsModal(UserAccount getuser)
        {
            InitializeComponent();
            GridFill();
            user = getuser;
        }
        public void GridFill()
        {
            try
            {
                var Getall = (from sc in db.tblSupplierCustomers
                              join acc in db.tblCOAs on sc.GlAccount_Id equals acc.Id
                              select new
                              {
                                  sc.Id,
                                  sc.Profile_Name,
                                  sc.Contact_No,
                                  sc.Address,
                                  sc.Company_Id,
                                  sc.Branch_Id,
                                  sc.GlAccount_Id,
                                  acc.Account_Title,
                                  sc.SupplierCustomerType
                              }).Where(x => x.SupplierCustomerType == "Doctor").ToList();

                if (Getall.Count > 0)
                {
                    DataTable dtgetAll = new DataTable();
                    dtgetAll.Columns.Add("Id");
                    dtgetAll.Columns.Add("ProfileName");
                    dtgetAll.Columns.Add("Contact#");
                    dtgetAll.Columns.Add("Address");
                    dtgetAll.Columns.Add("GLAccountId");
                    dtgetAll.Columns.Add("GLAccount");
                    dtgetAll.Columns.Add("TypeAccount");
                    foreach (var item in Getall)
                    {
                        dtgetAll.Rows.Add(item.Id, item.Profile_Name, item.Contact_No, item.Address, item.GlAccount_Id,item.Account_Title, item.SupplierCustomerType);
                    }
                    grdCustomer.DataSource = dtgetAll;
                    grdCustomer.RetrieveStructure();
                    GridSetting();
                }
                else
                {
                    grdCustomer.ClearStructure();
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
                grdCustomer.RootTable.Columns["ProfileName"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["Contact#"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["Address"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["GLAccount"].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                grdCustomer.RootTable.Columns["Id"].Visible = false;
                grdCustomer.RootTable.Columns["Address"].Visible = false;
                grdCustomer.RootTable.Columns["GLAccount"].Visible = false;
                grdCustomer.RootTable.Columns["TypeAccount"].Visible = false;
                grdCustomer.RootTable.Columns["GLAccountId"].Visible = false;

                grdCustomer.RootTable.Columns["ProfileName"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomer.RootTable.Columns["Contact#"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomer.RootTable.Columns["Address"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;
                grdCustomer.RootTable.Columns["GLAccount"].FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox;

                grdCustomer.RootTable.Columns["ProfileName"].Width = 200;
                grdCustomer.RootTable.Columns.Add("Open");
                grdCustomer.RootTable.Columns["Open"].Key = "Open";
                grdCustomer.RootTable.Columns["Open"].Caption = "Open";
                grdCustomer.RootTable.Columns["Open"].ButtonDisplayMode = Janus.Windows.GridEX.CellButtonDisplayMode.Always;
                grdCustomer.RootTable.Columns["Open"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.ButtonCell;
                grdCustomer.RootTable.Columns["Open"].ButtonText = "Open";
                grdCustomer.RootTable.Columns["Open"].Width = 70;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdCustomer_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "Open")
                {
                    int Id = 0;
                    int GLId = 0;
                    GridEXRow item = grdCustomer.CurrentRow;
                    if (item != null && item.RowType == RowType.Record)
                    {
                        Id = Numerics.GetInt(item.Cells["Id"].Value.ToString());
                        GLId = Numerics.GetInt(item.Cells["GLAccountId"].Value.ToString());
                        DoctorTab doctor = new DoctorTab(GLId,Id, user);
                        doctor.Show();
                        Close();
                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoctorsModal_Load(object sender, EventArgs e)
        {
            //var lstRights = db.Proc_GetUserRights_UserId(user.Id, this.Name, user.RoleName).ToList();
            //if (lstRights != null)
            //{
            //    var newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Save").ToList();
            //    DoHaveSaveRight = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Print").ToList();
            //    DoHavePrintRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Update").ToList();
            //    DoHaveUpdateRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Field Chooser").ToList();
            //    DoHaveFieldChooserRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Save Layout").ToList();
            //    DoHaveSaveLayoutRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Grid Print").ToList();
            //    DoHaveGridPrintRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Grid Export").ToList();
            //    DoHaveGridExportRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Group Collapse").ToList();
            //    DoHaveGridGroupCollapseRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Group Expand").ToList();
            //    DoHaveGridGroupExpandRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Report Export").ToList();
            //    DoHaveReportExportRights = Convert.ToBoolean(newList[0].Value);
            //    newList = lstRights.Where(x => x.ScreenRightName.ToString() == "Report Print").ToList();
            //    DoHaveReportPrintRights = Convert.ToBoolean(newList[0].Value);
            //}
            ////btnSave.Enabled = DoHaveSaveRight;
            ////btnPrint.Enabled = DoHavePrintRights;
            //////btnUpdate.Enabled = DoHaveUpdateRights;
            ////ctrlGrdBar1.mGridChooseFielder.Enabled = DoHaveFieldChooserRights;
            ////ctrlGrdBar1.mGridSaveLayouts.Enabled = DoHaveSaveLayoutRights;
            ////ctrlGrdBar1.mGridPrint.Enabled = DoHaveGridPrintRights;
            ////ctrlGrdBar1.mGridExport.Enabled = DoHaveGridExportRights;
            ////ctrlGrdBar1.GroupCollaps.Enabled = DoHaveGridGroupCollapseRights;
            ////ctrlGrdBar1.GroupExpand.Enabled = DoHaveGridGroupExpandRights;

        }
    }
}
