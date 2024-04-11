namespace OrderQR.Domain.Entities
{
    public class ProductType : BaseEntityCompanyId
    {
        public string TypeName { get; set; }

        public ProductType()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
