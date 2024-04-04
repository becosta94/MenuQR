using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;

namespace MenuQR.Services.Services
{
    public class BillValueGetter : IBillValueGetter
    {
        private readonly IBaseService<Order> _orderService;
        private readonly IBaseService<OrderProduct> _orderProductService;
        private readonly IBaseService<Customer> _customerService;
        private readonly IBaseService<Bill> _billService;
        private readonly IBaseService<CustomerHistory> _customerHistoryService;
        private readonly IBaseService<ProductOffList> _productOffListService;
        private readonly IValidator _validator;
        public BillValueGetter(IBaseService<Order> orderService,
                      IBaseService<OrderProduct> orderProductRepository,
                      IBaseService<Customer> customerRepository,
                      IBaseService<Bill> billService,
                      IBaseService<CustomerHistory> costuerHistoryService,
                      IBaseService<ProductOffList> productOffListService,
                      IValidator validator)
        {
            _orderService = orderService;
            _orderProductService = orderProductRepository;
            _customerService = customerRepository;
            _billService = billService;
            _customerHistoryService = costuerHistoryService;
            _productOffListService = productOffListService;
            _validator = validator;
        }
        public object GetOpen(int tableId, int companyId, bool closeTotal, string custmerDocument, bool customerRequest)
        {
            Bill? bill = _billService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && x.Open).FirstOrDefault();
            List<Order> orders = new List<Order>();
            List<ProductOffList> productsOffList = new List<ProductOffList>();

            List<CustomerHistory> customerHistoryList = _customerHistoryService.Get().Where(x => x.OnPlace &&
                                                                                   x.BillId == bill.Id &&
                                                                                   x.BillCompanyId == bill.CompanyId &&
                                                                                   x.CompanyId == companyId).ToList();
            if (closeTotal || customerHistoryList.Where(x => x.OnPlace).Count() == 1)
            {
                foreach (CustomerHistory customerHistory in customerHistoryList)
                {
                    orders = _orderService.Get().Where(x => x.TableId == tableId && x.CompanyId == companyId && customerHistoryList.Any(y => y.Id == x.CustomerHistoryId && y.CompanyId == x.CustomerHistoryCompanyId && y.OnPlace)).ToList();
                }
                if (orders.Where(x => !x.Deliverd).Count() > 0)
                    return new ErroDTO("Existem pedidos em aberto.");
            }
            else
            {

                CustomerHistory customerHistory = _customerHistoryService.Get().Where(x => x.CustomerDocument == custmerDocument &&
                                                                                       x.OnPlace &&
                                                                                       x.BillId == bill.Id &&
                                                                                       x.BillCompanyId == bill.CompanyId &&
                                                                                       x.CompanyId == companyId).First();
                orders = _orderService.Get().Where(x => x.TableId == tableId &&
                                                                x.CompanyId == companyId &&
                                                                x.CustomerHistoryId == customerHistory.Id &&
                                                                x.CustomerHistoryCompanyId == customerHistory.CompanyId).ToList();
                if (orders.Where(x => !x.Deliverd && x.CustomerDocument == custmerDocument).Count() > 0)
                    return new ErroDTO("Existem pedidos em aberto.");
            }

            orders.ForEach(x => x.Customer = _customerService.Get().Where(y => y.Document == x.CustomerDocument).FirstOrDefault());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            if (bill is null)
                return null;
            foreach (Order order in orders)
                orderProducts.AddRange(_orderProductService.Get().Where(x => x.OrderId == order.Id &&
                                                                             x.CompanyId == order.CompanyId && x.BillId == bill.Id &&
                                                                             x.BillCompanyId == bill.CompanyId).ToList());
            ICollection<IGrouping<Customer, OrderProduct>> orderProducts1 = new HashSet<IGrouping<Customer, OrderProduct>>();
            Bill returnedBill = new Bill(bill);
            returnedBill.OrderProducts = new List<OrderProduct>(bill.OrderProducts);
            if (closeTotal)
            {

                orderProducts1 =  orderProducts.GroupBy(x => x.Order.Customer).ToList();
            }
            else
            {
                orderProducts1 =  orderProducts.Where(x => x.Order.CustomerDocument == custmerDocument).GroupBy(x => x.Order.Customer).ToList();
                returnedBill.OrderProducts.RemoveAll(x => x.Order.CustomerDocument != custmerDocument);
            }
            foreach (IGrouping<Customer, OrderProduct> gruped in orderProducts1)
            {
                returnedBill.AddNewCustomerTotal(gruped.Key, gruped.Where(x => x.Order.CustomerHistory.OnPlace).Sum(x => x.Total));
            }
            bill.CustomersAndTotals = new Dictionary<Customer, double>(returnedBill.CustomersAndTotals);
            productsOffList = _productOffListService.Get().Where(x => x.BillId == bill.Id && x.BillCompanyId == bill.CompanyId).ToList();
            productsOffList.ForEach(x => returnedBill.AddNewCustomerTotal(x.Customer, x.Amount * x.Price));
            productsOffList.ForEach(x => bill.AddNewCustomerTotal(x.Customer, x.Amount * x.Price));
            returnedBill.ProductOffLists = productsOffList;
            bill.ProductOffLists = productsOffList;
            returnedBill.SumTotal();
            if (customerRequest)
            {
                returnedBill.OrderProducts = orderProducts;
                if (returnedBill is not null)
                    return returnedBill;
                else
                    return null;
            }
            else
            {
                if (bill is not null)
                    return bill;
                else
                    return null;
            }

        }

        public object GetClose(int billId, int companyId)
        {
            Bill? bill = _billService.GetByCompoundKey(new object[] { billId, companyId });
            List<Order> orders = new List<Order>();
            List<CustomerHistory> customerHistoryList = _customerHistoryService.Get().Where(x => !x.OnPlace &&
                                                                                   x.BillId == bill.Id &&
                                                                                   x.BillCompanyId == bill.CompanyId &&
                                                                                   x.CompanyId == bill.CompanyId).ToList();
            foreach (CustomerHistory customerHistory in customerHistoryList)
            {
                orders = _orderService.Get().Where(x => x.TableId == bill.TableId && x.CompanyId == bill.CompanyId && customerHistoryList.Any(y => y.Id == x.CustomerHistoryId && y.CompanyId == x.CustomerHistoryCompanyId && !y.OnPlace)).ToList();
            }
            if (orders.Where(x => !x.Deliverd).Count() > 0)
                return new ErroDTO("Existem pedidos em aberto.");
            orders.ForEach(x => x.Customer = _customerService.Get().Where(y => y.Document == x.CustomerDocument).FirstOrDefault());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            if (bill is null)
                return null;
            foreach (Order order in orders)
                orderProducts.AddRange(_orderProductService.Get().Where(x => x.OrderId == order.Id && x.CompanyId == order.CompanyId && x.BillId == bill.Id && x.BillCompanyId == bill.CompanyId).ToList());
            ICollection<IGrouping<Customer, OrderProduct>> orderProducts1 = new HashSet<IGrouping<Customer, OrderProduct>>();
            orderProducts1 =  orderProducts.GroupBy(x => x.Order.Customer).ToList();
            foreach (IGrouping<Customer, OrderProduct> gruped in orderProducts1)
                bill.AddNewCustomerTotal(gruped.Key, gruped.Where(x => !x.Order.CustomerHistory.OnPlace).Sum(x => x.Total));
            if (bill is not null)
                return bill;
            else
                return null;

        }
    }
}
