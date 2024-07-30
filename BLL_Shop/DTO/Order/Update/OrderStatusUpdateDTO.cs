
namespace BLL_Shop.DTO.Order.Update
{
    public record OrderStatusUpdateDTO
    {
        public OrderStatusUpdateDTO(string value) => Status = value;

        public string Status { get; init; }
    }
}
