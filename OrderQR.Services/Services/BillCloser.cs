using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Validators;


namespace OrderQR.Services.Services
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

        public object RequestClosure(int tableId, int companyId, bool closeTotal, string custmerDocument, bool tips, Bill bill, string userId)
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
            BillClosureOrder? billClosureOrder = new BillClosureOrder() { CompanyId = companyId, OrderCompleted = false, TableId = tableId, TableCompanyId = companyId, CustomerDocument = custmerDocument, CloseTotal = closeTotal, Value = bill.Total, Tips = tips, BillId = bill.Id, BillCompanyId = bill.CompanyId };
            billClosureOrder = _validator.Execute(() => _billClosureOrderService.Add<BillClosureOrderValidator>(billClosureOrder, companyId, userId)) as BillClosureOrder;
            if (billClosureOrder is not null)
                return billClosureOrder;
            else
                return null;
        }

        public object Close(BillClosureOrder billClosureOrder, string userId)
        {
            CustomerHistory? customerHistory = null;
            Bill? bill = _billValueGetter.GetOpen(billClosureOrder.TableId, billClosureOrder.CompanyId, billClosureOrder.CloseTotal, billClosureOrder.CustomerDocument, billClosureOrder.Tips, false) as Bill;
            if (billClosureOrder.CloseTotal)
            {
                if (bill.CustomersAndTotals.Count > 0)
                    foreach (var custumerAndTotal in bill.CustomersAndTotals)
                    {
                        customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == custumerAndTotal.Key.Document && x.CompanyId == billClosureOrder.CompanyId && x.OnPlace).FirstOrDefault();
                        if (customerHistory is null)
                            throw new Exception();
                        customerHistory.OnPlace = false;
                        bill.Open = false;
                        _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory, billClosureOrder.CompanyId, userId);
                    }
                else
                {
                    List<CustomerHistory> customerHistoryList = _customerHistoryService.Get().Where(x => x.BillId == bill.Id && x.BillCompanyId == bill.CompanyId).ToList();
                    if (customerHistoryList is null)
                        throw new Exception();
                    customerHistoryList.ForEach(x => x.OnPlace = false);
                    bill.Open = false;
                    customerHistoryList.ForEach(x => _customerHistoryService.Update<CustomerHistoryValidator>(x, x.CompanyId, userId));
                }
            }
            else
            {

                customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == billClosureOrder.CustomerDocument && x.CompanyId == billClosureOrder.CompanyId && x.OnPlace).FirstOrDefault();
                if (customerHistory is null)
                    throw new Exception();
                customerHistory.OnPlace = false;
                _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory, customerHistory.CompanyId, userId);
            }
            billClosureOrder.OrderCompleted = true;
            billClosureOrder = _validator.Execute(() => _billClosureOrderService.Update<BillClosureOrderValidator>(billClosureOrder, billClosureOrder.CompanyId, userId)) as BillClosureOrder;
            bill.SumTotal(billClosureOrder.Tips);
            bill.ClosingDate = DateTime.Now;
            bill = _validator.Execute(() => _billService.Update<BillValidator>(bill, bill.CompanyId, userId)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
