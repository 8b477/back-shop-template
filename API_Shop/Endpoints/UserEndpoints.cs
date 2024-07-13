using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;
using BLL_Shop.Services;

using Microsoft.AspNetCore.Authorization;


namespace API_Shop.Controllers
{
    public static class UserEndpoints
    {
        public static void GetEndpointsUser(WebApplication app) {

            // GET
            //app.MapGet("/users",
            //    [Authorize(Policy = "AdminOnly")] async (UserServices userService) => await userService.GetAll());

            app.MapGet("/users",
                async (UserServices userService) => await userService.GetAllUser());


            app.MapGet("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, int id) => await userService.GetUserByID(id));

            app.MapGet("/users/{pseudo}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, string pseudo) => await userService.GetUserByPseudo(pseudo));


            // ADD
            app.MapPost("/user",
                async (UserServices userService, UserCreateDTO userToAdd) => await userService.CreateUser(userToAdd));


            // UPDATE
            app.MapPut("/user/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async (UserServices userService, int id, UserUpdateDTO userToAdd) => await userService.UpdateUser(id, userToAdd));

            app.MapPut("/user/pseudo/{id:int}",
                async (UserServices userService, int id, UserPseudoUpdateDTO pseudo) => await userService.UpdateUserPseudo(id, pseudo));

            app.MapPut("/user/mail/{id:int}",
                async (UserServices userService, int id, UserMailUpdateDTO mail) => await userService.UpdateUserMail(id, mail));

            app.MapPut("/user/pwd/{id:int}",
                async (UserServices userService, int id, UserPwdUpdateDTO pwd) => await userService.UpdateUserPwd(id, pwd));


            //DELETE
            app.MapDelete("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, int id) => await userService.DeleteUser(id));
        }
    }
}
