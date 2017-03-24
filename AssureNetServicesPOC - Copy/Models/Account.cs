namespace AssureNetServicesPOC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [Key]
        public int PKId { get; set; }

        public bool? Active { get; set; }

        public DateTime? DateActivated { get; set; }

        [StringLength(15)]
        public string LocationID { get; set; }

        [StringLength(200)]
        public string AccountName { get; set; }

        public string Description { get; set; }

        [StringLength(3)]
        public string CCY1Code { get; set; }

        [StringLength(3)]
        public string CCY2Code { get; set; }

        [StringLength(3)]
        public string CCY3Code { get; set; }

        public bool? ReconcileCCY1 { get; set; }

        public bool? ReconcileCCY2 { get; set; }

        public bool? ReconcileCCY3 { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1LowBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1HighBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2LowBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2HighBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3LowBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3HighBalance { get; set; }

        public int? ReconcilerID { get; set; }

        public int? BUReconcilerID { get; set; }

        [StringLength(15)]
        public string ReconciliationScheduleID { get; set; }

        public int? ReviewerID { get; set; }

        public int? BUReviewerID { get; set; }

        [StringLength(15)]
        public string ReviewScheduleID { get; set; }

        public bool? RequiresApproval { get; set; }

        public int? ApproverID { get; set; }

        public int? BUApproverID { get; set; }

        [StringLength(15)]
        public string ApprovalScheduleID { get; set; }

        public int? ReconciliationFormatID { get; set; }

        [StringLength(50)]
        public string NotificationID { get; set; }

        public DateTime? LastReconEffDate { get; set; }

        public DateTime? LastReconDueDate { get; set; }

        [StringLength(15)]
        public string LastReconciliationResultID { get; set; }

        public DateTime? LastReviewEffDate { get; set; }

        public DateTime? LastReviewDueDate { get; set; }

        public DateTime? LastApprovalEffDate { get; set; }

        public DateTime? LastApprovalDueDate { get; set; }

        public DateTime? NextReconEffDate { get; set; }

        public DateTime? NextReconDueDate { get; set; }

        public DateTime? NextReviewEffDate { get; set; }

        public DateTime? NextReviewDueDate { get; set; }

        public DateTime? NextApprovalEffDate { get; set; }

        public DateTime? NextApprovalDueDate { get; set; }

        [StringLength(15)]
        public string QARiskRatingID { get; set; }

        public DateTime? LastQADate { get; set; }

        [StringLength(15)]
        public string LastQAResultID { get; set; }

        [StringLength(15)]
        public string AccountTypeID { get; set; }

        public string ReconPolicy { get; set; }

        public bool? IsGroup { get; set; }

        public double? CCY1Rate { get; set; }

        public double? CCY2Rate { get; set; }

        public double? CCY3Rate { get; set; }

        public DateTime? DateLastImported { get; set; }

        [StringLength(15)]
        public string OwnerId { get; set; }

        public bool? ZeroBalanceBulkFlg { get; set; }

        public bool? ReconcileIndividually { get; set; }

        public bool? ManuallyAdded { get; set; }

        [StringLength(15)]
        public string QATestCycleID { get; set; }

        [StringLength(15)]
        public string ClearingStandardID { get; set; }

        public bool? CCY1GenerateBalance { get; set; }

        public bool? CCY2GenerateBalance { get; set; }

        public bool? CCY3GenerateBalance { get; set; }

        [StringLength(15)]
        public string CCY1DefaultRateType { get; set; }

        [StringLength(15)]
        public string CCY2DefaultRateType { get; set; }

        [StringLength(15)]
        public string CCY3DefaultRateType { get; set; }

        public bool? ExcludeFXConversion { get; set; }

        [StringLength(13)]
        public string ReconNETAccountObjectId { get; set; }

        public bool? RevalAccount { get; set; }

        public int? RevalAccountId { get; set; }

        public short? ReconNETCCYLevel { get; set; }

        public Guid? ReconConnectionId { get; set; }

        public int? UnityTaskID { get; set; }

        public bool NoChangeBulkFlg { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1SplitAllowance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2SplitAllowance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3SplitAllowance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1ManualMatchTolerance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2ManualMatchTolerance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3ManualMatchTolerance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1VarianceAllowance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2VarianceAllowance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3VarianceAllowance { get; set; }

        public int? EntityId { get; set; }

        public bool IsAssigned { get; set; }
    }
}
