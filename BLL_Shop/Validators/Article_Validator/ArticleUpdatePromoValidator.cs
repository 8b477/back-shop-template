using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdatePromoValidator : AbstractValidator<ArticlePromoUpdateDTO>
    {
        public ArticleUpdatePromoValidator()
        {
            RuleFor(a => a.Promo)
                .NotEmpty().WithMessage("La valeur de promotion est requise.")
                .Must(value => value == true || value == false).WithMessage("Le champ 'promo' l'article, valeur attendu : 'false' ou 'true'");
        }
    }
}
