﻿namespace OrderQR.Domain.Entities
{
    public class CustomerHistory : BaseEntityCompanyId
    {
        public string CustomerDocument { get; set; }
        public bool OnPlace { get; set; }
        public int BillId { get; set; }
        public int BillCompanyId { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public CustomerHistory()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
