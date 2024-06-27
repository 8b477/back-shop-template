using API_Shop.DTO.User;


namespace API_Shop.Interfaces
{
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Trying authenticate User data mail and password
        /// </summary>
        /// <param name="mail">Mail user</param>
        /// <param name="mdp">Password user</param>
        /// <returns>Return a UserToken with its data mapping</returns>
        public Task<UserTokenDTO?> Authentication(string mail, string mdp);
    }
}

