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
    
    public partial class Catalog_PartSupplier
    {
        public System.Guid PartSupplierID { get; set; }
        public System.Guid VendorID { get; set; }
        public System.Guid PartID { get; set; }
        public bool IsEnabled { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public int SupplierPreference { get; set; }
        public Nullable<decimal> CostToBuy { get; set; }
        public Nullable<int> SupplyTime { get; set; }
        public Nullable<bool> IsDangerousGoods { get; set; }
    
        public virtual Catalog_Part Catalog_Part { get; set; }
        public virtual Catalog_Vendor Catalog_Vendor { get; set; }
    }
}
