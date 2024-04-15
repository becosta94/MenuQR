using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface IProductTypeFactory
    {
        public ProductType Make(ProductTypeDTO productTypeDTO, string userId);
    }
}
