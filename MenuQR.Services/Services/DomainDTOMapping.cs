using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Services
{
    public class DomainDTOMapping : Profile
    {
        public DomainDTOMapping()
        {
            CreateMap<BillClosureOrder, BillClosureOrderDTO>().ForMember(x => x.Table, opt => opt.MapFrom(y => y.Table)).ForMember(x => x.Customer, opt => opt.MapFrom(y => y.Customer));
            CreateMap<BillClosureOrderDTO, BillClosureOrder>();
            CreateMap<Bill, BillDTO>().ForMember(x => x.Table, opt => opt.MapFrom(y => y.Table));
            CreateMap<BillDTO, Bill>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();            
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<ProductTypeDTO, ProductType>();
            CreateMap<ProductOffList, ProductOffListDTO>();
            CreateMap<ProductOffListDTO, ProductOffList>();
            CreateMap<Order, OrderDTO>().ForMember(x => x.Products, opt => opt.MapFrom(y => y.OrderProducts));
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderProduct, OrderProductDTO>().ForMember(x => x.Product, opt => opt.MapFrom(y => y.Product));
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<OrderProduct, OrderProductCreateDTO>().ForMember(x => x.Product, opt => opt.MapFrom(y => y.Product));
            CreateMap<OrderProductCreateDTO, OrderProduct>();
            CreateMap<Table, TableDTO>();
            CreateMap<TableDTO, Table>();

        }
    }
}
