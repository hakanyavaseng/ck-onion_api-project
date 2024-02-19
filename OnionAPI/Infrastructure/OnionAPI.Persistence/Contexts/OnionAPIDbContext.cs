using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionAPI.Domain.Entities;
using OnionAPI.Domain.Entities.Identity;
using System.Reflection;

namespace OnionAPI.Persistence.Contexts
{
    public class OnionAPIDbContext : IdentityDbContext<User,Role,Guid>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      
        }

        public OnionAPIDbContext(){}

        public OnionAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
