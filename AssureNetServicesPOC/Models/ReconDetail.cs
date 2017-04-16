using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.OData;
using System.Web.OData.Query;

namespace AssureNetServicesPOC.Models
{
    [Select(SelectType = SelectExpandType.Automatic)]
    [Select("ReconId", SelectType = SelectExpandType.Disabled)]
    public partial class ReconDetail
    {
        [StringLength(50)]
        public string CompanyCode { get; set; }

        [StringLength(50)]
        
        public string AccountNumber { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReconId { get; set; }

        public string AccountDesc { get; set; }

        [StringLength(15)]
        public string ReviewStatusID { get; set; }

        [StringLength(15)]
        public string ApprovalStatusID { get; set; }

        [StringLength(15)]
        public string ReconciliationStatusID { get; set; }

        [StringLength(50)]
        public string ReviewStatus { get; set; }

        [StringLength(50)]
        public string ReconStatus { get; set; }

        [StringLength(50)]
        public string ApprovalStatus { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string FiscalMonth { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime EffectiveDate { get; set; }

        [StringLength(3)]
        public string ReportingCurrency { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLEndBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLReconBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLReconItems { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnexplainBalance { get; set; }

        [StringLength(3)]
        public string LocalCurrency { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLEndBalanceL { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLReconBalanceL { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLReconItemsL { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnexplainBalanceL { get; set; }

        [StringLength(100)]
        public string ReconcilerFullName { get; set; }

        [StringLength(500)]
        public string Reconciler { get; set; }

        [StringLength(100)]
        public string ReviewerFullName { get; set; }

        [StringLength(500)]
        public string Reviewer { get; set; }

        [StringLength(100)]
        public string ApproverFullName { get; set; }

        [StringLength(500)]
        public string Approver { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        public int ReconcilerID { get; set; }

        public int ReviewerID { get; set; }

        public int ApproverID { get; set; }
    }
}