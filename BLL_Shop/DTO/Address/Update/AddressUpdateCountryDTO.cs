

namespace BLL_Shop.DTO.Address.Update
{
    public class AddressUpdateCountryDTO
    {
        public AddressUpdateCountryDTO(int postalCode, int streetNumber, string country, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            Country = country;
            City = city;
        }

        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
    }
}
