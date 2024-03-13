using MenuQR.Domain.Entities;
using Newtonsoft.Json;

namespace MenuQR.Domain.DTOs
{
    public class OrderDTO : BaseEntity
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public TableDTO? Table { get; set; }
        public Customer Customer { get; set; }
        public List<OrderProductDTO> Products { get; set; }
    }
}
