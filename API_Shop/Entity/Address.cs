namespace API_Shop.Models
{
    public class Address
    {
        public int    Id           { get; set; }
        public int    IdUser       { get; set; }
        public int    PostalCode   { get; set; }
        public int    StreetNumber { get; set; }
        public string Country      { get; set; } = string.Empty;
        public string City         { get; set; } = string.Empty;
    }
}
