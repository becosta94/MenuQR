using MenuQR.Domain.Entities;

namespace MenuQR.Application.Entities.DTOs
{
    public class BillClosureOrderDTO : BaseDTOCompanyId
    {
        public int TableId { get; set; }
        public int CompanyId { get; set; }
        public bool CloseTotal { get; set; }
        public bool OrderCompleted { get; set; }
        public string CustumerDocument { get; set; }
        public double Value { get; set; }
        public virtual Table Table { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
