

namespace BLL_Shop.DTO.Order.Update
{
    public record OrderStatusAndSentAtUpdateDTO
    {
        public OrderStatusAndSentAtUpdateDTO(string status, DateTime sentAt)
        {
            Status = status;
            SentAt = sentAt;
        }

        public required string Status { get; init; }
        public required DateTime SentAt { get; init; }
    }
}
