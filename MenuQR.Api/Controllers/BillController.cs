﻿using AutoMapper;
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
        [Authorize]
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
        public IActionResult Close([FromServices] IBillCloser billCloser, int tableId, int companyId)
        {
            object returnedObjectBillCloser = billCloser.Close(tableId, companyId);
            if (returnedObjectBillCloser is not null && returnedObjectBillCloser is Bill)
                return Ok(returnedObjectBillCloser);
            else if (returnedObjectBillCloser is not null && returnedObjectBillCloser is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
    }
}
