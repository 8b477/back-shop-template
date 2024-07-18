using BLL_Shop.DTO.Order.Create;
using BLL_Shop.DTO.Order.Update;
using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Services;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;


using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class OrderService : IOrderService
    {


        #region DI
        private readonly IOrderRepository _repoOrder;
        private readonly IArticleRepository _repoArticle;
        private readonly JWTGetClaimsService _getClaimService;
        private readonly ILogger<OrderService> _logger;
        public OrderService
            (
            IOrderRepository repoOrder,
            JWTGetClaimsService getClaimService,
            IArticleRepository repoArticle,
            ILogger<OrderService> logger
            )
        {
            _getClaimService = getClaimService;
            _repoOrder = repoOrder;
            _repoArticle = repoArticle;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateOrder(OrderCreateDTO order)
        {
            try
            {
                int idUser = _getClaimService.GetIdUserToken();

                if (idUser == 0)
                {
                    _logger.LogWarning("Unauthorized access attempt.");

                    return TypedResults.Unauthorized();
                }

                var listArticle = await _repoArticle.GetByIdList(order.ArticleIds);

                Order orderMapped = new() { UserId = idUser, CreatedAt = order.CreatedAt, SentAt = order.SentAt, Status = order.Status };

                orderMapped.OrderArticles = listArticle.Select(a => new OrderArticle
                {
                    ArticleId = a.Id,
                    Order = orderMapped
                }).ToList();

                var result = await _repoOrder.Create(orderMapped);

                if (result is null)
                {
                    _logger.LogWarning("Order creation failed for user ID {UserId}", idUser);

                    return TypedResults.BadRequest(new { Message = "Une erreur s'est produite lors de la création de la commande." });
                }

                _logger.LogInformation("Order created successfully for user ID {UserId}", idUser);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating order.");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAllOrder()
        {
            try
            {
                var result = await _repoOrder.GetAll();

                _logger.LogInformation("Retrieved all orders.");

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all orders.");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetOrderById(int id)
        {
            try
            {
                var result = await _repoOrder.GetById(id);

                if (result is null)
                {
                    _logger.LogWarning("Order with ID {OrderId} not found.", id);

                    return TypedResults.NotFound(new { Message = "Commande non trouvée." });
                }

                _logger.LogInformation("Retrieved order with ID {OrderId}", id);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving order with ID {OrderId}.", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetOrderByIdUser(int idUser)
        {
            try
            {
                var result = await _repoOrder.GetByIdUser(idUser);

                if (result is null)
                {
                    _logger.LogWarning("Orders for user ID {UserId} not found.", idUser);

                    return TypedResults.NotFound(new { Message = "Commandes non trouvées." });
                }

                _logger.LogInformation("Retrieved orders for user ID {UserId}", idUser);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving orders for user ID {UserId}.", idUser);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetOwnerOrder()
        {
            try
            {
                int idUser = _getClaimService.GetIdUserToken();

                if (idUser == 0)
                {
                    _logger.LogWarning("Unauthorized access attempt.");

                    return TypedResults.Unauthorized();
                }

                var result = await _repoOrder.GetByIdUser(idUser);

                if (result is null)
                {
                    _logger.LogWarning("Orders for user ID {UserId} not found.", idUser);

                    return TypedResults.NotFound(new { Message = "Commandes non trouvées." });
                }

                _logger.LogInformation("Retrieved orders for user ID {UserId}", idUser);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving orders for the owner user ID.");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateSendAtOrder(int idOrder, OrderSentAtUpdateDTO sendAt)
        {
            try
            {
                var result = await _repoOrder.UpdateSendAt(idOrder, sendAt.SentAt);

                if (string.IsNullOrEmpty(result))
                {
                    _logger.LogWarning("Failed to update SendAt for order ID {OrderId}", idOrder);

                    return TypedResults.BadRequest(new { Message = "Échec de la mise à jour de la date d'envoi." });
                }

                _logger.LogInformation("Updated SendAt for order ID {OrderId}", idOrder);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating SendAt for order ID {OrderId}", idOrder);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateStatusOrder(int idOrder, OrderStatusUpdateDTO status)
        {
            try
            {
                var result = await _repoOrder.UpdateStatus(idOrder, status.Status);

                if (string.IsNullOrEmpty(result))
                {
                    _logger.LogWarning("Failed to update Status for order ID {OrderId}", idOrder);

                    return TypedResults.BadRequest(new { Message = "Échec de la mise à jour du statut de la commande." });
                }

                _logger.LogInformation("Updated Status for order ID {OrderId}", idOrder);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating Status for order ID {OrderId}", idOrder);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteOrder(int id)
        {
            try
            {
                var result = await _repoOrder.Delete(id);

                if (!result)
                {
                    _logger.LogWarning("Failed to delete order ID {OrderId}", id);

                    return TypedResults.BadRequest(new { Message = "Échec de la suppression de la commande." });
                }

                _logger.LogInformation("Deleted order ID {OrderId}", id);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting order ID {OrderId}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion


    }
}
