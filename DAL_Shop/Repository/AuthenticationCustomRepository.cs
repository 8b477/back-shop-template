using DAL_Shop.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL_Shop.DTO.User.Token;
using Database_Shop.Context;
using Microsoft.Extensions.Logging;
using DAL_Shop.Cryptage;


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



        public async Task<UserTokenDTO?> Authentication(string mail, string password)
        {
            try
            {
                var user = await _db.User.FirstOrDefaultAsync(u => u.Mail == mail);
                if (user == null)
                {
                    _logger.LogInformation("User not found for email: {Email}", mail);
                    return null;
                }


                if (!PasswordHasher.VerifyPassword(password, user.Mdp))
                {
                    _logger.LogInformation("Invalid password for email: {Email}", mail);
                    return null;
                }

                _logger.LogInformation("Authentication successful for user: {UserId}", user.Id);
                return new UserTokenDTO(user.Id, user.Pseudo, user.Mail, user.Role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during authentication for email: {Email}", mail);
                return null;
            }
        }


    }

}
