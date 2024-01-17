using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Validators;
using Microsoft.AspNetCore.Mvc;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IBaseService<Order> _baseOrderService;

        public OrderController(IBaseService<Order> baseOrderService)
        {
            _baseOrderService = baseOrderService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order orderJson, [FromServices] INewOrder newOrder)
        {
            try
            {
                Order? order = newOrder.Make(orderJson.ToString());
                if (order != null)
                {
                    return Execute(() => _baseOrderService.Add<OrderValidator>(order));
                    
                }
                else
                    return BadRequest("Pedido não realizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
