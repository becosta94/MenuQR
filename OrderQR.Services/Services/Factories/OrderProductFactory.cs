using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;

namespace OrderQR.Services.Services.Factories
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
        public ICollection<OrderProduct>? Make(Order order, ICollection<OrderProductCreateDTO> listOrderProductReceived, string userId)
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
                Product product = _baseProductService.GetByCompoundKey( new object[] {  orderProduct.ProductId ,  order.CompanyId });
                if (product is null)
                    continue;
                orderProduct.Total = product.Price * orderProduct.Amount;
                orderProduct.Profit = (product.Price - product.Cost) * orderProduct.Amount;
                orderProduct.Id = 0;
                orderProduct.Order = order;
                orderProduct.Product = product;
                orderProduct.Bill = bill;
                orderProduct.CompanyId = order.CompanyId;
                OrderProduct? newOrderProduc = _validator.Execute(() => _baseOrderProductService.Add<OrderProductValidator>(orderProduct, orderProduct.CompanyId, userId)) as OrderProduct;
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
