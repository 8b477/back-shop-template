namespace BLL_Shop.DTO.Address.Update
{
    public record AddressCityUpdateDTO
    {
        public AddressCityUpdateDTO(string postalCode, string streetNumber, string streetName, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            StreetName = streetName;
            City = city;
        }

        public string PostalCode { get; init; }
        public string StreetNumber { get; init; }
        public string StreetName { get; init; }
        public string City { get; init; }
    }
}
