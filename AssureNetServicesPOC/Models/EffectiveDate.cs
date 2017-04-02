namespace AssureNetServicesPOC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 
    /// </summary>
    public partial class EffectiveDate
    {
        [Key]
        [Column("EffectiveDate")]
        public DateTime EffectiveDate1 { get; set; }

        [StringLength(2)]
        public string FiscalMonth { get; set; }

        [StringLength(4)]
        public string FiscalYear { get; set; }

        [StringLength(2)]
        public string ReportingPeriod { get; set; }
    }
}
