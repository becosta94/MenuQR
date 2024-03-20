using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromServices] ICustomerFactory customerFactory, [FromServices] IMapper mapper, CustomerDTO customerDTO)
        {
            object customerResult = customerFactory.Make(customerDTO);
            if (customerResult is not null && customerResult is Customer customer)
                return Ok(mapper.Map<CustomerDTO>(customer));
            if (customerResult is not null && customerResult is string message)
                return BadRequest(message);
            return BadRequest("Ocorreu um erro.");
        }
        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById([FromServices] IBaseService<Customer> customerService, [FromServices] IMapper mapper, string id)
        {
            Customer? customer = customerService.Get().Where(x => x.Document == id).FirstOrDefault();
            if (customer is not null)
                return Ok(mapper.Map<CustomerDTO>(customer));
            else
                return BadRequest("Cliente não encontrado");
        }
    }
}
