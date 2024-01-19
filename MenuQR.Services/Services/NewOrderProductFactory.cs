using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Validators;

namespace MenuQR.Services.Services
{
    public class NewOrderProductFactory : INewOrderProductFactory
    {
        private readonly IBaseService<OrderProduct> _baseOrderProductService;
        private readonly IBaseService<Product> _baseProductService;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;
        public NewOrderProductFactory(IBaseService<OrderProduct> baseOrderProductService, IBaseService<Product> baseProductService, IValidator validator, IMapper mapper)
        {
            _baseOrderProductService = baseOrderProductService;
            _baseProductService = baseProductService;
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
            foreach (OrderProduct orderProduct in listOrderProductMapped)
            {
                Product product = _baseProductService.GetById(orderProduct.ProductId);
                if (product is null) 
                    continue;
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
