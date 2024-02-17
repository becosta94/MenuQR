using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class OrderDTO : BaseEntity
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public Table? Table { get; set; }
        public Customer Customer { get; set; }
    }
}
