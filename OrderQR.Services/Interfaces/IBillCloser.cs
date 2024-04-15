using OrderQR.Domain.Entities;

namespace OrderQR.Services.Interfaces
{
    public interface IBillCloser
    {
        public object Close(BillClosureOrder billClosureOrder, string userId);
        public object RequestClosure(int tableId, int companyId, bool closeTotal, string custmerDocument, bool tips, Bill bill, string userId);
    }
}
