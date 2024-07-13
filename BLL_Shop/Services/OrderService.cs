using BLL_Shop.Interfaces;
using DAL_Shop.Repository;
using Database_Shop.Entity;
using Database_Shop.Models;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Services
{
    public class OrderService : IOrderService
    {

        #region DI
        private readonly OrderRepository _repoOrder;
        public OrderService(OrderRepository repoOrder) => _repoOrder = repoOrder;
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
        public async Task<IResult> UpdateOrder(int id, int idUser, Order order)
        {
            var result = await _repoOrder.Update(id, idUser, order);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }

        public async Task<IResult> UpdateSendAtOrder(int id, int idUser, DateTime sendAt)
        {
            var result = await _repoOrder.UpdateSendAt(id,idUser,sendAt);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }

        public async Task<IResult> UpdateStatusOrder(int id, int idUser, string status)
        {
            var result = await _repoOrder.UpdateStatus(id,idUser,status);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteOrder(int id, int idUser)
        {
            var result = await _repoOrder.Delete(id, idUser);

            return
                !result
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
        #endregion

    }
}
