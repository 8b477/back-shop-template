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

                return new AddressViewDTO(u.Id, u.UserId,u.PostalCode,u.StreetNumber,u.StreetName,u.Country,u.City,u.PhoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating address");

                throw;
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IReadOnlyCollection<Address?>> GetAll()
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

        public async Task<IReadOnlyCollection<Address?>> GetByPostalCode(int postalCode)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses with postal code: {PostalCode}", postalCode);

                var result = await _shopDB.Address.Where(a => a.PostalCode == postalCode).ToListAsync();


                if (result is null)
                {
                    _logger.LogWarning("PostalCode with value {value} not found", postalCode);

                    throw new ArgumentNullException("No matching search !");
                }

                _logger.LogInformation("Retrieved {Count} addresses with postal code: {PostalCode}", result.Count, postalCode);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses with postal code: {PostalCode}", postalCode);

                throw;
            }
        }

        public async Task<IReadOnlyCollection<Address?>> GetByCity(string city)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses in city: {City}", city);

                var result = await _shopDB.Address.Where(a => a.City.ToUpper() == city.ToUpper()).ToListAsync();


                if (result is null)
                {
                    _logger.LogWarning("City with value {value} not found", city);

                    throw new ArgumentNullException("No matching search !");
                }

                _logger.LogInformation("Retrieved {Count} addresses in city: {City}", result.Count, city);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses in city: {City}", city);

                throw;
            }
        }

        public async Task<IReadOnlyCollection<Address?>> GetByCountry(string country)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses in country: {Country}", country);

                var result = await _shopDB.Address.Where(a => a.Country.ToUpper() == country.ToUpper()).ToListAsync();


                if (result is null)
                {
                    _logger.LogWarning("Country with value {value} not found", country);

                    throw new ArgumentNullException("No matching search !");
                }

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
        public async Task<Address?> Update(int idUser, Address addressToAdd)
        {
            try
            {
                _logger.LogInformation("Updating address with ID: {IdUser}", idUser);

                var result = await _shopDB.Address.FirstOrDefaultAsync(a => a.UserId == idUser);

                if (result == null)
                {
                    _logger.LogWarning("Address with IDUser {IdUser} not found for update", idUser);

                    throw new ArgumentNullException("No matching search !");
                }

                foreach (var property in _shopDB.Entry(result).Properties)
                {
                    if (property.Metadata.Name != "Id" && property.Metadata.Name != "PhoneNumber")
                    {
                        property.CurrentValue = _shopDB.Entry(addressToAdd).Property(property.Metadata.Name).CurrentValue;
                    }
                }
                result.UserId = idUser;

                await _shopDB.SaveChangesAsync();

                _logger.LogInformation("Address with IDUser {IdUser} updated successfully", idUser);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with IDUser: {IdUser}", idUser);

                throw;
            }
        }

        public async Task<Address?> UpdateCity(int idUser, Address addressToUpdate)
        {
            try
            {
                _logger.LogInformation("Updating address with IDUser: {idUser}, postalCode: {postalCode}, streetNumber : {streetNumber}, city : {city}", idUser, addressToUpdate.PostalCode, addressToUpdate.StreetNumber, addressToUpdate.City);

                var result = await _shopDB.Address.FirstOrDefaultAsync(a => a.UserId == idUser);

                if (result == null)
                {
                    _logger.LogWarning("Address with IDUser {IdUser} not found for update", idUser);

                    throw new ArgumentNullException("No matching search !");
                }

                result.StreetNumber = addressToUpdate.StreetNumber;
                result.StreetName = addressToUpdate.StreetName;
                result.City = addressToUpdate.City;
                result.PostalCode = addressToUpdate.PostalCode;

                await _shopDB.SaveChangesAsync();

                _logger.LogInformation("Address with IDUser {IdUser}, postalCode: {postalCode}, streetNumber : {streetNumber}, city : {city} updated successfully", idUser, addressToUpdate.PostalCode, addressToUpdate.StreetNumber, addressToUpdate.City);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating City with IDUser: {IdUser}, postalCode: {postalCode}, streetNumber : {streetNumber}, city : {city}", idUser, addressToUpdate.PostalCode, addressToUpdate.StreetNumber, addressToUpdate.City);

                throw;
            }
        }

        public async Task<Address?> UpdatePhoneNumber(int idUser, string phoneNumber)
        {
            try
            {
                _logger.LogInformation("Updating address with IDUser: {IdUser}, phoneNumber : {phoneNumber}", idUser, phoneNumber);

                var result = await _shopDB.Address.FirstOrDefaultAsync(a => a.UserId == idUser);

                if (result == null)
                {
                    _logger.LogWarning("Address with ID {Id} not found for update", idUser);

                    throw new ArgumentNullException("No matching search !");
                }

                result.PhoneNumber = phoneNumber.ToString();

                await _shopDB.SaveChangesAsync();

                _logger.LogInformation("Address with IDUser {IdUser}, phoneNumber : {phoneNumber} updated successfully", idUser, phoneNumber);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating phoneNumber with IDUser: {IdUser}, phoneNumber : {phoneNumber}", idUser, phoneNumber);

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