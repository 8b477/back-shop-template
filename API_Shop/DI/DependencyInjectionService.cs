using API_Shop.Interfaces;
using API_Shop.JWT.Models;
using API_Shop.Repository;
using API_Shop.Services;
using API_Shop.JWT.Services;
using FluentValidation;
using API_Shop.Validators.User_Validator.UserValidator;
using API_Shop.DTO.User.Update;
using API_Shop.Validators.User_Validator;
using API_Shop.DTO.User.Create;
using API_Shop.Models;


namespace API_Shop.DI
{
    public static class DependencyInjectionService
    {
        public static void ConfigurationDependencyInjection(IServiceCollection services, IConfiguration options)
        {
            //USER
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserServices>();

            //VALIDATOR
            services.AddScoped<IValidator<UserCreateDTO>, UserCreateValidator>();
            services.AddScoped<IValidator<UserUpdateDTO>, UserUpdateValidator>();
            services.AddScoped<IValidator<UserPseudoUpdateDTO>, UserPseudoUpdateValidator>();
            services.AddScoped<IValidator<UserMailUpdateDTO>, UserMailUpdateValidator>();
            services.AddScoped<IValidator<UserPwdUpdateDTO>, UserPwdUpdateValidator>();

            //ADDRESS
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<AddressServices>();

            //AUTHENTICATION
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<AuthenticationService>();

            //JWT
            services.Configure<JWTSettings>(options.GetSection("JWT"));
            services.AddSingleton<JWTGenerationService>();
        }
    }
}
