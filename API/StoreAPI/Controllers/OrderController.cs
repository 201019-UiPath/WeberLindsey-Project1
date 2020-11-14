using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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




        [HttpGet("get/location/{locationId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByLocationId(int locationId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationId(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/user/{userId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByUserId(int userId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserId(userId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }




        [HttpGet("get/user/date/asc/{userId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByUserIdDateAsc(int userId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdDateAsc(userId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/user/date/desc/{userId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByUserIdDateDesc(int userId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdDateDesc(userId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/user/price/asc/{userId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByUserIdPriceAsc(int userId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdPriceAsc(userId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/user/price/desc/{userId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByUserIdPriceDesc(int userId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByUserIdPriceDesc(userId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }




        [HttpGet("get/location/date/asc/{locationId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByLocationIdDateAsc(int locationId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationIdDateAsc(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/location/date/desc/{locationId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByLocationIdDateDesc(int locationId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationIdDateDesc(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/location/price/asc/{locationId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByLocationIdPriceAsc(int locationId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationIdPriceAsc(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/location/price/desc/{locationId}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllOrdersByLocationIdPriceDesc(int locationId)
        {
            try
            {
                return Ok(orderService.GetAllOrdersByLocationIdPriceDesc(locationId));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }





        // Order GetOrderByDate(DateTime dateTime);
        // Order GetOrderById(int id);
        // Order GetOrderByLocationId(int id);
        // Order GetOrderByUserId(int id);
    }
}
