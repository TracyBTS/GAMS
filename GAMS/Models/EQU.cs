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
    
    public partial class EQU
    {
        public string TAG_NUMBER { get; set; }
        public string DESCRIPTN { get; set; }
        public string TYPE { get; set; }
        public string MANUFACTUR { get; set; }
        public string MODEL_NUM { get; set; }
        public string SERIAL_NUM { get; set; }
        public string INSVC_DATE { get; set; }
        public string EQU_STATUS { get; set; }
        public string STAT_DATE { get; set; }
        public string LOCATION { get; set; }
        public string LOC_DATE { get; set; }
        public string INC_FACTOR { get; set; }
        public string COST_CTR { get; set; }
        public string RESP_CTR { get; set; }
        public string SUPPLIER { get; set; }
        public string PO_NUMBER { get; set; }
        public Nullable<decimal> PURCH_COST { get; set; }
        public string WO_NOTES { get; set; }
        public string WO_PURGE { get; set; }
        public string AVG_COST { get; set; }
        public string FACILITY { get; set; }
        public string PRIM_TRADE { get; set; }
        public string SEC_TRADE { get; set; }
        public string ASSET_NUM { get; set; }
        public string TRADE_TYPE { get; set; }
        public string LAST_INV_DATE { get; set; }
        public string INVENTORY { get; set; }
        public Nullable<decimal> HOURLY_RATE { get; set; }
        public string REGION { get; set; }
        public string ENTITY { get; set; }
        public string GL_LOCATION { get; set; }
        public string GL_COST_CTR { get; set; }
        public string GL_CODE { get; set; }
        public Nullable<decimal> LAST_UPDATE { get; set; }
        public string EQU_MODEL_NAME { get; set; }
        public string ORIG_MANUFACTUR { get; set; }
        public string SALVAGE_DATE { get; set; }
        public Nullable<decimal> SALVAGE_VALUE { get; set; }
        public Nullable<decimal> REPLACEMENT_COST { get; set; }
        public string REPLACEMENT_DATE { get; set; }
        public string CONDITION_DATE { get; set; }
        public string TECH_COMM { get; set; }
        public string CONDITION { get; set; }
        public string EQU_NOTES { get; set; }
        public Nullable<int> SUBTYPE { get; set; }
        public string BLD_CODE { get; set; }
        public string CRITICAL { get; set; }
        public string LOC_CODE { get; set; }
        public Nullable<System.DateTime> CONDITION_DATETIME { get; set; }
        public Nullable<System.DateTime> INSVC_DATETIME { get; set; }
        public Nullable<System.DateTime> LAST_INV_DATETIME { get; set; }
        public Nullable<System.DateTime> LOC_DATETIME { get; set; }
        public Nullable<System.DateTime> REPLACEMENT_DATETIME { get; set; }
        public Nullable<System.DateTime> SALVAGE_DATETIME { get; set; }
        public Nullable<System.DateTime> STAT_DATETIME { get; set; }
        public string SITE { get; set; }
        public string OWNERSHIP { get; set; }
        public int MASTER_ID { get; set; }
        public Nullable<int> VMODEL_ID { get; set; }
        public Nullable<System.Guid> RelationshipIDBusinessFaction { get; set; }
        public Nullable<System.Guid> RelationshipIDBusinessArea { get; set; }
        public Nullable<System.Guid> RelationshipIDFacility { get; set; }
        public Nullable<System.Guid> RelationshipIDDepartment { get; set; }
        public Nullable<System.Guid> RealtionshipIDLocation { get; set; }
        public Nullable<System.Guid> RelationshipIDAccountAssetBought { get; set; }
        public Nullable<System.Guid> RelationshipIDAccountAssetMaintain { get; set; }
        public Nullable<System.Guid> RelationshipIDBuilding { get; set; }
        public string LSPN { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
    }
}
