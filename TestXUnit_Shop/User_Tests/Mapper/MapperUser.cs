using DAL_Shop.DTO.Address;
using DAL_Shop.DTO.User;
using Database_Shop.Entity;


namespace TestXUnit_Shop.User_Tests.Mapper
{
    internal static class MapperUser
    {
        internal static UserViewDTO EntityToDTO(User u)
        {
            return new UserViewDTO(
                u.Id,
                u.Pseudo,
                u.Mail,
                u.Role,
                u.Address is null ? null : new AddressViewDTO(
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
        }


        internal static List<UserViewDTO> EntityToDTO(List<User> u)
        {
            return u.Select(u => new UserViewDTO(
                u.Id,
                u.Pseudo,
                u.Mail,
                u.Role,
                u.Address is null ? null : new AddressViewDTO(
                    u.Address.Id,
                    u.Address.UserId,
                    u.Address.PostalCode,
                    u.Address.StreetNumber,
                    u.Address.StreetName,
                    u.Address.Country,
                    u.Address.City,
                    u.Address.PhoneNumber
                    )
                )).ToList();
        }
    }
}
