using DAL_Shop.Interfaces;
using Database_Shop.Entity;


namespace DAL_Shop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order?> CreateOrder(Order order, int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteOrder(int id, int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrderById(int id, int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateOrder(int id, int idUser, Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateOrderSendAt(int id, int idUser, DateTime sendAt)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateOrderStatus(int id, int idUser, string status)
        {
            throw new NotImplementedException();
        }
    }
}
