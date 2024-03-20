using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public int TypeId { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Product()
        {
            Active = true;
        }
    }
}
