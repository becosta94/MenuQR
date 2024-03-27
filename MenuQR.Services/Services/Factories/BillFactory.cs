using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
{
    public class BillFactory : IBillFactory
    {
        private readonly IBaseService<Table> _orderTable;
        private readonly IBaseService<Bill> _billService;
        private readonly IBaseService<CustomerHistory> _custumerHistoryService;
        private readonly IValidator _validator;

        public BillFactory(IBaseService<Table> tableService,
                              IBaseService<Bill> billService,
                              IBaseService<CustomerHistory> custumerHistoryService,
                              IValidator validator)
        {
            _orderTable = tableService;
            _billService = billService;
            _custumerHistoryService = custumerHistoryService;
            _validator = validator;
        }
        public Bill Make(int tableId, int companyId, string custumerDocument)
        {
            Bill exitingBill = _billService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && x.Open).FirstOrDefault();
            if (exitingBill is not null)
            {
                List<CustomerHistory> customerHistoryList = _custumerHistoryService.Get().Where(x => !x.OnPlace && x.CompanyId == companyId && x.CustomerDocument == custumerDocument).ToList();
                if (customerHistoryList.Count == 0)
                {
                    CustomerHistory customerHistory = new CustomerHistory() { BillId = exitingBill.Id, CompanyId = companyId, BillCompanyId = exitingBill.CompanyId, OnPlace = true, CustomerDocument = custumerDocument };
                    customerHistory = _validator.Execute(() => _custumerHistoryService.Add<CustomerHistoryValidator>(customerHistory)) as CustomerHistory;
                    if (customerHistory is not null)
                        return exitingBill;
                    else
                        return null;
                }

                return exitingBill;
            }
            Table table = _orderTable.GetByCompoundKey(new object[] { tableId, companyId });
            if (table is null)
                return null;
            Bill? bill = new Bill() { TableId = table.Id, TableCompanyId = table.CompanyId, CompanyId = companyId };
            bill = _validator.Execute(() => _billService.Add<BillValidator>(bill)) as Bill;
            if (bill is not null)
            {
                CustomerHistory customerHistory = new CustomerHistory() { Bill = bill, BillId = bill.Id, BillCompanyId = bill.CompanyId, CompanyId = companyId, OnPlace = true, CustomerDocument = custumerDocument };
                customerHistory = _validator.Execute(() => _custumerHistoryService.Add<CustomerHistoryValidator>(customerHistory)) as CustomerHistory;
                if (customerHistory is not null)
                    return bill;
                else
                    _billService.DeleteByCompoundKey(new object[] { bill.Id, bill.CompanyId });
            }
            return null;
        }
    }
}
