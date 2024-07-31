using BLL_Shop.DTO.Address.Update;
using FluentValidation;


namespace BLL_Shop.Validators.Address_Validator
{
    public class AddressUpdateValidator : AbstractValidator<AddressCountryUpdateDTO>
    {
        public AddressUpdateValidator()
        {

            RuleFor(a => a.Country)
                .NotEmpty().WithMessage("Pays requis")
                .MinimumLength(1).WithMessage("Pays incorrect, celle-ci doit contenir au moins 1 caractère")
                .MaximumLength(50).WithMessage("Pays incorrect, celle-ci doit contenir moins de 50 caractères");


            RuleFor(a => a.PostalCode)
                .NotEmpty().WithMessage("Code postal requis")
                .MinimumLength(1).WithMessage("Code postal incorrect, il doit contenir au moins 1 caractère")
                .MaximumLength(20).WithMessage("Code postal incorrect, il doit contenir moins de 20 caractères");


            RuleFor(a => a.StreetNumber)
                .NotEmpty().WithMessage("Numéro de rue requis")
                .MinimumLength(1).WithMessage("Numéro de rue incorrect, il doit contenir au moins 1 caractère")
                .MaximumLength(20).WithMessage("Numéro de rue incorrect, il doit contenir moins de 20 caractères");


            RuleFor(a => a.StreetName)
                .NotEmpty().WithMessage("Nom de la rue requis")
                .MinimumLength(1).WithMessage("Nom de la rue incorrect, celle-ci doit contenir au moins 1 caractère")
                .MaximumLength(50).WithMessage("Nom de la rue incorrect, celle-ci doit contenir moins de 50 caractères");


            RuleFor(a => a.City)
                .NotEmpty().WithMessage("La ville est requise")
                .MinimumLength(1).WithMessage("La ville incorrect, celle-ci doit contenir au moins 1 caractère")
                .MaximumLength(50).WithMessage("La ville incorrect, celle-ci doit contenir moins de 50 caractères");
        }
    }
}
