using DAL_Shop.DTO.Order;
using DAL_Shop.Interfaces;
using DAL_Shop.Mapper;
using Database_Shop.Context;
using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;



namespace DAL_Shop.Repository
{
    public class OrderRepository : IOrderRepository
    {

        #region
        private readonly ShopDB _db;
        public OrderRepository(ShopDB db) => _db = db;
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<OrderViewDTO?> Create(Order order)
        {
            _db.Order.Add(order);
            await _db.SaveChangesAsync();

            var orderViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(order); 

            return orderViewDTO;
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<List<OrderViewDTO>> GetAll()
        {
            var orders = await _db.Order
                        .Include(o => o.OrderArticles)
                        .ThenInclude(oa => oa.Article)
                        .ToListAsync();

            List<OrderViewDTO> ordersViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(orders);

            return ordersViewDTO;
        }

        public async Task<OrderViewDTO?> GetById(int id)
        {
            var order = await _db.Order
                              .Include(o => o.OrderArticles)
                              .ThenInclude(oa => oa.Article)
                              .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            var orderViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(order);

            return orderViewDTO;
        }

        public async Task<List<OrderViewDTO>> GetByIdUser(int idUser)
        {
            var result = await _db.Order.Where(o => o.UserId == idUser)
                .Include(o => o.OrderArticles)
                .ThenInclude(oa => oa.Article)
                .ToListAsync();

            List<OrderViewDTO> orderViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(result);

            return orderViewDTO;
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<string> UpdateSendAt(int idOrder, DateTime sendAt)
        {
            var existingOrder = await _db.Order.FindAsync(idOrder);

            if (existingOrder is null)
                return "";

            existingOrder.SentAt = sendAt;

            await _db.SaveChangesAsync();

            return "Mise à jour réussi !";
        }

        public async Task<string> UpdateStatus(int idOrder, string status)
        {
            var existingOrder = await _db.Order.FindAsync(idOrder);

            if (existingOrder is null)
                return "";

            existingOrder.Status = status;

            await _db.SaveChangesAsync();

            return "Mise à jour réussi !";
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            var result = await _db.Order.FindAsync(id);

            if (result is null)
                return false;

            _db.Remove(result);
            await _db.SaveChangesAsync();

            return true;
        }
        #endregion


    }
}
