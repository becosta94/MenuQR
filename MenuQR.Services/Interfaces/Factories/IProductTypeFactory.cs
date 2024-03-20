using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IProductTypeFactory
    {
        public ProductType Make(ProductTypeDTO productTypeDTO);
    }
}
