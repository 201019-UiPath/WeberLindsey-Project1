using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB.Models;
using StoreLib;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                orderService.AddOrder(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                orderService.UpdateOrder(order);
                return CreatedAtAction("UpdateOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                orderService.DeleteOrder(order);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        //List<Order> GetAllOrdersByLocationId(int id);
        //List<Order> GetAllOrdersByUserId(int id);
        // List<Order> GetAllOrdersByUserIdDateAsc(int id);
        // List<Order> GetAllOrdersByUserIdDateDesc(int id);
        // List<Order> GetAllOrdersByUserIdPriceAsc(int id);
        // List<Order> GetAllOrdersByUserIdPriceDesc(int id);
        // Order GetOrderByDate(DateTime dateTime);
        // Order GetOrderById(int id);
        // Order GetOrderByLocationId(int id);
        // Order GetOrderByUserId(int id);
    }
}
}
