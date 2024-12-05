using Autoinsurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;

namespace Autoinsurance.Infrastructure.Data
{
    public class AutoinsuranceDbContext : DbContext
    {
        public AutoinsuranceDbContext(DbContextOptions<AutoinsuranceDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Domain.Entities.Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
