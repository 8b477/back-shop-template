using DAL_Shop.DTO.Address;
using DAL_Shop.DTO.User;
using Database_Shop.Entity;


namespace DAL_Shop.Mapper
{
    internal static class MapperUser
    {

        public static UserViewDTO FromEntityToView(User u)
        {

            AddressViewDTO? addressDTO = u.Address != null ? new
                (
                    u.Address.Id,
                    u.Address.UserId,
                    u.Address.PostalCode,
                    u.Address.StreetNumber,
                    u.Address.StreetName,
                    u.Address.Country,
                    u.Address.City,
                    u.Address.PhoneNumber
                ) : null;



            UserViewDTO userViewDTO = new
                (
                    u.Id,
                    u.Pseudo,
                    u.Mail,
                    u.Role,
                    addressDTO
              );

            return userViewDTO;
        }


        public static List<UserViewDTO> FromEntityToView(List<User> users)
        {
            return users.Select(FromEntityToView).ToList();
        }
    }

}
