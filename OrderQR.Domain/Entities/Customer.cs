namespace OrderQR.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public Customer() 
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
