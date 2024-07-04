﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;

namespace API_Shop.JWT.Services
{
    public static class JWTConfigurationService
    {
        public static void AddAuthentication(WebApplicationBuilder builder)
        {

            var key = builder.Configuration["JWT:Key"];

            if (string.IsNullOrEmpty(key))
                key = JWTGenerationSecretKeyService.GetOrCreateKey(builder.Configuration as IConfiguration);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    RoleClaimType = ClaimTypes.Role
                };
            });
        }
    }
}
