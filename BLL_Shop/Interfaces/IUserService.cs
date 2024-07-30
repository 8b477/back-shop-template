using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IUserService
    {



        #region <-------------> CREATE <------------->

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userToAdd">The user data transfer object containing the details of the user to be added.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> CreateUser(UserCreateDTO userToAdd);

        #endregion



        #region <-------------> GET <------------->

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An <see cref="IResult"/> containing the list of all users.</returns>
        Task<IResult> GetAllUser();

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An <see cref="IResult"/> containing the user data if found, otherwise an error message.</returns>
        Task<IResult> GetUserByID(int id);

        /// <summary>
        /// Retrieves a user by their pseudo (username).
        /// </summary>
        /// <param name="pseudo">The pseudo of the user to retrieve.</param>
        /// <returns>An <see cref="IResult"/> containing the user data if found, otherwise an error message.</returns>
        Task<IResult> GetUserByPseudo(string pseudo);

        /// <summary>
        /// Retrieves the profile of a user by their ID.
        /// </summary>
        /// <returns>An <see cref="IResult"/> containing the user's profile data.</returns>
        Task<IResult> GetUserProfil();

        #endregion



        #region <-------------> UPDATE <------------->

        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userToAdd">The user data transfer object containing the updated details.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateUser(int id, UserUpdateDTO userToAdd);

        /// <summary>
        /// Updates the pseudo (username) of an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="pseudo">The new pseudo data transfer object.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateUserPseudo(int id, UserPseudoUpdateDTO pseudo);

        /// <summary>
        /// Updates the email of an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="mail">The new email data transfer object.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateUserMail(int id, UserMailUpdateDTO mail);

        /// <summary>
        /// Updates the password of an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="pwd">The new password data transfer object.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateUserPwd(int id, UserPwdUpdateDTO pwd);




        /// <summary>
        /// Updates the details for an authenticate user.
        /// </summary>
        /// <param name="userToAdd">The user data transfer object containing the updated details.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateOwnUser(UserUpdateDTO userToAdd);

        /// <summary>
        /// Update the pseudo for an authenticate user.
        /// </summary>
        /// <param name="pseudo">The new pseudo data transfer object.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateOwnUserPseudo(UserPseudoUpdateDTO pseudo);

        /// <summary>
        /// Update the mail for an authenticate user.
        /// </summary>
        /// <param name="mail">The new email data transfer object.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateOwnUserMail(UserMailUpdateDTO mail);

        /// <summary>
        /// Update the password for an authenticate user.
        /// </summary>
        /// <param name="pwd">The new password data transfer object.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateOwnUserPwd(UserPwdUpdateDTO pwd);

        #endregion



        #region <-------------> DELETE <------------->

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> DeleteUser(int id);

        #endregion

    }
}
