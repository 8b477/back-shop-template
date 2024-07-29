using BLL_Shop.DTO.Order.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Order_Validator
{
    public class OrderUpdateStatusAndSentAtValidator : AbstractValidator<OrderStatusAndSentAtUpdateDTO>
    {
        public OrderUpdateStatusAndSentAtValidator()
        {
            RuleFor(o => o.Status)
                .NotEmpty().WithMessage("Le statut est requis.")
                .Length(2, 50).WithMessage("Le statut doit contenir entre 2 et 50 caractères.");

            RuleFor(o => o.SentAt)
                .Must(BeAValidDate).WithMessage("La date d'envoi doit être une date valide et ne pas être dans le passé.");
        }


        private bool BeAValidDate(DateTime date)
        {
            return date >= DateTime.Now;
        }
    }
}
