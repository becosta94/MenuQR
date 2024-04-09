using MenuQR.Domain.Entities;

namespace MenuQR.Domain.Entities
{
    public class Bill : BaseEntityCompanyId
    {
        public Dictionary<Customer, double> CustomersAndTotals = new Dictionary<Customer, double>();
        public double Total { get; private set; }
        public int TableId { get; set; }
        public int TableCompanyId { get; set; }
        public bool Open { get; set; }
        public DateTime ClosingDate { get; set; }
        public virtual Table Table { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual List<ProductOffList> ProductOffLists {  get; set; } = null!; 

        public Bill()
        {
            Open = true;
            CustomersAndTotals = new Dictionary<Customer, double>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public Bill(Bill bill)
        {
            Total = bill.Total;
            TableId = bill.TableId;
            TableCompanyId = bill.TableCompanyId;
            Open = bill.Open;
            CompanyId = bill.CompanyId;
            Id = bill.Id;
            Table = new Table() { Id = bill.TableId, CompanyId = bill.TableCompanyId };
            CreatedAt = DateTime.Now;
        }

        public void AddNewCustomerTotal(Customer customer, double total)
        {
            if (CustomersAndTotals.ContainsKey(customer))
                CustomersAndTotals[customer] += total;
            else
                CustomersAndTotals.Add(customer, total);
        }

        public void SumTotal(bool? tips)
        {
            if (tips.HasValue && tips.Value)
                Total = Total + CustomersAndTotals.Sum(x => x.Value) * 1.10;
            else
                Total = Total + CustomersAndTotals.Sum(x => x.Value);

        }
    }
}
