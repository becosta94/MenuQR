using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Services
{
    public class DomainDTOMapping : Profile
    {
        public DomainDTOMapping()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Order, OrderDTO>().IncludeMembers(x => x.Table);
            CreateMap<OrderDTO, Order>().IncludeMembers(x => x.Table);
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<Table, TableDTO>();
            CreateMap<TableDTO, Table>();
        }
    }
}
