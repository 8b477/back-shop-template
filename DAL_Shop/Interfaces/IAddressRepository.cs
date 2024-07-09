using Database_Shop.Models;


namespace DAL_Shop.Interfaces
{
    public interface IAddressRepository
    {
        /// <summary>
        /// Retrieves all adresses from the database.
        /// </summary>
        /// <returns>A list of all address.</returns>
        public Task<IEnumerable<Address?>> GetAll();

        /// <summary>
        /// Retrieves address by their postal code.
        /// </summary>
        /// <param name="postalCode">The postal code to search for.</param>
        /// <returns>A list of addresses matching the specified postal code.</returns>
        public Task<IEnumerable<Address?>> GetByPostalCode(int postalCode);

        /// <summary>
        /// Retrieves address by their country.
        /// </summary>
        /// <param name="country">The country to search for.</param>
        /// <returns>A list of addresses matching the specified country.</returns>
        public Task<IEnumerable<Address?>> GetByCountry(string country);

        /// <summary>
        /// Retrieves address by their city.
        /// </summary>
        /// <param name="city">The city to search for.</param>
        /// <returns>A list of addresses matching the specified city.</returns>
        public Task<IEnumerable<Address?>> GetByCity(string city);

        /// <summary>
        /// Deletes a address from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the address to delete.</param>
        /// <returns>True if the address was deleted, false if the address was not found.</returns>
        public Task<bool> Delete(int id);

        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="id">The ID of the address to update.</param>
        /// <param name="addressToAdd">The new address data.</param>
        /// <returns>The updated address, or null if the address was not found.</returns>
        public Task<Address?> Update(int id, Address addressToAdd);

        /// <summary>
        /// Creates a new address in the database.
        /// </summary>
        /// <param name="addressToAdd">The address information to add.</param>
        /// <returns>The created address.</returns>
        public Task<Address?> Create(Address addressToAdd);
    }
}
