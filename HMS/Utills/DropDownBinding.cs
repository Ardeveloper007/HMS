using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricShopPOS.GeneralClasses
{
    public class DropDownBinding
    {
        public void BindDDL(DataTable dt, Infragistics.Win.UltraWinGrid.UltraCombo DDL, string ValueMember, string DisplayMember, string Caption, bool? ZeroIndex)
        {
            try
            {
                DDL.DataSource = dt;
                DDL.DisplayMember = DisplayMember;
                DDL.ValueMember = ValueMember;
                if (ZeroIndex == true)
                {
                    DataRow newRow = dt.NewRow();
                    newRow[0] = "0";
                    newRow[1] = "-- Select --";
                    dt.Rows.InsertAt(newRow, 0);
                }
                DDL.DisplayLayout.Bands[0].Columns[0].Hidden = true;
                DDL.DisplayLayout.Bands[0].Columns[1].Hidden = false;
                DDL.DisplayLayout.Bands[0].Columns[1].Header.Caption = Caption;
                DDL.DisplayLayout.Bands[0].Columns[1].Width = 200;
                if (ZeroIndex == true)
                {
                    DDL.Value = 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
