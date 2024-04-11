using OrderQR.Domain.Entities;

namespace OrderQR.Domain.DTOs
{
    public class ProductTypeDTO : BaseEntityCompanyId
    {
        public string TypeName { get; set; }
    }
}
