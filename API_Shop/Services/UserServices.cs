using API_Shop.DTO.User.Create;
using API_Shop.DTO.User.Update;
using API_Shop.Interfaces;
using API_Shop.Mappers;
using API_Shop.Models;
using API_Shop.Validators;

using FluentValidation;



namespace API_Shop.Services
{
    /// <summary>
    /// Manager of CRUD on User table
    /// </summary>
    public class UserServices
    {

        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserCreateDTO> _userCreateValidator;
        private readonly IValidator<UserUpdateDTO> _userUpdateFullValidator;
        private readonly IValidator<UserPseudoUpdateDTO> _userPseudoUpdateValidator;
        private readonly IValidator<UserMailUpdateDTO> _userMailUpdateValidator;
        private readonly IValidator<UserPwdUpdateDTO> _userPwdUpdateValidator;

        public UserServices(IUserRepository userRepository, IValidator<UserCreateDTO> userCreateValidator, IValidator<UserUpdateDTO> userUpdateFullValidator, IValidator<UserPseudoUpdateDTO> userPseudoUpdateValidator, IValidator<UserMailUpdateDTO> userMailUpdateValidator, IValidator<UserPwdUpdateDTO> userPwdUpdateValidator)
        {
            _userRepository = userRepository;
            _userCreateValidator = userCreateValidator;
            _userUpdateFullValidator = userUpdateFullValidator;
            _userPseudoUpdateValidator = userPseudoUpdateValidator;
            _userMailUpdateValidator = userMailUpdateValidator;
            _userPwdUpdateValidator = userPwdUpdateValidator;
        }



        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>An IResult containing a list of all users, or NoContent if the list is empty.</returns>
        public async Task<IResult> GetAll()
        {
            var result = await _userRepository.GetAll();

            return
                result is null
                ? TypedResults.NoContent()
                : TypedResults.Ok(result);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>An IResult containing the user with the specified ID, or NotFound if the user does not exist.</returns>
        public async Task<IResult> GetByID(int id)
        {
            var result = await _userRepository.GetByID(id);

            return
                result is null
                ? TypedResults.NotFound()
                : TypedResults.Ok(result);
        }

        /// <summary>
        /// Retrieves users by their pseudo.
        /// </summary>
        /// <param name="pseudo">The pseudo to search for.</param>
        /// <returns>An IResult containing a list of users with the specified pseudo, or NoContent if no users are found.</returns>
        public async Task<IResult> GetByPseudo(string pseudo)
        {
            var result = await _userRepository.GetByPseudo(pseudo);

            return
                result.Any()
                ? TypedResults.Ok(result)
                : TypedResults.NotFound();
        }

        /// <summary>
        /// Deletes a user from the database by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An IResult indicating success or failure of the deletion.</returns>
        public async Task<IResult> Delete(int id)
        {
            var result = await _userRepository.Delete(id);

            return
                result
                ? TypedResults.NoContent()
                : TypedResults.BadRequest();
        }

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userToAdd">The new user data.</param>
        /// <returns>An IResult containing the updated user, or BadRequest if the update fails.</returns>
        public async Task<IResult> Update(int id, UserUpdateDTO userToAdd)
        {
            var validationResult = await ValidatorModelState.ValidModelState(userToAdd, _userUpdateFullValidator);
            if (validationResult != Results.Ok()) return validationResult;

            User userMapped = MapperUser.FromUserUpdateDTOToEntity(userToAdd);

            var result = await _userRepository.Update(id, userMapped);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(new { result });
        }


        public async Task<IResult> UpdatePseudo(int id, UserPseudoUpdateDTO pseudo)
        {
            var validationResult = await ValidatorModelState.ValidModelState(pseudo, _userPseudoUpdateValidator);
            if (validationResult != Results.Ok()) return validationResult;

            var result = await _userRepository.UpdatePseudo(id, pseudo.Pseudo);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(new { result });
        }


        public async Task<IResult> UpdateMail(int id, UserMailUpdateDTO mail)
        {
            var validationResult = await ValidatorModelState.ValidModelState(mail, _userMailUpdateValidator);
            if (validationResult != Results.Ok()) return validationResult;

            var result = await _userRepository.UpdateMail(id, mail.Mail);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(new { result });
        }

        public async Task<IResult> UpdatePwd(int id, UserPwdUpdateDTO pwd)
        {
            var validationResult = await ValidatorModelState.ValidModelState(pwd, _userPwdUpdateValidator);
            if (validationResult != Results.Ok()) return validationResult;

            var result = await _userRepository.UpdatePwd(id, pwd.Mdp);

            return
                string.IsNullOrEmpty(result)
                ? TypedResults.BadRequest()
                : TypedResults.Ok(new { result });
        }



        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="userToAdd">The user information to add.</param>
        /// <returns>An IResult containing the created user, or BadRequest if the creation fails.</returns>
        public async Task<IResult> Create(UserCreateDTO userToAdd)
        {
            var validationResult = await ValidatorModelState.ValidModelState(userToAdd, _userCreateValidator);
            if (validationResult != Results.Ok()) return validationResult;

            User userMapped = MapperUser.FromUserCreateDTOToEntity(userToAdd);

            var result = await _userRepository.Create(userMapped);

            return
                result is null
                ? TypedResults.BadRequest()
                : TypedResults.Ok(result);
        }

 
    }
}
