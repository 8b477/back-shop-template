using Database_Shop.Entity;
using Database_Shop.SqlServer.Configurations;

using Microsoft.EntityFrameworkCore;


namespace Database_Shop.SqlServer.Context
{
    public class ShopDbContextSqlServer : DbContext
    {
        public ShopDbContextSqlServer(DbContextOptions<ShopDbContextSqlServer> options) : base(options) { }

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

            modelBuilder.ApplyConfiguration(new ArticleSqlServerConfiguration());
            modelBuilder.ApplyConfiguration(new CategorySqlServerConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleCategorySqlServerConfiguration());
            modelBuilder.ApplyConfiguration(new UserSqlServerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderSqlServerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderArticleSqlServerConfiguration());
            modelBuilder.ApplyConfiguration(new AddressSqlServerConfiguration());
        }

    }
}
