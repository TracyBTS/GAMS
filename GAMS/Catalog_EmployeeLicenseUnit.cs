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
    
    public partial class Catalog_EmployeeLicenseUnit
    {
        public System.Guid EmployeeLicenseUnitID { get; set; }
        public Nullable<System.Guid> EmployeeLicenseID { get; set; }
        public string UnitDescription { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
    
        public virtual Catalog_EmployeeLicense Catalog_EmployeeLicense { get; set; }
    }
}
