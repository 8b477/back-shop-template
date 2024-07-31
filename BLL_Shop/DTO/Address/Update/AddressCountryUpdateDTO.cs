

namespace BLL_Shop.DTO.Address.Update
{
    public record AddressCountryUpdateDTO
    {
        public AddressCountryUpdateDTO(string postalCode, string streetNumber, string streetName, string country, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
        }

        public string PostalCode { get; init; }
        public string StreetNumber { get; init; }
        public string StreetName { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
    }
}
