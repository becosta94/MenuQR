using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderQR.Services.Services.Factories
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
        public object Make(CustomerDTO customerDTO, int companyId)
        {
            customerDTO.Document = customerDTO.Document.Replace("-", "").Replace(".","");
            Customer? exitingcustomer = _customerBaseService.Get().Where(x => x.Document == customerDTO.Document).FirstOrDefault();
            if (exitingcustomer is not null)
                return new ErroDTO("Número de CPF já cadastrado");
            else if (!_cpfValidatorService.Validate(customerDTO.Document))
                return new ErroDTO("CPF inválido");
            Customer? newCustomer = _validator.Execute(() => _customerBaseService.Add<CustomerValidator>(_mapper.Map<Customer>(customerDTO), companyId, customerDTO.Document)) as Customer;
            if (newCustomer is null)
                return null;
            return newCustomer;
        }
    }
}
