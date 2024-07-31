using Database_Shop.Entity;
using Database_Shop.SqlLite.Configurations;

using Microsoft.EntityFrameworkCore;


namespace Database_Shop.SqlLite.Context
{
    public class ShopDbContextSqlLite : DbContext
    {
        public ShopDbContextSqlLite(DbContextOptions<ShopDbContextSqlLite> options) : base(options) { }

        public DbSet<Article> Article => Set<Article>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<ArticleCategory> ArticleCategories => Set<ArticleCategory>();
        public DbSet<User> User => Set<User>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<Address> Address => Set<Address>();
        public DbSet<OrderArticle> OrderArticle => Set<OrderArticle>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArticleSqlLiteConfiguration());
            modelBuilder.ApplyConfiguration(new CategorySqlLiteConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleCategorySqlLiteConfiguration());
            modelBuilder.ApplyConfiguration(new UserSqlLiteConfiguration());
            modelBuilder.ApplyConfiguration(new OrderSqlLiteConfiguration());
            modelBuilder.ApplyConfiguration(new OrderArticleSqlLiteConfiguration());
            modelBuilder.ApplyConfiguration(new AddressSqlLiteConfiguration());
        }
    }
}