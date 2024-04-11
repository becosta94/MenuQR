using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class OrderDTO : BaseEntityCompanyId
    {
        public bool Deliverd { get; set; }
        public string CustomerDocument { get; set; }
        public DateTime DeliveryTime { get; set; }
        public TableDTO? Table { get; set; }
        public CustomerDTO Customer { get; set; }
        public ICollection<OrderProductDTO> Products { get; set; }
    }
}
