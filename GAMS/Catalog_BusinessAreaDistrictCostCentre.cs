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
    
    public partial class Catalog_BusinessAreaDistrictCostCentre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalog_BusinessAreaDistrictCostCentre()
        {
            this.Catalog_CustomerReportingCostCentreMapping = new HashSet<Catalog_CustomerReportingCostCentreMapping>();
            this.Catalog_Employee = new HashSet<Catalog_Employee>();
            this.Catalog_EmployeeAccounts = new HashSet<Catalog_EmployeeAccounts>();
            this.Catalog_ServiceSite = new HashSet<Catalog_ServiceSite>();
            this.Catalog_ServiceSiteServiceDepartment = new HashSet<Catalog_ServiceSiteServiceDepartment>();
            this.Catalog_ServiceSiteServiceDepartment1 = new HashSet<Catalog_ServiceSiteServiceDepartment>();
            this.Configuration_ActorRoleAccountManager = new HashSet<Configuration_ActorRoleAccountManager>();
        }
    
        public System.Guid CostCentreID { get; set; }
        public Nullable<System.Guid> BusinessAreaID { get; set; }
        public Nullable<System.Guid> BusinessAreaDistrictID { get; set; }
        public string CostCentreCode { get; set; }
        public string CostCentreName { get; set; }
        public Nullable<System.Guid> AddressID { get; set; }
        public string Notes { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public bool IsEnabled { get; set; }
        public Nullable<decimal> ChargeRateDefault { get; set; }
        public Nullable<bool> IsPrivateCompany { get; set; }
        public Nullable<System.Guid> CostCentreIDParent { get; set; }
        public Nullable<System.Guid> CostCentreIDRecoverCostsTo { get; set; }
    
        public virtual Catalog_Address Catalog_Address { get; set; }
        public virtual Catalog_BusinessArea Catalog_BusinessArea { get; set; }
        public virtual Catalog_BusinessAreaDistrict Catalog_BusinessAreaDistrict { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_CustomerReportingCostCentreMapping> Catalog_CustomerReportingCostCentreMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_Employee> Catalog_Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_EmployeeAccounts> Catalog_EmployeeAccounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_ServiceSite> Catalog_ServiceSite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_ServiceSiteServiceDepartment> Catalog_ServiceSiteServiceDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_ServiceSiteServiceDepartment> Catalog_ServiceSiteServiceDepartment1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuration_ActorRoleAccountManager> Configuration_ActorRoleAccountManager { get; set; }
    }
}