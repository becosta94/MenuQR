using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Table : BaseEntity
    {
        public List<Customer> Customers { get; set; }
        public string Identification { get; set; }

        public Table(string identification, int companyId)
        {
            Identification = identification;
            CompanyId = companyId;
        }
    }
}
