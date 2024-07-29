
namespace DAL_Shop.CustomException
{
    public class SentAtBeforeCreatedAtException : Exception
    {
        public SentAtBeforeCreatedAtException(string message) : base(message) { }
    }
}
