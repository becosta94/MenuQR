namespace MenuQR.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual int CompanyId { get; set; }
    }
}
