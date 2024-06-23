using API_Shop.DTO.Address;
using API_Shop.Models;
using API_Shop.Services;



namespace API_Shop.Controllers
{
    public static class AddressEndpoints
    {
        public static void GetEndpointsAddress(WebApplication app)
        {
            // GET
            app.MapGet("/address",
                async (AddressServices addressService) => await addressService.GetAll());

            app.MapGet("/address/{postalCode:int}",
                async (AddressServices addressService, int postalCode) => await addressService.GetByPostalCode(postalCode));

            app.MapGet("/address/city/{city}",
                async (AddressServices addressService, string city) => await addressService.GetByCity(city));

            app.MapGet("/address/country/{country}",
                async (AddressServices addressService, string country) => await addressService.GetByCountry(country));


            // ADD
            app.MapPost("/address",
                async (AddressServices addressService, Address addressToAdd) => await addressService.Create(addressToAdd));


            // UPDATE
            app.MapPut("/address/{id:int}",
                async (AddressServices addressService, int id, AddressUpdateDTO addressToAdd) => await addressService.Update(id, addressToAdd));


            //DELETE
            app.MapDelete("/address/{id:int}",
                async (AddressServices addressService, int id) => await addressService.Delete(id));
        }
    }
}
