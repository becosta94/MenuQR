using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces
{
    public interface IBillCloser
    {
        public object Close(int tableId, int companyId);
    }
}
