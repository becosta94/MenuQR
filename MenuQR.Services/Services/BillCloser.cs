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
            Bill? bill = _billService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && x.Open).FirstOrDefault();
            CustomerHistory? customerHistory = _customerHistoryService.Get()
                                                                    .Where(x => x.CustomerDocument == custmerDocument && x.CompanyId == companyId && x.OnPlace)
                                                                    .FirstOrDefault();
            if (customerHistory is null)
                throw new Exception();
            customerHistory.OnPlace = false;
            _customerHistoryService.Update<CustomerHistoryValidator>(customerHistory);
            bill.Open = false;
            bill = _validator.Execute(() => _billService.Update<BillValidator>(bill)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
