using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");

            builder.HasData(
                new Product()
                {
                    Id = 1,
                    Title = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    BrandId = 1,
                    Price = faker.Finance.Amount(10, 1000),
                    Discount = faker.Random.Decimal(0, 10),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                new Product()
                {
                    Id = 2,
                    Title = faker.Commerce.ProductName(),
                    Description = faker.Commerce.ProductDescription(),
                    BrandId = 2,
                    Price = faker.Finance.Amount(10, 1000),
                    Discount = faker.Random.Decimal(0, 10),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                });
        }
    }
}
