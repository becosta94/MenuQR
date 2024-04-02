using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Table : BaseEntityCompanyId
    {
        public Guid Unique {  get; set; }
        public string Identification { get; set; }
        public string QRLink { get; set; }

        public Table() { }

        public Table(string identification, int companyId)
        {
            Identification = identification;
            CompanyId = companyId;
            Unique = Guid.NewGuid();
        }
    }
}
