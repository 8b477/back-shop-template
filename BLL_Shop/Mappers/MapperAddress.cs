using BLL_Shop.DTO.Address.Update;
using BLL_Shop.DTO.Address.Create;
using Database_Shop.Entity;



namespace BLL_Shop.Mappers
{
    internal static class MapperAddress
    {
        internal static Address FromAddressCreateDTOToEntity(AddressCreateDTO dto)
        {
            return new Address
            {
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                StreetNumber = dto.StreetNumber,
                StreetName = dto.StreetName,
                PhoneNumber = dto.PhoneNumber,
            };
        }

        internal static Address FromAddressCountryUpdateDTOToEntity(AddressCountryUpdateDTO dto)
        {
            return new Address
            {
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode,
                StreetNumber = dto.StreetNumber,
                StreetName = dto.StreetName
            };
        }

        internal static Address FromAddressCityUpdateDTOToEntity(AddressCityUpdateDTO dto)
        {
            return new Address
            {
                City = dto.City,
                PostalCode = dto.PostalCode,
                StreetNumber = dto.StreetNumber,
                StreetName = dto.StreetName
            };
        }

        internal static Address FromAddressPhoneNumberUpdateDTOToEntity(AddressPhoneNumberUpdateDTO dto)
        {
            return new Address
            {
                PhoneNumber = dto.PhoneNumber.ToString()
            };
        }
    }

}
