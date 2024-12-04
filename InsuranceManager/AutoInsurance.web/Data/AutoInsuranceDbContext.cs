using AutoInsure.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AutoInsure.Web.Data
{
    public class AutoInsureDbContext : DbContext
    {
        public AutoInsureDbContext(DbContextOptions<AutoInsureDbContext> options) : base(options)
        {
        }

        public DbSet<Clustomers> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
