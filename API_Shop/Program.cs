using API_Shop.Controllers;
using API_Shop.DB.Context;
using API_Shop.DI;
using API_Shop.Endpoints;
using API_Shop.JWT.Policy;
using API_Shop.JWT.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;




var builder = WebApplication.CreateBuilder(args);


// **************************************************** SETUP DB *****************************************************************************************
Batteries.Init();
builder.Services.AddDbContext<ShopDB>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// *******************************************************************************************************************************************************


// **************************************************** INJECTION ***************************************************
DependencyInjectionService.ConfigurationDependencyInjection(builder.Services,builder.Configuration);
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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


// ************* ENDPOINTS **************
UserEndpoints.GetEndpointsUser(app);
AddressEndpoints.GetEndpointsAddress(app);
AuthenticationEndpoint.GetAuthenticate(app);
// ***************************************


app.Run();
