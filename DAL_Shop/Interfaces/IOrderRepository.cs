using DAL_Shop.DTO.Order;

using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface IOrderRepository
    {

        #region <-------------> CREATE <------------->
        /// <summary>
        /// Creates a new order for a user.
        /// </summary>
        /// <param name="order">Order to add.</param>
        /// <param name="idUser">User ID to associate with the order.</param>
        /// <returns>If successful, returns the newly created order; otherwise, returns null.</returns>
        Task<OrderViewDTO?> Create(Order order);
        #endregion



        #region <-------------> GET <------------->
        /// <summary>
        /// Retrieves all orders by order ID and user ID.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <param name="idUser">User ID.</param>
        /// <returns>Returns all orders present in database.</returns>
        Task<List<Order>> GetAll();

        /// <summary>
        /// Retrieves an order by order ID and user ID.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <param name="idUser">User ID.</param>
        /// <returns>If the order is found in the database, returns it; otherwise, returns null.</returns>
        Task<OrderViewDTO?> GetById(int id);
        #endregion



        #region <-------------> UPDATE <------------->
        /// <summary>
        /// Updates an existing order in the database.
        /// </summary>
        /// <param name="id">ID of the order to update.</param>
        /// <param="idUser">ID of the user associated with the order to update.</param>
        /// <param name="order">The new values for the target order.</param>
        /// <returns>If successful, returns the updated order; otherwise, returns null.</returns>
        Task<Order?> Update(int idUser, Order order);

        /// <summary>
        /// Updates status of an existing order in the database.
        /// </summary>
        /// <param name="id">ID of the order to update.</param>
        /// <param="idUser">ID of the user associated with the order to update.</param>
        /// <param name="status">The new values for the target order.</param>
        /// <returns>If successful, returns the updated order; otherwise, returns null.</returns>
        Task<string> UpdateStatus(int idUser, string status);

        /// <summary>
        /// Updates sendAt of an existing order in the database.
        /// </summary>
        /// <param name="id">ID of the order to update.</param>
        /// <param="idUser">ID of the user associated with the order to update.</param>
        /// <param name="sendAt">The new values for the target order.</param>
        /// <returns>If successful, returns the updated order; otherwise, returns null.</returns>
        Task<string> UpdateSendAt(int idUser, DateTime sendAt);
        #endregion



        #region <-------------> DELETE <------------->
        /// <summary>
        /// Deletes an order from the database.
        /// </summary>
        /// <param name="id">ID of the order.</param>
        /// <param name="idUser">ID of the user associated with the order.</param>
        /// <returns>Returns a string with an explicit response.</returns>
        Task<bool> Delete(int id);
        #endregion
    }
}
