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
    
    public partial class Dictionary_PurchaseStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dictionary_PurchaseStatus()
        {
            this.Item_PurchaseOrder = new HashSet<Item_PurchaseOrder>();
            this.Item_PurchaseOrderRequest = new HashSet<Item_PurchaseOrderRequest>();
        }
    
        public System.Guid PurchaseStatusID { get; set; }
        public string PurchaseStatusName { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrder> Item_PurchaseOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderRequest> Item_PurchaseOrderRequest { get; set; }
    }
}
