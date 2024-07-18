

namespace BLL_Shop.DTO.Order.Update
{
    public record OrderStatusAndSentAtUpdateDTO
    {
        public OrderStatusAndSentAtUpdateDTO(string status, DateTime sentAt)
        {
            Status = status;
            SentAt = sentAt;
        }

        public string Status { get; init; }
        public DateTime SentAt { get; init; }
    }
}
