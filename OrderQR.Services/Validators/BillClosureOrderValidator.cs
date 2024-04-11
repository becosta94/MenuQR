using FluentValidation;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Validators
{
    public class BillClosureOrderValidator : AbstractValidator<BillClosureOrder>
    {
        public BillClosureOrderValidator()
        {

        }
    }
}
