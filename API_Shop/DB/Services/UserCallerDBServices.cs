using API_Shop.DB.Context;
using API_Shop.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Shop.DB.Services
{
    /// <summary>
    /// Manager of CRUD on User table
    /// </summary>
    public static class UserCallerDBServices
    {
        /// <summary>
        /// Get All Users in DB target
        /// </summary>
        /// <param name="db">DbContext</param>
        /// <returns>Liste of Type : User</returns>
        public static async Task<IResult> GetAll(ShopDB db)
        {
            var userList = await db.User.ToListAsync();
            return TypedResults.Ok(userList);
        }


        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="db">DbContext</param>
        /// <returns>User found in the database</returns>
        public static async Task<IResult> GetByID(int id, ShopDB db)
        {
            var result = await db.User.FindAsync(id);

            if (result is null) return TypedResults.NoContent();

            return TypedResults.Ok(result);
        }


        /// <summary>
        /// Get Users by pseudo
        /// </summary>
        /// <param name="pseudo">pseudo search</param>
        /// <param name="db">DbContext</param>
        /// <returns>The user or users found in the database</returns>
        public static async Task<IResult> GetByPseudo(string pseudo, ShopDB db)
        {

            var result = db.User.Where(u => u.Pseudo == pseudo);

            if (result.Count() == 0) return TypedResults.NoContent();

            return TypedResults.Ok(await result.ToListAsync());
        }


        /// <summary>
        /// Delete user present in the database
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="db">DbContext</param>
        /// <returns>Nothing</returns>
        public static async Task<IResult> Delete(int id, ShopDB db)
        {
            var result = await db.User.FindAsync(id);

            if (result is null) return TypedResults.NotFound();
            else
            {
                db.Remove(result);
                await db.SaveChangesAsync();
            }

            return TypedResults.Ok();
        }


        /// <summary>
        /// Update one user present in the database
        /// </summary>
        /// <param name="id">identifier</param>
        /// <param name="userToAdd">User to add</param>
        /// <param name="db">DbContext</param>
        /// <returns>Target user with new values</returns>
        public static async Task<IResult> Update(int id, User userToAdd, ShopDB db)
        {
            var result = await db.User.FindAsync(id);

            if (result is null) return TypedResults.NotFound();
            else
            {
                result.Pseudo = userToAdd.Pseudo;
                result.Mdp = userToAdd.Mdp;
                result.Mail = userToAdd.Mail;

                result.City = userToAdd.City;
                result.PostalCode = userToAdd.PostalCode;
                result.StreetNumber = userToAdd.StreetNumber;
                result.StreetName = userToAdd.StreetName;

                await db.SaveChangesAsync();
            }

            return TypedResults.Ok();
        }


        /// <summary>
        /// Create a new user in the database
        /// </summary>
        /// <param name="userToAdd">Informations for add new user</param>
        /// <param name="db">DbContext</param>
        /// <returns>The new user created in the database</returns>
        public static async Task<IResult> Create(User userToAdd, ShopDB db)
        {

            await db.User.AddAsync(userToAdd);

            await db.SaveChangesAsync();

            return TypedResults.Ok(userToAdd);
        }
    }
}
