using MenuQR.Domain.Entities;

namespace MenuQR.Services.Interfaces
{
    public interface IBillCloser
    {
        public object Close(BillClosureOrder billClosureOrder);
        public object RequestClosure(int tableId, int companyId, bool closeTotal, string custmerDocument, Bill bill);
    }
}
