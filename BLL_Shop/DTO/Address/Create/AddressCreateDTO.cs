

namespace BLL_Shop.DTO.Address.Create
{
    public record AddressCreateDTO
    {
        public AddressCreateDTO(int postalCode, int streetNumber, string streetName, string country, string city, int? phoneNumber = 0)
        {
            PhoneNumber = phoneNumber == 0 ? null : phoneNumber;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
        }

        public int? PhoneNumber { get; init; }
        public required int PostalCode { get; init; }
        public required int StreetNumber { get; init; }
        public required string StreetName{ get; init; }
        public required string Country { get; init; }
        public required string City { get; init; }
    }
}
