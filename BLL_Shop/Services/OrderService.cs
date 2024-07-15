using BLL_Shop.DTO.Order.Create;
using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Services;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;


using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Services
{
    public class OrderService : IOrderService
    {

        #region DI
        private readonly IOrderRepository _repoOrder;
        private readonly IArticleRepository _repoArticle;
        private readonly JWTGetClaimsService _getClaimService;
        public OrderService(IOrderRepository repoOrder, JWTGetClaimsService getClaimService, IArticleRepository repoArticle)
        {
            _getClaimService = getClaimService;
            _repoOrder = repoOrder;
            _repoArticle = repoArticle;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateOrder(OrderCreateDTO order)
        {
            int idUser = _getClaimService.GetIdUserToken();
            if (idUser == 0)
                return TypedResults.Unauthorized();

            List<Article> listArticle = await _repoArticle.GetByIdList(order.ArticleIds);

            Order orderMapped = new () { UserId = idUser, CreatedAt = order.CreatedAt, SentAt = order.SentAt, Status = order.Status };

            orderMapped.OrderArticles = listArticle.Select(a => new OrderArticle
            {
                ArticleId = a.Id,
                Order = orderMapped
            }).ToList();

            var result = await _repoOrder.Create(orderMapped);

            return 
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAllOrder()
        {
            var result = await _repoOrder.GetAll();

            return TypedResults.Ok(result);
        }

        public async Task<IResult> GetOrderById(int id)
        {
            var result = await _repoOrder.GetById(id);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateOrder(int idUser, Order order)
        {
            var result = await _repoOrder.Update(idUser, order);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }

        public async Task<IResult> UpdateSendAtOrder(int idUser, DateTime sendAt)
        {
            var result = await _repoOrder.UpdateSendAt(idUser,sendAt);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }

        public async Task<IResult> UpdateStatusOrder(int idUser, string status)
        {
            var result = await _repoOrder.UpdateStatus(idUser,status);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteOrder(int id)
        {
            var result = await _repoOrder.Delete(id);

            return
                !result
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion

    }
}
