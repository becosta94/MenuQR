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
            Table table = _orderTable.GetById(tableId);
            if (table is null)
                return null;
            Bill? bill = new Bill() { Table = table, TableId = table.Id, CompanyId = companyId };
            bill = _validator.Execute(() => _billService.Add<BillValidator>(bill)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
