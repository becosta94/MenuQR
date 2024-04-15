using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface IOrderProductFactory
    {
        public ICollection<OrderProduct>? Make(Order order, ICollection<OrderProductCreateDTO> listOrderProductReceived, string userId);
    }
}
