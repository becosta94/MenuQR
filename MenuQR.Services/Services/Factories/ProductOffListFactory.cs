using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
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
