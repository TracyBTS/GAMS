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
    
    public partial class Catalog_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalog_Employee()
        {
            this.Catalog_EmployeeAccounts = new HashSet<Catalog_EmployeeAccounts>();
            this.Catalog_EmployeeAccounts1 = new HashSet<Catalog_EmployeeAccounts>();
            this.Catalog_EmployeeCompetency = new HashSet<Catalog_EmployeeCompetency>();
            this.Catalog_EmployeeLicense = new HashSet<Catalog_EmployeeLicense>();
            this.Catalog_EmployeeReportingExceptions = new HashSet<Catalog_EmployeeReportingExceptions>();
            this.Catalog_EmployeeRole = new HashSet<Catalog_EmployeeRole>();
            this.Catalog_EmployeeServiceDepartments = new HashSet<Catalog_EmployeeServiceDepartments>();
            this.Configuration_ActorRoleSecurity = new HashSet<Configuration_ActorRoleSecurity>();
            this.Configuration_ActorRoleSecurityElement = new HashSet<Configuration_ActorRoleSecurityElement>();
            this.Configuration_ElectronicFormTask = new HashSet<Configuration_ElectronicFormTask>();
            this.Item_AssetControlItemValue = new HashSet<Item_AssetControlItemValue>();
            this.Item_AssetHistory = new HashSet<Item_AssetHistory>();
            this.Item_AssetProcedurePart = new HashSet<Item_AssetProcedurePart>();
            this.Item_Contract = new HashSet<Item_Contract>();
            this.Item_Contract1 = new HashSet<Item_Contract>();
            this.Item_ContractFile = new HashSet<Item_ContractFile>();
            this.Item_ContractLimit = new HashSet<Item_ContractLimit>();
            this.Item_DeliveryAdvice = new HashSet<Item_DeliveryAdvice>();
            this.Item_DeliveryAdvice1 = new HashSet<Item_DeliveryAdvice>();
            this.Item_DeliveryAdvice2 = new HashSet<Item_DeliveryAdvice>();
            this.Item_DeliveryAdvice3 = new HashSet<Item_DeliveryAdvice>();
            this.Item_DeliveryAdviceItem = new HashSet<Item_DeliveryAdviceItem>();
            this.Item_PurchaseOrder = new HashSet<Item_PurchaseOrder>();
            this.Item_PurchaseOrderHistory = new HashSet<Item_PurchaseOrderHistory>();
            this.Item_PurchaseOrderNotes = new HashSet<Item_PurchaseOrderNotes>();
            this.Item_PurchaseOrderRequest = new HashSet<Item_PurchaseOrderRequest>();
            this.Item_PurchaseOrderRequest1 = new HashSet<Item_PurchaseOrderRequest>();
            this.Item_WorkOrder1 = new HashSet<Item_WorkOrder>();
            this.Item_WorkOrderAsset = new HashSet<Item_WorkOrderAsset>();
            this.Item_WorkOrderEvent = new HashSet<Item_WorkOrderEvent>();
            this.Item_WorkOrderEventInvoice = new HashSet<Item_WorkOrderEventInvoice>();
            this.Item_WorkOrderEventWarehouseTransaction = new HashSet<Item_WorkOrderEventWarehouseTransaction>();
            this.Item_WorkOrderEventWarehouseTransaction1 = new HashSet<Item_WorkOrderEventWarehouseTransaction>();
            this.Item_WorkOrderFile = new HashSet<Item_WorkOrderFile>();
            this.Item_WorkOrderHistory = new HashSet<Item_WorkOrderHistory>();
        }
    
        public System.Guid EmployeeID { get; set; }
        public string ADUsername { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AliasName { get; set; }
        public Nullable<System.Guid> ServiceSiteIDPrimary { get; set; }
        public Nullable<System.Guid> ServiceDepartmentIDPrimary { get; set; }
        public Nullable<System.DateTime> DateHired { get; set; }
        public Nullable<System.DateTime> DateTerminated { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsEngineer { get; set; }
        public bool IsPhysist { get; set; }
        public bool IsContracts { get; set; }
        public bool IsPMManager { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsGodMode { get; set; }
        public bool IsAccounts { get; set; }
        public bool IsDispatch { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobile { get; set; }
        public string ContactMobilePrivate { get; set; }
        public string ContactEmergency { get; set; }
        public string PayrollNumber { get; set; }
        public string DriversLicenseFilename { get; set; }
        public System.Guid CostCentreID { get; set; }
        public Nullable<System.Guid> WorkOrderID { get; set; }
        public string Notes { get; set; }
        public decimal UtilisationTargetHoursDaily { get; set; }
    
        public virtual Catalog_BusinessAreaDistrictCostCentre Catalog_BusinessAreaDistrictCostCentre { get; set; }
        public virtual Catalog_ServiceSite Catalog_ServiceSite { get; set; }
        public virtual Catalog_ServiceSiteServiceDepartment Catalog_ServiceSiteServiceDepartment { get; set; }
        public virtual Item_WorkOrder Item_WorkOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeAccounts> Catalog_EmployeeAccounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeAccounts> Catalog_EmployeeAccounts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeCompetency> Catalog_EmployeeCompetency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeLicense> Catalog_EmployeeLicense { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeReportingExceptions> Catalog_EmployeeReportingExceptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeRole> Catalog_EmployeeRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeServiceDepartments> Catalog_EmployeeServiceDepartments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuration_ActorRoleSecurity> Configuration_ActorRoleSecurity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuration_ActorRoleSecurityElement> Configuration_ActorRoleSecurityElement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuration_ElectronicFormTask> Configuration_ElectronicFormTask { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_AssetControlItemValue> Item_AssetControlItemValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_AssetHistory> Item_AssetHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_AssetProcedurePart> Item_AssetProcedurePart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_Contract> Item_Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_Contract> Item_Contract1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_ContractFile> Item_ContractFile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_ContractLimit> Item_ContractLimit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdvice> Item_DeliveryAdvice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdvice> Item_DeliveryAdvice1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdvice> Item_DeliveryAdvice2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdvice> Item_DeliveryAdvice3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_DeliveryAdviceItem> Item_DeliveryAdviceItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrder> Item_PurchaseOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderHistory> Item_PurchaseOrderHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderNotes> Item_PurchaseOrderNotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderRequest> Item_PurchaseOrderRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderRequest> Item_PurchaseOrderRequest1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrder> Item_WorkOrder1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderAsset> Item_WorkOrderAsset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEvent> Item_WorkOrderEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventInvoice> Item_WorkOrderEventInvoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventWarehouseTransaction> Item_WorkOrderEventWarehouseTransaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderEventWarehouseTransaction> Item_WorkOrderEventWarehouseTransaction1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderFile> Item_WorkOrderFile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_WorkOrderHistory> Item_WorkOrderHistory { get; set; }
    }
}