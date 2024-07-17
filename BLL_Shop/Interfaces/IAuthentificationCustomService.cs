using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IAuthentificationCustomService
    {
        /// <summary>
        /// Authenticates a user based on their email and password.
        /// </summary>
        /// <param name="mail">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the authentication process.</returns>
        Task<IResult> Authentification(string mail, string password);
    }

}
