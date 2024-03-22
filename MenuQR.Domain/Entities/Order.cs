namespace MenuQR.Domain.Entities
{
    public class Order : BaseEntity
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public int? TableId { get; set; }
        public string CustomerDocument { get; set; }
        public virtual Table? Table { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Order() { }
        public Order(int tableId, string customerDocument, int companyId)
        {
            Date = DateTime.Now;
            Deliverd = false;
            TableId = tableId;
            CompanyId = companyId;
            CustomerDocument = customerDocument;
        }
    }
}
