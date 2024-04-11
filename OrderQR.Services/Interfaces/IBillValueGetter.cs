using OrderQR.Domain.DTOs;

namespace OrderQR.Services.Interfaces
{
    public interface IBillValueGetter
    {
        public object GetOpen(int tableId, int companyId, bool closeTotal, string custmerDocument, bool? tips, bool customerRequest);
        public object GetClose(int billId, int companyId);
    }
}
