using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
{
    public class ProductTypeFactory : IProductTypeFactory
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<ProductType> _productTypeBaseService;
        private readonly IValidator _validator;

        public ProductTypeFactory(IMapper mapper, IBaseService<ProductType> productTypeBaseService, IValidator validator)
        {
            _mapper = mapper;
            _productTypeBaseService = productTypeBaseService;
            _validator = validator;
        }

        public ProductType Make(ProductTypeDTO productTypeDTO)
        {
            ProductType? product = _mapper.Map<ProductType>(productTypeDTO);
            product = _validator.Execute(() => _productTypeBaseService.Add<ProductTypeValidator>(product)) as ProductType;
            if (product is not null)
                return product;
            return null;
        }
    }
}
