using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IProductOffListFactory
    {
        public ProductOffList Make(ProductOffListDTO productoffListDTO);
    }
}
