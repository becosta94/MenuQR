using FluentValidation;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Por favor insira um nome.");
        }
    }
}
