using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class OrderProductCreateDTO : BaseEntityCompanyId
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public ProductDTO Product { get; set; }
    }
}
