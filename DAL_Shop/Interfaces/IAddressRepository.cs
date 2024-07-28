using DAL_Shop.DTO.Address;

using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface IAddressRepository
    {

        #region <-------------> CREATE <------------->

        /// <summary>
        /// Creates a new address in the database.
        /// </summary>
        /// <param name="addressToAdd">The address information to add.</param>
        /// <returns>The created address.</returns>
        public Task<AddressViewDTO?> Create(Address addressToAdd);
        #endregion


        #region <-------------> GET <------------->

        /// <summary>
        /// Retrieves all adresses from the database.
        /// </summary>
        /// <returns>A list of all address.</returns>
        public Task<IReadOnlyCollection<Address?>> GetAll();

        /// <summary>
        /// Retrieves address by their postal code.
        /// </summary>
        /// <param name="postalCode">The postal code to search for.</param>
        /// <returns>A list of addresses matching the specified postal code.</returns>
        public Task<IReadOnlyCollection<Address?>> GetByPostalCode(int postalCode);

        /// <summary>
        /// Retrieves address by their country.
        /// </summary>
        /// <param name="country">The country to search for.</param>
        /// <returns>A list of addresses matching the specified country.</returns>
        public Task<IReadOnlyCollection<Address?>> GetByCountry(string country);

        /// <summary>
        /// Retrieves address by their city.
        /// </summary>
        /// <param name="city">The city to search for.</param>
        /// <returns>A list of addresses matching the specified city.</returns>
        public Task<IReadOnlyCollection<Address?>> GetByCity(string city);
        #endregion


        #region <-------------> UPDATE <------------->

        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="idUser">The ID of the user for find corresponding Address.</param>
        /// <param name="addressToAdd">The new address data.</param>
        /// <returns>The updated address, or null if the address was not found.</returns>
        public Task<Address?> Update(int idUser, Address addressToAdd);

        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="idUser">The IDUser for find the corresponding Address to update.</param>
        /// <param name="postalCode">The new postalCode data.</param>
        /// <param name="streetNumber">The new streetNumber data.</param>
        /// <param name="city">The new city data.</param>
        /// <returns>The updated address, or null if the address was not found.</returns>
        Task<Address?> UpdateCity(int idUser, Address addressToUpdate);

        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="idUser">The IDUser for find corresponding Address to update.</param>
        /// <param name="phoneNumber">The new phoneNumber data.</param>
        /// <returns>The updated address, or null if the address was not found.</returns>
        Task<Address?> UpdatePhoneNumber(int idUser, string phoneNumber);
        #endregion


        #region <-------------> DELETE <------------->

        /// <summary>
        /// Deletes a address from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the address to delete.</param>
        /// <returns>True if the address was deleted, false if the address was not found.</returns>
        public Task<bool> Delete(int id);
        #endregion


        #region <-------------> TOOLS <------------->

        /// <summary>
        /// Check whether the user has an address in the database.
        /// </summary>
        /// <param name="id">ID user</param>
        /// <returns>Returns true if user has no Address otherwise returns false</returns>
        Task<bool> CheckIfUserAlreadyHasAddress(int id);
        #endregion

    }
}
