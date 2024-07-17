

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

        public string Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? SentAt { get; init; }
        public List<int> ArticleIds { get; init; }

    }
}
