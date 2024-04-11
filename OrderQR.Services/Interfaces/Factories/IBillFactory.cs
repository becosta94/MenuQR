using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces.Factories
{
    public interface IBillFactory
    {
        public Bill Make(int tableId, int companyId, string customerDocument);
    }
}
