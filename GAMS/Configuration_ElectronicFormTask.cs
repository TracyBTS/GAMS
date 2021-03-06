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
    
    public partial class Configuration_ElectronicFormTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Configuration_ElectronicFormTask()
        {
            this.Configuration_ElectronicFormTaskRule = new HashSet<Configuration_ElectronicFormTaskRule>();
        }
    
        public System.Guid ElectronicFormTaskID { get; set; }
        public System.Guid ElectronicFormID { get; set; }
        public Nullable<System.Guid> GroupPanelID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int TaskSequence { get; set; }
        public bool IsNullable { get; set; }
        public string UIElementControlType { get; set; }
        public string UIElementValueType { get; set; }
        public string UIElementValueUnit { get; set; }
        public bool IsBaseline { get; set; }
        public Nullable<bool> IsBaselineCalculated { get; set; }
        public Nullable<int> BaselineCalculatedWithLastXReads { get; set; }
        public string Formula { get; set; }
        public string TaskDocumentLink { get; set; }
        public bool DisplayGraphOnDataEntry { get; set; }
        public Nullable<System.Guid> SerialCommandSetID { get; set; }
        public string UserResponse { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public string Alias { get; set; }
        public string TaskNameType { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.Guid> EmployeeIDLastEditted { get; set; }
    
        public virtual Catalog_Employee Catalog_Employee { get; set; }
        public virtual Configuration_ElectronicForm Configuration_ElectronicForm { get; set; }
        public virtual Dictionary_PresentationGroupPanel Dictionary_PresentationGroupPanel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Configuration_ElectronicFormTaskRule> Configuration_ElectronicFormTaskRule { get; set; }
    }
}
