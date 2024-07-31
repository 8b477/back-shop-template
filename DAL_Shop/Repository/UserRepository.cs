using DAL_Shop.Interfaces;
using DAL_Shop.DTO.User;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database_Shop.Entity;
using DAL_Shop.Mapper;
using Database_Shop.SqlLite.Context;


namespace DAL_Shop.Repository
{
    public class UserRepository : IUserRepository
    {


        #region DI
        private readonly ShopDbContextSqlLite _db;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ShopDbContextSqlLite db, ILogger<UserRepository> logger)
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
        public async Task<IReadOnlyCollection<UserViewDTO>> GetAll()
        {
            try
            {
                _logger.LogInformation("Retrieving all users");

                var users = await _db.User
                    .Include(u => u.Address)
                    .ToListAsync();

                _logger.LogInformation("Retrieved {Count} users", users.Count);

                List<UserViewDTO> usersViewDTO = MapperUser.FromEntityToView(users);

                return usersViewDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all users");

                throw;
            }
        }

        public async Task<UserViewDTO?> GetByID(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving user with ID: {Id}", id);

                var result = await _db.User.Include(u => u.Address)
                                           .FirstOrDefaultAsync(u => u.Id == id);
                if (result is null)
                {
                    _logger.LogWarning("User with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                UserViewDTO userViewDTO = MapperUser.FromEntityToView(result);

                return userViewDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user with ID: {Id}", id);

                throw;
            }
        }

        public async Task<IReadOnlyCollection<UserViewDTO?>> GetByPseudo(string pseudo)
        {
            try
            {
                _logger.LogInformation("Retrieving users with pseudo: {Pseudo}", pseudo);

                var result = await _db.User.Include(u => u.Address)
                                           .Where(u => u.Pseudo == pseudo)
                                           .ToListAsync();

                if (result is null)
                {
                    _logger.LogWarning("Name with value : {value} not found", pseudo);

                    throw new ArgumentNullException("No matching search !");
                }


                _logger.LogInformation("Retrieved {Count} users with pseudo: {Pseudo}", result.Count, pseudo);

                List<UserViewDTO> userViewDTO = MapperUser.FromEntityToView(result);

                return userViewDTO;
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

                if (existingUser is null)
                {
                    _logger.LogWarning("User with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
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

                if (existingUser is null)
                {
                    _logger.LogWarning("User with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
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

                if (existingUser is null)
                {
                    _logger.LogWarning("User with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
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

                if (existingUser is null)
                {
                    _logger.LogWarning("User with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
                }

                existingUser.Pwd = pwd;

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

                if (result is null)
                {
                    _logger.LogWarning("User with ID : {id} not found", id);

                    throw new ArgumentNullException("No matching search !");
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