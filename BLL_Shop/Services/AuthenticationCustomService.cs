using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Services;
using DAL_Shop.Interfaces;

using Microsoft.AspNetCore.Http;

namespace BLL_Shop.Services
{
    public class AuthenticationCustomService : IAuthentificationCustomService
    {
        #region DI
        private readonly IAuthentificationCustomRepository _authenticationRepository;
        private readonly JWTGenerationService _jWTService;

        public AuthenticationCustomService(IAuthentificationCustomRepository authenticationRepository, JWTGenerationService jWTService)
        {
            _authenticationRepository = authenticationRepository;
            _jWTService = jWTService;
        } 
        #endregion


        public async Task<IResult> Authentification(string mail, string password)
        {
            var result = await _authenticationRepository.Authentication(mail, password);

            if (result is null) return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });


            string token = _jWTService.GenerateToken(result.Id.ToString(), result.Mail, result.Pseudo, result.Role);

            return TypedResults.Ok(new {token});
        }

    }
}
