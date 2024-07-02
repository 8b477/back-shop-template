using API_Shop.Models;
using FluentValidation;


namespace API_Shop.Validators.Address_Validator.AddressValidator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.IdUser)
                .NotEmpty().WithMessage("ID utilisateur requis");

            RuleFor(a => a.PostalCode)
                .NotEmpty().WithMessage("Code postal requis")
                .InclusiveBetween(1, 99999).WithMessage("Le code postal doit être compris entre 1 et 99999");

            RuleFor(a => a.StreetNumber)
                .NotEmpty().WithMessage("Numéro de rue requis")
                .InclusiveBetween(1, 9401).WithMessage("Le numéro de rue doit être compris entre 1 et 9401");

            RuleFor(a => a.Country)
                .NotEmpty().WithMessage("Pays requis")
                .MaximumLength(35).WithMessage("Le pays ne doit pas dépasser 35 caractères");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("La ville est requise")
                .MaximumLength(85).WithMessage("La ville ne doit pas dépasser 85 caractères");
        }
    }
}
