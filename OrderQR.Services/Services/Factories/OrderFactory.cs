using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;

namespace OrderQR.Services.Services.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IBaseService<Order> _baseServiceOrder;
        private readonly IBaseService<Table> _baseServiceTable;
        private readonly IBaseService<Customer> _baseServiceCustomer;
        private readonly IBaseService<CustomerHistory> _customerHistorybaseService;
        private readonly IValidator _validator;
        public OrderFactory(IBaseService<Order> baseOrderService,
                               IBaseService<Table> baseServiceTable,
                               IBaseService<Customer> baseServiceCustomer,
                               IBaseService<CustomerHistory> customerHistorybaseService,
                               IValidator validator)
        {
            _baseServiceOrder = baseOrderService;
            _baseServiceTable = baseServiceTable;
            _baseServiceCustomer = baseServiceCustomer;
            _customerHistorybaseService = customerHistorybaseService;
            _validator = validator;
        }
        public Order? Make(int tableId, string customerDocument, int companyId, bool makeByCustomer, string userId)
        {
            Table table = _baseServiceTable.GetByCompoundKey(new object[] { tableId, companyId });
            Customer? customer = _baseServiceCustomer.Get().Where(x => x.Document == customerDocument).FirstOrDefault();
            CustomerHistory? customerHistory = _customerHistorybaseService.Get()
                                                                          .Where(x => x.CustomerDocument == customer.Document && x.CompanyId == companyId && x.OnPlace)
                                                                          .FirstOrDefault();
            if (customer is not null && customerHistory.OnPlace)
            {
                if (makeByCustomer)
                    return _validator.Execute(() => _baseServiceOrder.Add<OrderValidator>(new Order(table.Id, customer.Document, companyId, customerHistory.Id, customerHistory.CompanyId), companyId, userId)) as Order;
                else
                {
                    Order order = new Order(table.Id, customer.Document, companyId, customerHistory.Id, customerHistory.CompanyId);
                    order.Deliverd = true;
                    return _validator.Execute(() => _baseServiceOrder.Add<OrderValidator>(order, companyId, userId)) as Order;
                }
            }
            return null;
        }
    }
}
