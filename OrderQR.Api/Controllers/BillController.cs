using AutoMapper;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Infra.Data.Context;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        [HttpGet]
        [Route("getallfromtheday")]
        //[Authorize]
        public IActionResult GetAllFromTheDay([FromServices] IBaseService<Bill> billBaseService, [FromServices] SqlContext context, [FromServices] IMapper mapper, int companyId)
        {
            List<Bill>? bills = billBaseService.Get().Where(x => x.CompanyId == companyId && x.CreatedAt.Value >= DateTime.Today.AddHours(-6)).OrderByDescending(x => x.Open).ToList();
            bills.ForEach(x => context.Entry(x).Reference(x => x.Table).Load());
            bills.ForEach(x => context.Entry(x).Collection(x => x.OrderProducts).Load());
            bills.ForEach(x => x.OrderProducts.ForEach(y => context.Entry(y).Reference(y => y.Order).Load()));
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
            Bill bill = newBillFactory.Make(tableId, companyId, customerDocument.Replace("-","").Replace(".",""));
            if (bill is not null)
                return Ok(bill);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
        [HttpPut]
        [Route("close")]
        //[Authorize]
        public IActionResult Close([FromServices] IBillCloser billCloser, BillClosureOrderDTO billClosureOrderDTO, IMapper mapper)
        {
            BillClosureOrder billClosureOrder = mapper.Map<BillClosureOrder>(billClosureOrderDTO);
            object returnedObjectBill = billCloser.Close(billClosureOrder);
            if (returnedObjectBill is not null && returnedObjectBill is Bill bill)
                return Ok(bill);
            else if (returnedObjectBill is not null && returnedObjectBill is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }

        [HttpGet]
        [Route("getopen")]
        [Authorize]
        public IActionResult GetOpen([FromServices] IBillValueGetter billValueGetter, [FromServices] SqlContext context, [FromServices] IMapper mapper, int tableId, int companyId, bool closeTotal, string customerDocument)
        {
            object returnedObjectBill = billValueGetter.GetOpen(tableId, companyId, closeTotal, customerDocument, null, true);
            if (returnedObjectBill is not null && returnedObjectBill is Bill bill)
            {
                bill.OrderProducts.ToList().ForEach(x => context.Entry(x).Reference(o => o.Product).Load());
                bill.OrderProducts.ToList().ForEach(x => x.Product.Image = string.Empty);
                return Ok(mapper.Map<BillDTO>(bill));
            }
            else if (returnedObjectBill is not null && returnedObjectBill is ErroDTO erro)
                return Ok(erro);
            else
                return BadRequest("Não foi possível gerar a conta");
        }
        [HttpGet]
        [Route("getclose")]
        [Authorize]
        public IActionResult GetClose([FromServices] IBillValueGetter billValueGetter, [FromServices] SqlContext context, int billId, int companyId)
        {
            object returnedObjectBill = billValueGetter.GetClose(billId, companyId);
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

        [HttpDelete]
        [Route("delete")]
        //[Authorize]
        public void Delete([FromServices] IBaseService<Bill> billBaseService, [FromServices] IBaseService<BillClosureOrder> billClosureOrderService, int id, int companyId)
        {
            Bill bill = billBaseService.GetByCompoundKey(new object[] { id, companyId });
            BillClosureOrder? billClosureOrders = billClosureOrderService.Get().Where(x => x.CompanyId == companyId && !x.OrderCompleted && x.TableId == bill.TableId && x.TableCompanyId == companyId).LastOrDefault();
            billBaseService.DeleteByCompoundKey(new object[] { id, companyId });
            billClosureOrderService.DeleteByCompoundKey(new object[] { billClosureOrders.Id, billClosureOrders.CompanyId });
        }
    }
}
