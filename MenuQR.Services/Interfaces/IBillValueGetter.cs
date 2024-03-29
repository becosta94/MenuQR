namespace MenuQR.Services.Interfaces
{
    public interface IBillValueGetter
    {
        public object Get(int tableId, int companyId, bool closeTotal, string custmerDocument, bool customerRequest);
    }
}
