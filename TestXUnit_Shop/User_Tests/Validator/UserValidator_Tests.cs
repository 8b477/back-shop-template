using BLL_Shop.DTO.User.Create;
using BLL_Shop.Validators.User_Validator;

using FluentValidation.TestHelper;


namespace TestXUnit_Shop.User_Tests.Validator
{
    /// <summary>
    /// Testing Validator class based on UserCreateDTO
    /// </summary>
    public class UserValidator_Tests
    {
        private readonly UserCreateValidator _validator;

        public UserValidator_Tests()
        {
            _validator = new UserCreateValidator();
        }


        [Theory]
        [InlineData("", "Mail requis")]
        [InlineData("invalidemail", "L'adresse mail renseignée n'est pas valide !")]
        [InlineData("invalidemail@", "L'adresse mail renseignée n'est pas valide !")]
        [InlineData("invalidemail@.com", "L'adresse mail renseignée n'est pas valide !")]
        public void Should_Have_Error_When_Mail_Is_Invalid(string mail, string expectedErrorMessage)
        {
            var model = GetModel(mail : mail);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Mail)
                .WithErrorMessage(expectedErrorMessage);
        }


        [Theory]
        [InlineData("", "Mot de passe requis")]
        [InlineData("weak", "8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        [InlineData("onlylow", "8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        [InlineData("ONLYCAPS", "8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        [InlineData("NoDigit", "8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        [InlineData("NoSpecial1", "8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        public void Should_Have_Error_When_Mdp_Is_Invalid(string mdp, string expectedErrorMessage)
        {
            var model = GetModel(mdp : mdp);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Mdp)
                .WithErrorMessage(expectedErrorMessage);
        }



        [Theory]
        [InlineData("", "Pseudo requis")]
        [InlineData("N", "Pseudo doit contenir au minimum 2 caractères")]
        [InlineData("qZ7x9!tR3@pL5*eF8#uJ1$hN2^mQ4&vW6)bY0-zA8+cE1qZ7x9!tR3@p", "Pseudo doit contenir au maximum 50 caractères")]
        public void Should_Returns_Length_Error_Or_Required_Error(string pseudo, string expectedErrorMessage)
        {
            var model = GetModel(pseudo : pseudo);
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(user => user.Pseudo)
                .WithErrorMessage(expectedErrorMessage);
        }

        [Fact]
        public void Should_Not_Have_Error_When_PhoneNumber_Is_Null()
        {
            var model = GetModel(phoneNumber : null);

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact]
        public void Should_Not_Have_Error_When_Pseudo_Is_Valid()
        {
            var model = GetModel();

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact]
        public void Should_Not_Have_Error_When_Mail_Is_Valid()
        {
            var model = GetModel();

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact]
        public void Should_Not_Have_Error_When_Mdp_Is_Valid()
        {
            var model = GetModel();

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact]
        public void Should_Not_Have_Error_When_MdpConfirm_Is_Valid()
        {
            var model = GetModel();

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = GetModel();

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        private UserCreateDTO GetModel(
            string? phoneNumber = "060800",
            string pseudo = "Arthur",
            string mail = "mail@test.be",
            string mdp = "Test1234*",
            string mdpConfirm = "Test1234*"
            )
        {
            return new UserCreateDTO(phoneNumber, pseudo, mail, mdp, mdpConfirm);
        }

    }
}