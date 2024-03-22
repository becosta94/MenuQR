using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Table : BaseEntity
    {
        public string Identification { get; set; }
        public string QRLink { get; set; }

        public Table(string identification, int companyId)
        {
            Identification = identification;
            CompanyId = companyId;
        }
    }
}
