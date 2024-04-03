using FluentValidation;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Validators
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(c => c.Identification)
                .NotNull().WithMessage("Por favor insira uma identificação.");

            RuleFor(c => c.Link)
                .NotNull().WithMessage("Por favor insira um link.");

        }
    }
}
