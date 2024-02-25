using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasData(
                new Product
                {
                    id = 1,
                    name = "Jackob",
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    count = 50,
                    price = 120,
                    brandId = 1,
                    cityId = 1,
                    color = "black",
                    description = "its nice",
                    IsAvalaible = true,
                    productCategoryId = 1,
                    size = "large",
                    img = null,
                    sellerid = "",



                        },
                         new Product
                         {
                             id = 2,
                             name = "mitra",
                             CreatedDay = DateTime.Now,
                             LastModifiedDate = DateTime.Now,
                             count = 20,
                             price = 200,
                             brandId = 2,
                             cityId = 2,
                             color = "brown",
                             description = "its nice",
                             IsAvalaible = true,
                             productCategoryId = 2,
                             size = "small",
                             img = null,
                             sellerid = "",

                         }
                        );
                }
    }
}
