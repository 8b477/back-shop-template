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
    async (UserServices userService) => await userService.GetAll());


            app.MapGet("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, int id) => await userService.GetByID(id));

            app.MapGet("/users/{pseudo}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, string pseudo) => await userService.GetByPseudo(pseudo));


            // ADD
            app.MapPost("/user",
                async (UserServices userService, UserCreateDTO userToAdd) => await userService.Create(userToAdd));


            // UPDATE
            app.MapPut("/user/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async (UserServices userService, int id, UserUpdateDTO userToAdd) => await userService.Update(id, userToAdd));

            app.MapPut("/user/pseudo/{id:int}",
     async(UserServices userService, int id, UserPseudoUpdateDTO pseudo) => await userService.UpdatePseudo(id, pseudo));

            app.MapPut("/user/mail/{id:int}",
async (UserServices userService, int id, UserMailUpdateDTO mail) => await userService.UpdateMail(id, mail));

            app.MapPut("/user/pwd/{id:int}",
async (UserServices userService, int id, UserPwdUpdateDTO pwd) => await userService.UpdatePwd(id, pwd));


            //DELETE
            app.MapDelete("/user/{id:int}",
                [Authorize(Policy = "AdminOnly")] async (UserServices userService, int id) => await userService.Delete(id));
        }
    }
}
