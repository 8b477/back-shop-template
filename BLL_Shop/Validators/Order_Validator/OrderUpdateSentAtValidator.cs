﻿using BLL_Shop.DTO.Order.Update;

using FluentValidation;


namespace BLL_Shop.Validators.Order_Validator
{
    public class OrderUpdateSentAtValidator : AbstractValidator<OrderSentAtUpdateDTO>
    {
        public OrderUpdateSentAtValidator()
        {
            RuleFor(o => o.SentAt)
                .NotEmpty().WithMessage("Le champ 'sentAt' est requis");
        }
    }
}
