using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdatePromoValidator : AbstractValidator<ArticlePromoUpdateDTO>
    {
        public ArticleUpdatePromoValidator()
        {
            RuleFor(a => a.Promo)
                .NotNull().WithMessage("La valeur de promotion est requise.");
        }
    }
}
