using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackSwan.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId= "d37936b9-11a0-48c3-bddc-7632f1e71a6d",
                    RoleId= "8d6c672c-c4e9-4d45-89e3-545e9cb7bea8"
                },
                  new IdentityUserRole<string>
                  {
                      UserId = "323fd5e9-57af-41d6-b9cc-1222667b28ea",
                      RoleId = "1de02abf-c398-4ed4-92bc-f85e2e484519"
                  }
                );
        }
    }
}
