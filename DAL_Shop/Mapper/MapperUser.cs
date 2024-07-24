using DAL_Shop.DTO.Address;
using DAL_Shop.DTO.User;
using Database_Shop.Entity;


namespace DAL_Shop.Mapper
{
    internal static class MapperUser
    {

        public static UserViewDTO FromEntityToView(User u)
        {

            UserViewDTO userViewDTO = new UserViewDTO(
                u.Id,
                u.Pseudo,
                u.Mail,
                u.Role,
                u.Address is null ? null : new AddressViewDTO
                (
                    u.Address.Id,
                    u.Address.UserId,
                    u.Address.PostalCode,
                    u.Address.StreetNumber,
                    u.Address.StreetName,
                    u.Address.Country,
                    u.Address.City,
                    u.Address.PhoneNumber
                ));
            return userViewDTO;
            }




        public static List<UserViewDTO> FromEntityToView(List<User> users)
        {
            List<UserViewDTO> usersViewDTO = new List<UserViewDTO>();

            foreach (User u in users)
            {
                UserViewDTO userViewDTO = new UserViewDTO(
                    u.Id,
                    u.Pseudo,
                    u.Mail,
                    u.Role,
                  u.Address is null ? null : new AddressViewDTO
                  (
                      u.Address.Id,
                      u.Address.UserId,
                      u.Address.PostalCode,
                      u.Address.StreetNumber,
                      u.Address.StreetName,
                      u.Address.Country,
                      u.Address.City,
                      u.Address.PhoneNumber
                  )
                  );
              
                usersViewDTO.Add(userViewDTO);
            }

            return usersViewDTO;
        }
    }

}
