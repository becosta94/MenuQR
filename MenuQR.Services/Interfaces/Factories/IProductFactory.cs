using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IProductFactory
    {
        public Product Make(ProductDTO productDTO);
    }
}
