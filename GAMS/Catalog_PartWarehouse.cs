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
    
    public partial class Catalog_PartWarehouse
    {
        public System.Guid PartWarehouseID { get; set; }
        public System.Guid WarehouseID { get; set; }
        public System.Guid PartID { get; set; }
        public Nullable<decimal> ReorderLevel { get; set; }
        public Nullable<decimal> ReOrderQuantity { get; set; }
        public Nullable<decimal> QuantityOnHand { get; set; }
        public Nullable<decimal> QuantityReceivedInHolding { get; set; }
        public Nullable<bool> IsImprest { get; set; }
        public Nullable<System.Guid> UnitOfMeasureIDDistribution { get; set; }
    
        public virtual Catalog_Part Catalog_Part { get; set; }
        public virtual Dictionary_Warehouse Dictionary_Warehouse { get; set; }
    }
}
