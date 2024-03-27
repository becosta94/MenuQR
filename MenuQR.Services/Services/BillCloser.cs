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
        private readonly IBaseService<CustomerHistory> _costuerHistoryService;
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
            _costuerHistoryService = costuerHistoryService;
            _validator = validator;
        }

        public object Close(int tableId, int companyId)
        {
            List<Order> orders = _orderService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId).ToList();
            if (orders.Where(x => !x.Deliverd).Count() > 0)
                return new ErroDTO("Existem pedidos em aberto.");
            orders.ForEach(x => x.Customer = _customerService.Get().Where(y => y.Document == x.CustomerDocument).FirstOrDefault());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            Bill? bill = _billService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && x.Open).FirstOrDefault();
            if (bill is null)
                return null;
            foreach (Order order in orders)
                orderProducts.AddRange(_orderProductService.Get().Where(x => x.OrderId == order.Id && 
                                                                             x.CompanyId == order.CompanyId && x.BillId == bill.Id && 
                                                                             x.BillCompanyId == bill.CompanyId).ToList());
            ICollection<IGrouping<Customer, OrderProduct>> orderProducts1 =  orderProducts.GroupBy(x => x.Order.Customer).ToList();
            foreach (IGrouping<Customer, OrderProduct> gruped in orderProducts1)
            {
                bill.AddNewCustomerTotal(gruped.Key, gruped.Sum(x => x.Total));
                CustomerHistory? customerHistory = _costuerHistoryService.Get()
                                                                        .Where(x => x.CustomerDocument == gruped.Key.Document && x.CompanyId == companyId && x.OnPlace)
                                                                        .FirstOrDefault();
                if (customerHistory is null)
                    throw new Exception();
                customerHistory.OnPlace = false;
                _costuerHistoryService.Update<CustomerHistoryValidator>(customerHistory);
            }
            bill.SumTotal();
            bill.Open = false;
            bill = _validator.Execute(() => _billService.Update<BillValidator>(bill)) as Bill;
            if (bill is not null)
                return bill;
            else
                return null;
        }
    }
}
