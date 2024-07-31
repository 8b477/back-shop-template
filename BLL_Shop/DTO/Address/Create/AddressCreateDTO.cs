

namespace BLL_Shop.DTO.Address.Create
{
    public record AddressCreateDTO
    {
        public AddressCreateDTO(string? phoneNumber, string postalCode, string streetNumber, string streetName, string country, string city)
        {
            PhoneNumber = phoneNumber;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
        }

        public string? PhoneNumber { get; init; }
        public string PostalCode { get; init; }
        public string StreetNumber { get; init; }
        public string StreetName{ get; init; }
        public string Country { get; init; }
        public string City { get; init; }
    }
}
