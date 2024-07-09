namespace BLL_Shop.JWT.Models
{
    public class Token
    {
        public string Value { get; init; }

        public Token(string value)
        {
            Value = value;
        }
    }
}
