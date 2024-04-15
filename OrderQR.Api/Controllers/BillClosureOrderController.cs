using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Infra.Data.Context;
using OrderQR.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class BillClosureOrderController : ControllerBase
    {
        [HttpPost]
        [Route("billclosureorder")]
        //[Authorize]
        public IActionResult RequestClosure([FromServices] IBillValueGetter billValueGetter, [FromServices] IBaseService<CustomerHistory> customerHistoryService, [FromServices] IBillCloser billCloser, int tableId, int companyId, bool closeTotal, string customerDocument, bool tips, string userId)
        {
            object returnedBill = billValueGetter.GetOpen(tableId, companyId, closeTotal, customerDocument, tips, true);
            if (returnedBill is not null && returnedBill is Bill bill)
            {

                List<CustomerHistory> customerHistoryList = customerHistoryService.Get().Where(x => x.OnPlace &&
                                                                                       x.BillId == bill.Id &&
                                                                                       x.BillCompanyId == bill.CompanyId &&
                                                                                       x.CompanyId == companyId).ToList();
                if (customerHistoryList.Count == 1)
                    closeTotal = true;
                object returnedRequestClosure = billCloser.RequestClosure(tableId, companyId, closeTotal, customerDocument, tips, bill, userId);
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
            billClosureOrders.ForEach(x => context.Entry(x).Reference(x => x.Bill).Load());
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
        [HttpDelete]
        [Route("delete")]
        //[Authorize]
        public void Delete([FromServices] IBaseService<BillClosureOrder> billClosureOrderService, int id, int companyId, string userId)
        {
            billClosureOrderService.DeleteByCompoundKey(new object[] { id, companyId }, companyId, userId);
        }
        [HttpGet]
        [Route("billclosureordergetpaid")]
        public IActionResult GetPaid([FromServices] IBaseService<BillClosureOrder> billClosureOrderService, int biilId, int companyId, string customerDocument)
        {
            BillClosureOrder? billClosureOrders = billClosureOrderService.Get().Where(x => x.BillId == biilId && x.BillCompanyId == companyId && x.CustomerDocument == customerDocument && x.OrderCompleted).LastOrDefault();
            if (billClosureOrders is not null)
                return Ok(billClosureOrders);
            else if (billClosureOrders is null)
                return Ok(new BillClosureOrder());
            else
                return BadRequest("Não foi possível gerar a conta");
        }
    }
}
