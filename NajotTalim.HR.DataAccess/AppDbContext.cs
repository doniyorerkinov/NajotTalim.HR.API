using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAccess.Entities;

namespace NajotTalim.HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasDefaultValueSql("'sample@email.com'");

            modelBuilder.Entity<Address>()
                .HasData(
                new Address
                {
                    id = 999,
                    AddressLine1 = "asdas",
                    AddressLine2 = "asdas",
                    PostalCode = "asdas",
                    City = "asdas",
                    Country = "asdas",
                });
        }

    }
}
