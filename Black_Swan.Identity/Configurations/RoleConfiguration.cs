using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "1de02abf-c398-4ed4-92bc-f85e2e484519",
                    Name="payam",
                    NormalizedName="PAYAM"
                },
                 new IdentityRole
                 {
                     Id = "8d6c672c-c4e9-4d45-89e3-545e9cb7bea8",
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR"
                 }
                );
        }
    }
}
