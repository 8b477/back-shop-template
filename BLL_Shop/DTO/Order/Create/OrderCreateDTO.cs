

namespace BLL_Shop.DTO.Order.Create
{
    public record OrderCreateDTO
    {
        public OrderCreateDTO(List<int> articlesId)
        {
            ArticlesId = articlesId;
        }

        public List<int> ArticlesId { get; init; }

    }
}
