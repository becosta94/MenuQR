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
            builder.AddTransient<IBaseService<Order>, BaseService<Order>>();
            builder.AddTransient<INewOrder, NewOrder>();
        }

    }
}
