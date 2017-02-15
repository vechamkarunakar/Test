using AssureNetServicesPOC.Models;
using System.Data.Entity;
namespace AssureNetServicesPOC.DAL
{
    public class ReconciliationAccountsContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ReconciliationAccountsContext>(null);
            modelBuilder.Entity<ReconAccount>().ToTable("ReconAccount");
            modelBuilder.Entity<Reconciliations_Files>().ToTable("Reconciliations_Files");
            //modelBuilder.Entity<view_ReconciliationResults>().ToTable("view_ReconciliationResults")
            //   .HasRequired(c => c.FileAttachment).WithRequiredPrincipal(x => x.RAccount);

            modelBuilder.Entity<view_ReconciliationResults>().ToTable("view_ReconciliationResults")
                .HasOptional(x => x.FileAttachment).WithOptionalDependent(y => y.RAccount);

            modelBuilder.Entity<Reconciliations_Files>()
                .HasOptional(x => x.RAccount).WithOptionalPrincipal(y => y.FileAttachment);



        }
        public ReconciliationAccountsContext()
                : base("name=AssureNetContext")
        {
        }
        public virtual DbSet<ReconAccount> ReconAccounts { get; set; }
        public virtual DbSet<Reconciliations_Files> Reconciliations_Files { get; set; }
        public virtual DbSet<view_ReconciliationResults> view_ReconciliationResults { get; set; }
    }
}