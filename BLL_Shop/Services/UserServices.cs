﻿using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;
using BLL_Shop.JWT.Services;
using BLL_Shop.Mappers;
using BLL_Shop.Validators;
using BLL_Shop.Interfaces;
using DAL_Shop.Interfaces;
using DAL_Shop.Cryptage;
using Database_Shop.Entity;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BLL_Shop.Validators.User_Validator;



namespace BLL_Shop.Services
{
    public class UserServices : IUserService
    {


        #region DI
        private readonly IUserRepository _userRepository;
        private readonly JWTGetClaimsService _getClaimService;
        private readonly IValidator<UserCreateDTO> _userCreateValidator;
        private readonly IValidator<UserUpdateDTO> _userUpdateFullValidator;
        private readonly IValidator<UserPseudoUpdateDTO> _userPseudoUpdateValidator;
        private readonly IValidator<UserMailUpdateDTO> _userMailUpdateValidator;
        private readonly IValidator<UserPwdUpdateDTO> _userPwdUpdateValidator;
        private readonly IValidator<UserRoleUpdateDTO> _userRoleUpdateValidator;
        private readonly ILogger<UserServices> _logger;

        public UserServices(
            IUserRepository userRepository,
            JWTGetClaimsService getClaimService,
            IValidator<UserCreateDTO> userCreateValidator,
            IValidator<UserUpdateDTO> userUpdateFullValidator,
            IValidator<UserPseudoUpdateDTO> userPseudoUpdateValidator,
            IValidator<UserMailUpdateDTO> userMailUpdateValidator,
            IValidator<UserPwdUpdateDTO> userPwdUpdateValidator,
            IValidator<UserRoleUpdateDTO> userRoleUpdateValidator,
            ILogger<UserServices> logger
            )
        {
            _userRepository = userRepository;
            _getClaimService = getClaimService;
            _userCreateValidator = userCreateValidator;
            _userUpdateFullValidator = userUpdateFullValidator;
            _userPseudoUpdateValidator = userPseudoUpdateValidator;
            _userMailUpdateValidator = userMailUpdateValidator;
            _userPwdUpdateValidator = userPwdUpdateValidator;
            _userRoleUpdateValidator = userRoleUpdateValidator;
            _logger = logger;
        }
        #endregion


        #region <-------------> CREATE <------------->
        public async Task<IResult> CreateUser(UserCreateDTO userToAdd)
        {
            try
            {
                _logger.LogInformation("Creating new user");

                var validationResult = await ValidatorModelState.ValidModelState(userToAdd, _userCreateValidator);

                if (validationResult != Results.Ok())
                {
                    _logger.LogWarning("Validation failed for user creation");

                    return validationResult;
                }

                bool isValidMail = await _userRepository.IsValidMail(userToAdd.Mail);

                if (!isValidMail)
                {
                    _logger.LogWarning("Invalid email provided for user creation: {Email}", userToAdd.Mail);

                    return TypedResults.BadRequest(new { Message = "The information provided is incorrect. Please try again." });
                }

                User userMapped = MapperUser.DtoToEntity(userToAdd);

                try
                {
                    userMapped.Pwd = PasswordHasher.HashPassword(userMapped.Pwd);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while hashing password");

                    return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
                }

                var result = await _userRepository.Create(userMapped);

                if (result is null)
                {
                    _logger.LogWarning("User creation failed");

                    return TypedResults.BadRequest(new { Message = "An error occurred while creating the user. Please try again." });
                }

                _logger.LogInformation("User created successfully: {Id}", result.Id);

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> GET <------------->
        public async Task<IResult> GetAllUser()
        {
            try
            {
                _logger.LogInformation("Retrieving all users");

                var result = await _userRepository.GetAll();

                return result is null ? TypedResults.NoContent() : TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all users");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetUserByID(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving user with ID: {Id}", id);

                var result = await _userRepository.GetByID(id);

                return 
                    result is null 
                    ? TypedResults.NotFound(new { Message = "Aucune correspondance" }) 
                    : TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user with ID: {Id}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetUserByPseudo(string pseudo)
        {
            try
            {
                _logger.LogInformation("Retrieving users with pseudo: {Pseudo}", pseudo);

                var result = await _userRepository.GetByPseudo(pseudo);

                return
                    result.Any()
                    ? TypedResults.Ok(result)
                    : TypedResults.NotFound(new { Message = "Aucune correspondance" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users with pseudo: {Pseudo}", pseudo);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> GetUserProfil()
        {
            int idUser = _getClaimService.GetIdUserToken();

            if (idUser == 0)
                return TypedResults.Unauthorized();

            try
            {
                _logger.LogInformation("Retrieving user with ID: {Id}", idUser);

                var result = await _userRepository.GetByID(idUser);

                return
                    result is null
                    ? TypedResults.NotFound(new { Message = "Aucune correspondance" })
                    : TypedResults.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user with ID: {Id}", idUser);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

        

        #region <-------------> UPDATE <------------->
        public async Task<IResult> UpdateUser(int id, UserUpdateDTO userToAdd)
        {
            try
            {
                _logger.LogInformation("Updating user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(userToAdd, _userUpdateFullValidator);

                if (validationResult != Results.Ok()) 
                    return validationResult;

                User userMapped = MapperUser.DtoToEntity(userToAdd);


                try
                {
                    userMapped.Pwd = PasswordHasher.HashPassword(userMapped.Pwd);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while hashing password");

                    return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
                }


                var result = await _userRepository.Update(id, userMapped);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user with ID: {Id}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateUserPseudo(int id, UserPseudoUpdateDTO pseudo)
        {
            try
            {
                _logger.LogInformation("Updating pseudo for user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(pseudo, _userPseudoUpdateValidator);

                if (validationResult != Results.Ok()) return validationResult;

                var result = await _userRepository.UpdatePseudo(id, pseudo.Pseudo);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating pseudo for user with ID: {Id}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateUserMail(int id, UserMailUpdateDTO mail)
        {
            try
            {
                _logger.LogInformation("Updating email for user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(mail, _userMailUpdateValidator);

                if (validationResult != Results.Ok()) return validationResult;


                bool isValidMail = await _userRepository.IsValidMail(mail.Mail);

                if (!isValidMail)
                {
                    _logger.LogWarning("Invalid email provided for user creation: {Email}", mail.Mail);

                    return TypedResults.BadRequest(new { Message = "The information provided is incorrect. Please try again." });
                }


                var result = await _userRepository.UpdateMail(id, mail.Mail);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating email for user with ID: {Id}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateUserPwd(int id, UserPwdUpdateDTO pwd)
        {
            try
            {
                _logger.LogInformation("Updating password for user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(pwd, _userPwdUpdateValidator);

                if (validationResult != Results.Ok())
                    return validationResult;

                string pwdHash = PasswordHasher.HashPassword(pwd.Pwd);

                var result = await _userRepository.UpdatePwd(id, pwdHash);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating password for user with ID: {Id}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // 🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧
        public async Task<IResult> UpdateUserRole(int id, UserRoleUpdateDTO role)
        {

            var validationResult = await ValidatorModelState.ValidModelState(role, _userRoleUpdateValidator);

            if (validationResult != Results.Ok())
                return validationResult;

            var result = await _userRepository.UpdateRole(id, role.Role);

            if (string.IsNullOrEmpty(result))
                return TypedResults.BadRequest(new { Message = "The update role user is failed" });

            return TypedResults.Ok(new { result });
        }
        // 🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧🚧

        public async Task<IResult> UpdateOwnUser(UserUpdateDTO userToAdd)
        {
            try
            {
                int id = _getClaimService.GetIdUserToken();

                if (id == 0)
                {
                    _logger.LogWarning("Unauthorized attempt to create address, 'id' recover in token is not valid");

                    return TypedResults.Unauthorized();
                }

                _logger.LogInformation("Updating user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(userToAdd, _userUpdateFullValidator);

                if (validationResult != Results.Ok())
                    return validationResult;

                User userMapped = MapperUser.DtoToEntity(userToAdd);


                try
                {
                    userMapped.Pwd = PasswordHasher.HashPassword(userMapped.Pwd);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while hashing password");

                    return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
                }


                var result = await _userRepository.Update(id, userMapped);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating user");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateOwnUserPseudo(UserPseudoUpdateDTO pseudo)
        {
            try
            {
                int id = _getClaimService.GetIdUserToken();

                if (id == 0)
                {
                    _logger.LogWarning("Unauthorized attempt to create address, 'id' recover in token is not valid");

                    return TypedResults.Unauthorized();
                }

                _logger.LogInformation("Updating pseudo for user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(pseudo, _userPseudoUpdateValidator);

                if (validationResult != Results.Ok()) return validationResult;

                var result = await _userRepository.UpdatePseudo(id, pseudo.Pseudo);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating pseudo for user");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateOwnUserMail(UserMailUpdateDTO mail)
        {
            try
            {
                int id = _getClaimService.GetIdUserToken();

                if (id == 0)
                {
                    _logger.LogWarning("Unauthorized attempt to create address, 'id' recover in token is not valid");

                    return TypedResults.Unauthorized();
                }

                _logger.LogInformation("Updating email for user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(mail, _userMailUpdateValidator);

                if (validationResult != Results.Ok()) 
                    return validationResult;


                bool isValidMail = await _userRepository.IsValidMail(mail.Mail);

                if (!isValidMail)
                {
                    _logger.LogWarning("Invalid email provided for user creation: {Email}", mail.Mail);

                    return TypedResults.BadRequest(new { Message = "The information provided is incorrect. Please try again." });
                }


                var result = await _userRepository.UpdateMail(id, mail.Mail);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating email for user");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<IResult> UpdateOwnUserPwd(UserPwdUpdateDTO pwd)
        {
            try
            {
                int id = _getClaimService.GetIdUserToken();

                if (id == 0)
                {
                    _logger.LogWarning("Unauthorized attempt to create address, 'id' recover in token is not valid");

                    return TypedResults.Unauthorized();
                }

                _logger.LogInformation("Updating password for user with ID: {Id}", id);

                var validationResult = await ValidatorModelState.ValidModelState(pwd, _userPwdUpdateValidator);

                if (validationResult != Results.Ok())
                    return validationResult;


                string pwdHash = PasswordHasher.HashPassword(pwd.Pwd);
                

                var result = await _userRepository.UpdatePwd(id, pwdHash);

                return string.IsNullOrEmpty(result) ? TypedResults.BadRequest(new { Message = "Something went wrong, please try again" }) : TypedResults.Ok(new { result });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating password for user");

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion



        #region <-------------> DELETE <------------->
        public async Task<IResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user with ID: {Id}", id);

                var result = await _userRepository.Delete(id);

                return result ? TypedResults.NoContent() : TypedResults.BadRequest(new { Message = "Something went wrong, please try again" });
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting user with ID: {Id}", id);

                return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

       
    }
}