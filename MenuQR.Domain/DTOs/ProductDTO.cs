using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class ProductDTO : BaseEntityCompanyId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductTypeCompanyId { get; set; }
    }
}
