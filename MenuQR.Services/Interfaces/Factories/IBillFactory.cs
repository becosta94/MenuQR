using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces.Factories
{
    public interface IBillFactory
    {
        public Bill Make(int tableId, int companyId, string customerDocument);
    }
}
