using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class CustomerDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
