//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item_DeliveryAdvice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item_DeliveryAdvice()
        {
            this.Item_WorkOrderEventWarehouseTransaction = new HashSet<Item_WorkOrderEventWarehouseTransaction>();
        }
    
        public System.Guid DeliveryAdviceID { get; set; }
        public string DeliveryAdviceConstructedNumber { get; set; }
        public System.Guid AddressIDTo { get; set; }
        public System.Guid AddressIDFrom { get; set; }
        public string AddressAttnTo { get; set; }
        public string AddressAttnFrom { get; set; }
        public string Courier { get; set; }
        public string ConsignmentNumber { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public Nullable<System.DateTime> DateReceived { get; set; }
        public Nullable<System.DateTime> DateLastPrinted { get; set; }
        public System.Guid EmployeeIDRaised { get; set; }
        public Nullable<System.Guid> EmployeeIDLastEditted { get; set; }
        public Nullable<System.Guid> EmployeeIDReceipt { get; set; }
        public Nullable<System.Guid> EmployeeIDPrintedLast { get; set; }
        public Nullable<bool> IsEdittable { get; set; }
        public string DeliveryAdviceType { get; set; }
        public string DeliveryNotes { get; set; }
        public string Notes { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Catalog_Employee Catalog_Employee1 { get; set; }
        public virtual Catalog_Employee Catalog_Employee2 { get; set; }
        public virtual Catalog_Employee Catalog_Employee3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventWarehouseTransaction> Item_WorkOrderEventWarehouseTransaction { get; set; }
    }
}