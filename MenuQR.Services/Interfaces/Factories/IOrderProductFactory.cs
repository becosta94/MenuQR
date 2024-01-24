using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IOrderProductFactory
    {
        public ICollection<OrderProduct>? Make(Order order, ICollection<OrderProductDTO> listOrderProductReceived);
    }
}
