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
    
    public partial class Item_ContractLimit
    {
        public System.Guid ContractLimits { get; set; }
        public System.Guid ContractID { get; set; }
        public System.Guid ContractLimitTypeID { get; set; }
        public decimal LimitTypeValue { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public System.DateTime DateDeleted { get; set; }
        public System.Guid EmployeeID { get; set; }
        public string Notes { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Dictionary_ContractLimitType Dictionary_ContractLimitType { get; set; }
        public virtual Item_Contract Item_Contract { get; set; }
    }
}