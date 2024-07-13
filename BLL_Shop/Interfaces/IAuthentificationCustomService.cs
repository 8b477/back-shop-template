using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IAuthentificationCustomService
    {
        Task<IResult> Authentification(string mail, string password);
    }
}
