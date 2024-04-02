namespace MenuQR.Domain.Entities
{
    public class OrderProduct : BaseEntityCompanyId
    {
        public int OrderId { get; set; }
        public int OrderCompanyId { get; set; }
        public int ProductId { get; set; }
        public int ProductCompanyId { get; set; }
        public int BillId { get; set; }
        public int BillCompanyId { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Bill Bill { get; set; } = null!;

        public OrderProduct()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
