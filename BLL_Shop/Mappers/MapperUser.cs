using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;

using DAL_Shop.DTO.User;

using Database_Shop.Entity;


namespace BLL_Shop.Mappers
{
    internal class MapperUser
    {

        internal static User DtoToEntity(UserCreateDTO userCreate)
        {
            return new User
            {
                Pseudo = userCreate.Pseudo,
                Mail = userCreate.Mail,
                Pwd = userCreate.Mdp,
                Role = userCreate.Role,
            };
        }


        internal static User DtoToEntity(UserUpdateDTO userToUpdate)
        {
            return new User
            {
                Pseudo = userToUpdate.Pseudo,
                Mail = userToUpdate.Mail,
                Pwd = userToUpdate.Pwd        
            };
        }


        internal static User DtoToEntity(UserMailUpdateDTO userCreate)
        {
            return new User
            {
                Mail = userCreate.Mail,
            };
        }


        internal static User DtoToEntity(UserPseudoUpdateDTO userPseudoToUpdate) 
        {
            return new User
            {
                Pseudo = userPseudoToUpdate.Pseudo,
            };
        }


        public static User DtoToEntity(UserPwdUpdateDTO userPwdToUpdate)
        {
            return new User
            {
                Pwd = userPwdToUpdate.Mdp
            };
        }

    }
}
