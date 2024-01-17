using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product(string name, double price, int companyId, int orderId)
        {
            Name = name;
            Price = price;
            CompanyId = companyId;
            OrderId = orderId;
        }
    }
}
