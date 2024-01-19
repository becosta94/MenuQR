using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces
{
    public interface INewOrderProductFactory
    {
        public ICollection<OrderProduct>? Make(Order order, ICollection<OrderProductDTO> listOrderProductReceived);
    }
}
