using Black_Swan.Identity.Configurations;
using Black_Swan.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan.Identity
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
        }
    }
}
