using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class TableDTO : BaseEntityCompanyId
    {
        public string Identification { get; set; }
        public Guid Unique {  get; set; }
        public string Link { get; set; }
    }
}
