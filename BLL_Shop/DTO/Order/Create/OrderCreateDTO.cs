

namespace BLL_Shop.DTO.Order.Create
{
    public record OrderCreateDTO
    {
        public OrderCreateDTO(List<int> articleIds)
        {
            ArticleIds = articleIds;
        }

        public List<int> ArticleIds { get; init; }

    }
}
