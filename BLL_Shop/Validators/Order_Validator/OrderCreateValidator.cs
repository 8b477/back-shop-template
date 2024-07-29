using BLL_Shop.DTO.Order.Create;

using FluentValidation;


namespace BLL_Shop.Validators.Order_Validator
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDTO>
    {
        public OrderCreateValidator()
        {
            RuleFor(o => o.Status)
                .NotEmpty().WithMessage("Le statut est requis.")
                .Length(2, 50).WithMessage("Le statut doit contenir entre 2 et 50 caractères.");

            RuleFor(o => o.ArticleIds)
                .NotEmpty().WithMessage("Au moins une catégorie est requise.")
                .Must(categories => categories != null && categories.Count != 0).WithMessage("La commande doit contenir au moins un article.");
        }

    }
}
