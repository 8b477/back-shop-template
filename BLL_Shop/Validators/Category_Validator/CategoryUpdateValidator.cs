using BLL_Shop.DTO.Category.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Category_Validator
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(c => c.Name)
             .MaximumLength(50).WithMessage("Le nom doit contenir au maximum 50 charactères")
             .NotEmpty().WithMessage("Le nom est requis");
        }
    }
}
