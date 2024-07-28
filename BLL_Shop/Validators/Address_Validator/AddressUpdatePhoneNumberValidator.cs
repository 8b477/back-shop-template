using BLL_Shop.DTO.Address.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Address_Validator
{
    public class AddressUpdatePhoneNumberValidator : AbstractValidator<AddressPhoneNumberUpdateDTO>
    {
        public AddressUpdatePhoneNumberValidator()
        {
            RuleFor(a => a.PhoneNumber)
                .NotEmpty().WithMessage("Numéro de téléphone requis");
        }
    }
}
