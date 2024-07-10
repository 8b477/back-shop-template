using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;
using BLL_Shop.JWT.Services;
using BLL_Shop.Mappers;
using DAL_Shop.Interfaces;
using Database_Shop.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class AddressServices
    {
        #region DI
        private readonly IAddressRepository _addressRepository;
        private readonly JWTGetClaimsService _jwtGetClaimService;
        private readonly ILogger<AddressServices> _logger;

        public AddressServices(IAddressRepository addressRepository, JWTGetClaimsService jwtGetClaims, ILogger<AddressServices> logger)
        {
            _addressRepository = addressRepository;
            _jwtGetClaimService = jwtGetClaims;
            _logger = logger;
        }
        #endregion



        #region <-------------> CREATE <------------->
        public async Task<IResult> Create(AddressCreateDTO addressToAdd)
        {
            try
            {
                _logger.LogInformation("Attempting to create a new address");

                int idUser = _jwtGetClaimService.GetIdUserToken();

                if (idUser == 0)
                {
                    _logger.LogWarning("Unauthorized attempt to create address, 'id' recover in token is not valid");
                    return TypedResults.Unauthorized();
                }

                var userCanCreateAddress = await _addressRepository.CheckIfUserAlreadyHasAddress(idUser);

                if(userCanCreateAddress == false)
                {
                    _logger.LogWarning("The user already has an address");
                    return TypedResults.BadRequest("The user already has an address, please update it if it has changed");
                }

                Address addressMapped = MapperAddress.FromAddressCreateDTOToEntity(addressToAdd);
                addressMapped.IdUser = idUser;

                var result = await _addressRepository.Create(addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to create address");
                    return TypedResults.BadRequest();
                }

                _logger.LogInformation("Address created successfully for user: {UserId}", idUser);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating address");
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Retrieving all addresses");
                var result = await _addressRepository.GetAll();

                if (result is null || !result.Any())
                {
                    _logger.LogInformation("No addresses found");
                    return TypedResults.NoContent();
                }

                _logger.LogInformation("Retrieved {Count} addresses", result.Count());
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all addresses");
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetByPostalCode(int postalCode)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses by postal code: {PostalCode}", postalCode);
                var result = await _addressRepository.GetByPostalCode(postalCode);

                if (!result.Any())
                {
                    _logger.LogInformation("No addresses found for postal code: {PostalCode}", postalCode);
                    return TypedResults.NotFound();
                }

                _logger.LogInformation("Retrieved {Count} addresses for postal code: {PostalCode}", result.Count(), postalCode);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses by postal code: {PostalCode}", postalCode);
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetByCity(string city)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses by city: {City}", city);
                var result = await _addressRepository.GetByCity(city);

                if (!result.Any())
                {
                    _logger.LogInformation("No addresses found for city: {City}", city);
                    return TypedResults.NotFound();
                }

                _logger.LogInformation("Retrieved {Count} addresses for city: {City}", result.Count(), city);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses by city: {City}", city);
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetByCountry(string country)
        {
            try
            {
                _logger.LogInformation("Retrieving addresses by country: {Country}", country);
                var result = await _addressRepository.GetByCountry(country);

                if (!result.Any())
                {
                    _logger.LogInformation("No addresses found for country: {Country}", country);
                    return TypedResults.NotFound();
                }

                _logger.LogInformation("Retrieved {Count} addresses for country: {Country}", result.Count(), country);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses by country: {Country}", country);
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> Update(int id, AddressUpdateCountryDTO addressToAdd)
        {
            try
            {
                _logger.LogInformation("Updating address with ID: {Id}", id);

                Address addressMapped = MapperAddress.FromAddressCountryUpdateDTOToEntity(addressToAdd);

                var result = await _addressRepository.Update(id, addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update address with ID: {Id}", id);
                    return TypedResults.BadRequest();
                }

                _logger.LogInformation("Address with ID {Id} updated successfully", id);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with ID: {Id}", id);
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting address with ID: {Id}", id);
                var result = await _addressRepository.Delete(id);

                if (!result)
                {
                    _logger.LogWarning("Failed to delete address with ID: {Id}", id);
                    return TypedResults.BadRequest();
                }

                _logger.LogInformation("Address with ID {Id} deleted successfully", id);
                return TypedResults.NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting address with ID: {Id}", id);
                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

    }
}