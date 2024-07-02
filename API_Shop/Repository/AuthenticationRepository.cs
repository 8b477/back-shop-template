using API_Shop.DB.Context;
using API_Shop.Interfaces;


using Microsoft.EntityFrameworkCore;
using API_Shop.DTO.User.Token;

namespace API_Shop.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ShopDB _db;

        public AuthenticationRepository(ShopDB db) => _db = db;

        public async Task<UserTokenDTO?> Authentication(string mail , string mdp)
        {
            var result = await _db.User.Where((u) => u.Mail == mail && u.Mdp == mdp).FirstOrDefaultAsync();

            if (result == null ) return null;

            return new UserTokenDTO (result.Id, result.Pseudo, result.Mail, result.Role);
        }
    }
}
