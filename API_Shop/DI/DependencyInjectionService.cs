﻿using API_Shop.Interfaces;
using API_Shop.JWT.Models;
using API_Shop.Repository;
using API_Shop.Services;
using API_Shop.JWT.Services;
using FluentValidation;
using API_Shop.Models;
using API_Shop.Validators;


namespace API_Shop.DI
{
    public static class DependencyInjectionService
    {
        public static void ConfigurationDependencyInjection(IServiceCollection services, IConfiguration options)
        {
            //USER
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserServices>();

            services.AddScoped<IValidator<User>, UserValidator> ();


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
