using DAL_Shop.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DAL_Shop.DTO.Address;
using Database_Shop.Entity;
using Database_Shop.Context;


namespace DAL_Shop.Repository
{
    public class AddressRepository : IAddressRepository
    {
        #region DI
        private readonly ShopDB _shopDB;
        private readonly ILogger<AddressRepository> _logger;

        public AddressRepository(ShopDB ctx, ILogger<AddressRepository> logger)
        {
            _shopDB = ctx;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<AddressViewDTO?> Create(Address addressToAdd)
        {
            try
            {
                _logger.LogInformation("Creating new address");

                var user = await _shopDB.Address.AddAsync(addressToAdd);
                await _shopDB.SaveChangesAsync();

                var u = user.Entity;
                _logger.LogInformation("Address created successfully: {Id}", u.Id);

                return new AddressViewDTO(u.Id, u.UserId ?? 0,u.PostalCode,u.StreetNumber,u.StreetName,u.Country,u.City,u.PhoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating address");
                throw;
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IEnumerable<Address?>> GetAll()
        {
            try
            {
                _logger.LogInformation("Retrieving all addresses");
                var result = await _shopDB.Address.ToListAsync();
                _logger.LogInformation("Retrieved {Count} addresses", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all addresses");
                throw;
            }
        }

        public async Task<IEnumerable<Address?>> GetByPostalCode(int postalCode)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses with postal code: {PostalCode}", postalCode);
                var result = await _shopDB.Address.Where(a => a.PostalCode == postalCode).ToListAsync();
                _logger.LogInformation("Retrieved {Count} addresses with postal code: {PostalCode}", result.Count, postalCode);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses with postal code: {PostalCode}", postalCode);
                throw;
            }
        }

        public async Task<IEnumerable<Address?>> GetByCity(string city)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses in city: {City}", city);
                var result = await _shopDB.Address.Where(a => a.City == city).ToListAsync();
                _logger.LogInformation("Retrieved {Count} addresses in city: {City}", result.Count, city);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses in city: {City}", city);
                throw;
            }
        }

        public async Task<IEnumerable<Address?>> GetByCountry(string country)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses in country: {Country}", country);
                var result = await _shopDB.Address.Where(a => a.Country == country).ToListAsync();
                _logger.LogInformation("Retrieved {Count} addresses in country: {Country}", result.Count, country);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses in country: {Country}", country);
                throw;
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<Address?> Update(int id, Address addressToAdd)
        {
            try
            {
                _logger.LogInformation("Updating address with ID: {Id}", id);
                var result = await _shopDB.Address.FindAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("Address with ID {Id} not found for update", id);
                    return null;
                }

                foreach (var property in _shopDB.Entry(result).Properties)
                {
                    if (property.Metadata.Name != "Id" && property.Metadata.Name != "Role")
                    {
                        property.CurrentValue = _shopDB.Entry(addressToAdd).Property(property.Metadata.Name).CurrentValue;
                    }
                }

                await _shopDB.SaveChangesAsync();

                _logger.LogInformation("Address with ID {Id} updated successfully", id);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with ID: {Id}", id);
                throw;
            }
        }

        public async Task<Address?> UpdateCity(int id, int postalCode, int streetNumber, string city)
        {
            try
            {
                _logger.LogInformation("Updating address with ID: {Id}, postalCode: {postalCode}, streetNumber : {streetNumber}, city : {city}", id, postalCode, streetNumber, city);

                var result = await _shopDB.Address.FindAsync(id);

                if (result == null)
                {
                    _logger.LogWarning("Address with ID {Id} not found for update", id);
                    return null;
                }

                result.StreetNumber = streetNumber;
                result.City = city;
                result.PostalCode = postalCode;

                await _shopDB.SaveChangesAsync();

                _logger.LogInformation("Address with ID {Id}, postalCode: {postalCode}, streetNumber : {streetNumber}, city : {city} updated successfully", id, postalCode, streetNumber, city);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating City with ID: {Id}, postalCode: {postalCode}, streetNumber : {streetNumber}, city : {city}", id, postalCode, streetNumber, city);
                throw;
            }
        }

        public async Task<Address?> UpdatePhoneNumber(int id, int phoneNumber)
        {
            try
            {
                _logger.LogInformation("Updating address with ID: {Id}, phoneNumber : {phoneNumber}", id, phoneNumber);

                var result = await _shopDB.Address.FindAsync(id);

                if (result == null)
                {
                    _logger.LogWarning("Address with ID {Id} not found for update", id);
                    return null;
                }

                result.PhoneNumber = phoneNumber.ToString();

                await _shopDB.SaveChangesAsync();

                _logger.LogInformation("Address with ID {Id}, phoneNumber : {phoneNumber} updated successfully", id, phoneNumber);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating phoneNumber with ID: {Id}, phoneNumber : {phoneNumber}", id, phoneNumber);
                throw;
            }
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<bool> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting address with ID: {Id}", id);
                var result = await _shopDB.Address.FindAsync(id);
                if (result is null)
                {
                    _logger.LogWarning("Address with ID {Id} not found for deletion", id);
                    return false;
                }
                else
                {
                    _shopDB.Address.Remove(result);
                    await _shopDB.SaveChangesAsync();
                    _logger.LogInformation("Address with ID {Id} deleted successfully", id);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting address with ID: {Id}", id);
                throw;
            }
        }
        #endregion


        #region <-------------> TOOLS <------------->
        public async Task<bool> CheckIfUserAlreadyHasAddress(int id) 
        {
            var result = await _shopDB.Address.AnyAsync(x => x.UserId == id);

            return !result;
        }
        #endregion
    }
}