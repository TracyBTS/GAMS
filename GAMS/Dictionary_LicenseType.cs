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
    
    public partial class Dictionary_LicenseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dictionary_LicenseType()
        {
            this.Catalog_EmployeeLicense = new HashSet<Catalog_EmployeeLicense>();
        }
    
        public System.Guid LicenseTypeID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsExpires { get; set; }
        public Nullable<System.Guid> PeriodID { get; set; }
        public Nullable<int> PeriodUnit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeLicense> Catalog_EmployeeLicense { get; set; }
    }
}
