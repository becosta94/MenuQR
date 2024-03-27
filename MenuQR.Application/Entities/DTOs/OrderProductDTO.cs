namespace MenuQR.Application.Entities.DTOs
{
    public class OrderProductDTO : BaseDTOCompanyId
    {
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public ProductDTO Product { get; set; }
    }
}
