using DAL_Shop.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL_Shop.DTO.User.Token;
using Microsoft.Extensions.Logging;
using DAL_Shop.Cryptage;
using Database_Shop.SqlLite.Context;


namespace DAL_Shop.Repository
{
    public class AuthenticationCustomRepository : IAuthentificationCustomRepository
    {


        #region DI
        private readonly ShopDbContextSqlLite _db;
        private readonly ILogger<AuthenticationCustomRepository> _logger;

        public AuthenticationCustomRepository(ShopDbContextSqlLite db, ILogger<AuthenticationCustomRepository> logger)
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


                if (!PasswordHasher.VerifyPassword(password, user.Pwd))
                {
                    _logger.LogInformation("Invalid password for email: {Email}", mail);
                    return null;
                }

                _logger.LogInformation("Authentication successful for user: {UserId}", user.Id);
                return new UserTokenDTO(user.Id, user.Pseudo, user.Mail, user.Role);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalide operation occurred during authentication");
                throw new InvalidOperationException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during authentication for email: {Email}", mail);
                return null;
            }
        }


    }

}
