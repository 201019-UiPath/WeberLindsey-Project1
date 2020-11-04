using Microsoft.EntityFrameworkCore;
using StoreDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StoreDB
{
    public class StoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if(!(optionsBuilder.IsConfigured)) {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("StoreDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var bookConverter = new EnumToStringConverter<Book.bookType>();
            var userConverter = new EnumToStringConverter<User.userType>();

            modelBuilder.Entity<Book>()
            .Property(b => b.type)
            .HasConversion(bookConverter);

            modelBuilder.Entity<User>()
            .Property(u => u.type)
            .HasConversion(userConverter);

        }

    }
}
