using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class TableDTO : BaseEntity
    {
        public string Identification { get; set; }
        public string QRLink { get; set; }
    }
}
