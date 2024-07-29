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
            var userDto = order.User != null ? new UserViewDTO(
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
            ) : null;

            var articlesDto = order.OrderArticles?.Select(oa => new ArticleViewDTO(
                oa.Id,
                oa.Article?.Name,
                oa.Article?.Stock ?? 0,
                oa.Article?.Promo ?? false,
                oa.Article?.Price ?? 0,
                oa.Article?.ArticleCategories?.Select(ac => new CategoryViewDTO(
                    ac.Category?.Name
                )).ToList() ?? new List<CategoryViewDTO>()
            )).ToList() ?? new List<ArticleViewDTO>();

            var result = new OrderViewDTO(
                order.Id,
                order.UserId,
                order.Status,
                order.CreatedAt,
                order.SentAt,
                userDto,
                articlesDto
            );

            return result;
        }

        public static List<OrderViewDTO> FromOrderEntityToOrderViewDTO(List<Order> orders)
        {
            return orders.Select(FromOrderEntityToOrderViewDTO).ToList();
        }








        //public static OrderViewDTO FromOrderEntityToOrderViewDTO(Order order)
        //{
        //    var result = new OrderViewDTO(
        //        order.Id,
        //        order.UserId,
        //        order.Status,
        //        order.CreatedAt,
        //        order.SentAt,
        //        new UserViewDTO(
        //            order.User.Id,
        //            order.User.Pseudo,
        //            order.User.Mail,
        //            order.User.Role,
        //            order.User.Address is null ? null : new AddressViewDTO(
        //                order.User.Address.Id,
        //                order.User.Address.UserId,
        //                order.User.Address.PostalCode,
        //                order.User.Address.StreetNumber,
        //                order.User.Address.StreetName,
        //                order.User.Address.Country,
        //                order.User.Address.City,
        //                order.User.Address.PhoneNumber
        //                )
        //            ),
        //        order.OrderArticles.Select(oa => new ArticleViewDTO(
        //            oa.Id,
        //            oa.Article.Name,
        //            oa.Article.Stock,
        //            oa.Article.Promo,
        //            oa.Article.Price,
        //            oa.Article.ArticleCategories.Select(ac => new CategoryViewDTO
        //            (
        //                ac.Category.Name
        //            )).ToList()
        //        )).ToList()
        //    );

        //    return result;
        //}


        //public static List<OrderViewDTO> FromOrderEntityToOrderViewDTO(List<Order> orders)
        //{
        //    List<OrderViewDTO> listMapped = [];

        //    foreach (Order o in orders)
        //    {
        //        listMapped.Add(FromOrderEntityToOrderViewDTO(o));
        //    }

        //    return listMapped;
        //}

    }
}
