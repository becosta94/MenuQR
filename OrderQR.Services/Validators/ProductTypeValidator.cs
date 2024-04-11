using FluentValidation;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Validators
{
    public class ProductTypeValidator : AbstractValidator<ProductType>
    {
        public ProductTypeValidator()
        {
            RuleFor(c => c.TypeName)
                .NotNull().WithMessage("Por favor insira um nome.");

            RuleFor(c => c.CompanyId)
                .NotNull().WithMessage("Por favor insira a empresa do tipo.");
        }
    }
}
