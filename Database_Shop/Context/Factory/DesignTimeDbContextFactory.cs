using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Database_Shop.Context.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopDB>
    {
        public ShopDB CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShopDB>();
            var provider = configuration["DatabaseProvider"];
            var connectionString = provider == "SqlLite"
                ? configuration.GetConnectionString("SqlLiteConnection")
                : configuration.GetConnectionString("SqlServerConnection");

            if (provider == "SqlServer")
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionsBuilder.UseSqlite(connectionString);
            }

            return new ShopDB(optionsBuilder.Options);
        }
    }
}
