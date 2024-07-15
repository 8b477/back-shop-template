using DAL_Shop.DTO.Article;
using DAL_Shop.DTO.Order;
using DAL_Shop.Interfaces;
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
            var orderView = new Order
            {
                UserId = order.UserId,
                Status = order.Status,
                CreatedAt = DateTime.UtcNow,
                SentAt = order.SentAt,
                OrderArticles = order.OrderArticles.Select(articleId => new OrderArticle
                {
                    ArticleId = articleId.ArticleId
                }).ToList()
            };

            _db.Order.Add(order);
            await _db.SaveChangesAsync();

            var orderDto = new OrderViewDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                SentAt = order.SentAt,
                Articles = order.OrderArticles.Select(oa => new ArticleViewDTO
                {
                    Id = oa.Article.Id,
                    Name = oa.Article.Name,
                    Stock = oa.Article.Stock,
                    Promo = oa.Article.Promo,
                    Price = oa.Article.Price
                }).ToList()
            };

            return orderDto;
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<List<Order>> GetAll()
        {
            return await _db.Order.ToListAsync();
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

            var orderDto = new OrderViewDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                SentAt = order.SentAt,
                Articles = order.OrderArticles.Select(oa => new ArticleViewDTO
                {
                    Id = oa.Article.Id,
                    Name = oa.Article.Name,
                    Stock = oa.Article.Stock,
                    Promo = oa.Article.Promo,
                    Price = oa.Article.Price
                }).ToList()
            };

            return orderDto;
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
