using Database_Shop.Models;
using Database_Shop.Entity;
using Database_Shop.Context.Configurations;
using Database_Shop.EntityConfigurations;
using Database_Shop.Configurations;

using Microsoft.EntityFrameworkCore;



namespace Database_Shop.DB.Context
{
    public class ShopDB : DbContext
    {
        public ShopDB(DbContextOptions<ShopDB> options) : base(options) { }


        public DbSet<Article> Article => Set<Article>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<ArticleCategory> ArticleCategories => Set<ArticleCategory>();
        public DbSet<User> User => Set<User>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<Address> Address => Set<Address>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
