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
    
    public partial class Dictionary_ContractType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dictionary_ContractType()
        {
            this.Item_ContractAsset = new HashSet<Item_ContractAsset>();
        }
    
        public System.Guid ContractTypeID { get; set; }
        public string ContractTypeName { get; set; }
        public bool IncludesLabour { get; set; }
        public bool IncludesParts { get; set; }
        public Nullable<bool> IncludesFreight { get; set; }
        public Nullable<bool> IncludesService { get; set; }
        public Nullable<bool> IncludesRepair { get; set; }
        public Nullable<bool> IncludesSoftware { get; set; }
        public Nullable<bool> IsAllianceAgreement { get; set; }
        public int ReviewXDaysBeforeTermination { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_ContractAsset> Item_ContractAsset { get; set; }
    }
}
