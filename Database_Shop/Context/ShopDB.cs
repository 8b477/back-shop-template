using API_Shop.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Shop.DB.Context
{
    public class ShopDB : DbContext
    {
        public ShopDB(DbContextOptions<ShopDB> options) : base(options) { }
        public DbSet<User> User => Set<User>();
        public DbSet<Address> Address => Set<Address>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
