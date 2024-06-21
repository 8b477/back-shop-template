using API_Shop.Models;

namespace API_Shop.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A list of all users.</returns>
        public Task<IEnumerable<User?>> GetAll();

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        public Task<User?> GetByID(int id);

        /// <summary>
        /// Retrieves users by their pseudo.
        /// </summary>
        /// <param name="pseudo">The pseudo to search for.</param>
        /// <returns>A list of users matching the specified pseudo.</returns>
        public Task<IEnumerable<User?>> GetByPseudo(string pseudo);

        /// <summary>
        /// Deletes a user from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the user was deleted, false if the user was not found.</returns>
        public Task<bool> Delete(int id);

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userToAdd">The new user data.</param>
        /// <returns>The updated user, or null if the user was not found.</returns>
        public Task<User?> Update(int id, User userToAdd);

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="userToAdd">The user information to add.</param>
        /// <returns>The created user.</returns>
        public Task<User?> Create(User userToAdd);
    }
}
