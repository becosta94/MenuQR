using MenuQR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface ICustomerHistoryFactory
    {
        public CustomerHistory Make(Customer customer);
    }
}
