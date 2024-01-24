using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface ICustomerFactory
    {
        public Customer Make(CustomerDTO customerDTO);
    }
}
