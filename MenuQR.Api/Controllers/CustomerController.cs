using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MenuQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromServices] ICustomerFactory customerFactory, CustomerDTO customerDTO)
        {
            Customer customer = customerFactory.Make(customerDTO);
            if (customer is not null)
                return Ok(customer);
            return BadRequest("Não foi possível cadastrar o usuário");
        }
    }
}
