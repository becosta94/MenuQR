using FluentValidation;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Price)
                .NotNull().WithMessage("Por favor insira um preço.");            
            
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Por favor insira um nome.");

            RuleFor(c => c.CompanyId)
                .NotNull().WithMessage("Por favor insira a empresa do produto.");
        }
    }
}
