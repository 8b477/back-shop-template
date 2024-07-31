using BLL_Shop.DTO.Category.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Category_Validator
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(1).WithMessage("Le nom de la catégorie doit contenir au maximum 1 caractères")
                .MaximumLength(50).WithMessage("Le nom de la catégorie doit contenir au maximum 50 caractères")
                .NotEmpty().WithMessage("Le nom est requis");
        }
    }
}
