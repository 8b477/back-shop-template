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

        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string StreetName { get; init; }
        public string City { get; init; }
    }
}
