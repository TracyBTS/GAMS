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
    
    public partial class Item_WorkOrderHistory
    {
        public System.Guid WorkOrderHistoryID { get; set; }
        public System.Guid WorkOrderID { get; set; }
        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public string OldValue { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.Guid EmployeeID { get; set; }
        public string Notes { get; set; }
        public Nullable<System.Guid> RelatedToItemID { get; set; }
        public Nullable<System.Guid> ExceptionID { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Item_WorkOrder Item_WorkOrder { get; set; }
    }
}