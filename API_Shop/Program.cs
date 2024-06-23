using API_Shop.Controllers;
using API_Shop.DB.Context;
using API_Shop.DI;
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


var app = builder.Build();
app.UseHttpsRedirection();


// ************* ENDPOINTS **************
UserEndpoints.GetEndpointsUser(app);
AddressEndpoints.GetEndpointsAddress(app);
// ***************************************


app.Run();
