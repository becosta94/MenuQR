using OrderQR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface ICustomerHistoryFactory
    {
        public CustomerHistory Make(Customer customer, int companyId);
    }
}
