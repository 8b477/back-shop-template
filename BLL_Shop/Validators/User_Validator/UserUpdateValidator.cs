using BLL_Shop.DTO.User.Update;
using FluentValidation;

namespace BLL_Shop.Validators.User_Validator
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(u => u.Pseudo)
                .NotEmpty().WithMessage("Pseudo requis")
                .MinimumLength(2).WithMessage("Le champ pseudo doit contenir au minimum 2 caractères")
                .MaximumLength(50).WithMessage("Le champ pseudo doit contenir au maximum 50 caractères");

            RuleFor(u => u.Mail)
                .NotEmpty().WithMessage("Mail requis")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("L'adresse mail renseignée n'est pas valide");

            RuleFor(u => u.Mdp)
                .NotEmpty().WithMessage("Mot de passe requis")
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$")
                .WithMessage("8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial");

            RuleFor(u => u.MdpConfirm)
                .NotEmpty().WithMessage("Confirmation du mot de passe requise")
                .Equal(u => u.Mdp).WithMessage("Le champ mot de passe et celui de la confirmation du mot de passe ne correspondent pas !");
        }
    }
}
