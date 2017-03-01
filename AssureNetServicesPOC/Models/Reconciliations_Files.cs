namespace AssureNetServicesPOC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reconciliations_Files
    {
        [Key]
        public int PKId { get; set; }

        public int ReconciliationID { get; set; }

        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        [Required]
        [StringLength(200)]
        public string FileTitle { get; set; }

        [StringLength(15)]
        public string FileClassificationID { get; set; }

        [StringLength(1000)]
        public string Comments { get; set; }

        public DateTime? EntryDate { get; set; }

        public bool? ReviewModified { get; set; }

        public int? SubmittedByID { get; set; }

        public int? ReconciliationDetailID { get; set; }

        public bool? FromCarryForward { get; set; }

        public int? FromCarryForwardFileID { get; set; }

        public bool? CarriedForward { get; set; }

        [StringLength(500)]
        public string FileUploadPath { get; set; }

        [StringLength(1000)]
        public string Commentary { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? ModifyByID { get; set; }


        //public virtual view_ReconciliationResults RAccount { get; set; }
    }
}
