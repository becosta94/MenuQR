using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces
{
    public interface INewOrderFactory
    {
        public Order? Make();
    }
}
