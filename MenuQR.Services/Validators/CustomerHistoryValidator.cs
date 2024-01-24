using FluentValidation;
using MenuQR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQR.Services.Validators
{
    public class CustomerHistoryValidator : AbstractValidator<CustomerHistory>
    {
        public CustomerHistoryValidator()
        {

            RuleFor(c => c.CompanyId)
                .NotNull().WithMessage("Por favor insira a empresa do pedido.");
        }
    }
}
