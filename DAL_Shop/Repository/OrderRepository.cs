using DAL_Shop.CustomException;
using DAL_Shop.DTO.Order;
using DAL_Shop.Interfaces;
using DAL_Shop.Mapper;
using Database_Shop.Context;
using Database_Shop.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DAL_Shop.Repository
{
    public class OrderRepository : IOrderRepository
    {



        #region DI
        private readonly ShopDB _db;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ShopDB db, ILogger<OrderRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<OrderViewDTO?> Create(Order order)
        {
            try
            {
                _db.Order.Add(order);

                await _db.SaveChangesAsync();

                _logger.LogInformation("Order created successfully with ID: {OrderId}", order.Id);


                var newOrder = await _db.Order
                                        .Include(o => o.OrderArticles)
                                            .ThenInclude(oa => oa.Article)
                                                .ThenInclude(a => a.ArticleCategories)
                                                    .ThenInclude(ac => ac.Category)
                                        .Include(o => o.User)
                                            .ThenInclude(u => u.Address)
                                        .FirstOrDefaultAsync(o => o.Id == order.Id);

                if (newOrder == null)
                {
                    _logger.LogError("Failed to reload the order with ID: {OrderId}", order.Id);
                    return null;
                }

                var orderViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(newOrder);

                return orderViewDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating order");

                throw;
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IReadOnlyCollection<OrderViewDTO>> GetAll()
        {
            try
            {
                var orders = await _db.Order
                    .Include(o => o.OrderArticles)
                        .ThenInclude(oa => oa.Article)
                            .ThenInclude(a => a.ArticleCategories)
                                .ThenInclude(ac => ac.Category)
                    .Include(o => o.User)
                        .ThenInclude(u => u.Address)
                    .ToListAsync();

                _logger.LogInformation("Retrieved {Count} orders", orders.Count);

                List<OrderViewDTO> ordersViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(orders);

                return ordersViewDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all orders");

                throw;
            }
        }

        public async Task<OrderViewDTO?> GetById(int id)
        {
            try
            {
                var order = await _db.Order
                    .Include(o => o.OrderArticles)
                        .ThenInclude(oa => oa.Article)
                            .ThenInclude(c => c.ArticleCategories)
                                .ThenInclude(ac => ac.Category)
                    .Include(u => u.User)
                        .ThenInclude(ad => ad.Address)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    _logger.LogWarning("Order with ID {OrderId} not found", id);

                    return null;
                }

                var orderViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(order);

                _logger.LogInformation("Retrieved order with ID: {OrderId}", id);

                return orderViewDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving order with ID: {OrderId}", id);

                throw;
            }
        }

        public async Task<IReadOnlyCollection<OrderViewDTO>> GetByIdUser(int idUser)
        {
            try
            {
                var result = await _db.Order.Where(o => o.UserId == idUser)
                    .Include(o => o.OrderArticles)
                        .ThenInclude(oa => oa.Article)
                            .ThenInclude(c => c.ArticleCategories)
                                .ThenInclude(ac => ac.Category)
                    .Include(u => u.User)
                        .ThenInclude(ad => ad.Address)
                    .ToListAsync();

                _logger.LogInformation("Retrieved {Count} orders for user with ID: {UserId}", result.Count, idUser);

                List<OrderViewDTO> orderViewDTO = MapperOrder.FromOrderEntityToOrderViewDTO(result);

                return orderViewDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving orders for user with ID: {UserId}", idUser);

                throw;
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<string> UpdateSendAt(int idOrder, DateTime sendAt)
        {
            try
            {
                var existingOrder = await _db.Order.FindAsync(idOrder);

                if (existingOrder is null)
                {
                    _logger.LogWarning("Order with ID {OrderId} not found for updating SendAt", idOrder);

                    return "";
                }


                if (existingOrder.CreatedAt > existingOrder.SentAt)
                {
                    _logger.LogError("SentAt cannot be before CreatedAt for order with ID: {OrderId}", idOrder);
                    throw new SentAtBeforeCreatedAtException($"SentAt cannot be before CreatedAt for order with ID: {idOrder}");
                }


                existingOrder.SentAt = sendAt;

                await _db.SaveChangesAsync();

                _logger.LogInformation("Updated SendAt for order with ID: {OrderId}", idOrder);

                return "Mise à jour réussie !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating SendAt for order with ID: {OrderId}", idOrder);

                throw;
            }
        }

        public async Task<string> UpdateStatus(int idOrder, string status)
        {
            try
            {
                var existingOrder = await _db.Order.FindAsync(idOrder);

                if (existingOrder is null)
                {
                    _logger.LogWarning("Order with ID {OrderId} not found for updating Status", idOrder);

                    return "";
                }

                existingOrder.Status = status;

                await _db.SaveChangesAsync();

                _logger.LogInformation("Updated Status for order with ID: {OrderId}", idOrder);

                return "Mise à jour réussie !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Status for order with ID: {OrderId}", idOrder);

                throw;
            }
        }

        public async Task<string> UpdateStatusAndSentAt(int idOrder, string status, DateTime sentAt)
        {
            try
            {
                var existingOrder = await _db.Order.FindAsync(idOrder);

                if (existingOrder is null)
                {
                    _logger.LogWarning("Order with ID {OrderId} not found for updating Status and SentAt", idOrder);

                    return "";
                }


                if (existingOrder.CreatedAt > existingOrder.SentAt)
                {
                    _logger.LogError("SentAt cannot be before CreatedAt for order with ID: {OrderId}", idOrder);
                    throw new SentAtBeforeCreatedAtException($"SentAt cannot be before CreatedAt for order with ID: {idOrder}");
                }


                existingOrder.Status = status;
                existingOrder.SentAt = sentAt;

                await _db.SaveChangesAsync();

                _logger.LogInformation("Updated Status and SentAt for order with ID: {OrderId}", idOrder);

                return "Mise à jour réussie !";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Status and SendAt for order with ID: {OrderId}", idOrder);

                throw;
            }
        }
        #endregion




        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _db.Order.FindAsync(id);

                if (result is null)
                {
                    _logger.LogWarning("Order with ID {OrderId} not found for deletion", id);

                    return false;
                }

                _db.Remove(result);

                await _db.SaveChangesAsync();

                _logger.LogInformation("Deleted order with ID: {OrderId}", id);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting order with ID: {OrderId}", id);

                throw;
            }
        }
        #endregion



    }
}
