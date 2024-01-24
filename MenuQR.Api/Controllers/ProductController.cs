using AutoMapper;
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
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromServices] IProductFactory productFactory, ProductDTO productDTO)
        {
            Product product = productFactory.Make(productDTO);
            if (product is not null)
                return Ok(product);
            else
                return BadRequest("Não foi possível criar o produto");
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromServices] IBaseService<Product> productBaseService,
                                    [FromServices] IValidator validator,
                                    [FromServices] IMapper mapper,
                                    ProductDTO product)
        {
            Product? productUpdated = validator.Execute(() => productBaseService.Update<ProductValidator>(mapper.Map<Product>(product))) as Product;
            if (productUpdated is not null)
                return Ok(productUpdated);
            else
                return BadRequest("Não foi possível atualizar o produto");
        }

        [HttpPut]
        [Route("disable")]
        public IActionResult Disable([FromServices] IBaseService<Product> productBaseService, [FromServices] IValidator validator, int productId)
        {
            Product? productOutdated = productBaseService.GetById(productId);
            productOutdated.Active = false;
            Product? productUpdated = validator.Execute(() => productBaseService.Update<ProductValidator>(productOutdated)) as Product;
            if (productUpdated is not null)
                return Ok(productUpdated);
            else
                return BadRequest("Não foi possível atualizar o produto");
        }

        [HttpGet]
        public IActionResult GetById([FromServices] IBaseService<Product> productBaseService, int productId)
        {
            Product? product = productBaseService.GetById(productId);
            if (product is not null)
                return Ok(product);
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
    }
}
