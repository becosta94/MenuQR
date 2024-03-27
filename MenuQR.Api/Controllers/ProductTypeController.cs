using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize]
        public IActionResult Create([FromServices] IProductTypeFactory productTypeFactory, [FromServices] IMapper mapper, ProductTypeDTO productTypeDTO)
        {
            ProductType productType = productTypeFactory.Make(productTypeDTO);
            if (productType is not null)
                return Ok(mapper.Map<ProductTypeDTO>(productType));
            else
                return BadRequest("Não foi possível criar o produto");
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public IActionResult Update([FromServices] IBaseService<ProductType> productTypeBaseService,
                            [FromServices] IValidator validator,
                            [FromServices] IMapper mapper,
                            ProductTypeDTO productTypeDTO)
        {
            ProductType? productUpdated = validator.Execute(() => productTypeBaseService.Update<ProductTypeValidator>(mapper.Map<ProductType>(productTypeDTO))) as ProductType;
            if (productUpdated is not null)
                return Ok(mapper.Map<ProductTypeDTO>(productUpdated));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }

        [HttpGet]
        [Route("getall")]
        [Authorize]
        public IActionResult GetAll([FromServices] IBaseService<ProductType> productTypeBaseService, [FromServices] IMapper mapper, int companyId)
        {
            List<ProductType>? productsType = productTypeBaseService.Get().Where(x => x.CompanyId == companyId).ToList();
            if (productsType is not null)
            {
                List<ProductTypeDTO> productsTypeDTO = new List<ProductTypeDTO>();
                productsType.ForEach(x => productsTypeDTO.Add(mapper.Map<ProductTypeDTO>(x)));
                return Ok(productsTypeDTO);
            }
            else
                return BadRequest("Não foi possível obter a lista de tipos");
        }

        [HttpGet]
        [Route("getbyid")]
        [Authorize]
        public IActionResult GetById([FromServices] IBaseService<ProductType> productTypeBaseService, [FromServices] IMapper mapper, int id)
        {
            ProductType? product = productTypeBaseService.Get().Where(x => x.Id == id).FirstOrDefault();
            if (product is not null)
                return Ok(mapper.Map<ProductTypeDTO>(product));
            else
                return BadRequest("Não foi possível encontrar o produto");
        }
    }
}
