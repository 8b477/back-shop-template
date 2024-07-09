﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BLL_Shop.JWT.Policy
{
    public static class HandlerPolicy
    {
        public static void AddAuthorization(WebApplicationBuilder builder) {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserOrAdmin", policy => policy.RequireRole("User", "Admin"));
            });
        }
    }
}
