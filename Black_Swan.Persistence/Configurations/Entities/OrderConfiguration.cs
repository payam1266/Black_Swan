using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    id = 1,
                    address = "shiraz",
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    paymentmethod = "pay in place",
                    phone = "09364154728",
                    city = "shiraz",
                    postalcode = "1234567891",
                    status = Order.OrderStatus.Paid,
                    totalPrice = 500,
                },
                 new Order
                 {
                     id = 2,
                     address = "boshehr",
                     CreatedDay = DateTime.Now,
                     LastModifiedDate = DateTime.Now,
                     paymentmethod = "pay in place",
                     phone = "09364154728",
                     city = "shiraz",
                     postalcode = "1234567891",
                     status = Order.OrderStatus.PendingPayment,
                     totalPrice = 1000,
                 }
                );
        }
    }
}

