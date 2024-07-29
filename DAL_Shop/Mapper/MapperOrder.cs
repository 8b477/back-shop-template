using DAL_Shop.DTO.Address;
using DAL_Shop.DTO.Article;
using DAL_Shop.DTO.Category;
using DAL_Shop.DTO.Order;
using DAL_Shop.DTO.User;
using Database_Shop.Entity;


namespace DAL_Shop.Mapper
{
    internal class MapperOrder
    {

        public static OrderViewDTO FromOrderEntityToOrderViewDTO(Order order)
        {
            var userDto = new UserViewDTO(
                order.User.Id,
                order.User.Pseudo,
                order.User.Mail,
                order.User.Role,
                order.User.Address != null ? new AddressViewDTO(
                    order.User.Address.Id,
                    order.User.Address.UserId,
                    order.User.Address.PostalCode,
                    order.User.Address.StreetNumber,
                    order.User.Address.StreetName,
                    order.User.Address.Country,
                    order.User.Address.City,
                    order.User.Address.PhoneNumber
                ) : null
            );

            var articlesDto = order.OrderArticles.Select(oa => new ArticleViewDTO(
                oa.Id,
                oa.Article.Name,
                oa.Article.Stock,
                oa.Article.Promo,
                oa.Article.Price,
                oa.Article.ArticleCategories.Select(ac => new CategoryViewDTO(
                    ac.Category.Name
                )).ToList()
            )).ToList();

            var result = new OrderViewDTO(
                order.Id,
                order.UserId,
                order.Status,
                order.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                order.SentAt?.ToString("dd/MM/yyyy HH:mm") ?? "",
                userDto,
                articlesDto
            );

            return result;
        }

        public static List<OrderViewDTO> FromOrderEntityToOrderViewDTO(List<Order> orders)
        {
            return orders.Select(FromOrderEntityToOrderViewDTO).ToList();
        }


    }
}
