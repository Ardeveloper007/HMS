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
    
    public partial class tblVoucherHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVoucherHead()
        {
            this.tblVoucherDetails = new HashSet<tblVoucherDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> DocumentType_Id { get; set; }
        public Nullable<int> RefDocTypeId { get; set; }
        public Nullable<int> RefDocNoId { get; set; }
        public Nullable<int> Voucher_Code { get; set; }
        public Nullable<System.DateTime> Voucher_Date { get; set; }
        public Nullable<double> Voucher_Amount { get; set; }
        public Nullable<int> RefrenceAccount { get; set; }
        public Nullable<int> AgainstAccount { get; set; }
        public Nullable<int> Entry_User { get; set; }
        public Nullable<int> Branch_Id { get; set; }
        public Nullable<int> Company_Id { get; set; }
        public Nullable<double> DoctorAmount { get; set; }
    
        public virtual tblBranch tblBranch { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblDocumentType tblDocumentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVoucherDetail> tblVoucherDetails { get; set; }
    }
}
