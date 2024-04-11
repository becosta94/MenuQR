using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface ICustomerFactory
    {
        public object Make(CustomerDTO customerDTO);
    }
}
