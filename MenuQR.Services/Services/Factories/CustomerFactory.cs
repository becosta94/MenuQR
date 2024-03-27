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
        private readonly ICpfValidatorService _cpfValidatorService;
        public CustomerFactory(IBaseService<Customer> customerBaseService, IMapper mapper, IValidator validator, ICpfValidatorService cpfValidatorService)
        {
            _customerBaseService = customerBaseService;
            _mapper = mapper;
            _validator = validator;
            _cpfValidatorService = cpfValidatorService;
        }
        public object Make(CustomerDTO customerDTO)
        {
            Customer? exitingcustomer = _customerBaseService.Get().Where(x => x.Document == customerDTO.Document).FirstOrDefault();
            if (exitingcustomer is not null)
                return new ErroDTO("Número de CPF já cadastrado");
            else if (!_cpfValidatorService.Validate(customerDTO.Document))
                return new ErroDTO("CPF inválido");
            Customer? newCustomer = _validator.Execute(() => _customerBaseService.Add<CustomerValidator>(_mapper.Map<Customer>(customerDTO))) as Customer;
            if (newCustomer is null)
                return null;
            return newCustomer;
        }
    }
}
