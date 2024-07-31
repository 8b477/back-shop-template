using BLL_Shop.DTO.User.Update;
using FluentValidation;

namespace BLL_Shop.Validators.User_Validator
{
    public class UserMailUpdateValidator : AbstractValidator<UserMailUpdateDTO>
    {
        public UserMailUpdateValidator()
        {
            RuleFor(u => u.Mail)
                .NotEmpty().WithMessage("Mail requis")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("L'adresse mail renseignée n'est pas valide");
        }
    }
}
