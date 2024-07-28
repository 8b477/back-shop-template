using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL_Shop.Interfaces;

namespace API_Shop.Endpoints
{
    public static class AddressEndpoints
    {
        public static void GetEndpointsAddress(WebApplication app)
        {



            // ADD (USER & ADMIN)
            app.MapPost("/address",[Authorize(Policy = "UserOrAdmin")]
                async ([FromServices] IAddressService addressService, [FromBody] AddressCreateDTO addressToAdd)
                    => await addressService.Create(addressToAdd));



            // GET (ADMIN)
/*ALL*/     app.MapGet("/address",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService)
                    => await addressService.GetAll());

/*POSTAL*/  app.MapGet("/address/postalCode/{postalCode:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService, [FromRoute] int postalCode)
                    => await addressService.GetByPostalCode(postalCode));

/*CITY*/    app.MapGet("/address/city/{city}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService, [FromRoute] string city)
                    => await addressService.GetByCity(city));

/*COUNTRY*/ app.MapGet("/address/country/{country}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService, [FromRoute] string country)
                    => await addressService.GetByCountry(country));



            // UPDATE (USER)
/*FULL*/    app.MapPut("/address",[Authorize(Policy = "UserOnly")]
                async ([FromServices] IAddressService addressService, [FromBody] AddressCountryUpdateDTO addressToAdd)
                    => await addressService.UpdateAddressForSimpleUser(addressToAdd));

            // UPDATE (ADMIN)
/*FULL*/    app.MapPut("/address/{idUser:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService,[FromRoute] int idUser, [FromBody] AddressCountryUpdateDTO addressToAdd)
                    => await addressService.UpdateAddressUserWithAdminAccess(idUser, addressToAdd));

            // UPDATE (ADMIN)
/*CITY*/     app.MapPut("/address/city/{idUser:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService,[FromRoute] int idUser, [FromBody] AddressCityUpdateDTO addressToAdd)
                    => await addressService.UpdateCityUserWithAdminAccess(idUser, addressToAdd));

            // UPDATE (USER)
/*CITY*/     app.MapPut("/address/city",[Authorize(Policy = "UserOnly")]
                async ([FromServices] IAddressService addressService, [FromBody] AddressCityUpdateDTO addressToAdd)
                    => await addressService.UpdateCityForSimpleUser(addressToAdd));

            // UPDATE (ADMIN)
/*PHONE*/    app.MapPut("/address/phoneNumber/{id:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService,[FromRoute] int id, [FromBody] AddressPhoneNumberUpdateDTO addressToAdd)
                    => await addressService.UpdatePhoneNumberUserWithAdminAccess(id, addressToAdd));

            // UPDATE (USER)
/*PHONE*/    app.MapPut("/address/phoneNumber",[Authorize(Policy = "UserOnly")]
                async ([FromServices] IAddressService addressService, [FromBody] AddressPhoneNumberUpdateDTO addressToAdd)
                    => await addressService.UpdatePhoneNumberForSimpleUser(addressToAdd));



            // DELETE (ADMIN)
            app.MapDelete("/address/{id:int}",[Authorize(Policy = "AdminOnly")]
                async ([FromServices] IAddressService addressService,[FromRoute] int id)
                    => await addressService.Delete(id));

        }
    }
}
