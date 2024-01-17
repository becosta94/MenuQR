using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Bill : BaseEntity
    {
        public double Total { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }

        public Bill(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
