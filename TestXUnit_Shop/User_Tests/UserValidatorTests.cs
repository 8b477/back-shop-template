using API_Shop.Models;
using API_Shop.Validators.User_Validator.UserValidator;
using FluentValidation.TestHelper;


namespace API_Shop.Tests
{
    public class UserValidatorTests
    {
        private readonly UserCreateValidator _validator;

        public UserValidatorTests()
        {
            _validator = new UserCreateValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Pseudo_Is_Empty()
        {
            var model = new User { Pseudo = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Pseudo)
                .WithErrorMessage("Pseudo requis");
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        public void Should_Have_Error_When_Pseudo_Is_Too_Short(string pseudo)
        {
            var model = new User { Pseudo = pseudo };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Pseudo)
                .WithErrorMessage("Pseudo doit contenir au minimum 2 caractères");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Pseudo_Is_Two_Characters()
        {
            var model = new User { Pseudo = "ab" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(user => user.Pseudo);
        }

        [Fact]
        public void Should_Have_Error_When_Pseudo_Is_Too_Long()
        {
            var model = new User { Pseudo = new string('a', 51) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Pseudo)
                .WithErrorMessage("Pseudo doit contenir au maximum 50 caractères");
        }

        [Fact]
        public void Should_Have_Error_When_Mail_Is_Empty()
        {
            var model = new User { Mail = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Mail)
                .WithErrorMessage("Mail requis");
        }

        [Theory]
        [InlineData("invalidemail")]
        [InlineData("invalidemail@")]
        [InlineData("invalidemail@.com")]
        public void Should_Have_Error_When_Mail_Is_Invalid(string mail)
        {
            var model = new User { Mail = mail };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Mail)
                .WithErrorMessage("L'adresse mail renseignée n'est pas valide !");
        }

        [Fact]
        public void Should_Have_Error_When_Mdp_Is_Empty()
        {
            var model = new User { Mdp = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Mdp)
                .WithErrorMessage("Mot de passe requis");
        }

        [Theory]
        [InlineData("weak")]
        [InlineData("onlylow")]
        [InlineData("ONLYCAPS")]
        [InlineData("NoDigit")]
        [InlineData("NoSpecial1")]
        public void Should_Have_Error_When_Mdp_Is_Invalid(string mdp)
        {
            var model = new User { Mdp = mdp };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.Mdp)
                .WithErrorMessage("8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial");
        }

        [Fact]
        public void Should_Have_Error_When_MdpConfirm_Is_Empty()
        {
            var model = new User { Mdp = "ValidPassword1!", MdpConfirm = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.MdpConfirm)
                .WithErrorMessage("Confirmation du mot de passe requise");
        }

        [Fact]
        public void Should_Have_Error_When_MdpConfirm_Does_Not_Match_Mdp()
        {
            var model = new User { Mdp = "ValidPassword1!", MdpConfirm = "DifferentPassword1!" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(user => user.MdpConfirm)
                .WithErrorMessage("Le champ mot de passe et celui de la confirmation du mot de passe ne correspondent pas !");
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            var model = new User
            {
                Pseudo = "ValidPseudo",
                Mail = "valid@email.com",
                Mdp = "ValidPassword1!",
                MdpConfirm = "ValidPassword1!"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}