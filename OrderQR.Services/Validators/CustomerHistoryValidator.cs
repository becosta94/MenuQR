using FluentValidation;
using OrderQR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderQR.Services.Validators
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
