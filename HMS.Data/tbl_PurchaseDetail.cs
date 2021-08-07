//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_PurchaseDetail
    {
        public int Id { get; set; }
        public Nullable<int> PurchaseMaster_Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> PackQty { get; set; }
        public Nullable<double> ItemQty { get; set; }
        public Nullable<double> NetQty { get; set; }
        public Nullable<double> UnitRate { get; set; }
        public Nullable<double> ItemRate { get; set; }
        public Nullable<double> ItemAmount { get; set; }
        public Nullable<double> BillAmount { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string RemarksDetail { get; set; }
    
        public virtual tbl_Item_Allocation tbl_Item_Allocation { get; set; }
        public virtual tbl_PurchaseMaster tbl_PurchaseMaster { get; set; }
        public virtual tblCategory tblCategory { get; set; }
    }
}
