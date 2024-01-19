using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Services
{
    public class DomainDTOMapping : Profile
    {
        public DomainDTOMapping()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();
        }
    }
}
