
namespace OrderQR.Application.Entities.DTOs
{
    public class OrderProductCreateDTO : BaseDTOCompanyId
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public ProductDTO Product { get; set; }
    }
}
