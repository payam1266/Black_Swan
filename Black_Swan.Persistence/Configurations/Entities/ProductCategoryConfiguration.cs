using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                new ProductCategory
                {
                    id = 1,
                    name = "shoe",
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                },
                  new ProductCategory
                  {
                      id = 2,
                      name = "dress",
                      CreatedDay = DateTime.Now,
                      LastModifiedDate = DateTime.Now,
                  }
                );
        }
    }
}
