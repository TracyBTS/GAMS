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
    
    public partial class Catalog_ManufacturerModelVersion
    {
        public System.Guid ModelVersionID { get; set; }
        public System.Guid ModelID { get; set; }
        public string ModelVersionDescription { get; set; }
        public System.DateTime DateCeated { get; set; }
        public System.DateTime DateModified { get; set; }
        public Nullable<System.Guid> RiskID { get; set; }
        public Nullable<System.Guid> EquipmentTypeID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> ListPrice { get; set; }
        public bool IsEnabled { get; set; }
    }
}
