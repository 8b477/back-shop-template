using API_Shop.DTO.User.Log;
using API_Shop.Services;

using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public static class AuthenticationEndpoint
    {

        public static void GetAuthenticate(WebApplication app)
        {
            app.MapGet("/log",
                async ([FromServices] AuthenticationService authenticationService,[FromBody] UserLogDTO log)
                => await authenticationService.Authentification(log.Mail, log.Mdp));

        }

    }
}
