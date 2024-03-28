using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Validators;


namespace MenuQR.Services.Services
{
    public class BillCloser : IBillCloser
    {
        private readonly IBaseService<Order> _orderService;
        private readonly IBaseService<OrderProduct> _orderProductService;
        private readonly IBaseService<Customer> _customerService;
        private readonly IBaseService<Bill> _billService;
        private readonly IBaseService<CustomerHistory> _customerHistoryService;
        private readonly IValidator _validator;

        public BillCloser(IBaseService<Order> orderService,
                              IBaseService<OrderProduct> orderProductRepository,
                              IBaseService<Customer> customerRepository,
                              IBaseService<Bill> billService,
                              IBaseService<CustomerHistory> costuerHistoryService,
                              IValidator validator)
        {
            _orderService = orderService;
            _orderProductService = orderProductRepository;
            _customerService = customerRepository;
            _billService = billService;
            _customerHistoryService = costuerHistoryService;
            _validator = validator;
        }

        public object Close(int tableId, int companyId, bool closeTotal, string custmerDocument)
        {
            CustomerHistory? customerHistory = null;
            Bill? bill = _billService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && x.Open).FirstOrDefault();
            List<CustomerHistory> customersOnPlace = bill.OrderProducts.Select(x => x.Order.CustomerHistory).Where(x => x.OnPlace).ToList();
            if (closeTotal || customersOnPlace.Count == 1)
            {
                foreach (var custumerAndTotal in bill.CustomersAndTotals)
                {
                    customerHistory = _customerHistoryService.Get()
                                                        .Where(x => x.CustomerDocument == custumerAndTotal.Key.Document && x.CompanyId == companyId && x.OnPlace)
                                                        .FirstOrDefault();
                    if (customerHistory is null)
                        throw new Exception();
                    customerHistory.OnPlace = false;
                    bill.Open = false;
                    _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory);
                }
            }
            else
            {

                customerHistory = _customerHistoryService.Get()
                                                                        .Where(x => x.CustomerDocument == custmerDocument && x.CompanyId == companyId && x.OnPlace)
                                                                        .FirstOrDefault();
                if (customerHistory is null)
                    throw new Exception();
                customerHistory.OnPlace = false;
                _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory);
                bill.CustomersAndTotals.Remove(bill.OrderProducts.Select(x => x.Order.Customer).Where(x => x.Document == custmerDocument).First());
            }
            bill = _validator.Execute(() => _billService.Update<BillValidator>(bill)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
