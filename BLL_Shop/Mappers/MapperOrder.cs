using BLL_Shop.DTO.Order.Create;
using Database_Shop.Entity;


namespace BLL_Shop.Mappers
{
    internal static class MapperOrder
    {
        internal static Order DTOToEntity(OrderCreateDTO orderDTO)
        {
            return new Order
            {
                Status = orderDTO.Status
            };
        }
    }
}
