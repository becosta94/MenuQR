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
        private readonly IValidator _validator;

        public BillFactory(IBaseService<Table> tableService,
                              IBaseService<Bill> billService,
                              IValidator validator)
        {
            _orderTable = tableService;
            _billService = billService;
            _validator = validator;
        }
        public Bill Make(int tableId, int companyId)
        {
            Bill exitingBill = _billService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && x.Open).FirstOrDefault();
            if (exitingBill is not null)
                return exitingBill;
            Table table = _orderTable.GetByCompoundKey(new object[] { tableId, companyId });
            if (table is null)
                return null;
            Bill? bill = new Bill() { TableId = table.Id, TableCompanyId = table.CompanyId, CompanyId = companyId };
            bill = _validator.Execute(() => _billService.Add<BillValidator>(bill)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
