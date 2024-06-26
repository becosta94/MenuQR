﻿namespace OrderQR.Application.Entities.DTOs
{
    public class OrderDTO : BaseDTOCompanyId
    {
        public bool Deliverd { get; set; }
        public string CustomerDocument { get; set; }
        public DateTime DeliveryTime { get; set; }
        public TableDTO? Table { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public List<OrderProductDTO> Products { get; set; }
    }
}
