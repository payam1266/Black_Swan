using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasData(
                new OrderDetails
                {
                    id = 1,
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    orderId =1,
                    productName = "jackob",
                    productId = 1,
                    productPrice = 100,
                    quantity = 5,
                    subtotal = 500,

                }
                 //new OrderDetails
                 //{
                 //    id = 2,
                 //    CreatedDay = DateTime.Now,
                 //    LastModifiedDate = DateTime.Now,
                 //    orderId = 2,
                 //    productName = "jackob",
                 //    productId = 2,
                 //    productPrice = 50,
                 //    quantity = 5,
                 //    subtotal = 250,

                 //}
                );
        }
    }
}
