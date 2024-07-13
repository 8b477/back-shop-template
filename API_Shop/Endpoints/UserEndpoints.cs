using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;
using BLL_Shop.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Controllers
{
    public static class UserEndpoints
    {
        public static void GetEndpointsUser(WebApplication app)
        {

            // GET
            //app.MapGet("/users",
            //    [Authorize(Policy = "AdminOnly")] async (UserServices userService) => await userService.GetAll());

            app.MapGet("/users",
                async ([FromServices] IUserService userService) => await userService.GetAllUser());

            app.MapGet("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IUserService userService, int id) => await userService.GetUserByID(id));

            app.MapGet("/users/{pseudo}",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IUserService userService, string pseudo) => await userService.GetUserByPseudo(pseudo));

            // ADD
            app.MapPost("/user",
                async ([FromServices] IUserService userService, [FromBody] UserCreateDTO userToAdd) => await userService.CreateUser(userToAdd));

            // UPDATE
            app.MapPut("/user/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async ([FromServices] IUserService userService, int id, [FromBody] UserUpdateDTO userToAdd) => await userService.UpdateUser(id, userToAdd));

            app.MapPut("/user/pseudo/{id:int}",
                async ([FromServices] IUserService userService, int id, [FromBody] UserPseudoUpdateDTO pseudo) => await userService.UpdateUserPseudo(id, pseudo));

            app.MapPut("/user/mail/{id:int}",
                async ([FromServices] IUserService userService, int id, [FromBody] UserMailUpdateDTO mail) => await userService.UpdateUserMail(id, mail));

            app.MapPut("/user/pwd/{id:int}",
                async ([FromServices] IUserService userService, int id, [FromBody] UserPwdUpdateDTO pwd) => await userService.UpdateUserPwd(id, pwd));

            // DELETE
            app.MapDelete("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IUserService userService, int id) => await userService.DeleteUser(id));
        }
    }
}
