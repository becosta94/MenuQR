using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class BillDTO : BaseEntityCompanyId
    {
        public ICollection<OrderProductDTO> OrderProducts { get; set; } = null!;
        public List<ProductOffList> ProductOffLists { get; set; } = null!;
        public double Total { get; set; }
        public double Profit { get; set; }
        public int TableId { get; set; }
        public DateTime ClosingDate { get; set; }
        public virtual TableDTO Table { get; set; }
        public bool Open { get; set; }
    }
}
