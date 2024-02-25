using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    id = 1,
                    name = "anahita",
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    description = "wow",

                },
                 new Brand
                 {
                     id = 2,
                     name = "mitra",
                     CreatedDay = DateTime.Now,
                     LastModifiedDate = DateTime.Now,
                     description = "amazing",
                 }
                );
        }
    }
}
