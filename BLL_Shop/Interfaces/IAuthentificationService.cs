using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IAuthentificationService
    {
        Task<IResult> Authentification(string mail, string password);
    }
}
