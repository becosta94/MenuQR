using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Infra.Data.Context;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] ICollection<OrderProductDTO> listOrderProductReceived,
                                    [FromServices] IOrderFactory newOrderFactory,
                                    [FromServices] IOrderProductFactory newOrderProductFactory,
                                    [FromServices] IBaseService<Order> orderService,
                                    [FromServices] IMapper mapper,
                                    int tableId,
                                    string customerDocument)
        {
            try
            {
                Order? newOrder = newOrderFactory.Make(tableId, customerDocument, listOrderProductReceived.FirstOrDefault().CompanyId);
                try
                {
                    if (newOrder is not null)
                    {
                        ICollection<OrderProduct>? orderProducts = newOrderProductFactory.Make(newOrder, listOrderProductReceived);
                        if (orderProducts is not null)
                            return Ok(mapper.Map<OrderDTO>(newOrder));
                        return BadRequest("Pedido não realizado");
                    }
                    else
                        return BadRequest("Pedido não realizado");
                }
                catch
                {
                    orderService.DeleteByCompoundKey(new object[] { newOrder.Id, newOrder.CompanyId  });
                    throw new Exception("Problema ao registar OrderProduct");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("deliverOrder")]
        public IActionResult DeliverOrder([FromServices] IBaseService<Order> orderBaseService, [FromServices] IValidator validator, int orderId)
        {
            Order? orderOutdated = orderBaseService.GetById(orderId);
            orderOutdated.Deliverd = true;
            Order? orderUpdated = validator.Execute(() => orderBaseService.Update<OrderValidator>(orderOutdated)) as Order;
            if (orderUpdated is not null)
                return Ok(orderUpdated);
            else
                return BadRequest("Não foi possível atualizar o produto");
        }

        [HttpGet]
        [Route("getalltodelivery")]
        public IActionResult GetAllToDelivery([FromServices] IBaseService<Order> orderBaseService, [FromServices] IValidator validator, [FromServices] IMapper mapper, [FromServices] SqlContext context, int companyId)
        {
            List<Order>? orders = orderBaseService.Get().Where(x => x.CompanyId == companyId && !x.Deliverd).OrderBy(x => x.Date).ToList();
            orders.ForEach(x => context.Entry(x).Reference(o => o.Table).Load());
            orders.ForEach(x => context.Entry(x).Collection(o => o.OrderProducts).Load());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            orders.ForEach(x => orderProducts.AddRange(x.OrderProducts));
            orders.First().GetComponentType();
            orderProducts.ForEach(x => context.Entry(x).Reference(o => o.Product).Load());
            if (orders is not null)
            {
                List<OrderDTO> ordersDto = new List<OrderDTO>();
                orders.ForEach(x => ordersDto.Add(mapper.Map<OrderDTO>(x)));
                return Ok(JsonConvert.SerializeObject(ordersDto));
            }
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
    }
}
