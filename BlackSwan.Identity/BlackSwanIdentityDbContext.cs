using BlackSwan.Identity.Configurations;
using BlackSwan.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackSwan.Identity
{
    public class BlackSwanIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public BlackSwanIdentityDbContext(DbContextOptions<BlackSwanIdentityDbContext> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
