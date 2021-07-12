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
    
    public partial class PRT
    {
        public string FACILITY { get; set; }
        public string PART_NUM { get; set; }
        public string PART_DESC { get; set; }
        public string PART_DESC2 { get; set; }
        public string CATEGORY { get; set; }
        public string LOCATION1 { get; set; }
        public string LOCATION2 { get; set; }
        public string LOCATION3 { get; set; }
        public Nullable<decimal> QTY_ONHAND { get; set; }
        public Nullable<decimal> QTY_ONORD { get; set; }
        public Nullable<decimal> QTY_COMMIT { get; set; }
        public string COMM_FLAG { get; set; }
        public string ISS_UOM { get; set; }
        public Nullable<decimal> MARKUP { get; set; }
        public Nullable<decimal> METH_COST { get; set; }
        public Nullable<decimal> ISS_PRICE { get; set; }
        public string SUB_PART { get; set; }
        public Nullable<decimal> YTD_USAGE { get; set; }
        public Nullable<decimal> YR1_USAGE { get; set; }
        public Nullable<decimal> YR2_USAGE { get; set; }
        public Nullable<decimal> YR3_USAGE { get; set; }
        public Nullable<decimal> YR4_USAGE { get; set; }
        public Nullable<decimal> YR5_USAGE { get; set; }
        public Nullable<decimal> REORD_LVL { get; set; }
        public Nullable<decimal> REORD_QTY { get; set; }
        public string EXP_FLAG { get; set; }
        public string ACCOUNT { get; set; }
        public string ACCOUNT_FACILITY { get; set; }
        public string INVENTORY { get; set; }
        public Nullable<decimal> LAST_UPDATE { get; set; }
        public string LAST_INV_DATE { get; set; }
        public string NOTES { get; set; }
        public int PRT_ID { get; set; }
        public Nullable<System.DateTime> LAST_INV_DATETIME { get; set; }
        public decimal LIST_PRICE { get; set; }
        public string OEM_NUMBER { get; set; }
        public string PART_KIT { get; set; }
    }
}