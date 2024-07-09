using BLL_Shop.JWT.Services;
using DAL_Shop.Interfaces;

using Microsoft.AspNetCore.Http;

namespace BLL_Shop.Services
{
    public class AuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly JWTGenerationService _jWTService;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, JWTGenerationService jWTService)
        {
            _authenticationRepository = authenticationRepository;
            _jWTService = jWTService;
        }


        public async Task<IResult> Authentification(string mail, string password)
        {
            var result = await _authenticationRepository.Authentication(mail, password);

            if (result is null) return TypedResults.BadRequest();


            string token = _jWTService.GenerateToken(result.Id.ToString(), result.Mail, result.Pseudo, result.Role);

            return TypedResults.Ok(new {token});
        }

    }
}
