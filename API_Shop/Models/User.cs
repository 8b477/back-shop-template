namespace API_Shop.Models
{
    public class User
    {
        public int     Id           { get; set; }
        public string? City         { get; set; }
        public int?    PostalCode   { get; set; }
        public int?    StreetNumber { get; set; }
        public string  StreetName   { get; set; } = string.Empty;
        public string  Pseudo       { get; set; } = string.Empty;
        public string  Mail         { get; set; } = string.Empty;
        public string  Mdp          { get; set; } = string.Empty;
    }
}
