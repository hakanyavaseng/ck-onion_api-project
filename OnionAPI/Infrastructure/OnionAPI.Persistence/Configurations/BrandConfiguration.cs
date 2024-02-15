using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(256);

            //Creating faker instance to fill out properties using Bogus.
            Faker faker = new("tr");

            builder.HasData(
                new Brand()
                {
                    Id = 1,
                    Name = faker.Commerce.Department(),
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
                 new Brand()
                 {
                     Id = 2,
                     Name = faker.Commerce.Department(),
                     CreatedDate = DateTime.Now,
                     IsDeleted = false
                 },
                  new Brand()
                  {
                      Id = 3,
                      Name = faker.Commerce.Department(),
                      CreatedDate = DateTime.Now,
                      IsDeleted = true
                  });
        }
    }
}
