using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromServices] IBillFactory newBillFactory ,int tableId, int companyId)
        {
            Bill bill = newBillFactory.Make(tableId, companyId);
            if (bill is not null)
                return Ok(bill);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
        [HttpPut]
        [Route("close")]
        public IActionResult Close([FromServices] IBillCloser billCloser, int tableId)
        {
            Bill bill = billCloser.Close(tableId);
            if (bill is not null)
                return Ok(bill);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
    }
}
