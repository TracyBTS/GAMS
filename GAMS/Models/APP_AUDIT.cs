//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class APP_AUDIT
    {
        public string APP_TYPE { get; set; }
        public string KEY1 { get; set; }
        public string KEY2 { get; set; }
        public int SEQUENCE { get; set; }
        public Nullable<System.DateTime> AUDIT_DATE { get; set; }
        public string AUDITOR { get; set; }
        public string NOTES { get; set; }
    }
}