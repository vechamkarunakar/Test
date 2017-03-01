namespace AssureNetServicesPOC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class view_ReconciliationResults
    {
        [StringLength(50)]
        public string AccountSegment1 { get; set; }

        [StringLength(50)]
        public string AccountSegment2 { get; set; }

        [StringLength(50)]
        public string AccountSegment3 { get; set; }

        [StringLength(50)]
        public string AccountSegment4 { get; set; }

        [StringLength(50)]
        public string AccountSegment5 { get; set; }

        [StringLength(50)]
        public string AccountSegment6 { get; set; }

        [StringLength(50)]
        public string AccountSegment7 { get; set; }

        [StringLength(50)]
        public string AccountSegment8 { get; set; }

        [StringLength(50)]
        public string AccountSegment9 { get; set; }

        [StringLength(100)]
        public string AccountSegment10 { get; set; }

        public int PKId { get; set; }

        [StringLength(15)]
        public string LocationID { get; set; }

        public string Description { get; set; }

        public int? reconcilerid { get; set; }

        public int? reviewerid { get; set; }

        public int? approverid { get; set; }

        [StringLength(15)]
        public string ReconciliationScheduleID { get; set; }

        [StringLength(15)]
        public string ReviewScheduleID { get; set; }

        [StringLength(15)]
        public string ApprovalScheduleID { get; set; }

        [StringLength(15)]
        public string QARiskRatingID { get; set; }

        [StringLength(15)]
        public string AccountTypeID { get; set; }

        public bool? IsGroup { get; set; }

        [StringLength(15)]
        public string OwnerId { get; set; }

        [StringLength(15)]
        public string ClearingStandardID { get; set; }

        [StringLength(15)]
        public string ReconciliationStatusID { get; set; }

        [StringLength(15)]
        public string ReviewStatusID { get; set; }

        [StringLength(15)]
        public string ApprovalStatusID { get; set; }

        [Key]
        [Column(Order = 0)]
        public DateTime EffectiveDate { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime DateReconciliationDue { get; set; }

        public DateTime? DateReconciled { get; set; }

        [StringLength(15)]
        public string ReconciliationResultID { get; set; }

        public DateTime? DateReviewDue { get; set; }

        public DateTime? DateReviewed { get; set; }

        public bool? requiresapproval { get; set; }

        public DateTime? DateApprovalDue { get; set; }

        public bool? reconcileccy1 { get; set; }

        public bool? reconcileccy2 { get; set; }

        public bool? reconcileccy3 { get; set; }

        [StringLength(5)]
        public string BulkReconType { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(3)]
        public string CCY1Code { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1GLBegBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1GLActivity { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1GLEndBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1ReconBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1RIGL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1RISL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY1NetUnexplainBalance { get; set; }

        [StringLength(3)]
        public string CCY2Code { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2GLBegBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2GLActivity { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2GLEndBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2ReconBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2RIGL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2RISL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY2NetUnexplainBalance { get; set; }

        [StringLength(3)]
        public string CCY3Code { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3GLBegBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3GLActivity { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3GLEndBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3ReconBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3RIGL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3RISL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CCY3NetUnexplainBalance { get; set; }

        [StringLength(100)]
        public string ReconcilerFullName { get; set; }

        [StringLength(100)]
        public string ReviewerFullName { get; set; }

        [StringLength(100)]
        public string ApproverFullName { get; set; }

        //public virtual Reconciliations_Files FileAttachment { get; set; }
    }
}
