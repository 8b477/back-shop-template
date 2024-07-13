using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IUserService
    {

        #region <-------------> CREATE <------------->
        Task<IResult> CreateUser(UserCreateDTO userToAdd);
        #endregion



        #region <-------------> GET <------------->
        Task<IResult> GetAllUser();
        Task<IResult> GetUserByID(int id);
        Task<IResult> GetUserByPseudo(string pseudo);
        #endregion



        #region <-------------> UPDATE <------------->
        Task<IResult> UpdateUser(int id, UserUpdateDTO userToAdd);
        Task<IResult> UpdateUserPseudo(int id, UserPseudoUpdateDTO pseudo);
        Task<IResult> UpdateUserMail(int id, UserMailUpdateDTO mail);
        Task<IResult> UpdateUserPwd(int id, UserPwdUpdateDTO pwd);
        #endregion



        #region <-------------> DELETE <------------->
        Task<IResult> DeleteUser(int id);
        #endregion
    }
}
