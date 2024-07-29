using BLL_Shop.DTO.Order.Create;
using BLL_Shop.DTO.Order.Update;

using Microsoft.AspNetCore.Http;


namespace BLL_Shop.Interfaces
{
    public interface IOrderService
    {



        #region <-------------> CREATE <------------->
        /// <summary>
        /// Creates a new order for a user.
        /// </summary>
        /// <param name="order">Order to add.</param>
        /// <param name="idUser">User ID to associate with the order.</param>
        /// <returns>If successful, returns the newly created order; otherwise, returns null.</returns>
        Task<IResult> CreateOrder(OrderCreateDTO order);
        #endregion



        #region <-------------> GET <------------->
        /// <summary>
        /// Retrieves all orders by order ID and user ID.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <param name="idUser">User ID.</param>
        /// <returns>Returns all orders present in database.</returns>
        Task<IResult> GetAllOrder();

        /// <summary>
        /// Retrieves an order by order ID and user ID.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <param name="idUser">User ID.</param>
        /// <returns>If the order is found in the database, returns it; otherwise, returns null.</returns>
        Task<IResult> GetOrderById(int id);

        /// <summary>
        /// Retrieves order(s) by user ID.
        /// </summary>
        /// <param name="idUser">User identifier.</param>
        /// <returns>If the order(s) is found in the database, returns it; otherwise, returns null.</returns>
        Task<IResult> GetOrderByIdUser(int idUser);

        /// <summary>
        /// Retrieves orders from an authenticated userD.
        /// </summary>
        /// <returns>If the order(s) is found in the database, returns it; otherwise, returns null.</returns>
        Task<IResult> GetOwnerOrder();
        #endregion



        #region <-------------> UPDATE <------------->
        /// <summary>
        /// Updates status of an existing order in the database.
        /// </summary>
        /// <param name="idOrder">Identifier order to update.</param>
        /// <param name="status">The new values for the target order.</param>
        /// <returns>If successful, returns the updated order; otherwise, returns null.</returns>
        Task<IResult> UpdateStatusOrder(int idOrder, OrderStatusUpdateDTO status);

        /// <summary>
        /// Updates sendAt of an existing order in the database.
        /// </summary>
        /// <param name="idOrder">Identifier order to update.</param>
        /// <param name="sendAt">The new values for the target order.</param>
        /// <returns>If successful, returns the updated order; otherwise, returns null.</returns>
        Task<IResult> UpdateSendAtOrder(int idOrder, OrderSentAtUpdateDTO sendAt);

        /// <summary>
        /// Updates sendAt of an existing order in the database.
        /// </summary>
        /// <param name="idOrder">Identifier order to update.</param>
        /// <param name="statusAndSendAt">The new values for the target order.</param>
        /// <returns>If successful, returns the updated order; otherwise, returns null.</returns>
        Task<IResult> UpdateStatusSendAtOrder(int idOrder, OrderStatusAndSentAtUpdateDTO statusAndSendAt);
        #endregion



        #region <-------------> DELETE <------------->
        /// <summary>
        /// Deletes an order from the database.
        /// </summary>
        /// <param name="id">ID of the order.</param>
        /// <param name="idUser">ID of the user associated with the order.</param>
        /// <returns>Returns a string with an explicit response.</returns>
        Task<IResult> DeleteOrder(int id);
        #endregion


    }
}
