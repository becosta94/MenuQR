using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class OrderProductDTO : OrderProductCreateDTO
    {

        public OrderDTO Order { get; set; }
    }
}
