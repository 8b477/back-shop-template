using BLL_Shop.DTO.Article.Create;

using FluentValidation;


namespace BLL_Shop.Validators.Article_Validator
{
    public class ArticleCreateValidator : AbstractValidator<ArticleCreateDTO>
    {
        public ArticleCreateValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Nom de l'article requis.")
                .MinimumLength(1).WithMessage("Le nom doit contenir au minimum 1 caractère")
                .MaximumLength(50).WithMessage("Le nom doit contenir au maximum 50 caractères");

            RuleFor(a => a.Stock)
                .NotEmpty().WithMessage("Le nombre d'articles en stock est requis.")
                .InclusiveBetween(0, 10000).WithMessage("Le stock doit être compris entre 0 et 10 000.");

            RuleFor(a => a.Promo)
                .NotEmpty().WithMessage("La valeur de promotion est requise.")
                .Must(value => value == true || value == false).WithMessage("Le champ 'promo' l'article, valeur attendu : 'false' ou 'true'");

            RuleFor(a => a.Price)
                .NotEmpty().WithMessage("Le prix de l'article est requis.")
                .InclusiveBetween(0, 200).WithMessage("Le prix de l'article doit être compris entre les valeurs 0 et 200.");

            RuleFor(a => a.Categories)
                .NotEmpty().WithMessage("Le champ 'categories' est requis, exemple de valeur attendu [1,5], l'exemple ajoute la catégorie 1 et 5 à l'article.")
                .Must(categories => categories != null && categories.Count != 0)
                .WithMessage("Un article doit appartenir au minimum à une catégorie.");
        }
    }
}
