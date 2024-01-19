using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces
{
    public interface INewOrderFactory
    {
        public Order? Make(int tableId, int custumerId);
    }
}
