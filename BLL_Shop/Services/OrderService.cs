using BLL_Shop.DTO.Order.Create;
using BLL_Shop.DTO.Order.Update;
using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Services;
using BLL_Shop.Mappers;
using BLL_Shop.Validators;
using DAL_Shop.CustomException;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class OrderService : IOrderService
    {


        #region DI
        private readonly IOrderRepository _repoOrder;
        private readonly IArticleRepository _repoArticle;
        private readonly IValidator<OrderCreateDTO> _orderCreateDTOValidator;
        private readonly IValidator<OrderSentAtUpdateDTO> _orderSentAtUpdateDTOValidator;
        private readonly IValidator<OrderStatusUpdateDTO> _orderStatusUpdateDTOValidator;
        private readonly IValidator<OrderStatusAndSentAtUpdateDTO> _orderStatusAndSentAtUpdateDTOValidator;
        private readonly JWTGetClaimsService _getClaimService;
        private readonly ILogger<OrderService> _logger;
        public OrderService
            (
            IOrderRepository repoOrder,
            IArticleRepository repoArticle,
            IValidator<OrderCreateDTO> orderCreateDTOValidator,
            IValidator<OrderSentAtUpdateDTO> orderSentAtUpdateDTOValidator,
            IValidator<OrderStatusUpdateDTO> orderStatusUpdateDTOValidator,
            IValidator<OrderStatusAndSentAtUpdateDTO> orderStatusAndSentAtUpdateDTOValidator,
            JWTGetClaimsService getClaimService,
            ILogger<OrderService> logger
            )
        {
            _repoOrder = repoOrder;
            _repoArticle = repoArticle;
            _orderCreateDTOValidator = orderCreateDTOValidator;
            _orderSentAtUpdateDTOValidator = orderSentAtUpdateDTOValidator;
            _orderStatusUpdateDTOValidator = orderStatusUpdateDTOValidator;
            _orderStatusAndSentAtUpdateDTOValidator = orderStatusAndSentAtUpdateDTOValidator;
            _getClaimService = getClaimService;
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


                _logger.LogInformation("Creating new order");

                var validationResult = await ValidatorModelState.ValidModelState(order, _orderCreateDTOValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for order creation");

                    return validationResult;
                }


                var listArticle = await _repoArticle.GetByIdList(order.ArticlesId);

                Order orderMapped = MapperOrder.DtoToEntity(order);

                orderMapped.UserId = idUser;


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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
                _logger.LogInformation("Updating value 'sentAt' order : {id}",idOrder);

                var validationResult = await ValidatorModelState.ValidModelState(sendAt, _orderSentAtUpdateDTOValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for order value 'sentAt' updating");

                    return validationResult;
                }


                var result = await _repoOrder.UpdateSendAt(idOrder, sendAt.SentAt);

                if (string.IsNullOrEmpty(result))
                {
                    _logger.LogWarning("Failed to update SendAt for order ID {OrderId}", idOrder);

                    return TypedResults.BadRequest(new { Message = "Échec de la mise à jour de la date d'envoi." });
                }

                _logger.LogInformation("Updated SendAt for order ID {OrderId}", idOrder);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (SentAtBeforeCreatedAtException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating SendAt for order ID {OrderId}", idOrder);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateStatusSendAtOrder(int idOrder, OrderStatusAndSentAtUpdateDTO statusAndSendAt)
        {
            try
            {
                _logger.LogInformation("Updating value 'sentAt' and 'status' order : {id}", idOrder);

                var validationResult = await ValidatorModelState.ValidModelState(statusAndSendAt, _orderStatusAndSentAtUpdateDTOValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for order value 'sentAt' and 'status' updating");

                    return validationResult;
                }


                var result = await _repoOrder.UpdateStatusAndSentAt(idOrder, statusAndSendAt.Status, statusAndSendAt.SentAt);

                if (string.IsNullOrEmpty(result))
                {
                    _logger.LogWarning("Failed to update Status and SendAt for order ID {OrderId}", idOrder);

                    return TypedResults.BadRequest(new { Message = "Failed to update SentAt and Status." });
                }


                _logger.LogInformation("Updated SendAt for order ID {OrderId}", idOrder);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (SentAtBeforeCreatedAtException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
                _logger.LogInformation("Updating value 'status' order : {id}", idOrder);

                var validationResult = await ValidatorModelState.ValidModelState(status, _orderStatusUpdateDTOValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for order value 'status' updating");

                    return validationResult;
                }


                var result = await _repoOrder.UpdateStatus(idOrder, status.Status);

                if (string.IsNullOrEmpty(result))
                {
                    _logger.LogWarning("Failed to update Status for order ID {OrderId}", idOrder);

                    return TypedResults.BadRequest(new { Message = "Échec de la mise à jour du statut de la commande." });
                }

                _logger.LogInformation("Updated Status for order ID {OrderId}", idOrder);
                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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
