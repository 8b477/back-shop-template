namespace API_Shop.Models
{
    public class User
    {
        public int      Id           { get; set; }
        public int?     PhoneNumber  { get; set; }
        public string   Pseudo       { get; set; } = string.Empty;
        public string   Mail         { get; set; } = string.Empty;
        public string   Mdp          { get; set; } = string.Empty;
        public Address? Address      { get; set; }
    }
}
