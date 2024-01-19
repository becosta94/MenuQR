namespace MenuQR.Domain.Entities
{
    public class Order : BaseEntity
    {
        public bool Deliverd { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Order()
        {
            Date = DateTime.Now;
            Deliverd = false;
        }
    }
}
