using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Persistence.Configurations.Entities
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City
                {
                    id = 1,
                    name = "shiraz",
                    CreatedDay = DateTime.Now,
                    LastModifiedDate = DateTime.Now

                },
                 new City
                 {
                     id = 2,
                     name = "Tehran",
                     CreatedDay = DateTime.Now,
                     LastModifiedDate = DateTime.Now

                 }

                );
            ;
        }
    }
}
