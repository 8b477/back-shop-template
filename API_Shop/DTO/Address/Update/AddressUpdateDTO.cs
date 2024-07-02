namespace API_Shop.DTO.Address.Update
{
    public record AddressUpdateDTO
    {
        public AddressUpdateDTO(int? phoneNumber, int postalCode, int streetNumber, string country, string city)
        {
            PhoneNumber = phoneNumber;
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
