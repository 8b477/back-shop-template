using Database_Shop.SqlLite.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Database_Shop.SqlLite.Factory
{
    public class DesignTimeDbContextFactorySqlLite : IDesignTimeDbContextFactory<ShopDbContextSqlLite>
    {
        public ShopDbContextSqlLite CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContextSqlLite>();
            var connectionString = configuration.GetConnectionString("SqlLiteConnection");

            optionsBuilder.UseSqlite(connectionString);

            return new ShopDbContextSqlLite(optionsBuilder.Options);
        }
    }

}
