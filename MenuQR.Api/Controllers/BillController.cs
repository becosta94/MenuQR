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
    public class BillController : ControllerBase
    {
        [HttpGet]
        [Route("getall")]
        [Authorize]
        public IActionResult GetAll([FromServices] IBaseService<Bill> billBaseService, [FromServices] SqlContext context, [FromServices] IMapper mapper, int companyId)
        {
            List<Bill>? bills = billBaseService.Get().Where(x => x.CompanyId == companyId).OrderByDescending(x => x.Open).ToList();
            bills.ForEach(x => context.Entry(x).Reference(o => o.Table).Load());
            if (bills is not null)
            {
                List<BillDTO> billDTO = new List<BillDTO>();
                bills.ForEach(x => billDTO.Add(mapper.Map<BillDTO>(x)));
                return Ok(billDTO);
            }
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpPost]
        [Route("create")]
        //[Authorize]
        public IActionResult Create([FromServices] IBillFactory newBillFactory, int tableId, int companyId, string customerDocument)
        {
            Bill bill = newBillFactory.Make(tableId, companyId, customerDocument);
            if (bill is not null)
                return Ok(bill);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
        [HttpPut]
        [Route("close")]
        [Authorize]
        public IActionResult Close([FromServices] IBillValueGetter billValueGetter, [FromServices] IBillCloser billCloser, int tableId, int companyId, bool closeTotal, string custmerDocument)
        {
            object returnedObjectBill = billValueGetter.Get(tableId, companyId, closeTotal, custmerDocument);
            if (returnedObjectBill is not null && returnedObjectBill is Bill)
            {
                returnedObjectBill = billCloser.Close(tableId, companyId, closeTotal, custmerDocument);
                if (returnedObjectBill is not null && returnedObjectBill is Bill bill)
                    return Ok(bill);
            }
            if (returnedObjectBill is not null && returnedObjectBill is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }

        [HttpGet]
        [Route("get")]
        //[Authorize]
        public IActionResult Get([FromServices] IBillValueGetter billValueGetter, [FromServices] SqlContext context, int tableId, int companyId, bool closeTotal, string customerDocument)
        {
            object returnedObjectBill = billValueGetter.Get(tableId, companyId, closeTotal, customerDocument);
            if (returnedObjectBill is not null && returnedObjectBill is Bill bill)
            {
                bill.OrderProducts.ToList().ForEach(x => context.Entry(x).Reference(o => o.Product).Load());
                bill.OrderProducts.ToList().ForEach(x => x.Product.Image = string.Empty);
                return Ok(bill);
            }
            else if (returnedObjectBill is not null && returnedObjectBill is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
    }
}
