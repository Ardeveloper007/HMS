using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace grid.User_Conrtols
{
    public partial class CtrlGrdBar : UserControl
    {
        public Boolean _AutoAdjust = false ;
        private int[] AryColWidth;
        private Janus.Windows.GridEX.GridEX _MyGrid; 
        private Boolean  _ExpandCheckbox =  false;
        public string str_Path = String.Empty;
       // private _Email As SBModel.SendingEmail
        private Form _FormName;
        public enum EnmAccountType
        {
            Customers,
            Vendors,
            General
        }
        public static string strForm_Name = String.Empty;
        public Janus.Windows.GridEX.GridEX MyGrid
        {
            get { return _MyGrid; }
            set { _MyGrid = value; GridEXPrintDocument1.GridEX = value; }
        }

        public Form FormName
        {
            get { return _FormName; }
            set { _FormName = value;  }
        }   

        public CtrlGrdBar()
        {
            InitializeComponent();
        }

        private void mGridChooseFielder_Click(object sender, EventArgs e)
        {
            try
            {
                MyGrid.AllowRemoveColumns = InheritableBoolean.True;
                 if (MyGrid.IsFieldChooserVisible() == false) 
                 {
                    MyGrid.ShowFieldChooser(FormName);
                 }
                 else
                 {
                     MyGrid.HideFieldChooser();
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mGridSaveLayouts_Click(object sender, EventArgs e)
        {
            try
            {
                if(System.IO.Directory.Exists(Application.ExecutablePath + @"\..\Layouts") == false)
                {
                      System.IO.Directory.CreateDirectory(Application.ExecutablePath + @"\..\Layouts");
                }
                var fs =  new System.IO.FileStream(Application.ExecutablePath + @"\..\Layouts\" + FormName.Name + "_" + MyGrid.Name, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
             MyGrid.SaveLayoutFile(fs);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            MessageBox.Show("Layout Saved successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.PageSetupDialog1.PageSettings.Landscape = true;
                this.GridEXPrintDocument1.PageHeaderCenter = this.txtGridTitle.Text;
                this.PageSetupDialog1.ShowDialog();
                if ((this.PrintPreviewDialog1.Document) != null)
                {
                     this.PrintPreviewDialog1.ShowDialog();
                }       
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.SaveFileDialog myDailog = new System.Windows.Forms.SaveFileDialog();
                myDailog.AddExtension = true;
                myDailog.DefaultExt = ".xls";
                myDailog.Filter = "Excel Files|*.xls";
                if (myDailog.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = string.Empty;
                    strFileName = myDailog.FileName;
                    if (strFileName.Length > 0)
                    {
                        var fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                        this.GridEXExporter1.GridEX = MyGrid;
                        this.GridEXExporter1.Export(fs);
                        fs.Flush();
                        fs.Close();
                        fs.Dispose();
                        MessageBox.Show("Exported successfully");
                    }
                }
              
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GroupCollaps_Click(object sender, EventArgs e)
        {
            try
            {
                _ExpandCheckbox = false;
                if (this._MyGrid != null && this._MyGrid.RootTable != null)
                {
                    if (!_ExpandCheckbox)
                    {
                        this._MyGrid.CollapseGroups();
                        this._MyGrid.CollapseRecords();
                    }
                    else
                    {
                        this._MyGrid.ExpandGroups();
                        this._MyGrid.ExpandRecords();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GroupExpand_Click(object sender, EventArgs e)
        {
            try
            {
                _ExpandCheckbox = true;
                if (this._MyGrid != null && this._MyGrid.RootTable != null)
                {
                    if (!_ExpandCheckbox)
                    {
                        this._MyGrid.CollapseGroups();
                        this._MyGrid.CollapseRecords();
                     }
                    else
                    {
                        this._MyGrid.ExpandGroups();
                        this._MyGrid.ExpandRecords();
                    }
                }   
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GridResizeColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._MyGrid.RootTable == null)
                {
                    return;
                }

                if (this._MyGrid.RootTable.Columns.Count == 0)
                {
                    return;
                }
                if (this._AutoAdjust)
                {
                    for (int index = 0; index < this._MyGrid.RootTable.Columns.Count - 1; index++)
                    {
                        this._MyGrid.RootTable.Columns[index].Width = this.AryColWidth[index];
                    }
                    _AutoAdjust = false;
                }
                else
                {
                    System.Array.Resize(ref AryColWidth, this._MyGrid.RootTable.Columns.Count - 1);
                    for (int index = 0; index < this._MyGrid.RootTable.Columns.Count - 1; index++)
                    {
                        AryColWidth[index] = this._MyGrid.RootTable.Columns[index].Width;
                    }
                    for (int index = 0; index < this._MyGrid.RootTable.Columns.Count - 1; index++)
                    {
                        this._MyGrid.RootTable.Columns[index].AutoSize();
                    }
                    _AutoAdjust = true;
                } 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
