using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface IProductFactory
    {
        public Product Make(ProductDTO productDTO);
    }
}
