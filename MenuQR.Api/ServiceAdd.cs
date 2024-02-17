using MenuQR.Domain.Entities;
using MenuQR.Infra.Data.Repository;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Services;
using MenuQR.Services.Services.Factories;

namespace MenuQR.Api
{
    public static class ServiceAdd
    {
        public static void Add(IServiceCollection builder)
        {
            builder.AddTransient<IBaseRepository<Bill>, BaseRepository<Bill>>();
            builder.AddTransient<IBaseRepository<Customer>, BaseRepository<Customer>>();
            builder.AddTransient<IBaseRepository<CustomerHistory>, BaseRepository<CustomerHistory>>();
            builder.AddTransient<IBaseRepository<Order>, BaseRepository<Order>>();
            builder.AddTransient<IBaseRepository<OrderProduct>, BaseRepository<OrderProduct>>();
            builder.AddTransient<IBaseRepository<Product>, BaseRepository<Product>>();
            builder.AddTransient<IBaseRepository<Table>, BaseRepository<Table>>();

            builder.AddTransient<IBaseService<Bill>, BaseService<Bill>>();
            builder.AddTransient<IBaseService<Customer>, BaseService<Customer>>();
            builder.AddTransient<IBaseService<CustomerHistory>, BaseService<CustomerHistory>>();
            builder.AddTransient<IBaseService<Order>, BaseService<Order>>();
            builder.AddTransient<IBaseService<OrderProduct>, BaseService<OrderProduct>>();
            builder.AddTransient<IBaseService<Product>, BaseService<Product>>();
            builder.AddTransient<IBaseService<Table>, BaseService<Table>>();


            builder.AddTransient<IBillFactory, BillFactory>();
            builder.AddTransient<IBillCloser, BillCloser>();
            builder.AddTransient<ICustomerFactory, CustomerFactory>();
            builder.AddTransient<ICustomerHistoryFactory, CustomerHistoryFactory>();
            builder.AddTransient<IOrderFactory, OrderFactory>();
            builder.AddTransient<IOrderProductFactory, OrderProductFactory>();
            builder.AddTransient<IProductFactory, ProductFactory>();
            builder.AddTransient<ITableFactory, TableFactory>();
            builder.AddTransient<IValidator, Validator>();
        }
    }
}
