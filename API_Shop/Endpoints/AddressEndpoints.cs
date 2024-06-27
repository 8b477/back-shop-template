using API_Shop.DTO.Address;
using API_Shop.Models;
using API_Shop.Services;

using Microsoft.AspNetCore.Authorization;



namespace API_Shop.Controllers
{
    public static class AddressEndpoints
    {
        public static void GetEndpointsAddress(WebApplication app)
        {
            // GET
            app.MapGet("/address",
                [Authorize(Policy = "AdminOnly")] async (AddressServices addressService) => await addressService.GetAll());

            app.MapGet("/address/{postalCode:int}",
                [Authorize(Policy = "AdminOnly")] async (AddressServices addressService, int postalCode) => await addressService.GetByPostalCode(postalCode));

            app.MapGet("/address/city/{city}",
                [Authorize(Policy = "AdminOnly")] async (AddressServices addressService, string city) => await addressService.GetByCity(city));

            app.MapGet("/address/country/{country}",
                [Authorize(Policy = "AdminOnly")] async (AddressServices addressService, string country) => await addressService.GetByCountry(country));


            // ADD
            app.MapPost("/address",
                [Authorize(Policy = "UserOrAdmin")] async (AddressServices addressService, Address addressToAdd) => await addressService.Create(addressToAdd));


            // UPDATE
            app.MapPut("/address/{id:int}",
               [Authorize(Policy = "UserOrAdmin")] async (AddressServices addressService, int id, AddressUpdateDTO addressToAdd) => await addressService.Update(id, addressToAdd));


            //DELETE
            app.MapDelete("/address/{id:int}",
               [Authorize(Policy = "AdminOnly")] async (AddressServices addressService, int id) => await addressService.Delete(id));
        }
    }
}
