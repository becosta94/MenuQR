using AutoMapper;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
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
        public CustomerHistory Make(Customer customer)
        {
            CustomerHistory? customerHistory = new CustomerHistory();
            customerHistory.Customer = customer;
            customerHistory.CustomerId = customer.Id;
            customerHistory.OnPlace = true;
            customerHistory = _validator.Execute(() => _customerHistoryBaseService.Add<CustomerHistoryValidator>(customerHistory)) as CustomerHistory;
            if (customerHistory is not null)
                return customerHistory;
            return null;           
        }
    }
}
