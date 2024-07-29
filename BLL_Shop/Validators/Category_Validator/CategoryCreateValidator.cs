using BLL_Shop.DTO.Category.Create;

using FluentValidation;


namespace BLL_Shop.Validators.Category_Validator
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(50).WithMessage("Le nom doit contenir au maximum 50 charactères")
                .NotEmpty().WithMessage("Le nom est requis");
        }
    }
}
