using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;
using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Services;
using BLL_Shop.Mappers;
using BLL_Shop.Validators;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace BLL_Shop.Services
{
    public class AddressService : IAddressService
    {


        #region DI
        private readonly IAddressRepository _addressRepository;
        private readonly JWTGetClaimsService _jwtGetClaimService;
        private readonly ILogger<IAddressService> _logger;
        private readonly IValidator<AddressCreateDTO> _addressCreateValidator;
        private readonly IValidator<AddressCountryUpdateDTO> _addressUpdateCountryValidator;
        private readonly IValidator<AddressCityUpdateDTO> _addressUpdateCityValidator;
        private readonly IValidator<AddressPhoneNumberUpdateDTO> _addressUpdatePhoneNumberValidator;

        public AddressService(
            IAddressRepository addressRepository,
            JWTGetClaimsService jwtGetClaimService,
            ILogger<IAddressService> logger,
            IValidator<AddressCreateDTO> addressCreateValidator,
            IValidator<AddressCountryUpdateDTO> addressUpdateCountryValidator,
            IValidator<AddressCityUpdateDTO> addressUpdateCityValidator,
            IValidator<AddressPhoneNumberUpdateDTO> addressUpdatePhoneNumberValidator
            )
        {
            _addressRepository = addressRepository;
            _jwtGetClaimService = jwtGetClaimService;
            _logger = logger;
            _addressCreateValidator = addressCreateValidator;
            _addressUpdatePhoneNumberValidator = addressUpdatePhoneNumberValidator;
            _addressUpdateCountryValidator = addressUpdateCountryValidator;
            _addressUpdateCityValidator = addressUpdateCityValidator;
            _addressCreateValidator = addressCreateValidator;
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

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressCreateValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address creation");

                    return validationResult;
                }

                var userCanCreateAddress = await _addressRepository.CheckIfUserAlreadyHasAddress(idUser);

                if(userCanCreateAddress == false)
                {
                    _logger.LogWarning("The user already has an address");

                    return TypedResults.BadRequest(new { Message = "The user already has an address, please update it if it has changed"});
                }

                Address addressMapped = MapperAddress.DtoToEntity(addressToAdd);

                addressMapped.UserId = idUser;

                var result = await _addressRepository.Create(addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to create address");

                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
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

                if (result is null || result.Count == 0)
                {
                    _logger.LogInformation("No addresses found");

                    return TypedResults.NoContent();
                }

                _logger.LogInformation("Retrieved {Count} addresses", result.Count);

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

                if (result.Count == 0)
                {
                    _logger.LogInformation("No addresses found for postal code: {PostalCode}", postalCode);

                    return TypedResults.NotFound(new { Message = "Aucune correspondance" });
                }

                _logger.LogInformation("Retrieved {Count} addresses for postal code: {PostalCode}", result.Count, postalCode);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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

                if (result.Count == 0)
                {
                    _logger.LogInformation("No addresses found for city: {City}", city);

                    return TypedResults.NotFound(new { Message = "Aucune correspondance" });
                }

                _logger.LogInformation("Retrieved {Count} addresses for city: {City}", result.Count, city);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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

                if (result.Count == 0)
                {
                    _logger.LogInformation("No addresses found for country: {Country}", country);

                    return TypedResults.NotFound(new { Message = "Aucune correspondance" });
                }

                _logger.LogInformation("Retrieved {Count} addresses for country: {Country}", result.Count, country);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving addresses by country: {Country}", country);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateAddressForSimpleUser(AddressCountryUpdateDTO addressToAdd)
        {
            try
            {
                _logger.LogInformation("Try to authenticate user");

                int idUser = _jwtGetClaimService.GetIdUserToken();

                if (idUser == 0)
                {
                    _logger.LogWarning("Unauthorized attempt to create address, 'id' recover in token is not valid");
                    return TypedResults.Unauthorized();
                }

                _logger.LogInformation("Updating address with IDUser: {IdUser}", idUser);

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressUpdateCountryValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address update");

                    return validationResult;
                }

                Address addressMapped = MapperAddress.DtoToEntity(addressToAdd);

                var result = await _addressRepository.Update(idUser, addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update address with IDUser: {IdUser}", idUser);
                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });

                }

                _logger.LogInformation("Address with ID {IdUser} updated successfully", idUser);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with IDUser");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateAddressUserWithAdminAccess(int idUser, AddressCountryUpdateDTO addressToAdd)
        {
            try
            {
                _logger.LogInformation("Updating address with IDUser: {idUser}", idUser);

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressUpdateCountryValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address update");

                    return validationResult;
                }

                Address addressMapped = MapperAddress.DtoToEntity(addressToAdd);

                var result = await _addressRepository.Update(idUser, addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update address with IDUser: {IdUser}", idUser);
                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });

                }

                _logger.LogInformation("Address with ID {Id} updated successfully", idUser);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with ID: {Id}", idUser);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateCityForSimpleUser(AddressCityUpdateDTO addressToAdd)
        {
            try
            {
                int idUser = _jwtGetClaimService.GetIdUserToken();
                if(idUser == 0)
                {
                    _logger.LogWarning("Authentication failed ! Impossible to retrieve the id user in token");

                    return TypedResults.Unauthorized();
                }

                _logger.LogInformation("Updating City address with IDUser: {IdUser}", idUser);

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressUpdateCityValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address creation");

                    return validationResult;
                }

                Address addressMapped = MapperAddress.DtoToEntity(addressToAdd);

                var result = await _addressRepository.UpdateCity(idUser,addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update City address with IDUser: {IdUser}", idUser);

                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
                }

                _logger.LogInformation("Address with IDUser {IdUser} updated successfully", idUser);

                return TypedResults.Ok(result);                
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with IDUser give, PostalCode: {PostalCode}, StreetNumber: {StreetNumber}, City: {City}", addressToAdd.PostalCode, addressToAdd.StreetNumber, addressToAdd.City);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateCityUserWithAdminAccess(int idUser, AddressCityUpdateDTO addressToAdd)
        {
            try
            {
                _logger.LogInformation("Updating City address with IDUser: {IdUser}", idUser);

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressUpdateCityValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address creation");

                    return validationResult;
                }

                Address addressMapped = MapperAddress.DtoToEntity(addressToAdd);

                var result = await _addressRepository.UpdateCity(idUser, addressMapped);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update City address with IDUser: {IdUser}", idUser);

                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
                }

                _logger.LogInformation("Address with IDUser {IdUser} updated successfully", idUser);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with IDUser give, PostalCode: {PostalCode}, StreetNumber: {StreetNumber}, City: {City}", addressToAdd.PostalCode, addressToAdd.StreetNumber, addressToAdd.City);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdatePhoneNumberForSimpleUser(AddressPhoneNumberUpdateDTO addressToAdd)
        {
            try
            {
                int idUser = _jwtGetClaimService.GetIdUserToken();

                if(idUser == 0)
                {
                    _logger.LogWarning("Authentication failed ! Impossible to retrieve the id user in token");
                    return TypedResults.Unauthorized();
                }


                _logger.LogInformation("Updating PhoneNumber with IDUser: {IdUser}", idUser);

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressUpdatePhoneNumberValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address creation");

                    return validationResult;
                }

                var result = await _addressRepository.UpdatePhoneNumber(idUser, addressToAdd.PhoneNumber);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update PhoneNumber with IDUser: {IdUser}", idUser);

                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
                }

                _logger.LogInformation("Address with IDUser {IdUser} and PhoneNumber {PhoneNumber} updated successfully", idUser, addressToAdd.PhoneNumber);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with IDUser and PhoneNumber {PhoneNumber}", addressToAdd.PhoneNumber);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdatePhoneNumberUserWithAdminAccess(int idUser, AddressPhoneNumberUpdateDTO addressToAdd)
        {
            try
            {
                _logger.LogInformation("Updating PhoneNumber with IDUser: {Id}", idUser);

                var validationResult = await ValidatorModelState.ValidModelState(addressToAdd, _addressUpdatePhoneNumberValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for address creation");

                    return validationResult;
                }

                var result = await _addressRepository.UpdatePhoneNumber(idUser, addressToAdd.PhoneNumber);

                if (result is null)
                {
                    _logger.LogWarning("Failed to update PhoneNumber with IDUser: {IdUser}", idUser);

                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
                }

                _logger.LogInformation("Address with ID {IdUser} and PhoneNumber {PhoneNumber} updated successfully", idUser, addressToAdd.PhoneNumber);

                return TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating address with IDUser and PhoneNumber {PhoneNumber}", addressToAdd.PhoneNumber);

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

                    return TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
                }

                _logger.LogInformation("Address with ID {Id} deleted successfully", id);

                return TypedResults.NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
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