

namespace BLL_Shop.DTO.Order.Update
{
    public record OrderSentAtUpdateDTO
    {
        public OrderSentAtUpdateDTO(DateTime sentAt) => SentAt = sentAt;

        public DateTime SentAt { get; init; }
    }
}
