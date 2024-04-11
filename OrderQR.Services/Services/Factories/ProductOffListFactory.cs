using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;

namespace OrderQR.Services.Services.Factories
{
    public class ProductOffListFactory : IProductOffListFactory
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<ProductOffList> _productOffListBaseService;
        private readonly IValidator _validator;

        public ProductOffListFactory(IMapper mapper, IBaseService<ProductOffList> productOffListBaseService, IValidator validator)
        {
            _mapper = mapper;
            _productOffListBaseService = productOffListBaseService;
            _validator = validator;
        }

        public ProductOffList Make(ProductOffListDTO productoffListDTO)
        {
            ProductOffList? product = _mapper.Map<ProductOffList>(productoffListDTO);
            product = _validator.Execute(() => _productOffListBaseService.Add<ProductOffListValidator>(product)) as ProductOffList;
            if (product is not null)
                return product;
            return null;
        }
    }
}
