using API_Shop.Interfaces;
using API_Shop.Repository;
using API_Shop.Services;

namespace API_Shop.DI
{
    public static class DependencyInjectionService
    {
        public static void ConfigurationDependencyInjection(IServiceCollection services, IConfiguration options)
        {
            //USER
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserServices>();

            //ADDRESS
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<AddressServices>();
        }


    }
}
