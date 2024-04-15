using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderQR.Domain.Entities;
using OrderQR.Infra.Data.Context;
using OrderQR.Services.Interfaces;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        [Route("getincome")]
        [Authorize]
        public IActionResult GetIncome([FromServices] IBaseService<Bill> billService, int companyId, DateTime from, DateTime to)
        {
            to = to.AddDays(1).Date;
            if (from == DateTime.MinValue && to == DateTime.MinValue)
            {
                from = DateTime.Now.Date;
                to = DateTime.Now;
            }
            double income = billService.Get().Where(x => x.CreatedAt >= from && x.ClosingDate  <= to && x.CompanyId == companyId).Sum(x => x.Total);
            return Ok(income);
        }
        [HttpGet]
        [Route("getprofit")]
        [Authorize]
        public IActionResult GetProfit([FromServices] IBaseService<Bill> billService, int companyId, DateTime from, DateTime to)
        {
            to = to.AddDays(1).Date;
            if (from == DateTime.MinValue && to == DateTime.MinValue)
            {
                from = DateTime.Now.Date;
                to = DateTime.Now;
            }
            double profit = billService.Get().Where(x => x.CreatedAt >= from && x.ClosingDate  <= to && x.CompanyId == companyId).Sum(x => x.Profit);
            return Ok(profit);
        }
        [HttpGet]
        [Route("getmostorderedproducts")]
        [Authorize]
        public IActionResult GetMostOrdereProducts([FromServices] IBaseService<OrderProduct> orderProductService, [FromServices] SqlContext context, int companyId, DateTime from, DateTime to)
        {
            to = to.AddDays(1).Date;
            if (from == DateTime.MinValue && to == DateTime.MinValue)
            {
                from = DateTime.Now.Date;
                to = DateTime.Now;
            }
            var orderProducts = orderProductService.Get().Where(x => x.CreatedAt >= from && x.CreatedAt  <= to && x.CompanyId == companyId).ToList();
            orderProducts.ForEach(x => context.Entry(x).Reference(x => x.Product).Load());
            var top3Itens = orderProducts.Select(x => x.Product).GroupBy(x => x.Id).OrderByDescending(x => x.Count()).Take(3).Select(x => x.First()).Select(x => x.Name).ToList();
            return Ok(top3Itens);
        }
    }
}
