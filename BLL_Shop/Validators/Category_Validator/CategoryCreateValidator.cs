using BLL_Shop.DTO.Category.Create;

using FluentValidation;


namespace BLL_Shop.Validators.Category_Validator
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(1).WithMessage("Le nom de la catégorie doit contenir au maximum 1 caractères")
                .MaximumLength(50).WithMessage("Le nom de la catégorie doit contenir au maximum 50 caractères")
                .NotEmpty().WithMessage("Le nom est requis");
        }
    }
}
