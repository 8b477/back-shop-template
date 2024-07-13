using BLL_Shop.Services;

using Database_Shop.Entity;

namespace API_Shop.Endpoints
{
    public class OrderEndpoints
    {
        public static void GetEndpointsOrder(WebApplication app)
        {

            // ADD
            app.MapPost("/order/{idUser:int}",
                async (OrderService orderService, Order order, int idUser) => await orderService.CreateOrder(order,idUser));


            // GET
            app.MapGet("/order",
                async (OrderService orderService) => await orderService.GetAllOrder());


            // UPDATE
            app.MapPut("/order/{id:int}/{idUser:int}",
                async (OrderService orderService,int id, int idUser, Order order) => await orderService.UpdateOrder(id,idUser,order));

            app.MapPut("/order/status/{id:int}/{idUser:int}/{status}",
                async (OrderService orderService, int id, int idUser, string status) => await orderService.UpdateStatusOrder(id, idUser, status));

            app.MapPut("/order/sentAt/{id:int}/{idUser:int}/{sentAt}",
                async (OrderService orderService, int id, int idUser, DateTime sentAt) => await orderService.UpdateSendAtOrder(id, idUser, sentAt));


            //DELETE
            app.MapDelete("/order/{id:int}/{idUser:int}",
                async (OrderService orderService, int id, int idUser) => await orderService.DeleteOrder(id, idUser));

        }
    }
}
// NEED TO ADD GET ON STATUS + GET BY DATE (ORDERED)