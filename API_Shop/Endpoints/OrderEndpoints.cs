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
                    => await orderService.GetAllOrder()); //Get all orders

/*ONE*/     app.MapGet("/order/{id:int}", [Authorize(Policy = "AdminOnly")]  
                async ([FromServices] IOrderService orderService, int id)
                    => await orderService.GetOrderById(id)); //Get order by id Order
                                                             

/*ID-USER*/ app.MapGet("/order/user/{idUser:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService, int idUser)
                    => await orderService.GetOrderByIdUser(idUser)); // Get order by id User



            // UPDATE (ADMIN)
/*STATUS*/  app.MapPut("/order/status/{idOrder:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService, int idOrder, [FromBody] OrderStatusUpdateDTO status)
                    => await orderService.UpdateStatusOrder(idOrder, status));

/*SENT-AT*/ app.MapPut("/order/sentAt/{idOrder:int}", [Authorize(Policy = "AdminOnly")]
                async ([FromServices] IOrderService orderService, int idOrder, [FromBody] OrderSentAtUpdateDTO sentAt)
                    => await orderService.UpdateSendAtOrder(idOrder, sentAt));



            // DELETE (ADMIN)
            app.MapDelete("/order/{idOrder:int}", [Authorize(Policy ="AdminOnly")]
                async ([FromServices] IOrderService orderService, int idOrder)
                    => await orderService.DeleteOrder(idOrder));



        }
    }
}
