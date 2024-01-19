using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services
{
    public class NewOrderFactory : INewOrderFactory
    {
        private IBaseService<Order> _baseOrderService;
        private IValidator _validator;
        public NewOrderFactory(IBaseService<Order> baseOrderService, IValidator validator)
        {
            _baseOrderService = baseOrderService;
            _validator = validator;
        }
        public Order? Make()
        {
            return _validator.Execute(() => _baseOrderService.Add<OrderValidator>(new Order())) as Order;
        }
    }
}
