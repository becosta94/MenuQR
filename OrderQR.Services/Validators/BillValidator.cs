using FluentValidation;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Validators
{
    public class BillValidator : AbstractValidator<Bill>
    {
        public BillValidator()
        {
            
        }
    }
}
