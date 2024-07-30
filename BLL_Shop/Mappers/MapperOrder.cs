using BLL_Shop.DTO.Order.Create;
using Database_Shop.Entity;


namespace BLL_Shop.Mappers
{
    internal static class MapperOrder
    {
        internal static Order DtoToEntity(OrderCreateDTO orderDTO)
        {
            return new Order
            {           
                Status = "En attente",
                CreatedAt = DateTime.Now,
                SentAt = null
            };
        }

    }
}
