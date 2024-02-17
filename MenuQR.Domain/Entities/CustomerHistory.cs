namespace MenuQR.Domain.Entities
{
    public class CustomerHistory : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public bool OnPlace { get; set; }
    }
}
