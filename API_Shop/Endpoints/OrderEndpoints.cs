using BLL_Shop.DTO.Order.Create;
using BLL_Shop.Interfaces;
using Database_Shop.Entity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Shop.Endpoints
{
    public class OrderEndpoints
    {
        public static void GetEndpointsOrder(WebApplication app)
        {
            // ADD
            app.MapPost("/order",
                [Authorize(Policy = "UserOrAdmin")] async ([FromServices] IOrderService orderService, [FromBody] OrderCreateDTO order) => await orderService.CreateOrder(order));


            // GET
            app.MapGet("/order",
                async ([FromServices] IOrderService orderService) => await orderService.GetAllOrder());

            app.MapGet("/order/{id:int}", 
                async ([FromServices] IOrderService orderService, int id) => await orderService.GetOrderById(id));


            // UPDATE
            app.MapPut("/order/{idUser:int}",
                async ([FromServices] IOrderService orderService, int idUser, [FromBody] Order order) => await orderService.UpdateOrder(idUser, order));

            app.MapPut("/order/status/{idUser:int}",
                async ([FromServices] IOrderService orderService, int idUser, [FromBody] string status) => await orderService.UpdateStatusOrder(idUser, status));

            app.MapPut("/order/sentAt/{idUser:int}",
                async ([FromServices] IOrderService orderService, int idUser, [FromBody] DateTime sentAt) => await orderService.UpdateSendAtOrder(idUser, sentAt));


            // DELETE
            app.MapDelete("/order/{id:int}",
                async ([FromServices] IOrderService orderService, int id) => await orderService.DeleteOrder(id));
        }
    }
}

// NEED TO ADD GET ON STATUS + GET BY DATE (ORDERED)