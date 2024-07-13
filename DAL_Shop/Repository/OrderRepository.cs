using DAL_Shop.Interfaces;
using Database_Shop.DB.Context;
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
        public async Task<Order?> Create(Order order, int idUser)
        {
            order.UserId = idUser;
            var result = await _db.Order.AddAsync(order);
            
            return result.Entity;
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<List<Order>> GetAll()
        {
            return await _db.Order.ToListAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            var result = await _db.Order.FindAsync(id);

            return result;
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<Order?> Update(int idUser, Order order)
        {
            var existingOrder = await _db.Order.FindAsync(idUser);

            if (existingOrder is null)
                return null;

            foreach (var props in _db.Entry(existingOrder).Properties)
            {
                if (props.Metadata.Name != "Id" && props.Metadata.Name != "UserId")
                {
                    props.CurrentValue = _db.Entry(order).Property(props.Metadata.Name);
                }
            }
            await _db.SaveChangesAsync();

            return order;
        }

        public async Task<string> UpdateSendAt(int idUser, DateTime sendAt)
        {
            var existingOrder = await _db.Order.FindAsync(idUser);

            if (existingOrder is null)
                return "";

            existingOrder.SentAt = sendAt;

            await _db.SaveChangesAsync();

            return "Mise à jour réussi !";
        }

        public async Task<string> UpdateStatus(int idUser, string status)
        {
            var existingOrder = await _db.Order.FindAsync(idUser);

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
