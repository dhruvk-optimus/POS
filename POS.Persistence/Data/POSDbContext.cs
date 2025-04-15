using Microsoft.EntityFrameworkCore;
using POS.Domain;
using POS.Domain.Entities;

namespace POS.Persistence.Data
{
    public class POSDbContext : DbContext
    {
        
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {
        }

        
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enum conversions (Role and OrderStatus saved as strings)
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<OrderEntity>()
                .Property(o => o.Status)
                .HasConversion<string>();

            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
