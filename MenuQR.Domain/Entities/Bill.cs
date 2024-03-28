using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Bill : BaseEntityCompanyId
    {
        public Dictionary<Customer, double> CustomersAndTotals = new Dictionary<Customer, double>();
        public double Total { get; private set; }
        public int TableId { get; set; }
        public int TableCompanyId { get; set; }
        public virtual Table Table { get; set; }
        public bool Open { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; } = null!;

        public Bill()
        {
            Open = true;
            CustomersAndTotals = new Dictionary<Customer, double>();
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
            CustomersAndTotals.Add(customer, total);
        }

        public void SumTotal()
        {
            Total = Total + CustomersAndTotals.Sum(x => x.Value);
        }
    }
}
