using API_Shop.DB.Context;
using API_Shop.DB.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;



var builder = WebApplication.CreateBuilder(args);


// ************************************ SETUP DB *****************************************************
Batteries.Init();
builder.Services.AddDbContext<ShopDB>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// ***************************************************************************************************


var app = builder.Build();
app.UseHttpsRedirection();



//************************* ENDPOINTS USER *******************************
// GET
app.MapGet("/users", UserCallerDBServices.GetAll);
app.MapGet("/user/{id:int}", UserCallerDBServices.GetByID);
app.MapGet("/users/{pseudo}", UserCallerDBServices.GetByPseudo);
// ADD
app.MapPost("/user", UserCallerDBServices.Create);
// UPDATE
app.MapPut("/user/{id:int}", UserCallerDBServices.Update);
//DELETE
app.MapDelete("/user/{id:int}", UserCallerDBServices.Delete);
//************************************************************************

app.Run();
