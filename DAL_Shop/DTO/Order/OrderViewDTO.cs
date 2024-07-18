using DAL_Shop.DTO.Article;


namespace DAL_Shop.DTO.Order
{
#nullable disable
    public record OrderViewDTO
    {
        public OrderViewDTO(int id, int userId, string status, DateTime createdAt, DateTime? sentAt, List<ArticleViewDTO> articles)
        {
            Id = id;
            UserId = userId;
            Status = status;
            CreatedAt = createdAt;
            SentAt = sentAt;
            Articles = articles;
        }

        public int Id { get; init; }
        public int UserId { get; init; }
        public string Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? SentAt { get; init; }
        public List<ArticleViewDTO> Articles { get; init; }
    }
#nullable disable
}
