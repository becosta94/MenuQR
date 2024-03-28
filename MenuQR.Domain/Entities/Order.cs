namespace MenuQR.Domain.Entities
{
    public class Order : BaseEntityCompanyId
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public int? TableId { get; set; }
        public string CustomerDocument { get; set; }
        public int? CustomerHistoryId { get; set; }
        public int? CustomerHistoryCompanyId { get; set; }
        public virtual Table? Table { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerHistory CustomerHistory { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Order() { }
        public Order(int tableId, string customerDocument, int companyId, int customerHistoryId, int? customerCompanyId)
        {
            Date = DateTime.Now;
            Deliverd = false;
            TableId = tableId;
            CompanyId = companyId;
            CustomerDocument = customerDocument;
            CustomerHistoryId = customerHistoryId;
            CustomerHistoryCompanyId=customerCompanyId;
        }
    }
}
