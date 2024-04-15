using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize]
        public IActionResult Create([FromServices] IProductTypeFactory productTypeFactory, [FromServices] IMapper mapper, ProductTypeDTO productTypeDTO, string userId)
        {
            ProductType productType = productTypeFactory.Make(productTypeDTO, userId);
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
                            ProductTypeDTO productTypeDTO,
                            string userId)
        {
            ProductType? productUpdated = validator.Execute(() => productTypeBaseService.Update<ProductTypeValidator>(mapper.Map<ProductType>(productTypeDTO), productTypeDTO.CompanyId, userId)) as ProductType;
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
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public IActionResult Delete([FromServices] IBaseService<ProductType> productTypeBaseService, [FromServices] IBaseService<Product> productBaseService, int id, int companyId, string userId)
        {
            bool hasProducts = productBaseService.Get().Where(x => x.ProductTypeId == id && x.ProductTypeCompanyId == companyId).Any();
            if (!hasProducts)
            {
                productTypeBaseService.DeleteByCompoundKey(new object[] { id, companyId }, companyId, userId);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
