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
    
    public partial class Item_WorkOrderEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item_WorkOrderEvent()
        {
            this.Item_DeliveryAdviceItem = new HashSet<Item_DeliveryAdviceItem>();
            this.Item_DeliveryAdviceItem1 = new HashSet<Item_DeliveryAdviceItem>();
            this.Item_WorkOrderEventControlItemValue = new HashSet<Item_WorkOrderEventControlItemValue>();
            this.Item_WorkOrderEventInvoice = new HashSet<Item_WorkOrderEventInvoice>();
            this.Item_WorkOrderEventWarehouseTransaction = new HashSet<Item_WorkOrderEventWarehouseTransaction>();
        }
    
        public System.Guid WorkOrderEventID { get; set; }
        public System.Guid WorkOrderID { get; set; }
        public Nullable<System.Guid> WorkOrderAssetID { get; set; }
        public Nullable<System.Guid> EmployeeID { get; set; }
        public Nullable<System.Guid> VendorID { get; set; }
        public System.Guid EventResponseID { get; set; }
        public bool IsCorrective { get; set; }
        public bool IsSuccessfull { get; set; }
        public bool IsTesting { get; set; }
        public Nullable<int> TimeTaken { get; set; }
        public Nullable<decimal> TimeMultiplier { get; set; }
        public Nullable<decimal> TimeFixedFee { get; set; }
        public Nullable<decimal> TimeChargeTotal { get; set; }
        public bool IsLabourBillable { get; set; }
        public Nullable<System.Guid> PartID { get; set; }
        public Nullable<System.Guid> WarehouseID { get; set; }
        public Nullable<System.Guid> PurchaseLineItemID { get; set; }
        public string VendorPartNumber { get; set; }
        public string VendorPartDescription { get; set; }
        public string UnitOfMeasureID { get; set; }
        public Nullable<System.Guid> RequestID { get; set; }
        public Nullable<decimal> PartChargeEach { get; set; }
        public Nullable<decimal> PartQuantity { get; set; }
        public Nullable<decimal> PartQuantityReceived { get; set; }
        public Nullable<decimal> PartServiceCharge { get; set; }
        public Nullable<decimal> PartChargeTotal { get; set; }
        public Nullable<System.DateTime> DatePartExpiry { get; set; }
        public Nullable<bool> IsPartBillable { get; set; }
        public Nullable<bool> IsPartFromWarehouse { get; set; }
        public bool IsEventProvisionedAndNotActionedYet { get; set; }
        public Nullable<decimal> FinalCharge { get; set; }
        public bool IsPrivateViewOnly { get; set; }
        public Nullable<System.Guid> AssetIDTestEquipment { get; set; }
        public Nullable<System.DateTime> TestEquipmentStickerDate { get; set; }
        public Nullable<System.Guid> CostCentreIDIfDifferentToWO { get; set; }
        public string Notes { get; set; }
        public System.DateTime DateOfEvent { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public System.Guid ChargeRateTierID { get; set; }
        public Nullable<decimal> Longitudue { get; set; }
        public Nullable<decimal> Latitude { get; set; }
    
        public virtual Catalog_ChargeRateTier Catalog_ChargeRateTier { get; set; }
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Catalog_EventResponse Catalog_EventResponse { get; set; }
        public virtual Catalog_Part Catalog_Part { get; set; }
        public virtual Catalog_Vendor Catalog_Vendor { get; set; }
        public virtual Dictionary_Warehouse Dictionary_Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdviceItem> Item_DeliveryAdviceItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdviceItem> Item_DeliveryAdviceItem1 { get; set; }
        public virtual Item_PurchaseOrderRequest Item_PurchaseOrderRequest { get; set; }
        public virtual Item_WorkOrder Item_WorkOrder { get; set; }
        public virtual Item_WorkOrderAsset Item_WorkOrderAsset { get; set; }
        public virtual Item_WorkOrderEvent Item_WorkOrderEvent1 { get; set; }
        public virtual Item_WorkOrderEvent Item_WorkOrderEvent2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventControlItemValue> Item_WorkOrderEventControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventInvoice> Item_WorkOrderEventInvoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventWarehouseTransaction> Item_WorkOrderEventWarehouseTransaction { get; set; }
    }
}