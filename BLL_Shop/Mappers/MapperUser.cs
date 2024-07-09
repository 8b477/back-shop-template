using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;

using Database_Shop.Models;


namespace BLL_Shop.Mappers
{
    internal class MapperUser
    {
        /// <summary>
        /// Converts a UserCreateDTO object to a User entity.
        /// </summary>
        /// <param name="userCreate">The DTO containing information to create a new user.</param>
        /// <returns>A new instance of the User entity.</returns>
        public static User FromUserCreateDTOToEntity(UserCreateDTO userCreate)
        {
            return new User
            {
                Pseudo = userCreate.Pseudo,
                Mail = userCreate.Mail,
                Mdp = userCreate.Mdp,
                MdpConfirm = userCreate.MdpConfirm,
                Role = userCreate.Role,
            };
        }


        /// <summary>
        /// Converts a UserPwdUpdateDTO object to a User entity for password update.
        /// </summary>
        /// <param name="userPwdToUpdate">The DTO containing information to update the user's password.</param>
        /// <returns>An instance of the User entity with the updated password.</returns>
        public static User FromUserUpdateDTOToEntity(UserUpdateDTO userToUpdate)
        {
            return new User
            {
                Pseudo = userToUpdate.Pseudo,
                Mail = userToUpdate.Mail,
                Mdp = userToUpdate.Mdp,            
                MdpConfirm = userToUpdate.MdpConfirm,   
            };
        }


        /// <summary>
        /// Converts a UserMailUpdateDTO object to a User entity for email update.
        /// </summary>
        /// <param name="userCreate">The DTO containing information to update the user's email.</param>
        /// <returns>An instance of the User entity with the updated email.</returns>
        public static User FromUserMailUpdateDTOToEntity(UserMailUpdateDTO userCreate)
        {
            return new User
            {
                Mail = userCreate.Mail,
            };
        }


        /// <summary>
        /// Converts a UserPseudoUpdateDTO object to a User entity for pseudo update.
        /// </summary>
        /// <param name="userPseudoToUpdate">The DTO containing information to update the user's pseudo.</param>
        /// <returns>An instance of the User entity with the updated pseudo.</returns>
        public static User FromUserPseudoUpdateDTOToEntity(UserPseudoUpdateDTO userPseudoToUpdate) 
        {
            return new User
            {
                Pseudo = userPseudoToUpdate.Pseudo,
            };
        }


        /// <summary>
        /// Converts a UserPwdUpdateDTO object to a User entity for password update.
        /// </summary>
        /// <param name="userPwdToUpdate">The DTO containing information to update the user's password.</param>
        /// <returns>An instance of the User entity with the updated password.</returns>
        public static User FromUserPwdUpdateDTOToEntity(UserPwdUpdateDTO userPwdToUpdate)
        {
            return new User
            {
                Mdp = userPwdToUpdate.Mdp,
                MdpConfirm = userPwdToUpdate.MdpConfirm,
            };
        }
    }
}
