using Black_Swan_Domain;
using Black_Swan_Domain.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Black_Swan.Persistence
{
    public class BlackSwanManagementDbContext : DbContext
    {
        public BlackSwanManagementDbContext(DbContextOptions<BlackSwanManagementDbContext> option)
            : base(option)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<CardItem> cardItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlackSwanManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDay = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDay = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }

}
