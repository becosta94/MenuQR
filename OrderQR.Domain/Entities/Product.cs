using OrderQR.Domain.Entities;

namespace OrderQR.Domain.Entities
{
    public class Product : BaseEntityCompanyId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductTypeCompanyId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Product()
        {
            Active = true;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
