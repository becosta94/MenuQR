using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class BillDTO : BaseEntityCompanyId
    {
        public ICollection<OrderProductDTO> OrderProducts { get; set; } = null!;
        public double Total { get; set; }
        public int TableId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public virtual TableDTO Table { get; set; }
        public bool Open { get; set; }
    }
}
