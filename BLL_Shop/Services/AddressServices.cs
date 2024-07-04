using API_Shop.DB.Context;
using API_Shop.DTO.Address.Update;
using API_Shop.Interfaces;
using API_Shop.Models;
using API_Shop.Repository;

using Microsoft.AspNetCore.Http;

namespace API_Shop.Services
{
    public class AddressServices
    {
        private readonly IAddressRepository _addressRepository;
        public AddressServices(IAddressRepository addressRepository) => _addressRepository = addressRepository;


        /// <summary>
        /// Retrieves all addresses from the database.
        /// </summary>
        /// <returns>An IResult containing a list of all addresses, or NoContent if the list is empty.</returns>
        public async Task<IResult> GetAll()
        {
            var result = await _addressRepository.GetAll();

            return
                result is null
                ? TypedResults.NoContent()
                : TypedResults.Ok(result);
        }


        /// <summary>
        /// Retrieves addresses by their postalCode.
        /// </summary>
        /// <param name="postalCode">The postalCode to search for.</param>
        /// <returns>An IResult containing a list of addresses with the specified postalCode, or NoContent if no addresses are found.</returns>
        public async Task<IResult> GetByPostalCode(int postalCode)
        {
            var result = await _addressRepository.GetByPostalCode(postalCode);

            return
                result.Any()
                ? TypedResults.Ok(result)
                : TypedResults.NotFound();
        }


        /// <summary>
        /// Retrieves addresses by their city.
        /// </summary>
        /// <param name="city">The city to search for.</param>
        /// <returns>An IResult containing a list of addresses with the specified city, or NoContent if no addresses are found.</returns>
        public async Task<IResult> GetByCity(string city)
        {
            var result = await _addressRepository.GetByCity(city);

            return
                result.Any()
                ? TypedResults.Ok(result)
                : TypedResults.NotFound();
        }


        /// <summary>
        /// Retrieves addresses by their country.
        /// </summary>
        /// <param name="country">The country to search for.</param>
        /// <returns>An IResult containing a list of addresses with the specified country, or NoContent if no addresses are found.</returns>
        public async Task<IResult> GetByCountry(string country)
        {
            var result = await _addressRepository.GetByCountry(country);

            return
                result.Any()
                ? TypedResults.Ok(result)
                : TypedResults.NotFound();
        }


        /// <summary>
        /// Deletes a address from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the address to delete.</param>
        /// <returns>An IResult indicating success or failure of the deletion.</returns>
        public async Task<IResult> Delete(int id)
        {
            var result = await _addressRepository.Delete(id);

            return
                result
                ? TypedResults.NoContent()
                : TypedResults.BadRequest();
        }


        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="id">The ID of the address to update.</param>
        /// <param name="addressToAdd">The new address data.</param>
        /// <returns>An IResult containing the updated address, or BadRequest if the update fails.</returns>
        public async Task<IResult> Update(int id, AddressUpdateDTO addressToAdd)
        {
            var result = await _addressRepository.Update(id, addressToAdd);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }


        /// <summary>
        /// Creates a new address in the database.
        /// </summary>
        /// <param name="addressToAdd">The address information to add.</param>
        /// <returns>An IResult containing the created address, or BadRequest if the creation fails.</returns>
        public async Task<IResult> Create(Address addressToAdd)
        {
            var result = await _addressRepository.Create(addressToAdd);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }
    }
}
