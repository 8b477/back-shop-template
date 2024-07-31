using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdateNameValidator : AbstractValidator<ArticleNameUpdateDTO>
    {
        public ArticleUpdateNameValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Nom de l'article requis.")
                .MinimumLength(1).WithMessage("Le nom doit contenir au minimum 1 caractère")
                .MaximumLength(50).WithMessage("Le nom doit contenir au maximum 50 caractères");
        }
    }
}
