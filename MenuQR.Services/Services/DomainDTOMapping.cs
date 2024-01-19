using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Services
{
    public class DomainDTOMapping : Profile
    {
        public DomainDTOMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();
        }
    }
}
