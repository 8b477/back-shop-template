using BLL_Shop.Interfaces;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;


using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Services
{
    public class OrderService : Interfaces.IOrderService
    {

        #region DI
        private readonly IOrderRepository _repoOrder;
        public OrderService(IOrderRepository repoOrder) => _repoOrder = repoOrder;
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateOrder(Order order, int idUser)
        {
            var result = await _repoOrder.Create(order, idUser);

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
