
namespace DAL_Shop.DTO.Article
{
    public record ArticleViewDTO
    {
        public ArticleViewDTO(int id, string name, int stock, bool promo, double price)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Promo = promo;
            Price = price;
        }

        public required int Id { get; init; }
        public required string Name { get; init; }
        public required int Stock { get; init; }
        public required bool Promo { get; init; }
        public required double Price { get; init; }
    }
}
