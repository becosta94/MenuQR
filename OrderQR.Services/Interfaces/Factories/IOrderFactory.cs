using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface IOrderFactory
    {
        public Order? Make(int tableId, string customerDocument, int companyId, bool makeByCustomer);
    }
}
