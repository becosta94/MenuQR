using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IOrderFactory
    {
        public Order? Make(int tableId, string customerDocument, int companyId);
    }
}
