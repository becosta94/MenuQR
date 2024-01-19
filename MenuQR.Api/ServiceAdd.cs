using MenuQR.Domain.Entities;
using MenuQR.Infra.Data.Repository;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Services;

namespace MenuQR.Api
{
    public static class ServiceAdd
    {
        public static void Add(IServiceCollection builder)
        {
            builder.AddTransient<IBaseRepository<Order>, BaseRepository<Order>>();
            builder.AddTransient<IBaseRepository<OrderProduct>, BaseRepository<OrderProduct>>();
            builder.AddTransient<IBaseRepository<Table>, BaseRepository<Table>>();
            builder.AddTransient<IBaseRepository<Costumer>, BaseRepository<Costumer>>();
            builder.AddTransient<IBaseRepository<Product>, BaseRepository<Product>>();

            builder.AddTransient<IBaseService<Order>, BaseService<Order>>();
            builder.AddTransient<IBaseService<OrderProduct>, BaseService<OrderProduct>>();
            builder.AddTransient<IBaseService<Table>, BaseService<Table>>();
            builder.AddTransient<IBaseService<Costumer>, BaseService<Costumer>>();
            builder.AddTransient<IBaseService<Product>, BaseService<Product>>();


            builder.AddTransient<INewOrderFactory, NewOrderFactory>();
            builder.AddTransient<INewOrderProductFactory, NewOrderProductFactory>();
            builder.AddTransient<IValidator, Validator>();
        }
    }
}
