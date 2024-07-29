using BLL_Shop.DTO.Order.Create;
using BLL_Shop.DTO.Order.Update;
using BLL_Shop.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public class OrderEndpoints
    {
        public static void GetEndpointsOrder(WebApplication app)
        {



            // ADD (ADMIN & USER)
            app.MapPost("/order",[Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] IOrderService orderService, [FromBody] OrderCreateDTO order)
                    => await orderService.CreateOrder(order));



            //GET (ADMIN & USER)
/*OWNER*/   app.MapGet("order/owner", [Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] IOrderService orderService)
                    => await orderService.GetOwnerOrder());

            // GET (ADMIN)
/*ALL*/     app.MapGet("/order", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService)
                    => await orderService.GetAllOrder());

/*ONE*/     app.MapGet("/order/{id:int}", [Authorize(Policy = "AdminOnly")]  
                async ([FromServices] IOrderService orderService,[FromRoute] int id)
                    => await orderService.GetOrderById(id));
                                                             
/*ID-USER*/ app.MapGet("/order/user/{idUser:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService,[FromRoute] int idUser)
                    => await orderService.GetOrderByIdUser(idUser));



            // UPDATE (ADMIN)
/*STATUS*/  app.MapPut("/order/status/{idOrder:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService,[FromRoute] int idOrder, [FromBody] OrderStatusUpdateDTO status)
                    => await orderService.UpdateStatusOrder(idOrder, status));

/*SENT-AT*/ app.MapPut("/order/sentAt/{idOrder:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService,[FromRoute] int idOrder, [FromBody] OrderSentAtUpdateDTO sentAt)
                    => await orderService.UpdateSendAtOrder(idOrder, sentAt));

/*STATUS*/ app.MapPut("/order/statusAndSentAt/{idOrder:int}", [Authorize(Policy = "AdminOnly")]
/*AND*/         async ([FromServices] IOrderService orderService, [FromRoute] int idOrder, [FromBody] OrderStatusAndSentAtUpdateDTO StatusAndSentAt)
/*SENT-AT*/         => await orderService.UpdateStatusSendAtOrder(idOrder, StatusAndSentAt));



            // DELETE (ADMIN)
            app.MapDelete("/order/{idOrder:int}", [Authorize(Policy ="AdminOnly")]
                async ([FromServices] IOrderService orderService,[FromRoute] int idOrder)
                    => await orderService.DeleteOrder(idOrder));



        }
    }
}
