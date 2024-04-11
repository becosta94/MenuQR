using AutoMapper;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;

namespace OrderQR.Services.Services.Factories
{
    public class CustomerHistoryFactory : ICustomerHistoryFactory
    {
        private readonly IBaseService<CustomerHistory> _customerHistoryBaseService;
        private readonly IValidator _validator;
        public CustomerHistoryFactory(IBaseService<CustomerHistory> customerHistoryBaseService, IValidator validator)
        {
            _customerHistoryBaseService = customerHistoryBaseService;
            _validator = validator;
        }
        public CustomerHistory Make(Customer customer, int companyId)
        {
            CustomerHistory? customerHistory = new CustomerHistory();
            customerHistory.CustomerDocument = customer.Document;
            customerHistory.CompanyId = companyId;
            customerHistory.OnPlace = true;
            customerHistory = _validator.Execute(() => _customerHistoryBaseService.Add<CustomerHistoryValidator>(customerHistory)) as CustomerHistory;
            if (customerHistory is not null)
                return customerHistory;
            return null;           
        }
    }
}
