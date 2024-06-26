﻿using AutoMapper;
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
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        [Authorize]
        public IActionResult Create([FromServices] IProductFactory productFactory, [FromServices] IMapper mapper, ProductDTO productDTO, string userId)
        {
            Product product = productFactory.Make(productDTO, userId);
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
                                    ProductDTO product,
                                    string userId)
        {
            Product? productUpdated = validator.Execute(() => productBaseService.Update<ProductValidator>(mapper.Map<Product>(product), product.CompanyId, userId)) as Product;
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
                                            int companyId,
                                            string userId)
        {
            Product? productOutdated = productBaseService.GetByCompoundKey(new object[] { productId, companyId });
            productOutdated.Active = !productOutdated.Active;
            Product? productUpdated = validator.Execute(() => productBaseService.Update<ProductValidator>(productOutdated, productOutdated.CompanyId, userId)) as Product;
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
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public void Delete([FromServices] IBaseService<Product> productBaseService, int id, int companyId, string userId)
        {
            productBaseService.DeleteByCompoundKey(new object[] { id, companyId }, companyId, userId);
        }
    }
}
