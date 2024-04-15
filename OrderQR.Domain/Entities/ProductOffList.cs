using System;

namespace OrderQR.Domain.Entities
{
    public class ProductOffList : BaseEntityCompanyId
    {
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public int BillId { get; set; }
        public int BillCompanyId { get; set; }
        public string CustomerDocument { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Bill Bill { get; set; }

        public ProductOffList()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
