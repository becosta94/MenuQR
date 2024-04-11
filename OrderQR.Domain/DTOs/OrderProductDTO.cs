using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class OrderProductDTO : OrderProductCreateDTO
    {

        public OrderDTO Order { get; set; }
    }
}
