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
            var result = await _db.User.Where(u => u.Pseudo == pseudo).ToListAsync();

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

        public async Task<User?> Create(User userToAdd)
        {
            var result = await _db.User.AddAsync(userToAdd);
            await _db.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<string> Update(int id, User user)
        {
            var existingUser = await _db.User.FindAsync(id);
            if (existingUser == null)
                return "";

            foreach (var property in _db.Entry(existingUser).Properties)
            {
                if (property.Metadata.Name != "Id" && property.Metadata.Name != "Role")
                {
                    property.CurrentValue = _db.Entry(user).Property(property.Metadata.Name).CurrentValue;
                }
            }
            await _db.SaveChangesAsync();
            return "User update !";
        }


        public async Task<string> UpdatePseudo(int id, string pseudo)
        {
            var existingUser = await _db.User.FindAsync(id);
            if (existingUser == null)
                return "";

            existingUser.Pseudo = pseudo;
            await _db.SaveChangesAsync();

            return "Pseudo update !";
        }


        public async Task<string> UpdateMail(int id, string mail)
        {
            var existingUser = await _db.User.FindAsync(id);
            if (existingUser == null)
                return "";

            existingUser.Mail = mail;
            await _db.SaveChangesAsync();

            return "Mail update !";
        }


        public async Task<string> UpdatePwd(int id, string pwd)
        {
            var existingUser = await _db.User.FindAsync(id);
            if (existingUser == null)
                return "";

            existingUser.Mdp = pwd;
            existingUser.MdpConfirm = pwd;

            await _db.SaveChangesAsync();

            return "Pwd update !";
        }


    }
}
