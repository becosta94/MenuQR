﻿using AutoMapper;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrderQR.Domain.DTOs;
using OrderQR.Services.Validators;
using Microsoft.AspNetCore.Authorization;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        //[Authorize]
        public IActionResult Create([FromServices] ITableFactory tableFactory, [FromServices] IMapper mapper, TableDTO tableDTO, string userId)
        {
            Table product = tableFactory.Make(tableDTO, userId);
            if (product is not null)
                return Ok(mapper.Map<TableDTO>(product));
            else
                return BadRequest("Não foi possível criar o produto");
        }
        [HttpPut]
        [Route("update")]
        [Authorize]
        public IActionResult Update([FromServices] IBaseService<Table> tableBaseService,
                                    [FromServices] IValidator validator,
                                    [FromServices] IMapper mapper,
                                    TableDTO table,
                                    string userId)
        {
            Table? tableUpdated = validator.Execute(() => tableBaseService.Update<TableValidator>(mapper.Map<Table>(table), table.CompanyId, userId)) as Table;
            if (tableUpdated is not null)
                return Ok(mapper.Map<TableDTO>(tableUpdated));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById([FromServices] IBaseService<Table> tableBaseService, [FromServices] IMapper mapper, int tableId, int companyId)
        {
            Table? table = tableBaseService.GetByCompoundKey(new object[] { tableId, companyId});
            if (table is not null)
                return Ok(mapper.Map<TableDTO>(table));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpGet]
        [Route("getall")]
        [Authorize]
        public IActionResult GetAll([FromServices] IBaseService<Table> tableBaseService, [FromServices] IMapper mapper, int companyId)
        {
            List<Table>? tables = tableBaseService.Get().Where(x => x.CompanyId == companyId).OrderByDescending(x => x.Identification).ToList();
            if (tables is not null)
            {
                List<TableDTO> tableDTO = new List<TableDTO>();
                tables.ForEach(x => tableDTO.Add(mapper.Map<TableDTO>(x)));
                return Ok(tableDTO);
            }
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpDelete]
        [Route("delete")]
        //[Authorize]
        public void Delete([FromServices] IBaseService<Table> tableBaseService, int id, int companyId, string userId)
        {
            tableBaseService.DeleteByCompoundKey(new object[] { id, companyId }, companyId, userId);
        }
    }
}
