using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;

namespace OrderQR.Services.Services.Factories
{
    public class ProductFactory : IProductFactory
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<Product> _productBaseService;
        private readonly IValidator _validator;
        public ProductFactory(IMapper mapper, IBaseService<Product> productBaseService, IValidator validator)
        {
            _mapper = mapper;
            _productBaseService = productBaseService;
            _validator = validator;
        }
        public Product Make(ProductDTO productDTO, string userId)
        {
            Product? product = _mapper.Map<Product>(productDTO);
            product = _validator.Execute(() => _productBaseService.Add<ProductValidator>(product, product.CompanyId, userId)) as Product;
            if (product is not null)
                return product;
            return null;
        }
    }
}
