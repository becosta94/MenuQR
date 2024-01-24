using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQR.Services.Services.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly IBaseService<Customer> _customerBaseService;
        private readonly IMapper _mapper;
        private readonly IValidator _validator;
        private readonly ICustomerHistoryFactory _customerHistoryFactory;
        public CustomerFactory(IBaseService<Customer> customerBaseService, IMapper mapper, IValidator validator, ICustomerHistoryFactory customerHistoryFactory)
        {
            _customerBaseService=customerBaseService;
            _mapper=mapper;
            _validator=validator;
            _customerHistoryFactory=customerHistoryFactory;
        }
        public Customer Make(CustomerDTO customerDTO)
        {
            Customer? exitingcustomer = _customerBaseService.Get().Where(x => x.Document == customerDTO.Document).FirstOrDefault();
            if (exitingcustomer is not null)
                return null;
            Customer? newCustomer = _validator.Execute(() => _customerBaseService.Add<CustomerValidator>(_mapper.Map<Customer>(customerDTO))) as Customer;
            if (newCustomer is null)
                return null;
            CustomerHistory? customerHistory = _customerHistoryFactory.Make(newCustomer);
            if (customerHistory is null)
                return null;
            return newCustomer;
        }
    }
}
