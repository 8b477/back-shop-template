
namespace DAL_Shop.DTO.Address
{
    public record AddressViewDTO
    {
        public AddressViewDTO(int id, int userId, int postalCode, int streetNumber, string country, string city, string? phoneNumber)
        {
            Id = id;
            UserId = userId;
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            Country = country;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; init; }
        public int UserId { get; init; }
        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
