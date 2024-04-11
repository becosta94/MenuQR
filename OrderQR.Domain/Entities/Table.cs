using OrderQR.Domain.Entities;

namespace OrderQR.Domain.Entities
{
    public class Table : BaseEntityCompanyId
    {
        public Guid Unique {  get; set; }
        public string Identification { get; set; }
        public string Link { get; set; }

        public Table() 
        {
            //CreatedAt = DateTime.Now;
        }

        public Table(string identification, int companyId)
        {
            Identification = identification;
            CompanyId = companyId;
            Unique = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
