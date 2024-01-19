using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] ICollection<OrderProductDTO> listOrderProductReceived, [FromServices] INewOrderFactory newOrderFactory, [FromServices] INewOrderProductFactory newOrderProductFactory)
        {
            try
            {
                Order? newOrder = newOrderFactory.Make();
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
