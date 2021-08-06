﻿using FoodDeliveryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(a=>a.FoodItems).
                WithOne(t=>t.Category);

            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
