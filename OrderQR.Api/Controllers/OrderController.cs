﻿using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using OrderQR.Domain.DTOs;
using OrderQR.Domain.Entities;
using OrderQR.Infra.Data.Context;
using OrderQR.Services.Interfaces;
using OrderQR.Services.Interfaces.Factories;
using OrderQR.Services.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OrderQR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("createbycustomer")]
        [Authorize]
        public IActionResult CreateByCustomer([FromBody] ICollection<OrderProductCreateDTO> listOrderProductReceived,
                                    [FromServices] IOrderFactory newOrderFactory,
                                    [FromServices] IOrderProductFactory newOrderProductFactory,
                                    [FromServices] IBaseService<Order> orderService,
                                    [FromServices] IMapper mapper,
                                    int tableId,
                                    string customerDocument,
                                    string userId)
        {
            try
            {
                Order? newOrder = newOrderFactory.Make(tableId, customerDocument, listOrderProductReceived.FirstOrDefault().CompanyId, true, userId);
                try
                {
                    if (newOrder is not null)
                    {
                        ICollection<OrderProduct>? orderProducts = newOrderProductFactory.Make(newOrder, listOrderProductReceived, userId);
                        if (orderProducts is not null)
                            return Ok(mapper.Map<OrderDTO>(newOrder));
                        return BadRequest("Pedido não realizado");
                    }
                    else
                        return BadRequest("Pedido não realizado");
                }
                catch
                {
                    orderService.DeleteByCompoundKey(new object[] { newOrder.Id, newOrder.CompanyId }, newOrder.CompanyId, userId);
                    throw new Exception("Problema ao registar OrderProduct");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("createbycompany")]
        [Authorize]
        public IActionResult CreateByCompany([FromBody] OrderProductCreateDTO orderProductReceived,
                            [FromServices] IOrderFactory newOrderFactory,
                            [FromServices] IOrderProductFactory newOrderProductFactory,
                            [FromServices] IBaseService<Order> orderService,
                            [FromServices] IMapper mapper,
                            int tableId,
                            string customerDocument,
                            string userId)
        {
            try
            {
                Order? newOrder = newOrderFactory.Make(tableId, customerDocument, orderProductReceived.CompanyId, false, userId);
                try
                {
                    if (newOrder is not null)
                    {
                        List<OrderProductCreateDTO> orderProductDTOs = new List<OrderProductCreateDTO>();
                        orderProductDTOs.Add(orderProductReceived);
                        ICollection<OrderProduct>? orderProducts = newOrderProductFactory.Make(newOrder, orderProductDTOs, userId);
                        if (orderProducts is not null)
                            return Ok(mapper.Map<OrderDTO>(newOrder));
                        return BadRequest("Pedido não realizado");
                    }
                    else
                        return BadRequest("Pedido não realizado");
                }
                catch
                {
                    orderService.DeleteByCompoundKey(new object[] { newOrder.Id, newOrder.CompanyId }, newOrder.CompanyId, userId);
                    throw new Exception("Problema ao registar OrderProduct");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("deliverOrder")]
        [Authorize]
        public IActionResult DeliverOrder([FromServices] IBaseService<Order> orderBaseService, [FromServices] IValidator validator, int id, int companyId, string userId)
        {
            Order? orderOutdated = orderBaseService.GetByCompoundKey(new object[] {id, companyId});
            if (orderOutdated is null)
                return BadRequest("Pedido não encontrado.");
            if (orderOutdated.Deliverd == false)
            {
                orderOutdated.DeliveryTime = DateTime.Now;
                orderOutdated.Deliverd = true;
            }
            else
            {
                orderOutdated.DeliveryTime = DateTime.MinValue;
                orderOutdated.Deliverd = false;
            }
            Order? orderUpdated = validator.Execute(() => orderBaseService.Update<OrderValidator>(orderOutdated, companyId, userId)) as Order;
            if (orderUpdated is not null)
                return Ok(orderUpdated);
            else
                return BadRequest("Não foi possível atualizar o pedido");
        }

        [HttpGet]
        [Route("getalltodelivery")]
        [Authorize]
        public IActionResult GetAllToDelivery([FromServices] IBaseService<Order> orderBaseService, [FromServices] IMapper mapper, [FromServices] SqlContext context, int companyId)
        {
            List<Order>? orders = orderBaseService.Get().Where(x => x.CompanyId == companyId && !x.Deliverd).OrderBy(x => x.CreatedAt).ToList();
            if (orders.Count == 0)
            {
                List<OrderDTO> ordersDto = new List<OrderDTO>();
                orders.ForEach(x => ordersDto.Add(mapper.Map<OrderDTO>(x)));
                return Ok(JsonConvert.SerializeObject(ordersDto));
            }
            orders.ForEach(x => context.Entry(x).Reference(o => o.Table).Load());
            orders.ForEach(x => context.Entry(x).Collection(o => o.OrderProducts).Load());
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            orders.ForEach(x => orderProducts.AddRange(x.OrderProducts));
            orders.First().GetComponentType();
            orderProducts.ForEach(x => context.Entry(x).Reference(o => o.Product).Load());
            if (orders is not null)
            {
                List<OrderDTO> ordersDto = new List<OrderDTO>();
                orders.ForEach(x => ordersDto.Add(mapper.Map<OrderDTO>(x)));
                return Ok(ordersDto);
            }
            else
                return BadRequest("Não foi possível atualizar o produto");
        }
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public void Delete([FromServices] IBaseService<Order> orderBaseService, int id, int companyId, string userId)
        {
            orderBaseService.DeleteByCompoundKey(new object[] { id, companyId }, companyId, userId);
        }
    }
}
