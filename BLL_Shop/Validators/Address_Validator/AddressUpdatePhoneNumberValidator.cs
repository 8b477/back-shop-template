using BLL_Shop.DTO.Address.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Address_Validator
{
    public class AddressUpdatePhoneNumberValidator : AbstractValidator<AddressPhoneNumberUpdateDTO>
    {
        public AddressUpdatePhoneNumberValidator()
        {
            RuleFor(a => a.PhoneNumber)
                .NotEmpty().WithMessage("Numéro de téléphone requis")
                .MaximumLength(20).WithMessage("Numéro de téléphone invalide, il ne peut pas contenir plus de 20 caractères");
        }
    }
}
