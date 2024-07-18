namespace BLL_Shop.DTO.Address.Update
{
    public record AddressCityUpdateDTO
    {
        public AddressCityUpdateDTO(int postalCode, int streetNumber, string streetName, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            City = city;
        }

        public required int PostalCode { get; init; }
        public required int StreetNumber { get; init; }
        public required string StreetName { get; init; }
        public required string City { get; init; }
    }
}
