using PerformerDatabaseImplements.Models;
using Microsoft.EntityFrameworkCore;

namespace PerformerDatabaseImplements
{
    public class PerformerDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;initial catalog='PerformerDatabaseRealization';Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Procedure> Procedures { set; get; }
        public virtual DbSet<Purchase> Purchases { set; get; }
        public virtual DbSet<ProcedurePurchase> ProcedurePurchases { get; set; }
        public virtual DbSet<ProcedureVisit> ProcedureVisits { get; set; }
        public virtual DbSet<Visit> Visits { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
    }
}
