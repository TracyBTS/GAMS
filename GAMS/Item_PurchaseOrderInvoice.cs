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
    
    public partial class Item_PurchaseOrderInvoice
    {
        public System.Guid PurchaseOrderInvoiceID { get; set; }
        public System.Guid PurchaseOrderID { get; set; }
        public string InvoiceNumber { get; set; }
        public System.Guid WorkOrderEventInvoiceID { get; set; }
        public Nullable<decimal> ChargesToBeSharedOut { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateInvoiceReceived { get; set; }
        public Nullable<System.DateTime> DateOriginalFileDate { get; set; }
        public Nullable<System.DateTime> DateBatched { get; set; }
        public Nullable<System.DateTime> DateCleared { get; set; }
        public Nullable<decimal> ChargesFreight { get; set; }
        public Nullable<decimal> ChargesHandling { get; set; }
        public Nullable<decimal> ChargesAmountGross { get; set; }
        public Nullable<decimal> ChargesTax { get; set; }
    
        public virtual Item_PurchaseOrder Item_PurchaseOrder { get; set; }
    }
}