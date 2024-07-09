using API_Shop.Controllers;
using API_Shop.DB.Context;
using API_Shop.DI;
using API_Shop.Endpoints;
using API_Shop.JWT.Policy;
using API_Shop.JWT.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ********************** SETUP SERILOG **********************
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
// ***********************************************************


// **************************************************** SETUP DB *****************************************************************************************
Batteries.Init();
builder.Services.AddDbContext<ShopDB>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// *******************************************************************************************************************************************************


// **************************************************** INJECTION ***************************************************
DependencyInjectionService.ConfigurationDependencyInjection(builder.Services, builder.Configuration);
// *******************************************************************************************************************


// ********* ADD AUTHENTICATION SCHEME ***********
JWTConfigurationService.AddAuthentication(builder);
// ***********************************************


// *********** ADD POLICY **************
HandlerPolicy.AddAuthorization(builder);
// *************************************


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();


// ***** CHECK ENVIRONEMENT ********
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// *********************************


app.UseHttpsRedirection();

app.UseSerilogRequestLogging(); // Add this line to log HTTP requests

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ************* ENDPOINTS **************
UserEndpoints.GetEndpointsUser(app);
AddressEndpoints.GetEndpointsAddress(app);
AuthenticationEndpoint.GetAuthenticate(app);
// ***************************************

try
{
    Log.Information("Starting web application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}