using Database_Shop.DB.Context;
using DAL_Shop.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL_Shop.DTO.User.Token;


namespace DAL_Shop.Repository
{
    public class AuthenticationCustomRepository : IAuthentificationCustomRepository
    {
        private readonly ShopDB _db;

        public AuthenticationCustomRepository(ShopDB db) => _db = db;

        public async Task<UserTokenDTO?> Authentication(string mail , string mdp)
        {
            var result = await _db.User.Where((u) => u.Mail == mail && u.Mdp == mdp).FirstOrDefaultAsync();

            if (result == null ) return null;

            return new UserTokenDTO (result.Id, result.Pseudo, result.Mail, result.Role);
        }
    }
}
