using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class BillClosureOrderDTO : BaseEntityCompanyId
    {
        public int TableId { get; set; }
        public int CompanyId { get; set; }
        public bool CloseTotal { get; set; }
        public bool OrderCompleted { get; set; }
        public string CustumerDocument { get; set; }
        public double Value { get; set; }
        public virtual TableDTO Table { get; set; }
        public virtual CustomerDTO Customer { get; set; }
    }
}
