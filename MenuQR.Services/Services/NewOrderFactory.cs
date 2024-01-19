using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services
{
    public class NewOrderFactory : INewOrderFactory
    {
        private readonly IBaseService<Order> _baseServiceOrder;
        private readonly IBaseService<Table> _baseServiceTable;
        private readonly IBaseService<Costumer> _baseServiceCostumer;
        private readonly IValidator _validator;
        public NewOrderFactory(IBaseService<Order> baseOrderService, IBaseService<Table> baseServiceTable, IBaseService<Costumer> baseServiceCostumer, IValidator validator)
        {
            _baseServiceOrder = baseOrderService;
            _baseServiceTable = baseServiceTable;
            _baseServiceCostumer = baseServiceCostumer;
            _validator = validator;
        }
        public Order? Make(int tableId, int custumerId)
        {
            Table table = _baseServiceTable.GetById(tableId);
            Costumer customer = _baseServiceCostumer.GetById(custumerId);
            if (table is not null && customer is not null) 
                return _validator.Execute(() => _baseServiceOrder.Add<OrderValidator>(new Order(table, customer))) as Order;
            return null;
        }
    }
}
