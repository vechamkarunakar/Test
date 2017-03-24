namespace AssureNetServicesPOC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<EffectiveDate> EffectiveDates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EffectiveDate>()
                .Property(e => e.FiscalMonth)
                .IsFixedLength();

            modelBuilder.Entity<EffectiveDate>()
                .Property(e => e.FiscalYear)
                .IsFixedLength();

            modelBuilder.Entity<EffectiveDate>()
                .Property(e => e.ReportingPeriod)
                .IsFixedLength();
        }
    }
}
