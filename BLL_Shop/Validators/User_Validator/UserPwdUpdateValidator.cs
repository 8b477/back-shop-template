using BLL_Shop.DTO.User.Update;
using FluentValidation;

namespace BLL_Shop.Validators.User_Validator
{
    public class UserPwdUpdateValidator : AbstractValidator<UserPwdUpdateDTO>
    {
        public UserPwdUpdateValidator()
        {
            RuleFor(u => u.Pwd)
                .NotEmpty().WithMessage("Mot de passe requis")
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$")
                .WithMessage("8 caractères minimum, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial");

            RuleFor(u => u.PwdConfirm)
                .NotEmpty().WithMessage("Confirmation du mot de passe requise")
                .Equal(u => u.Pwd).WithMessage("Le champ mot de passe et celui de la confirmation du mot de passe ne correspondent pas !");
        }
    }
}
