
namespace DAL_Shop.DTO.Article
{
    public class ArticleViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public bool Promo { get; set; }
        public double Price { get; set; }
    }
}
