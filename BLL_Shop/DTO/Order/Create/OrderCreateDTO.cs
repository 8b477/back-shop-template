

namespace BLL_Shop.DTO.Order.Create
{
    public record OrderCreateDTO
    {
        public OrderCreateDTO(List<int> articleIds)
        {
            Status = "En attente";
            CreatedAt = DateTime.Now;
            ArticleIds = articleIds;
        }

        public string Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public List<int> ArticleIds { get; init; }

    }
}
