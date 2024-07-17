using DAL_Shop.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL_Shop.DTO.User.Token;
using Database_Shop.Context;
using Microsoft.Extensions.Logging;


namespace DAL_Shop.Repository
{
    public class AuthenticationCustomRepository : IAuthentificationCustomRepository
    {


        #region DI
        private readonly ShopDB _db;
        private readonly ILogger<AuthenticationCustomRepository> _logger;

        public AuthenticationCustomRepository(ShopDB db, ILogger<AuthenticationCustomRepository> logger)
        {
            _db = db;
            _logger = logger;
        } 
        #endregion




        public async Task<UserTokenDTO?> Authentication(string mail, string mdp)
        {
            try
            {
                var result = await _db.User.Where(u => u.Mail == mail && u.Mdp == mdp).FirstOrDefaultAsync();

                if (result == null)
                {
                    _logger.LogInformation("Authentication failed for email: {Email}", mail);
                    return null;
                }

                _logger.LogInformation("Authentication successful for user: {UserId}", result.Id);
                return new UserTokenDTO(result.Id, result.Pseudo, result.Mail, result.Role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during authentication for email: {Email}", mail);
                return null;
            }
        }



    }

}
