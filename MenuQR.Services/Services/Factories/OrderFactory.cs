using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
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
        public Order? Make(int tableId, string customerDocument, int companyId)
        {
            Table table = _baseServiceTable.GetByCompoundKey(new object[] { tableId, companyId });
            Customer? customer = _baseServiceCustomer.Get().Where(x => x.Document == customerDocument).FirstOrDefault();
            CustomerHistory? customerHistory = _customerHistorybaseService.Get()
                                                                          .Where(x => x.CustomerId == customer.Id && x.CompanyId == companyId && x.OnPlace)
                                                                          .FirstOrDefault();
            if (customer is not null && customerHistory.OnPlace)
                return _validator.Execute(() => _baseServiceOrder.Add<OrderValidator>(new Order(table.Id, customer.Document, companyId))) as Order;
            return null;
        }
    }
}
