using MenuQR.Domain.Entities;

namespace MenuQR.Domain.DTOs
{
    public class ProductTypeDTO : BaseEntityCompanyId
    {
        public string TypeName { get; set; }
    }
}
