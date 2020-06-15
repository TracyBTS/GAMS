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
    
    public partial class Item_WorkOrderAsset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item_WorkOrderAsset()
        {
            this.Item_WorkOrderEvent = new HashSet<Item_WorkOrderEvent>();
        }
    
        public System.Guid WorkOrderAssetID { get; set; }
        public Nullable<System.Guid> WorkOrderID { get; set; }
        public Nullable<System.Guid> AssetID { get; set; }
        public string IfAssetIDNullThenItemDescription { get; set; }
        public Nullable<System.Guid> ProcedureID { get; set; }
        public Nullable<System.Guid> EmployeeID { get; set; }
        public Nullable<System.Guid> VendorID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<System.DateTime> DateDue { get; set; }
        public Nullable<System.DateTime> DateWorkOrderStatus { get; set; }
        public Nullable<System.DateTime> DateComplete { get; set; }
        public Nullable<bool> IsBillable { get; set; }
        public Nullable<bool> IsWarranty { get; set; }
        public Nullable<bool> IsContract { get; set; }
        public Nullable<System.Guid> DecontaimicationIDOnPresentation { get; set; }
        public Nullable<int> EquipmentDowntime { get; set; }
        public Nullable<decimal> ChargeJobValue { get; set; }
        public Nullable<decimal> ChargeTotalProcessed { get; set; }
        public Nullable<System.DateTime> ChargeLastProcessed { get; set; }
        public Nullable<System.Guid> WorkOrderStatusID { get; set; }
        public Nullable<System.Guid> WorkOrderTypeID { get; set; }
        public Nullable<System.Guid> WorkOrderFailureID { get; set; }
        public string RequestText { get; set; }
        public string Notes { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Catalog_Vendor Catalog_Vendor { get; set; }
        public virtual Dictionary_Procedure Dictionary_Procedure { get; set; }
        public virtual Dictionary_WorkOrderFailure Dictionary_WorkOrderFailure { get; set; }
        public virtual Dictionary_WorkOrderStatus Dictionary_WorkOrderStatus { get; set; }
        public virtual Dictionary_WorkOrderType Dictionary_WorkOrderType { get; set; }
        public virtual Item_Asset Item_Asset { get; set; }
        public virtual Item_WorkOrder Item_WorkOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEvent> Item_WorkOrderEvent { get; set; }
    }
}
