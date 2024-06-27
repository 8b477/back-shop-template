using API_Shop.DTO.User;
using API_Shop.Models;
using API_Shop.Services;

using Microsoft.AspNetCore.Authorization;

namespace API_Shop.Controllers
{
    public static class UserEndpoints
    {
        public static void GetEndpointsUser(WebApplication app) {

            // GET
            app.MapGet("/users",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService) => await userService.GetAll());

            app.MapGet("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, int id) => await userService.GetByID(id));

            app.MapGet("/users/{pseudo}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, string pseudo) => await userService.GetByPseudo(pseudo));


            // ADD
            app.MapPost("/user",
                 async (UserServices userService, User userToAdd) => await userService.Create(userToAdd));


            // UPDATE
            app.MapPut("/user/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async (UserServices userService, int id, UserUpdateDTO userToAdd) => await userService.Update(id, userToAdd));


            //DELETE
            app.MapDelete("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, int id) => await userService.Delete(id));
        }
    }
}
