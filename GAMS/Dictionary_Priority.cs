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
    
    public partial class Dictionary_Priority
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dictionary_Priority()
        {
            this.Catalog_ManufacturerModelProcedure1 = new HashSet<Catalog_ManufacturerModelProcedure>();
            this.Item_AssetProcedure = new HashSet<Item_AssetProcedure>();
        }
    
        public System.Guid PriorityID { get; set; }
        public string PriorityName { get; set; }
        public string QuickKey { get; set; }
        public int DaysToComplete { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public bool IsEnabled { get; set; }
    
        public virtual Catalog_ManufacturerModelProcedure Catalog_ManufacturerModelProcedure { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_ManufacturerModelProcedure> Catalog_ManufacturerModelProcedure1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_AssetProcedure> Item_AssetProcedure { get; set; }
    }
}
