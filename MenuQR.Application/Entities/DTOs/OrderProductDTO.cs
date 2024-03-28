namespace MenuQR.Application.Entities.DTOs
{
    public class OrderProductDTO : OrderProductCreateDTO
    {
        public OrderDTO Order { get; set; }
    }
}
