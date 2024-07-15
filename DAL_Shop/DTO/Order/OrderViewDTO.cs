using DAL_Shop.DTO.Article;


namespace DAL_Shop.DTO.Order
{
    public class OrderViewDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public List<ArticleViewDTO> Articles { get; set; }
    }
}
