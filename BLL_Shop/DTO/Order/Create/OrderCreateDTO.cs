

namespace BLL_Shop.DTO.Order.Create
{
    public record OrderCreateDTO
    {
        public OrderCreateDTO()
        {
            Status = "En attente";
            CreatedAt = DateTime.Now.Date;
            SentAt = null;
        }

        public required string Status { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required DateTime? SentAt { get; init; }
        public required List<int> ArticleIds { get; init; }

    }
}
