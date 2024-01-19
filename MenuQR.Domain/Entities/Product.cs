using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public Product() { }
        public Product(string name, double price, int companyId)
        {
            Name = name;
            Price = price;
            CompanyId = companyId;
        }
    }
}
