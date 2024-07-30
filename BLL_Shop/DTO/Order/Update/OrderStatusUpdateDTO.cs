
namespace BLL_Shop.DTO.Order.Update
{
    public record OrderStatusUpdateDTO
    {
        public OrderStatusUpdateDTO(string status) => Status = status;

        public string Status { get; init; }
    }
}
