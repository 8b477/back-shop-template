using BLL_Shop.DTO.User.Update;


using FluentValidation;

namespace BLL_Shop.Validators.User_Validator
{
    public class UserPseudoUpdateValidator : AbstractValidator<UserPseudoUpdateDTO>
    {
        public UserPseudoUpdateValidator()
        {
            RuleFor(u => u.Pseudo)
                    .NotEmpty().WithMessage("Pseudo requis")
                    .MinimumLength(2).WithMessage("Pseudo doit contenir au minimum 2 caractères")
                    .MaximumLength(50).WithMessage("Pseudo doit contenir au maximum 50 caractères");            
        }
    }
}
