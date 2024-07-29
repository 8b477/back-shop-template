using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdateNameValidator : AbstractValidator<ArticleNameUpdateDTO>
    {
        public ArticleUpdateNameValidator()
        {
            RuleFor(a => a.Name)
               .NotEmpty().WithMessage("Le nom est requis.")
               .Length(1, 50).WithMessage("Le nom doit contenir entre 1 et 50 caractères.");
        }
    }
}
