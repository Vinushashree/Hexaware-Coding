using Microsoft.EntityFrameworkCore;
using HotPot.DAL.Models; // Adjust based on your Models folder structure

namespace HotPot.DAL.Context
{
    public class HotPotDbContext : DbContext
    {
        public HotPotDbContext(DbContextOptions<HotPotDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}

