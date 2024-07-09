using Database_Shop.DB.Context;
using DAL_Shop.Interfaces;
using Database_Shop.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database_Shop.Models;


namespace DAL_Shop.Repository
{
    public class UserRepository : IUserRepository
    {
        #region DI
        private readonly ShopDB _db;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ShopDB db, ILogger<UserRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        #endregion

        #region <-------------> CREATE <------------->
        public async Task<User?> Create(User userToAdd)
        {
            try
            {
                _logger.LogInformation("Attempting to create a new user: {Pseudo}", userToAdd.Pseudo);
                var result = await _db.User.AddAsync(userToAdd);
                await _db.SaveChangesAsync();
                _logger.LogInformation("User created successfully: {Id}", result.Entity.Id);
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user: {Pseudo}", userToAdd.Pseudo);
                throw;
            }
        }
        #endregion

        #region <-------------> GET <------------->
        public async Task<IEnumerable<User?>> GetAll()
        {
            try
            {
                _logger.LogInformation("Retrieving all users");
                var result = await _db.User.ToListAsync();
                _logger.LogInformation("Retrieved {Count} users", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all users");
                throw;
            }
        }

        public async Task<User?> GetByID(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving user with ID: {Id}", id);
                var result = await _db.User.FindAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("User with ID {Id} not found", id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user with ID: {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<User?>> GetByPseudo(string pseudo)
        {
            try
            {
                _logger.LogInformation("Retrieving users with pseudo: {Pseudo}", pseudo);
                var result = await _db.User.Where(u => u.Pseudo == pseudo).ToListAsync();
                _logger.LogInformation("Retrieved {Count} users with pseudo: {Pseudo}", result.Count, pseudo);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users with pseudo: {Pseudo}", pseudo);
                throw;
            }
        }
        #endregion

        #region <-------------> UPDATE <------------->
        public async Task<string> Update(int id, User user)
        {
            try
            {
                _logger.LogInformation("Updating user with ID: {Id}", id);
                var existingUser = await _db.User.FindAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning("User with ID {Id} not found for update", id);
                    return "";
                }

                foreach (var property in _db.Entry(existingUser).Properties)
                {
                    if (property.Metadata.Name != "Id" && property.Metadata.Name != "Role")
                    {
                        property.CurrentValue = _db.Entry(user).Property(property.Metadata.Name).CurrentValue;
                    }
                }

                await _db.SaveChangesAsync();
                _logger.LogInformation("User with ID {Id} updated successfully", id);
                return "User update !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user with ID: {Id}", id);
                throw;
            }
        }

        public async Task<string> UpdatePseudo(int id, string pseudo)
        {
            try
            {
                _logger.LogInformation("Updating pseudo for user with ID: {Id}", id);
                var existingUser = await _db.User.FindAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning("User with ID {Id} not found for pseudo update", id);
                    return "";
                }

                existingUser.Pseudo = pseudo;
                await _db.SaveChangesAsync();
                _logger.LogInformation("Pseudo updated for user with ID: {Id}", id);
                return "Pseudo update !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating pseudo for user with ID: {Id}", id);
                throw;
            }
        }

        public async Task<string> UpdateMail(int id, string mail)
        {
            try
            {
                _logger.LogInformation("Updating email for user with ID: {Id}", id);
                var existingUser = await _db.User.FindAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning("User with ID {Id} not found for email update", id);
                    return "";
                }

                existingUser.Mail = mail;
                await _db.SaveChangesAsync();
                _logger.LogInformation("Email updated for user with ID: {Id}", id);
                return "Mail update !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating email for user with ID: {Id}", id);
                throw;
            }
        }

        public async Task<string> UpdatePwd(int id, string pwd)
        {
            try
            {
                _logger.LogInformation("Updating password for user with ID: {Id}", id);
                var existingUser = await _db.User.FindAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning("User with ID {Id} not found for password update", id);
                    return "";
                }

                existingUser.Mdp = pwd;
                existingUser.MdpConfirm = pwd;
                await _db.SaveChangesAsync();
                _logger.LogInformation("Password updated for user with ID: {Id}", id);
                return "Pwd update !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating password for user with ID: {Id}", id);
                throw;
            }
        }
        #endregion

        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user with ID: {Id}", id);
                var result = await _db.User.FindAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("User with ID {Id} not found for deletion", id);
                    return false;
                }

                _db.Remove(result);
                await _db.SaveChangesAsync();
                _logger.LogInformation("User with ID {Id} deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user with ID: {Id}", id);
                throw;
            }
        }
        #endregion

        #region <-------------> TOOLS <------------->
        public async Task<bool> IsValidMail(string email)
        {
            try
            {
                _logger.LogInformation("Checking if email is valid: {Email}", email);
                var result = await _db.User.AnyAsync(u => u.Mail == email);
                _logger.LogInformation("Email {Email} is {Validity}", email, result ? "invalid" : "valid");
                return !result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking email validity: {Email}", email);
                throw;
            }
        }
        #endregion
    }
}