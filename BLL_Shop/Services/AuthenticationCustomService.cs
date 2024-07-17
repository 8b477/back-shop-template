using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Services;
using DAL_Shop.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BLL_Shop.Services
{
    public class AuthenticationCustomService : IAuthentificationCustomService
    {


        #region DI
        private readonly IAuthentificationCustomRepository _authenticationRepository;
        private readonly JWTGenerationService _jWTService;
        private readonly ILogger<AuthenticationCustomService> _logger;

        public AuthenticationCustomService(IAuthentificationCustomRepository authenticationRepository, JWTGenerationService jWTService, ILogger<AuthenticationCustomService> logger)
        {
            _authenticationRepository = authenticationRepository;
            _jWTService = jWTService;
            _logger = logger;
        } 
        #endregion



        public async Task<IResult> Authentification(string mail, string password)
        {
            try
            {
                var result = await _authenticationRepository.Authentication(mail, password);

                if (result is null)
                {
                    _logger.LogWarning("Authentication failed for email: {Email}.", mail);
                    return TypedResults.BadRequest(new { Message = "Authentication failed, please check your credentials" });
                }

                string token = _jWTService.GenerateToken(result.Id.ToString(), result.Mail, result.Pseudo, result.Role);

                return TypedResults.Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user authentication.");
                return TypedResults.BadRequest(new { Message = "An error occurred during authentication" });
            }
        }
    }

}
