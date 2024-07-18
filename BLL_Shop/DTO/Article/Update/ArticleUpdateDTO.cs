
namespace BLL_Shop.DTO.Article.Update
{
    public record ArticleUpdateDTO
    {
        public ArticleUpdateDTO(string name, int stock, bool promo, double price)
        {
            Name = name;
            Stock = stock;
            Promo = promo;
            Price = price;
        }

        public string Name { get; init; }
        public int Stock { get; init; }
        public bool Promo { get; init; }
        public double Price { get; init; }
    }
}
