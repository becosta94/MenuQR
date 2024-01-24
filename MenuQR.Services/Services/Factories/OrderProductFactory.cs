using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services.Factories
{
    public class OrderProductFactory : IOrderProductFactory
    {
        private readonly IBaseService<OrderProduct> _baseOrderProductService;
        private readonly IBaseService<Product> _baseProductService;
        private readonly IBaseService<Bill> _billBaseService;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;
        public OrderProductFactory(IBaseService<OrderProduct> baseOrderProductService,
                                      IBaseService<Product> baseProductService,
                                      IBaseService<Bill> billBaseService,
                                      IValidator validator,
                                      IMapper mapper)
        {
            _baseOrderProductService = baseOrderProductService;
            _baseProductService = baseProductService;
            _billBaseService = billBaseService;
            _validator = validator;
            _mapper = mapper;
        }
        public ICollection<OrderProduct>? Make(Order order, ICollection<OrderProductDTO> listOrderProductReceived)
        {
            List<OrderProduct> listOrderProductMapped = new List<OrderProduct>();
            if (listOrderProductReceived.Sum(x => x.Amount) == 0)
                return null;
            listOrderProductReceived.ToList().ForEach(x => listOrderProductMapped.Add(_mapper.Map<OrderProduct>(x)));
            listOrderProductMapped.ForEach(x => x.OrderId = order.Id);
            List<OrderProduct> orderProductsAddedd = new List<OrderProduct>();
            Bill? bill = _billBaseService.Get().Where(x => x.TableId == order.TableId && x.Open).FirstOrDefault();
            foreach (OrderProduct orderProduct in listOrderProductMapped)
            {
                Product product = _baseProductService.GetById(orderProduct.ProductId);
                if (product is null)
                    continue;
                orderProduct.Total = product.Price * orderProduct.Amount;
                orderProduct.Bill = bill;
                OrderProduct? newOrderProduc = _validator.Execute(() => _baseOrderProductService.Add<OrderProductValidator>(orderProduct)) as OrderProduct;
                if (newOrderProduc is null)
                    throw new Exception("Erro in OrderProduct");
                orderProductsAddedd.Add(newOrderProduc);
            }
            if (orderProductsAddedd.Count == 0)
                return null;
            return orderProductsAddedd;
        }
    }
}
