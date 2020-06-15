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
    
    public partial class Configuration_ControlItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Configuration_ControlItem()
        {
            this.Configuration_ActorRoleSecurityElement = new HashSet<Configuration_ActorRoleSecurityElement>();
            this.Item_AssetControlItemValue = new HashSet<Item_AssetControlItemValue>();
            this.Item_AssetHistory = new HashSet<Item_AssetHistory>();
            this.Item_ContractControlItemValue = new HashSet<Item_ContractControlItemValue>();
            this.Item_PurchaseOrderControlItemValue = new HashSet<Item_PurchaseOrderControlItemValue>();
            this.Item_WorkOrderControlItemValue = new HashSet<Item_WorkOrderControlItemValue>();
            this.Item_WorkOrderEventControlItemValue = new HashSet<Item_WorkOrderEventControlItemValue>();
        }
    
        public System.Guid ControlItemID { get; set; }
        public System.Guid ControlID { get; set; }
        public string FieldName { get; set; }
        public string FieldDescription { get; set; }
        public System.Guid GroupPanelID { get; set; }
        public System.Guid UserInputControlTypeID { get; set; }
        public System.Guid UserInputControlValueID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public string FromPickListTableName { get; set; }
        public bool IsStoreKey { get; set; }
        public bool IsNullable { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAuditable { get; set; }
        public Nullable<System.Guid> ModelVersionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuration_ActorRoleSecurityElement> Configuration_ActorRoleSecurityElement { get; set; }
        public virtual Configuration_ControlItem Configuration_ControlItem1 { get; set; }
        public virtual Configuration_ControlItem Configuration_ControlItem2 { get; set; }
        public virtual Dictionary_PresentationGroupPanel Dictionary_PresentationGroupPanel { get; set; }
        public virtual Dictionary_PresentationUserInputControlType Dictionary_PresentationUserInputControlType { get; set; }
        public virtual Dictionary_PresentationUserInputValue Dictionary_PresentationUserInputValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_AssetControlItemValue> Item_AssetControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_AssetHistory> Item_AssetHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_ContractControlItemValue> Item_ContractControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderControlItemValue> Item_PurchaseOrderControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderControlItemValue> Item_WorkOrderControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventControlItemValue> Item_WorkOrderEventControlItemValue { get; set; }
    }
}
