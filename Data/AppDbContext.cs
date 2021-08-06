using FoodDeliveryBackend.Models;
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

           /* modelBuilder.Entity<Category>()
                .HasMany(a=>a.FoodItems).
                WithOne(t=>t.Category).OnDelete(DeleteBehavior.Cascade);*/
               

            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, FirstName = "Ismaila", LastName = "Jallow", Email = "iss11@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("password"),
                Role = "admin"
            });


        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
