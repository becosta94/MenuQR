using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
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

        public Product Make(ProductDTO productDTO)
        {
            Product? product = _mapper.Map<Product>(productDTO);
            product = _validator.Execute(() => _productBaseService.Add<ProductValidator>(product)) as Product;
            if (product is not null)
                return product;
            return null;
        }
    }
}
