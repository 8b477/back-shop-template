
namespace DAL_Shop.DTO.Address
{
    public record AddressViewDTO
    {
        public AddressViewDTO(int id, int userId, string postalCode, string streetNumber, string streetName, string country, string city, string? phoneNumber)
        {
            Id = id;
            UserId = userId;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            Country = country;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; init; }
        public int UserId { get; init; }
        public string PostalCode { get; init; }
        public string StreetNumber { get; init; }
        public string StreetName { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
