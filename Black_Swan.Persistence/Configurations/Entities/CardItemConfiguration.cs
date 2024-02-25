using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    internal class CardItemConfiguration : IEntityTypeConfiguration<CardItem>
    {
        public void Configure(EntityTypeBuilder<CardItem> builder)
        {
            builder.HasData(
                new CardItem
                {
                    id = 1,
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    productcount = 5,
                    productid = 1,
                    productname = "sekiro",
                    productprice = 50,
                    
                },
                new CardItem
                {
                    id = 2,
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    productcount = 5,
                    productid = 1,
                    productname = "santa",
                    productprice = 50,

                }
                );
        }
    }
}
