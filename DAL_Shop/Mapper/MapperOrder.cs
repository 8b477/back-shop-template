using DAL_Shop.DTO.Article;
using DAL_Shop.DTO.Order;
using Database_Shop.Entity;


namespace DAL_Shop.Mapper
{
    internal class MapperOrder
    {
        public static OrderViewDTO FromOrderEntityToOrderViewDTO(Order order)
        {
            return new OrderViewDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                SentAt = order.SentAt,
                Articles = order.OrderArticles.Select(oa => new ArticleViewDTO
                {
                    Id = oa.Article.Id,
                    Name = oa.Article.Name,
                    Stock = oa.Article.Stock,
                    Promo = oa.Article.Promo,
                    Price = oa.Article.Price
                }).ToList()
            };
        }

        public static List<OrderViewDTO> FromOrderEntityToOrderViewDTO(List<Order> orders)
        {
            List<OrderViewDTO> orderViewDTOs = new List<OrderViewDTO>();

            foreach (Order order in orders)
            {
                var result = new OrderViewDTO
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    Status = order.Status,
                    CreatedAt = order.CreatedAt,
                    SentAt = order.SentAt,
                    Articles = order.OrderArticles.Select(oa => new ArticleViewDTO
                    {
                        Id = oa.Article.Id,
                        Name = oa.Article.Name,
                        Stock = oa.Article.Stock,
                        Promo = oa.Article.Promo,
                        Price = oa.Article.Price
                    }).ToList()
                };
                if(result is not null)
                    orderViewDTOs.Add(result);
            }
            return orderViewDTOs;
        }
    }
}
