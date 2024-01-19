namespace MenuQR.Domain.Entities
{
    public class Order : BaseEntity
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public int TableId { get; set; }
        public int CostumerId { get; set; }
        public virtual Table Table { get; set; }
        public virtual Costumer Costumer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Order() { }
        public Order(Table table, Costumer costumer)
        {
            Date = DateTime.Now;
            Deliverd = false;
            Table = table;
            Costumer = costumer;
        }
    }
}
