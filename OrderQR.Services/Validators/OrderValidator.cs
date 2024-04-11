using FluentValidation;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            //RuleFor(c => c.Products)
            //    .NotNull().WithMessage("Por favor insira um produto.");

            RuleFor(c => c.CompanyId)
                .NotNull().WithMessage("Por favor insira a empresa do pedido.");
        }
    }
}
