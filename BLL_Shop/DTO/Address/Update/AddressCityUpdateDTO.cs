namespace BLL_Shop.DTO.Address.Update
{
    public record AddressCityUpdateDTO
    {
        public AddressCityUpdateDTO(int postalCode, int streetNumber, string city)
        {
            PostalCode = postalCode;
            StreetNumber = streetNumber;
            City = city;
        }

        public int PostalCode { get; init; }
        public int StreetNumber { get; init; }
        public string City { get; init; }
    }
}
