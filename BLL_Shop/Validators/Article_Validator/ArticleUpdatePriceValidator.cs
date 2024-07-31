using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdatePriceValidator : AbstractValidator<ArticlePriceUpdateDTO>
    {
        public ArticleUpdatePriceValidator()
        {
            RuleFor(a => a.Price)
                .NotEmpty().WithMessage("Le prix de l'article est requis.")
                .InclusiveBetween(0, 200).WithMessage("Le prix de l'article doit être compris entre les valeurs 0 et 200.");
        }
    }
}
