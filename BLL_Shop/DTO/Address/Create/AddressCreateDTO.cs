

namespace BLL_Shop.DTO.Address.Create
{
    public record AddressCreateDTO
    {
        public AddressCreateDTO(int postalCode, int streetNumber, string country, string city, int? phoneNumber = 0)
        {
            PhoneNumber = phoneNumber == 0 ? null : phoneNumber;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            Country = country;
            City = city;
        }

        public int? PhoneNumber { get; init; }
        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
    }
}
