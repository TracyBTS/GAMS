//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item_PurchaseOrderControlItemValue
    {
        public System.Guid PurchaseOrderControlItemValue { get; set; }
        public System.Guid PurchaseOrderID { get; set; }
        public System.Guid ControlItemID { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Item_PurchaseOrder Item_PurchaseOrder { get; set; }
    }
}
