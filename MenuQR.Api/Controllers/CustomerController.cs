using AutoMapper;
using MenuQR.Domain.DTOs;
using MenuQR.Domain.Entities;
using MenuQR.Infra.Data.Context;
using MenuQR.Services.Interfaces;
using MenuQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Authorization;
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
            if (customerResult is not null && customerResult is ErroDTO erro)
                return BadRequest(erro);
            return BadRequest("Ocorreu um erro.");
        }
        [HttpGet]
        [Route("get")]
        public IActionResult Get([FromServices] IBaseService<Customer> customerService, [FromServices] IBaseService<CustomerHistory> customerHistoryService, [FromServices] IMapper mapper, [FromServices] SqlContext context, string document, int companyId, int tableId)
        {
            Customer? customer = customerService.Get().Where(x => x.Document == document).FirstOrDefault();
            if (customer == null)
                return Ok(new CustomerDTO());
            CustomerHistory customerHistory = customerHistoryService.Get().Where(x => x.CustomerDocument == customer.Document && x.CompanyId == companyId).LastOrDefault();
            if (customerHistory is not null && customerHistory.OnPlace)
            {
                context.Entry(customerHistory).Reference(x => x.Bill).Load();
                if (customerHistory.Bill.TableId != tableId)
                    return Ok(new ErroDTO("Você possui uma conta aberta em outra mesa."));
                else
                    return Ok(mapper.Map<CustomerDTO>(customer));
            }
            else if (customer is not null)
                return Ok(mapper.Map<CustomerDTO>(customer));
            else
                return BadRequest("Cliente não encontrado");
        }
    }
}
