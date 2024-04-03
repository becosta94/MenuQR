namespace MenuQR.Domain.Entities
{
    public class BillClosureOrder : BaseEntityCompanyId
    {
        public int TableId { get; set; }
        public int TableCompanyId { get; set; }
        public bool CloseTotal { get; set; }
        public bool OrderCompleted { get; set; }
        public string CustomerDocument { get; set; }
        public double Value { get; set; }
        public virtual Table Table { get; set; }
        public virtual Customer Customer { get; set; }

        public BillClosureOrder()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
