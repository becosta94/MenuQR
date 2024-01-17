using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<Product> Products { get; set; }
        public bool Deliverd { get; set; }
        public Order(int companyId)
        {
            CompanyId = companyId;
            Deliverd = false;
        }
    }
}
