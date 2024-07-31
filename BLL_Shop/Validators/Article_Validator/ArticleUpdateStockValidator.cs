using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdateStockValidator : AbstractValidator<ArticleStockUpdateDTO>
    {
        public ArticleUpdateStockValidator()
        {
            RuleFor(a => a.Stock)
                .NotEmpty().WithMessage("Le nombre d'articles en stock est requis.")
                .InclusiveBetween(0, 10000).WithMessage("Le stock doit être compris entre 0 et 10 000.");
        }
    }
}
