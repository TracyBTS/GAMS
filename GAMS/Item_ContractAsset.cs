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
    
    public partial class Item_ContractAsset
    {
        public System.Guid ContractAssetID { get; set; }
        public System.Guid ContractID { get; set; }
        public System.Guid AssetID { get; set; }
        public Nullable<System.DateTime> DateCoverageStart { get; set; }
        public Nullable<System.DateTime> DateCoverageEnd { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.Guid> ContractTypeID { get; set; }
    
        public virtual Dictionary_ContractType Dictionary_ContractType { get; set; }
        public virtual Item_Contract Item_Contract { get; set; }
        public virtual Item_ContractAsset Item_ContractAsset1 { get; set; }
        public virtual Item_ContractAsset Item_ContractAsset2 { get; set; }
    }
}