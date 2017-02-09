using System.Data.Entity;
namespace AssureNetServicesPOC.Models
{
    public class ReconciliationAccountsContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ReconciliationAccountsContext>(null);

            modelBuilder.Entity<ReconAccount>().ToTable("ReconAccount");
            modelBuilder.Entity<ReconAccount>().HasKey(t => new { t.Id});
        }
        public ReconciliationAccountsContext()
                : base("name=AssureNetContext")
        {
        }
        public DbSet<ReconAccount> ReconAccounts { get; set; }


    }
}