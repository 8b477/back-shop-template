using DAL_Shop.DTO.Article;
using DAL_Shop.DTO.User;


namespace DAL_Shop.DTO.Order
{
    public record OrderViewDTO
    {
        public OrderViewDTO(int id, int userId, string status, DateTime createdAt, DateTime? sentAt, UserViewDTO user, List<ArticleViewDTO> articles)
        {
            Id = id;
            UserId = userId;
            Status = status;
            CreatedAt = createdAt;
            SentAt = sentAt;
            User = user;
            Articles = articles;
        }

        public int Id { get; init; }
        public int UserId { get; init; }
        public string Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? SentAt { get; init; }
        public UserViewDTO User { get; init; }
        public List<ArticleViewDTO> Articles { get; init; }
    }

}
