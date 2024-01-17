using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;

namespace MenuQR.Services.Interfaces
{
    public interface INewOrder
    {
        public Order? Make(string orderJson);
    }
}
