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
                .NotEmpty().WithMessage("Le champ 'statut' est requis.")
                .MinimumLength(2).WithMessage("Le status doit contenir au minimum 2 caractères")
                .MaximumLength(50).WithMessage("Le status doit contenir au maximum 50 caractères")
                .IsEnumName(typeof(OrderStatusEnum), caseSensitive: false).WithMessage("Le statut doit être une de ces valeurs : 'Pending', 'InProgress' ou 'Sent' (Respecter les majuscule)"); ;
        }
    }
}
