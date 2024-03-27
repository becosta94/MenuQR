using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class OrderProductDTO : BaseEntityCompanyId
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public ProductDTO Product { get; set; }
    }
}
