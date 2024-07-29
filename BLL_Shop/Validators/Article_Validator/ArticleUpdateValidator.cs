using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdateValidator : AbstractValidator<ArticleUpdateDTO>
    {
        public ArticleUpdateValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Le nom est requis.")
                .Length(1, 50).WithMessage("Le nom doit contenir entre 1 et 50 caractères.");

            RuleFor(a => a.Stock)
                .NotNull().WithMessage("Le stock est requis.")
                .InclusiveBetween(0, 10000).WithMessage("Le stock doit être compris entre 0 et 10000.");

            RuleFor(a => a.Promo)
                .NotNull().WithMessage("La valeur de promotion est requise.");

            RuleFor(a => a.Price)
                .NotNull().WithMessage("Le prix est requis.")
                .InclusiveBetween(0, 200).WithMessage("Le prix doit être compris entre 0 et 200.");

            RuleFor(a => a.Categories)
                .NotEmpty().WithMessage("Au moins une catégorie est requise.")
                .Must(categories => categories != null && categories.Any())
                .WithMessage("L'article doit avoir au moins une catégorie.");
        }
    }
}
