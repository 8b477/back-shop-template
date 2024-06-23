namespace API_Shop.DTO.Address
{
    public class AddressUpdateDTO
    {
        public int PostalCode { get; set; }
        public int StreetNumber { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
