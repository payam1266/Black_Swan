using BlackSwan.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlackSwan.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id= "d37936b9-11a0-48c3-bddc-7632f1e71a6d",
                    Email="admin@localhost.com",
                    NormalizedEmail="ADMIN@LOCALHOST.COM",
                    FirstName="admin",
                    LastName="adminian",
                    UserName= "admin@localhost.com",
                    NormalizedUserName= "ADMIN@LOCALHOST.COM",
                    PasswordHash=hasher.HashPassword(null,"Pp123456"),
                    EmailConfirmed=true
                },
                 new ApplicationUser
                 {
                     Id = "323fd5e9-57af-41d6-b9cc-1222667b28ea",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "payam",
                     LastName = "ghaznavi",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "Ss123456"),
                     EmailConfirmed = true
                 }
                );
        }
    }
}
