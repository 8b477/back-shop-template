using API_Shop.DB.Context;
using API_Shop.Interfaces;
using API_Shop.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Shop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDB _db;
        public UserRepository(ShopDB db) => _db = db;



        public async Task<IEnumerable<User?>> GetAll()
        {
            var result = await _db.User.ToListAsync();
            return result;
        }


        public async Task<User?> GetByID(int id)
        {
            var result = await _db.User.FindAsync(id);
            return result;
        }


        public async Task<IEnumerable<User?>> GetByPseudo(string pseudo)
        {
            var result = await _db.User
                        .Where(u => u.Pseudo == pseudo)
                        .ToListAsync();
            return result;
        }


        public async Task<bool> Delete(int id)
        {
            var result = await _db.User.FindAsync(id);

            if (result is null) return false;

            _db.Remove(result);
            await _db.SaveChangesAsync();
            return true;
        }


        public async Task<User?> Update(int id, User userToAdd)
        {
            var result = await _db.User.FindAsync(id);

            if (result is null) return null;

            result.Pseudo = userToAdd.Pseudo;
            result.Mdp = userToAdd.Mdp;
            result.Mail = userToAdd.Mail;
            result.City = userToAdd.City;
            result.PostalCode = userToAdd.PostalCode;
            result.StreetNumber = userToAdd.StreetNumber;
            result.StreetName = userToAdd.StreetName;

            await _db.SaveChangesAsync();
            return result;
        }


        public async Task<User?> Create(User userToAdd)
        {
            var result = await _db.User.AddAsync(userToAdd);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

    }
}
