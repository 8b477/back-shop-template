﻿using BLL_Shop.DTO.User.Create;
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


            // ADD (ALLOWED)
            app.MapPost("/user",
                async ([FromServices] IUserService userService, [FromBody] UserCreateDTO userToAdd) => await userService.CreateUser(userToAdd));



            // GET (ADMIN)
/*ALL*/     app.MapGet("/user", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService) => await userService.GetAllUser());

/*ONE*/    app.MapGet("/user/{id:int}", [Authorize(Policy = "AdminOnly")]
            async ([FromServices] IUserService userService,[FromRoute] int id)
                    => await userService.GetUserByID(id));

/*PSEUDO*/ app.MapGet("/user/{pseudo}", [Authorize(Policy = "AdminOnly")]
            async ([FromServices] IUserService userService,[FromRoute] string pseudo)
                        => await userService.GetUserByPseudo(pseudo));



            // GET (USER & ADMIN)
/*OWN*/    app.MapGet("/user/profil", [Authorize(Policy = "UserOrAdmin")]
            async ([FromServices] IUserService userService) => await userService.GetUserProfil());



            // UPDATE (ADMIN)
/*FULL*/   app.MapPut("/user/{id:int}", [Authorize(Policy = "AdminOnly")]
            async ([FromServices] IUserService userService, [FromRoute] int id, [FromBody] UserUpdateDTO userToAdd)
                    => await userService.UpdateUser(id, userToAdd));

/*PSEUDO*/  app.MapPut("/user/pseudo/{id:int}", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService, [FromRoute] int id, [FromBody] UserPseudoUpdateDTO pseudo)
                    => await userService.UpdateUserPseudo(id, pseudo));

/*MAIL*/    app.MapPut("/user/mail/{id:int}", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService, [FromRoute] int id, [FromBody] UserMailUpdateDTO mail)
                    => await userService.UpdateUserMail(id, mail));

/*PWD*/    app.MapPut("/user/pwd/{id:int}", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService, [FromRoute] int id, [FromBody] UserPwdUpdateDTO pwd)
                    => await userService.UpdateUserPwd(id, pwd));

            
/*ROLE*/   app.MapPut("/user/role/{id:int}", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService, [FromRoute] int id, [FromBody] UserRoleUpdateDTO role)
                    => await userService.UpdateUserRole(id, role));



            // UPDATE (User)
/*FULL*/   app.MapPut("/user", [Authorize(Policy = "UserOnly")]
            async ([FromServices] IUserService userService,[FromBody] UserUpdateDTO userToAdd)
                    => await userService.UpdateOwnUser(userToAdd));

/*PSEUDO*/  app.MapPut("/user/pseudo", [Authorize(Policy = "UserOnly")]
             async ([FromServices] IUserService userService,[FromBody] UserPseudoUpdateDTO pseudo)
                    => await userService.UpdateOwnUserPseudo(pseudo));

/*MAIL*/    app.MapPut("/user/mail", [Authorize(Policy = "UserOnly")]
             async ([FromServices] IUserService userService,[FromBody] UserMailUpdateDTO mail)
                    => await userService.UpdateOwnUserMail(mail));

/*PWD*/    app.MapPut("/user/pwd/", [Authorize(Policy = "UserOnly")]
             async ([FromServices] IUserService userService,[FromBody] UserPwdUpdateDTO pwd)
                    => await userService.UpdateOwnUserPwd(pwd));



            // DELETE (ADMIN)
            app.MapDelete("/user/{id:int}", [Authorize(Policy = "AdminOnly")]
             async ([FromServices] IUserService userService,[FromRoute] int id)
                    => await userService.DeleteUser(id));

        }
    }
}
