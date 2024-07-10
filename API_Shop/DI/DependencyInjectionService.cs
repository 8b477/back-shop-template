using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;
using BLL_Shop.JWT.Models;
using BLL_Shop.JWT.Services;
using BLL_Shop.Services;
using BLL_Shop.Validators.Address_Validator.AddressValidator;
using BLL_Shop.Validators.User_Validator;
using BLL_Shop.Validators.User_Validator.UserValidator;
using DAL_Shop.Interfaces;
using DAL_Shop.Repository;

using FluentValidation;



namespace API_Shop.DI
{
    public static class DependencyInjectionService
    {
        public static void ConfigurationDependencyInjection(IServiceCollection services, IConfiguration options)
        {
            //USER
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserServices>();

            //USER VALIDATOR
            services.AddScoped<IValidator<UserCreateDTO>, UserCreateValidator>();
            services.AddScoped<IValidator<UserUpdateDTO>, UserUpdateValidator>();
            services.AddScoped<IValidator<UserPseudoUpdateDTO>, UserPseudoUpdateValidator>();
            services.AddScoped<IValidator<UserMailUpdateDTO>, UserMailUpdateValidator>();
            services.AddScoped<IValidator<UserPwdUpdateDTO>, UserPwdUpdateValidator>();

            //ADDRESS
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<AddressServices>();

            //ADDRESS VALIDATOR
            services.AddScoped<IValidator<AddressCreateDTO>, AddressValidator>();


            //AUTHENTICATION
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<AuthenticationService>();

            //JWT
            services.Configure<JWTSettings>(options.GetSection("JWT"));
            services.AddSingleton<JWTGenerationService>();
            services.AddSingleton<JWTGetClaimsService>();

            //HTTP CONTEXT
            services.AddHttpContextAccessor();
        }
    }
}
