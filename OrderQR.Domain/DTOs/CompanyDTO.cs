using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class CompanyDTO: BaseEntity
    {
        public string Name { get; set; }
        public string Banner { get; set; }
    }
}
