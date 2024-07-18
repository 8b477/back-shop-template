

namespace BLL_Shop.DTO.Article.Create
{
    public record ArticleCreateDTO
    {
        public ArticleCreateDTO(string name, int stock, bool promo, double price)
        {
            Name = name;
            Stock = stock;
            Promo = promo;
            Price = price;
        }

        public required string Name { get; init; }
        public required int Stock { get; init; }
        public required bool Promo { get; init; }
        public required double Price { get; init; }
    }
}
