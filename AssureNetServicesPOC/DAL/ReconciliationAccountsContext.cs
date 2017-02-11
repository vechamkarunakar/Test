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
            modelBuilder.Entity<view_ReconciliationResults>().ToTable("view_ReconciliationResults")
               .HasOptional<Reconciliations_Files>(c => c.FileAttachment);

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