using BLL_Shop.DTO.Order.Create;
using BLL_Shop.DTO.Order.Update;
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

            var listArticle = await _repoArticle.GetByIdList(order.ArticleIds);

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
                ? TypedResults.NotFound(new { Message = "Aucune correspondance" })
                : TypedResults.Ok(result);
        }

        public async Task<IResult> GetOrderByIdUser(int idUser)
        {
            var result = await _repoOrder.GetByIdUser(idUser);

            return result is null 
                ? TypedResults.NotFound(new { Message = "Aucune correspondance" })
                : TypedResults.Ok(result);
        }

        public async Task<IResult> GetOwnerOrder()
        {
            int idUser = _getClaimService.GetIdUserToken();
            if (idUser == 0)
                return TypedResults.Unauthorized();

            var result = await _repoOrder.GetByIdUser(idUser);

            return result is null
                ? TypedResults.NotFound(new { Message = "Aucune correspondance" })
                : TypedResults.Ok(result);
        }
        #endregion
        


        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateSendAtOrder(int idOrder, OrderSentAtUpdateDTO sendAt)
        {
            var result = await _repoOrder.UpdateSendAt(idOrder, sendAt.SentAt);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }

        public async Task<IResult> UpdateStatusOrder(int idOrder, OrderStatusUpdateDTO status)
        {
            var result = await _repoOrder.UpdateStatus(idOrder, status.Status);

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
