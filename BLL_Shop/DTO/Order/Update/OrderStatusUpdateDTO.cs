
namespace BLL_Shop.DTO.Order.Update
{
    public record OrderStatusUpdateDTO
    {
        public OrderStatusUpdateDTO(string status) => Status = status;

        public required string Status { get; init; }
    }
}
