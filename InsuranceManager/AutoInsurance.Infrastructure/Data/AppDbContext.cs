using Autoinsurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autoinsurance.Infrastructure.Data
{
    public class AutoinsuranceDbContext : DbContext
    {
        public AutoinsuranceDbContext(DbContextOptions<AutoinsuranceDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Policy>()
                .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomersId);
        }
    }
}