

namespace BLL_Shop.DTO.Address.Update
{
    public class AddressCountryUpdateDTO
    {
        public AddressCountryUpdateDTO(int postalCode, int streetNumber, string streetName, string country, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
        }

        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string StreetName { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
    }
}
