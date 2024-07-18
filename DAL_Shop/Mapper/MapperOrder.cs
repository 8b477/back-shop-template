using DAL_Shop.DTO.Article;
using DAL_Shop.DTO.Order;
using Database_Shop.Entity;


namespace DAL_Shop.Mapper
{
    internal class MapperOrder
    {
        public static OrderViewDTO FromOrderEntityToOrderViewDTO(Order order)
        {
            return new OrderViewDTO(
                order.Id,
                order.UserId,
                order.Status,
                order.CreatedAt,
                order.SentAt,
                order.OrderArticles.Select(oa => new ArticleViewDTO(
                    oa.Article.Id,
                    oa.Article.Name,
                    oa.Article.Stock,
                    oa.Article.Promo,
                    oa.Article.Price
                )).ToList()
            );
        }


        public static List<OrderViewDTO> FromOrderEntityToOrderViewDTO(List<Order> orders)
        {
            return orders.Select(order => new OrderViewDTO(
                order.Id,
                order.UserId,
                order.Status,
                order.CreatedAt,
                order.SentAt,
                order.OrderArticles.Select(oa => new ArticleViewDTO(
                    oa.Article.Id,
                    oa.Article.Name,
                    oa.Article.Stock,
                    oa.Article.Promo,
                    oa.Article.Price
                )).ToList()
            )).ToList();
        }

    }
}
