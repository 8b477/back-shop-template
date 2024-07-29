using BLL_Shop.DTO.Order.Update;
using BLL_Shop.Enum;

using FluentValidation;


namespace BLL_Shop.Validators.Order_Validator
{
    public class OrderUpdateStatusValidator : AbstractValidator<OrderStatusUpdateDTO>
    {
        public OrderUpdateStatusValidator()
        {
            RuleFor(o => o.Status)
                .NotEmpty().WithMessage("Le statut est requis.")
                .Length(2, 50).WithMessage("Le statut doit contenir entre 2 et 50 caractères.")
                .IsEnumName(typeof(OrderStatusEnum), caseSensitive: true).WithMessage("Le statut doit être 'Pending', 'InProgress' ou 'Sent' (Respecter les majuscule)"); ;
        }
    }
}
