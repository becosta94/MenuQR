using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class OrderProductCreateDTO : BaseEntityCompanyId
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public ProductDTO Product { get; set; }
    }
}
