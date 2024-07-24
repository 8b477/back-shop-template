

namespace BLL_Shop.DTO.Address.Create
{
    public record AddressCreateDTO
    {
        public AddressCreateDTO(int postalCode, int streetNumber, string streetName, string country, string city, string? phoneNumber)
        {
            PhoneNumber = phoneNumber;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
        }

        public string? PhoneNumber { get; init; }
        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string StreetName{ get; init; }
        public string Country { get; init; }
        public string City { get; init; }
    }
}
