using DAL_Shop.DTO.Address;
using Database_Shop.Entity;


namespace TestXUnit_Shop.Address_Tests.Mapper
{
    internal static class MapperAddress
    {
        internal static AddressViewDTO EntityToDTO(Address address)
        {
            return new AddressViewDTO
            (
                address.Id,
                address.UserId,
                address.PostalCode,
                address.StreetNumber,
                address.StreetName,
                address.Country,
                address.City,
                address.PhoneNumber
            );
        }


        internal static List<AddressViewDTO> EntityToDTO(List<Address> addressList)
        {
            List<AddressViewDTO> addressViewDTOs = new ();

            foreach (Address ad in addressList)
            {
                AddressViewDTO actualValue = EntityToDTO(ad);
                addressViewDTOs.Add(actualValue);
            }
            return addressViewDTOs;
        }

    }
}
