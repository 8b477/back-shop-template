using BLL_Shop.DTO.Article.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleUpdateStockValidator : AbstractValidator<ArticleStockUpdateDTO>
    {
        public ArticleUpdateStockValidator()
        {
            RuleFor(a => a.Stock)
                .NotNull().WithMessage("Le stock est requis.")
                .InclusiveBetween(0, 10000).WithMessage("Le stock doit être compris entre 0 et 10000.");
        }
    }
}
