using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces
{
    public interface IBillCloser
    {
        public Bill Close(int tableId, int companyId);
    }
}
