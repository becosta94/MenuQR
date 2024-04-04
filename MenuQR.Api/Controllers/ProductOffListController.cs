using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductOffListController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        //[Authorize]
        public IActionResult Create([FromServices]IProductOffListFactory productFactory, [FromServices]IMapper mapper, [FromBody]ProductOffListDTO productOffListDTO/*, string customerDocument*/)
        {
            ProductOffList productOffList = productFactory.Make(productOffListDTO);
            if (productOffList is not null)
                return Ok(mapper.Map<ProductOffListDTO>(productOffList));
            else
                return BadRequest("Não foi possível criar o produto");
        }
    }
}
