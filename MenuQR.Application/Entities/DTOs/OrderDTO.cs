using Newtonsoft.Json;

namespace MenuQR.Application.Entities.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public TableDTO? TableDTO { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
    }
}
