using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;

using Microsoft.AspNetCore.Http;

namespace BLL_Shop.Interfaces
{
    public interface IAddressService
    {



        #region <-------------> CREATE <------------->

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="addressToAdd">The address data transfer object containing the details of the address to be added.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> Create(AddressCreateDTO addressToAdd);

        #endregion




        #region <-------------> GET <------------->

        /// <summary>
        /// Retrieves all addresses.
        /// </summary>
        /// <returns>An <see cref="IResult"/> containing the list of all addresses.</returns>
        Task<IResult> GetAll();

        /// <summary>
        /// Retrieves addresses by postal code.
        /// </summary>
        /// <param name="postalCode">The postal code to filter addresses by.</param>
        /// <returns>An <see cref="IResult"/> containing the list of addresses with the specified postal code.</returns>
        Task<IResult> GetByPostalCode(int postalCode);

        /// <summary>
        /// Retrieves addresses by city.
        /// </summary>
        /// <param name="city">The city to filter addresses by.</param>
        /// <returns>An <see cref="IResult"/> containing the list of addresses in the specified city.</returns>
        Task<IResult> GetByCity(string city);

        /// <summary>
        /// Retrieves addresses by country.
        /// </summary>
        /// <param name="country">The country to filter addresses by.</param>
        /// <returns>An <see cref="IResult"/> containing the list of addresses in the specified country.</returns>
        Task<IResult> GetByCountry(string country);

        #endregion




        #region <-------------> UPDATE <------------->

        /// <summary>
        /// Updates the country of an existing address.
        /// </summary>
        /// <param name="id">The ID of the address to update.</param>
        /// <param name="addressToAdd">The address data transfer object containing the updated country details.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> Update(int id, AddressCountryUpdateDTO addressToAdd);

        /// <summary>
        /// Updates the city of an existing address.
        /// </summary>
        /// <param name="id">The ID of the address to update.</param>
        /// <param name="addressToAdd">The address data transfer object containing the updated city details.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdateCity(int id, AddressCityUpdateDTO addressToAdd);

        /// <summary>
        /// Updates the phone number of an existing address.
        /// </summary>
        /// <param name="id">The ID of the address to update.</param>
        /// <param name="addressToAdd">The address data transfer object containing the updated phone number details.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> UpdatePhoneNumber(int id, AddressPhoneNumberUpdateDTO addressToAdd);

        #endregion




        #region <-------------> DELETE <------------->

        /// <summary>
        /// Deletes an address by its ID.
        /// </summary>
        /// <param name="id">The ID of the address to delete.</param>
        /// <returns>An <see cref="IResult"/> indicating the outcome of the operation.</returns>
        Task<IResult> Delete(int id);

        #endregion
    }

}
