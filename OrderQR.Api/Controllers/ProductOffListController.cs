using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductOffListController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize]
        public IActionResult Create([FromServices]IProductOffListFactory productFactory, [FromServices]IMapper mapper, [FromBody]ProductOffListDTO productOffListDTO/*, string customerDocument*/)
        {
            ProductOffList productOffList = productFactory.Make(productOffListDTO);
            if (productOffList is not null)
                return Ok(mapper.Map<ProductOffListDTO>(productOffList));
            else
                return BadRequest("Não foi possível criar o produto");
        }
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public void Delete([FromServices] IBaseService<ProductOffList> productOffListBaseService, int id, int companyId)
        {
            productOffListBaseService.DeleteByCompoundKey(new object[] { id, companyId });
        }
    }
}
