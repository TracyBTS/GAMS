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
    
    public partial class Item_AssetControlItemValue
    {
        public System.Guid AssetFieldValueID { get; set; }
        public System.Guid AssetID { get; set; }
        public System.Guid ControlItemID { get; set; }
        public string Value { get; set; }
        public string Notes { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateValidTo { get; set; }
        public System.Guid EmployeeIDCreated { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Configuration_ControlItem Configuration_ControlItem { get; set; }
        public virtual Item_Asset Item_Asset { get; set; }
    }
}