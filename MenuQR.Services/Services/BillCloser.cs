using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Validators;


namespace MenuQR.Services.Services
{
    public class BillCloser : IBillCloser
    {
        private readonly IBaseService<Bill> _billService;
        private readonly IBaseService<BillClosureOrder> _billClosureOrderService;
        private readonly IBaseService<CustomerHistory> _customerHistoryService;
        private readonly IValidator _validator;
        private readonly IBillValueGetter _billValueGetter;

        public BillCloser(IBaseService<Bill> billService,
                          IBaseService<CustomerHistory> costuerHistoryService,
                          IBaseService<BillClosureOrder> billClosureOrderService,
                          IValidator validator,
                          IBillValueGetter billValueGetter)
        {
            _billService = billService;
            _billClosureOrderService = billClosureOrderService;
            _customerHistoryService = costuerHistoryService;
            _validator = validator;
            _billValueGetter=billValueGetter;
        }

        public object RequestClosure(int tableId, int companyId, bool closeTotal, string custmerDocument, Bill bill)
        {
            CustomerHistory? customerHistory = null;
            List<CustomerHistory> customersOnPlace = bill.OrderProducts.Select(x => x.Order.CustomerHistory).Where(x => x.OnPlace).ToList();
            if (closeTotal || customersOnPlace.Count == 1)
            {
                foreach (var custumerAndTotal in bill.CustomersAndTotals)
                {
                    customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == custumerAndTotal.Key.Document && x.CompanyId == companyId && x.OnPlace).FirstOrDefault();
                    if (customerHistory is null)
                        throw new Exception();
                }
            }
            else
            {
                customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == custmerDocument && x.CompanyId == companyId && x.OnPlace).FirstOrDefault();
                if (customerHistory is null)
                    throw new Exception();
                bill.CustomersAndTotals.Remove(bill.OrderProducts.Select(x => x.Order.Customer).Where(x => x.Document == custmerDocument).First());
            }
            BillClosureOrder? billClosureOrder = new BillClosureOrder() { CompanyId = companyId, OrderCompleted = false, TableId = tableId, CustumerDocument = custmerDocument, CloseTotal = closeTotal, Value = bill.Total };
            billClosureOrder = _validator.Execute(() => _billClosureOrderService.Add<BillClosureOrderValidator>(billClosureOrder)) as BillClosureOrder;
            if (billClosureOrder is not null)
                return billClosureOrder;
            else
                return null;
        }

        public object Close(BillClosureOrder billClosureOrder)
        {
            CustomerHistory? customerHistory = null;
            Bill? bill = _billValueGetter.Get(billClosureOrder.TableId, billClosureOrder.CompanyId, billClosureOrder.CloseTotal, billClosureOrder.CustumerDocument, false) as Bill;
            if (billClosureOrder.CloseTotal)
            {
                foreach (var custumerAndTotal in bill.CustomersAndTotals)
                {
                    customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == custumerAndTotal.Key.Document && x.CompanyId == billClosureOrder.CompanyId && x.OnPlace).FirstOrDefault();
                    if (customerHistory is null)
                        throw new Exception();
                    customerHistory.OnPlace = false;
                    bill.Open = false;
                    _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory);
                }
            }
            else
            {

                customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == billClosureOrder.CustumerDocument && x.CompanyId == billClosureOrder.CompanyId && x.OnPlace).FirstOrDefault();
                if (customerHistory is null)
                    throw new Exception();
                customerHistory.OnPlace = false;
                _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory);
            }
            billClosureOrder.OrderCompleted = true;
            billClosureOrder = _validator.Execute(() => _billClosureOrderService.Update<BillClosureOrderValidator>(billClosureOrder)) as BillClosureOrder;
            bill.SumTotal();
            bill = _validator.Execute(() => _billService.Update<BillValidator>(bill)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
