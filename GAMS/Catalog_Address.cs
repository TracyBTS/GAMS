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
    
    public partial class Catalog_Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalog_Address()
        {
            this.Catalog_BusinessAreaDistrictCostCentre = new HashSet<Catalog_BusinessAreaDistrictCostCentre>();
            this.Catalog_ServiceSite = new HashSet<Catalog_ServiceSite>();
            this.Catalog_ServiceSiteServiceDepartment = new HashSet<Catalog_ServiceSiteServiceDepartment>();
            this.Catalog_VendorAddress = new HashSet<Catalog_VendorAddress>();
            this.Item_PurchaseOrderRequest = new HashSet<Item_PurchaseOrderRequest>();
        }
    
        public System.Guid AddressID { get; set; }
        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public string StreetUnitNumber { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public bool IsEnabled { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_BusinessAreaDistrictCostCentre> Catalog_BusinessAreaDistrictCostCentre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_ServiceSite> Catalog_ServiceSite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_ServiceSiteServiceDepartment> Catalog_ServiceSiteServiceDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog_VendorAddress> Catalog_VendorAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_PurchaseOrderRequest> Item_PurchaseOrderRequest { get; set; }
    }
}
