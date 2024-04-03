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
            bills.ForEach(x => context.Entry(x).Reference(x => x.Table).Load());
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
        public IActionResult Close([FromServices] IBillValueGetter billValueGetter, [FromServices] IBillCloser billCloser, BillClosureOrder billClosureOrder)
        {
            object returnedObjectBill = billCloser.Close(billClosureOrder);
            if (returnedObjectBill is not null && returnedObjectBill is Bill bill)
                return Ok(bill);
            else if (returnedObjectBill is not null && returnedObjectBill is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }

        [HttpPost]
        [Route("billclosureorder")]
        [Authorize]
        public IActionResult RequestClosure([FromServices] IBillValueGetter billValueGetter, [FromServices] IBaseService<CustomerHistory> customerHistoryService, [FromServices] IBillCloser billCloser, int tableId, int companyId, bool closeTotal, string customerDocument)
        {
            object returnedBill = billValueGetter.Get(tableId, companyId, closeTotal, customerDocument, true);
            if (returnedBill is not null && returnedBill is Bill bill)
            {

                List<CustomerHistory> customerHistoryList = customerHistoryService.Get().Where(x => x.OnPlace &&
                                                                                       x.BillId == bill.Id &&
                                                                                       x.BillCompanyId == bill.CompanyId &&
                                                                                       x.CompanyId == companyId).ToList();
                if (customerHistoryList.Count == 1)
                    closeTotal = true;
                object returnedRequestClosure = billCloser.RequestClosure(tableId, companyId, closeTotal, customerDocument, bill);
                if (returnedRequestClosure is not null && returnedRequestClosure is BillClosureOrder billClosureOrder)
                    return Ok(billClosureOrder);
            }
            if (returnedBill is not null && returnedBill is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }

        [HttpGet]
        [Route("billclosureordergetall")]
        [Authorize]
        public IActionResult Get([FromServices] IBaseService<BillClosureOrder> billClosureOrderService, [FromServices] SqlContext context, int companyId)
        {
            List<BillClosureOrder> billClosureOrders = billClosureOrderService.Get().Where(x => x.CompanyId == companyId && !x.OrderCompleted).ToList();
            billClosureOrders.ForEach(x => context.Entry(x).Reference(x => x.Table).Load());
            billClosureOrders.ForEach(x => context.Entry(x).Reference(x => x.Customer).Load());
            if (billClosureOrders is not null)
                return Ok(billClosureOrders);
            else
                return BadRequest("Não foi possível gerar a conta");
        }

        [HttpGet]
        [Route("billclosureorderget")]
        public IActionResult GetClose([FromServices] IBaseService<BillClosureOrder> billClosureOrderService, int companyId, int tableId)
        {
            BillClosureOrder? billClosureOrders = billClosureOrderService.Get().Where(x => x.CompanyId == companyId && !x.OrderCompleted && x.TableId == tableId && x.TableCompanyId == companyId).LastOrDefault();
            if (billClosureOrders is not null)
                return Ok(billClosureOrders);
            else if (billClosureOrders is null)
                return Ok(new BillClosureOrder());
            else
                return BadRequest("Não foi possível gerar a conta");
        }


        [HttpGet]
        [Route("get")]
        [Authorize]
        public IActionResult Get([FromServices] IBillValueGetter billValueGetter, [FromServices] SqlContext context, int tableId, int companyId, bool closeTotal, string customerDocument)
        {
            object returnedObjectBill = billValueGetter.Get(tableId, companyId, closeTotal, customerDocument, true);
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
