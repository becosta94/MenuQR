using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Bill : BaseEntityCompanyId
    {
        private Dictionary<Customer, double> _customersAndTotals;
        public double Total { get; private set; }
        public int TableId { get; set; }
        public int TableCompanyId { get; set; }
        public virtual Table Table { get; set; }
        public bool Open { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = null!;

        public Bill()
        {
            Open = true;
            _customersAndTotals = new Dictionary<Customer, double>();
        }
        public Bill(Bill bill)
        {
            Total = bill.Total;
            TableId = bill.TableId;
            TableCompanyId = bill.TableCompanyId;
            Open = bill.Open;
            CompanyId = bill.CompanyId;
            Id = bill.Id;
        }

        public void AddNewCustomerTotal(Customer customer, double total)
        {
            _customersAndTotals.Add(customer, total);
        }

        public void SumTotal()
        {
            Total = _customersAndTotals.Sum(x => x.Value);
        }
    }
}
