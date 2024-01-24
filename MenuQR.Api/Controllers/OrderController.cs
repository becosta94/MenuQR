using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;
using Microsoft.AspNetCore.Mvc;

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
                            return Ok(orderProducts.Select(x => x.Product));
                        return BadRequest("Pedido não realizado");
                    }
                    else
                        return BadRequest("Pedido não realizado");
                }
                catch
                {
                    orderService.Delete(newOrder.Id);
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
    }
}
