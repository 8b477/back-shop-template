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

        public required int Id { get; init; }
        public required int UserId { get; init; }
        public required string Status { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required DateTime? SentAt { get; init; }
        public required List<ArticleViewDTO> Articles { get; init; }
    }
#nullable disable
}
