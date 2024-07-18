

namespace BLL_Shop.DTO.Address.Update
{
    public record AddressCountryUpdateDTO
    {
        public AddressCountryUpdateDTO(int postalCode, int streetNumber, string streetName, string country, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
        }

        public required int PostalCode { get; init; }
        public required int StreetNumber { get; init; }
        public required string StreetName { get; init; }
        public required string Country { get; init; }
        public required string City { get; init; }
    }
}
