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
    
    public partial class Item_ContractFile
    {
        public System.Guid ContractFileID { get; set; }
        public System.Guid ContractID { get; set; }
        public string FileURI { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public System.Guid EmployeeID { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Item_Contract Item_Contract { get; set; }
    }
}
