using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class CompanyDTO: BaseEntity
    {
        public string Name { get; set; }
        public string Banner { get; set; }
    }
}
