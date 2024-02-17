using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class OrderProductDTO : BaseEntity
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }
    }
}
