using Microsoft.EntityFrameworkCore;

using RedisMvcApp.Persistence.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RedisMvcApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) 
        {
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            ChangeTracker.Tracked += ChangeTracker_Tracked;
        }

        private void ChangeTracker_Tracked(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            if (e.Entry.Entity is BaseEntity baseEntity)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Added:
                        baseEntity.DateAdded = DateTime.UtcNow;
                        break;
                }
            }
        }

        private void ChangeTracker_StateChanged(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            if (e.Entry.Entity is BaseEntity baseEntity)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Deleted or EntityState.Modified:
                        baseEntity.LastModifed = DateTime.UtcNow;
                        break;
                }
            }
        }

        /// <summary>
        /// Product categories
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Product seller repository
        /// </summary>
        public DbSet<ProductSeller> ProductSellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Products");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}
