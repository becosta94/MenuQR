using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById([FromServices] IBaseService<Company> companyBaseService, [FromServices] IMapper mapper, [FromServices] IAccentRemover accentRemover, int id)
        {
            Company? company = companyBaseService.GetById(id);
            CompanyDTO companyDTO = mapper.Map<CompanyDTO>(company);
            companyDTO.Name = accentRemover.RemoveAccents(companyDTO.Name.Replace(' ', '-').ToLower());
            if (company is not null)
                return Ok(companyDTO);
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
    }
}
