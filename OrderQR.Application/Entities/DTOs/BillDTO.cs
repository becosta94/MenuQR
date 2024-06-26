﻿namespace OrderQR.Application.Entities.DTOs
{
    public class BillDTO : BaseDTOCompanyId
    {
        public ICollection<OrderProductDTO> OrderProducts { get; set; } = null!;
        public List<ProductOffListDTO> ProductOffLists { get; set; } = null!;
        public double Total { get; set; }
        public int TableId { get; set; }
        public virtual TableDTO Table { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool Open { get; set; }
    }
}
