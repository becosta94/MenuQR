namespace MenuQR.Domain.Entities
{
    public class OrderProduct : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Bill Bill { get; set; } = null!;
    }
}
