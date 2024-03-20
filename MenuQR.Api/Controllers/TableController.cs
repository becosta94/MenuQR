using AutoMapper;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces.Factories;
using MenuQR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MenuQR.Domain.DTOs;
using MenuQR.Services.Validators;
using Microsoft.AspNetCore.Authorization;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromServices] ITableFactory tableFactory, [FromServices] IMapper mapper, TableDTO tableDTO)
        {
            Table product = tableFactory.Make(tableDTO);
            if (product is not null)
                return Ok(mapper.Map<TableDTO>(product));
            else
                return BadRequest("Não foi possível criar o produto");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromServices] IBaseService<Table> tableBaseService,
                                    [FromServices] IValidator validator,
                                    [FromServices] IMapper mapper,
                                    TableDTO table)
        {
            Table? tableUpdated = validator.Execute(() => tableBaseService.Update<TableValidator>(mapper.Map<Table>(table))) as Table;
            if (tableUpdated is not null)
                return Ok(mapper.Map<TableDTO>(tableUpdated));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpGet]
        [Route("getbyid")]
        [Authorize]
        public IActionResult GetById([FromServices] IBaseService<Table> tableBaseService, [FromServices] IMapper mapper, int id)
        {
            Table? table = tableBaseService.GetById(id);
            if (table is not null)
                return Ok(mapper.Map<TableDTO>(table));
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpGet]
        [Route("getall")]
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
    }
}
