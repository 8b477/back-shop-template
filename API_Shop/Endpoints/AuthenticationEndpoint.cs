using BLL_Shop.DTO.User;
using BLL_Shop.Interfaces;


using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public static class AuthenticationEndpoint
    {

        public static void GetAuthenticate(WebApplication app)
        {
            app.MapGet("/log",
                async ([FromServices] IAuthentificationCustomService authenticationService,[FromBody] UserLogDto log)
                    => await authenticationService.Authentification(log.Mail, log.Mdp));

        }

    }
}

