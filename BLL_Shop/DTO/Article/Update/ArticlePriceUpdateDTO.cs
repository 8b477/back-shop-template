
namespace BLL_Shop.DTO.Article.Update
{
    public record ArticlePriceUpdateDTO
    {
        public ArticlePriceUpdateDTO(double price) => Price = price;

        public double Price { get; init; }
    }
}
