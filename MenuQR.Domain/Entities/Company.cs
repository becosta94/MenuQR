namespace MenuQR.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string ResponsibleName { get; set; }
    }
}
