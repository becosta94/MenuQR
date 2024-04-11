using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface IProductOffListFactory
    {
        public ProductOffList Make(ProductOffListDTO productoffListDTO);
    }
}
