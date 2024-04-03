using MenuQR.Domain.DTOs;

namespace MenuQR.Services.Interfaces
{
    public interface IBillValueGetter
    {
        public object GetOpen(int tableId, int companyId, bool closeTotal, string custmerDocument, bool customerRequest);
        public object GetClose(int billId, int companyId);
    }
}
