using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IOrderProductFactory
    {
        public ICollection<OrderProduct>? Make(Order order, ICollection<OrderProductCreateDTO> listOrderProductReceived);
    }
}
