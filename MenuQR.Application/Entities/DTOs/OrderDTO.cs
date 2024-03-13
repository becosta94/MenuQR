using Newtonsoft.Json;

namespace MenuQR.Application.Entities.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public TableDTO? Table { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public List<OrderProductDTO> Products { get; set; }
    }
}
