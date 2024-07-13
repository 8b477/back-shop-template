using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL_Shop.Interfaces;

namespace API_Shop.Controllers
{
    public static class AddressEndpoints
    {
        public static void GetEndpointsAddress(WebApplication app)
        {
            // GET
            app.MapGet("/address",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IAddressService addressService) => await addressService.GetAll());

            app.MapGet("/address/{postalCode:int}",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IAddressService addressService, int postalCode) => await addressService.GetByPostalCode(postalCode));

            app.MapGet("/address/city/",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IAddressService addressService, string city) => await addressService.GetByCity(city));

            app.MapGet("/address/country",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IAddressService addressService, string country) => await addressService.GetByCountry(country));

            // ADD
            app.MapPost("/address",
                [Authorize(Policy = "UserOrAdmin")] async ([FromServices] IAddressService addressService, [FromBody] AddressCreateDTO addressToAdd) => await addressService.Create(addressToAdd));

            // UPDATE
            app.MapPut("/address/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async ([FromServices] IAddressService addressService, int id, [FromBody] AddressCountryUpdateDTO addressToAdd) => await addressService.Update(id, addressToAdd));

            app.MapPut("/address/city/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async ([FromServices] IAddressService addressService, int id, [FromBody] AddressCityUpdateDTO addressToAdd) => await addressService.UpdateCity(id, addressToAdd));

            app.MapPut("/address/phoneNumber/{id:int}",
                [Authorize(Policy = "UserOrAdmin")] async ([FromServices] IAddressService addressService, int id, [FromBody] AddressPhoneNumberUpdateDTO addressToAdd) => await addressService.UpdatePhoneNumber(id, addressToAdd));

            // DELETE
            app.MapDelete("/address/{id:int}",
                [Authorize(Policy = "AdminOnly")] async ([FromServices] IAddressService addressService, int id) => await addressService.Delete(id));
        }
    }
}
