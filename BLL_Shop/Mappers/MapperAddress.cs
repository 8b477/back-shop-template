using BLL_Shop.DTO.Address.Update;
using BLL_Shop.DTO.Address.Create;
using Database_Shop.Models;



namespace BLL_Shop.Mappers
{
    internal static class MapperAddress
    {
        public static Address FromAddressCreateDTOToEntity(AddressCreateDTO dto)
        {
            return new Address
            {
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                StreetNumber = dto.StreetNumber,
                PhoneNumber = dto.PhoneNumber
            };
        }

        public static Address FromAddressCountryUpdateDTOToEntity(AddressCountryUpdateDTO dto)
        {
            return new Address
            {
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                StreetNumber = dto.StreetNumber
            };
        }

        public static Address FromAddressCityUpdateDTOToEntity(AddressCityUpdateDTO dto)
        {
            return new Address
            {
                City = dto.City,
                PostalCode = dto.PostalCode,
                StreetNumber = dto.StreetNumber
            };
        }

        public static Address FromAddressPhoneNumberUpdateDTOToEntity(AddressPhoneNumberUpdateDTO dto)
        {
            return new Address
            {
                PhoneNumber = dto.PhoneNumber
            };
        }
    }

}
