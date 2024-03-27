﻿using AutoMapper;
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
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize]
        public IActionResult Create([FromServices] IProductFactory productFactory, [FromServices] IMapper mapper, ProductDTO productDTO)
        {
            Product product = productFactory.Make(productDTO);
            if (product is not null)
                return Ok(mapper.Map<ProductDTO>(product));
            else
                return BadRequest("Não foi possível criar o produto");
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public IActionResult Update([FromServices] IBaseService<Product> productBaseService,
                                    [FromServices] IValidator validator,
                                    [FromServices] IMapper mapper,
                                    ProductDTO product)
        {
            Product? productUpdated = validator.Execute(() => productBaseService.Update<ProductValidator>(mapper.Map<Product>(product))) as Product;
            if (productUpdated is not null)
                return Ok(mapper.Map<ProductDTO>(productUpdated));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }

        [HttpPut]
        [Route("toggleactivity")]
        [Authorize]
        public IActionResult ToggleActivity([FromServices] IBaseService<Product> productBaseService,
                                            [FromServices] IMapper mapper,
                                            [FromServices] IValidator validator,
                                            int productId,
                                            int companyId)
        {
            Product? productOutdated = productBaseService.GetByCompoundKey(new object[] { productId, companyId });
            productOutdated.Active = !productOutdated.Active;
            Product? productUpdated = validator.Execute(() => productBaseService.Update<ProductValidator>(productOutdated)) as Product;
            if (productUpdated is not null)
                return Ok(mapper.Map<ProductDTO>(productUpdated));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }

        [HttpGet]
        [Route("getbyid")]
        [Authorize]
        public IActionResult GetById([FromServices] IBaseService<Product> productBaseService, [FromServices] IMapper mapper, int id)
        {
            Product? product = productBaseService.Get().Where(x => x.Id == id).FirstOrDefault();
            if (product is not null)
                return Ok(mapper.Map<ProductDTO>(product));
            else
                return BadRequest("Não foi possível encontrar o produto");
        }

        [HttpGet]
        [Route("getall")]
        [Authorize]
        public IActionResult GetAll([FromServices] IBaseService<Product> productBaseService, [FromServices] IMapper mapper, int companyId)
        {
            List<Product>? products = productBaseService.Get().Where(x => x.CompanyId == companyId).OrderByDescending(x => x.Active).ThenBy(x => x.Name).ToList();
            if (products is not null)
            {
                List<ProductDTO> productsDto = new List<ProductDTO>();
                products.ForEach(x => productsDto.Add(mapper.Map<ProductDTO>(x)));
                return Ok(productsDto);
            }
            else
                return BadRequest("Não foi possível obter a lista de produtos");
        }
    }
}
