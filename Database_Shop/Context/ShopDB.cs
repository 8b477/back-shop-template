using Database_Shop.Models;

using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;


namespace Database_Shop.DB.Context
{
    public class ShopDB : DbContext
    {
        public ShopDB(DbContextOptions<ShopDB> options) : base(options) { }
        public DbSet<User> User => Set<User>();
        public DbSet<Address> Address => Set<Address>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Article> Article => Set<Article>();
        public DbSet<Order> Order => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
