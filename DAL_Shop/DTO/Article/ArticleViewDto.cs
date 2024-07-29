
using DAL_Shop.DTO.Category;

namespace DAL_Shop.DTO.Article
{
    public record ArticleViewDTO
    {
        public ArticleViewDTO(int id, string name, int stock, bool promo, double price, List<CategoryViewDTO> categories)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Promo = promo;
            Price = price;
            Categories = categories;
        }

        public int Id { get; init; }
        public string Name { get; init; }
        public int Stock { get; init; }
        public bool Promo { get; init; }
        public double Price { get; init; }
        public List<CategoryViewDTO> Categories { get; init; }
    }
}
