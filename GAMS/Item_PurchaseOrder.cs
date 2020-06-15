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
    
    public partial class Item_PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item_PurchaseOrder()
        {
            this.Item_PurchaseOrderControlItemValue = new HashSet<Item_PurchaseOrderControlItemValue>();
            this.Item_PurchaseOrderHistory = new HashSet<Item_PurchaseOrderHistory>();
            this.Item_PurchaseOrderInvoice = new HashSet<Item_PurchaseOrderInvoice>();
            this.Item_PurchaseOrderNotes = new HashSet<Item_PurchaseOrderNotes>();
            this.Item_PurchaseOrderRequest = new HashSet<Item_PurchaseOrderRequest>();
            this.Item_WorkOrderEventInvoice = new HashSet<Item_WorkOrderEventInvoice>();
        }
    
        public System.Guid PurchaseOrderID { get; set; }
        public int PurchaseOrderReferenceNumber { get; set; }
        public System.Guid VendorID { get; set; }
        public Nullable<System.Guid> EmployeeIDApproved { get; set; }
        public Nullable<System.DateTime> DateLastSentToVendor { get; set; }
        public Nullable<System.Guid> ContactTypeIDPlacedVia { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<System.Guid> PurchaseStatusID { get; set; }
        public Nullable<System.DateTime> DatePurchaseStatus { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsClosed { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Catalog_Vendor Catalog_Vendor { get; set; }
        public virtual Dictionary_ContactType Dictionary_ContactType { get; set; }
        public virtual Dictionary_PurchaseStatus Dictionary_PurchaseStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderControlItemValue> Item_PurchaseOrderControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderHistory> Item_PurchaseOrderHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderInvoice> Item_PurchaseOrderInvoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderNotes> Item_PurchaseOrderNotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderRequest> Item_PurchaseOrderRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventInvoice> Item_WorkOrderEventInvoice { get; set; }
    }
}
