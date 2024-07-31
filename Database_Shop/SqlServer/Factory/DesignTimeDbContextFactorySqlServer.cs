using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Database_Shop.SqlServer.Context;


namespace Database_Shop.SqlServer.Factory
{
    public class DesignTimeDbContextFactorySqlServer : IDesignTimeDbContextFactory<ShopDbContextSqlServer>
    {
        public ShopDbContextSqlServer CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContextSqlServer>();
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new ShopDbContextSqlServer(optionsBuilder.Options);
        }
    }

}
