using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;

namespace OrderQR.Services.Services.Factories
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

        public ProductType Make(ProductTypeDTO productTypeDTO, string userId)
        {
            ProductType? product = _mapper.Map<ProductType>(productTypeDTO);
            product = _validator.Execute(() => _productTypeBaseService.Add<ProductTypeValidator>(product, product.CompanyId, userId)) as ProductType;
            if (product is not null)
                return product;
            return null;
        }
    }
}
