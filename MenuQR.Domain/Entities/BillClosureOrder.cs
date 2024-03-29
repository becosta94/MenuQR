namespace MenuQR.Domain.Entities
{
    public class BillClosureOrder : BaseEntityCompanyId
    {
        public int TableId { get; set; }
        public bool CloseTotal { get; set; }
        public bool OrderCompleted { get; set; }
        public string CustumerDocument { get; set; }
        public double Value { get; set; }
    }
}
