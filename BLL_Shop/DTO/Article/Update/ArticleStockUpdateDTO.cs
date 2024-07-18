
namespace BLL_Shop.DTO.Article.Update
{
    public record ArticleStockUpdateDTO
    {
        public ArticleStockUpdateDTO(int stock) => Stock = stock;

        public required int Stock { get; init; }
    }
}
