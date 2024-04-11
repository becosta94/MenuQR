using OrderQR.Application.Interfaces;
using Microsoft.AspNetCore.Components;

namespace OrderQR.Application.Services
{
    public class TableAndCompanyChecker : ITableAndCompanyChecker
    {
        private NavigationManager _navigationManager;

        public TableAndCompanyChecker(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void Check(string companyIdCookie, string tableGuidCookie, string companyIdPage, string tableGuidPage)
        {
            if (companyIdCookie != companyIdPage || tableGuidCookie != tableGuidPage)
                _navigationManager.NavigateTo($"/Error");
        }
    }
}
