﻿using FluentValidation;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Validators
{
    public class OrderProductValidator : AbstractValidator<OrderProduct>
    {
        public OrderProductValidator()
        {
            RuleFor(c => c.ProductId)
                .NotNull().WithMessage("Por favor insira um produto.");

            RuleFor(c => c.OrderId)
                .NotNull().WithMessage("Por favor insira a empresa do pedido.");
        }
    }
}
