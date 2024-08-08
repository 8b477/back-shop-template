using BLL_Shop.DTO.Order.Create;

using FluentValidation;


namespace BLL_Shop.Validators.Order_Validator
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDTO>
    {
        public OrderCreateValidator()
        {
            RuleFor(o => o.ArticlesId)
                .NotEmpty().WithMessage("Au moins une catégorie est requise.")
                .Must(categories => categories != null && categories.Count != 0).WithMessage("La commande doit contenir au moins un article.");
        }
    }
}
