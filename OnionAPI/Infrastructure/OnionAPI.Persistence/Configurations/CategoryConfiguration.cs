using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Elektrik",
                    Priority = 1,
                    ParentId = 0,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                new Category()
                {
                    Id = 2,
                    Name = "Moda",
                    Priority = 2,
                    ParentId = 0,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                },
                 new Category()
                 {
                     Id = 3,
                     Name = "Bilgisayar",
                     Priority = 1,
                     ParentId = 1,
                     CreatedDate = DateTime.Now,
                     IsDeleted = false,
                 },
                  new Category()
                  {
                      Id = 4,
                      Name = "Kadın",
                      Priority = 1,
                      ParentId = 2,
                      CreatedDate = DateTime.Now,
                      IsDeleted = false,
                  });
        }
    }
}
