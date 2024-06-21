using API_Shop.DB.Context;
using API_Shop.Interfaces;
using API_Shop.Models;
using API_Shop.Repository;
using API_Shop.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;



var builder = WebApplication.CreateBuilder(args);


// ************************************ SETUP DB *********************************************************************************************************
Batteries.Init();
builder.Services.AddDbContext<ShopDB>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// *******************************************************************************************************************************************************

// ******************** INJECTION ****************************
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserServices>();
// ***********************************************************


var app = builder.Build();
app.UseHttpsRedirection();


//*************************************************** ENDPOINTS USER ********************************************
// GET
app.MapGet("/users",
    async (UserServices userService) => await userService.GetAll());
app.MapGet("/user/{id:int}",
    async (UserServices userService, int id) => await userService.GetByID(id));
app.MapGet("/users/{pseudo}",
    async (UserServices userService, string pseudo) => await userService.GetByPseudo(pseudo));
// ADD
app.MapPost("/user",
    async (UserServices userService, User userToAdd) => await userService.Create(userToAdd));
// UPDATE
app.MapPut("/user/{id:int}",
    async (UserServices userService, int id, User userToAdd) => await userService.Update(id,userToAdd));
//DELETE
app.MapDelete("/user/{id:int}",
    async (UserServices userService, int id) => await userService.Delete(id));
//**************************************************************************************************************

app.Run();
