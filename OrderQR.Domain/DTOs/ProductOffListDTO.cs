using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class ProductOffListDTO : BaseEntityCompanyId
    {
        public int Amount { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string CustomerDocument { get; set; }
        public int BillId { get; set; }
        public int BillCompanyId { get; set; }
        
    }
}
