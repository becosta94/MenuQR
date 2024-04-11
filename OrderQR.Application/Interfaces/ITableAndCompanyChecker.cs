namespace OrderQR.Application.Interfaces
{
    public interface ITableAndCompanyChecker
    {
        public void Check(string companyIdCookie, string tableGuidCookie, string companyIdPage, string tableGuidPage);
    }
}
