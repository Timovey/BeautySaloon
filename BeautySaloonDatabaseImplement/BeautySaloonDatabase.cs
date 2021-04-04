using BeautySaloonDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySaloonDatabaseImplement
{
    public class BeautySaloonDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-7MR3DNA6\SQLEXPRESS;Initial Catalog=BeautySaloonEmployeeDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Cosmetic> Cosmetics { set; get; }

        public virtual DbSet<Distribution> Distributions { set; get; }

        public virtual DbSet<DistributionCosmetic> DistributionCosmetics { set; get; }

        public virtual DbSet<Employee> Employees { set; get; }

        public virtual DbSet<Receipt> Receipts { set; get; }

        public virtual DbSet<ReceiptCosmetic> ReceiptCosmetics { set; get; }
    }
}
