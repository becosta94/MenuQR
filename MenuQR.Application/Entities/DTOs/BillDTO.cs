namespace MenuQR.Application.Entities.DTOs
{
    public class BillDTO : BaseDTO
    {
        private Dictionary<CustomerDTO, double> _customersAndTotals;
        public double Total { get; set; }
        public int TableId { get; set; }
        public virtual TableDTO Table { get; set; }
        public bool Open { get; set; }
    }
}
