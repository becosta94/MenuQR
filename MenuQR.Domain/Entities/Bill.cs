using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Bill : BaseEntity
    {
        public double Total { get; set; }
        public int TableId { get; set; }
        public int CustomerId { get; set; }

        public Bill(int companyId, int tableId, int customerId)
        {
            CompanyId = companyId;
            TableId = tableId;
            CustomerId = customerId;
        }
    }
}
