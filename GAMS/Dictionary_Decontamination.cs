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
    
    public partial class Dictionary_Decontamination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dictionary_Decontamination()
        {
            this.Item_DeliveryAdviceItem = new HashSet<Item_DeliveryAdviceItem>();
            this.Item_WorkOrder = new HashSet<Item_WorkOrder>();
        }
    
        public System.Guid DecontaminationID { get; set; }
        public string DecontaminationName { get; set; }
        public string Notes { get; set; }
        public bool IsSafeForHandling { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdviceItem> Item_DeliveryAdviceItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrder> Item_WorkOrder { get; set; }
    }
}
