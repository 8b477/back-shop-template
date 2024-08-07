using API_Shop.DI;
using API_Shop.Endpoints;
using BLL_Shop.JWT.Policy;
using BLL_Shop.JWT.Services;

using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Serilog;
using Database_Shop.SqlLite.Context;


var builder = WebApplication.CreateBuilder(args);


// ********************** SETUP SERILOG **********************
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
// ***********************************************************


// **************************************************** SETUP DB *****************************************************************************************
Batteries.Init();

var provider = builder.Configuration["DatabaseProvider"];
var connectionString = provider == "SqlServer"
    ? builder.Configuration.GetConnectionString("SqlServerConnection")
    : builder.Configuration.GetConnectionString("SqlLiteConnection");

// Configure le DbContext en fonction du fournisseur
if (provider == "SqlServer")
{
    builder.Services.AddDbContext<ShopDbContextSqlLite>(opt => opt.UseSqlServer(connectionString));
}
else
{
    builder.Services.AddDbContext<ShopDbContextSqlLite>(opt => opt.UseSqlite(connectionString));
}

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
AddressEndpoints.GetEndpointsAddress(app);
ArticleEndpoints.GetEndpointsArticle(app);
AuthenticationEndpoint.GetAuthenticate(app);
CategoryEndpoints.GetEndpointsCategory(app);
OrderEndpoints.GetEndpointsOrder(app);
UserEndpoints.GetEndpointsUser(app);
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