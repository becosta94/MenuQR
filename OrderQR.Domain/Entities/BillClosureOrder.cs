namespace OrderQR.Domain.Entities
{
    public class BillClosureOrder : BaseEntityCompanyId
    {
        public int TableId { get; set; }
        public int TableCompanyId { get; set; }
        public int BillId { get; set; }
        public int BillCompanyId { get; set; }
        public bool CloseTotal { get; set; }
        public bool OrderCompleted { get; set; }
        public string CustomerDocument { get; set; }
        public double Value { get; set; }
        public bool Tips { get; set; }
        public virtual Table Table { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Bill Bill { get; set; }

        public BillClosureOrder()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
