using BLL_Shop.DTO.Order.Update;
using BLL_Shop.Enum;

using FluentValidation;


namespace BLL_Shop.Validators.Order_Validator
{
    public class OrderUpdateStatusAndSentAtValidator : AbstractValidator<OrderStatusAndSentAtUpdateDTO>
    {
        public OrderUpdateStatusAndSentAtValidator()
        {
            RuleFor(o => o.Status)
                .NotEmpty().WithMessage("Le champ 'statut' doit contenir une valeur.")
                .NotNull().WithMessage("Le champ 'status' ne peut pas être null")
                .Length(2, 50).WithMessage("Le statut doit contenir entre 2 et 50 caractères.")
                .IsEnumName(typeof(OrderStatusEnum), caseSensitive: true).WithMessage("Le statut doit être 'Pending', 'InProgress' ou 'Sent' (Respecter les majuscule).");

            RuleFor(o => o.SentAt)
                .NotNull().WithMessage("Le champ 'sentAt' ne peut pas être null")
                .NotEmpty().WithMessage("Le champ 'sentAt' doit contenir une valeur");
        }
    }
}
