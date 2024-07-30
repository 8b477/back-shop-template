using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;
using BLL_Shop.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public static class UserEndpoints
    {
        public static void GetEndpointsUser(WebApplication app)
        {


            // ADD (ADMIN & USER)
            app.MapPost("/user",
                async ([FromServices] IUserService userService, [FromBody] UserCreateDTO userToAdd) => await userService.CreateUser(userToAdd));



            // GET (ADMIN)
/*ALL*/     app.MapGet("/users", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService) => await userService.GetAllUser());

/*ONE*/    app.MapGet("/user/{id:int}", [Authorize(Policy = "AdminOnly")]
            async ([FromServices] IUserService userService, int id)
                    => await userService.GetUserByID(id));

/*PSEUDO*/ app.MapGet("/users/{pseudo}", [Authorize(Policy = "AdminOnly")]
            async ([FromServices] IUserService userService, string pseudo)
                        => await userService.GetUserByPseudo(pseudo));

            // GET (USER & ADMIN)
/*OWN*/    app.MapGet("/user/profil", [Authorize(Policy = "UserOrAdmin")]
            async ([FromServices] IUserService userService) => await userService.GetUserProfil());


            // UPDATE
/*FULL*/   app.MapPut("/user/{id:int}", [Authorize(Policy = "UserOrAdmin")]
            async ([FromServices] IUserService userService, int id, [FromBody] UserUpdateDTO userToAdd)
                    => await userService.UpdateUser(id, userToAdd));

/*PSEUDO*/  app.MapPut("/user/pseudo/{id:int}", [Authorize(Policy = "UserOrAdmin")]
             async ([FromServices] IUserService userService, int id, [FromBody] UserPseudoUpdateDTO pseudo)
                    => await userService.UpdateUserPseudo(id, pseudo));

/*MAIL*/    app.MapPut("/user/mail/{id:int}", [Authorize(Policy = "UserOrAdmin")]
             async ([FromServices] IUserService userService, int id, [FromBody] UserMailUpdateDTO mail)
                    => await userService.UpdateUserMail(id, mail));

/*PWD*/    app.MapPut("/user/pwd/{id:int}", [Authorize(Policy = "UserOrAdmin")]
             async ([FromServices] IUserService userService, int id, [FromBody] UserPwdUpdateDTO pwd)
                    => await userService.UpdateUserPwd(id, pwd));



            // DELETE (ADMIN)
            app.MapDelete("/user/{id:int}", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService,[FromRoute] int id)
                    => await userService.DeleteUser(id));



        }
    }
}
