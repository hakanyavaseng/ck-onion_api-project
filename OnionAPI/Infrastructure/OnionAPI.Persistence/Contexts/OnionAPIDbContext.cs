using Microsoft.EntityFrameworkCore;
using OnionAPI.Domain.Entities;
using System.Reflection;

namespace OnionAPI.Persistence.Contexts
{
    public class OnionAPIDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public OnionAPIDbContext(){}

        public OnionAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
