using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdatePriceValidator : AbstractValidator<ArticlePriceUpdateDTO>
    {
        public ArticleUpdatePriceValidator()
        {
            RuleFor(a => a.Price)
                .NotNull().WithMessage("Le prix est requis.")
                .InclusiveBetween(0, 200).WithMessage("Le prix doit être compris entre 0 et 200.");
        }
    }
}
