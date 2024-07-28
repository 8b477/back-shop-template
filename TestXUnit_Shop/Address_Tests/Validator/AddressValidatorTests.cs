using BLL_Shop.DTO.Address.Create;
using BLL_Shop.Validators.Address_Validator;

using FluentValidation.TestHelper;

namespace TestXUnit_Shop.Address_Tests.Validator
{
    public class AddressValidatorTests
    {
        private readonly AddressCreateValidator _validator;

        public AddressValidatorTests()
        {
            _validator = new AddressCreateValidator();
        }


        private AddressCreateDTO GetModel(
            int postalCode = 5600,
            int streetNumber = 50,
            string streetName = "Nom de la rue",
            string country = "Nom du pays",
            string city = "Nom de la ville",
            string phoneNumber = "06050500"
            )
        {
            return new AddressCreateDTO(postalCode, streetNumber, streetName, country, city, phoneNumber);
        }

        [Fact]
        public void Should_have_error_when_PostalCode_is_empty()
        {
            var model = GetModel(postalCode: 0);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode)
                  .WithErrorMessage("Code postal requis");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100000)]
        public void Should_have_error_when_PostalCode_is_out_of_range(int postalCode)
        {
            var model = GetModel(postalCode: postalCode);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode)
                  .WithErrorMessage("Le code postal doit être compris entre 1 et 99999");
        }

        [Fact]
        public void Should_not_have_error_when_PostalCode_is_valid()
        {
            var model = GetModel(postalCode: 12345);
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.PostalCode);
        }

        [Fact]
        public void Should_have_error_when_StreetNumber_is_empty()
        {
            var model = GetModel(streetNumber: 0);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.StreetNumber)
                  .WithErrorMessage("Numéro de rue requis");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9402)]
        public void Should_have_error_when_StreetNumber_is_out_of_range(int streetNumber)
        {
            var model = GetModel(streetNumber: streetNumber);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.StreetNumber)
                  .WithErrorMessage("Le numéro de rue doit être compris entre 1 et 9401");
        }

        [Fact]
        public void Should_not_have_error_when_StreetNumber_is_valid()
        {
            var model = GetModel(streetNumber: 123);
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.StreetNumber);
        }

        [Fact]
        public void Should_have_error_when_Country_is_empty()
        {
            var model = GetModel(country: "");
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Country)
                  .WithErrorMessage("Pays requis");
        }

        [Fact]
        public void Should_have_error_when_Country_exceeds_maximum_length()
        {
            string soLong = new string('a', 36);
            var model = GetModel(country: soLong);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Country)
                  .WithErrorMessage("Le pays ne doit pas dépasser 35 caractères");
        }

        [Fact]
        public void Should_not_have_error_when_Country_is_valid()
        {
            var model = GetModel(country: "France");
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Country);
        }

        [Fact]
        public void Should_have_error_when_City_is_empty()
        {
            var model = GetModel(city: "");
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.City)
                  .WithErrorMessage("La ville est requise");
        }

        [Fact]
        public void Should_have_error_when_City_exceeds_maximum_length()
        {
            string sooLong = new string('a', 86);
            var model = GetModel(city: sooLong);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.City)
                  .WithErrorMessage("La ville ne doit pas dépasser 85 caractères");
        }

        [Fact]
        public void Should_not_have_error_when_City_is_valid()
        {
            var model = GetModel(city: "Paris");
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.City);
        }
    }
}
