using Database_Shop.Models;
using BLL_Shop.Services;
using BLL_Shop.DTO.Address.Create;

using Microsoft.AspNetCore.Authorization;
using BLL_Shop.DTO.Address.Update;


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
                [Authorize(Policy = "UserOrAdmin")] async (AddressServices addressService, AddressCreateDTO addressToAdd) => await addressService.Create(addressToAdd));



            // UPDATE
            app.MapPut("/address/{id:int}",
               [Authorize(Policy = "UserOrAdmin")] async (AddressServices addressService, int id, AddressUpdateCountryDTO addressToAdd) => await addressService.Update(id, addressToAdd));

            app.MapPut("/address/city/{id:int}",
   [Authorize(Policy = "UserOrAdmin")] async (AddressServices addressService, int id, AddressUpdateCountryDTO addressToAdd) => await addressService.Update(id, addressToAdd));

            app.MapPut("/address/phoneNumber/{id:int}",
   [Authorize(Policy = "UserOrAdmin")] async (AddressServices addressService, int id, AddressUpdateCountryDTO addressToAdd) => await addressService.Update(id, addressToAdd));

            //DELETE
            app.MapDelete("/address/{id:int}",
               [Authorize(Policy = "AdminOnly")] async (AddressServices addressService, int id) => await addressService.Delete(id));
        }
    }
}
