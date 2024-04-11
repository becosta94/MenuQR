using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class CustomerDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
