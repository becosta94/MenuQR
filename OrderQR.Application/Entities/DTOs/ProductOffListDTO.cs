namespace OrderQR.Application.Entities.DTOs
{
    public class ProductOffListDTO : BaseDTOCompanyId
    {
        public int Amount { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public string CustomerDocument { get; set; }
        public int BillId { get; set; }
        public int BillCompanyId { get; set; }
    }
}
