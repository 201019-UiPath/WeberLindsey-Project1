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
    public class LineItemController : ControllerBase
    {
        private readonly ILineItemService lineItemService;

        public LineItemController(ILineItemService lineItemService)
        {
            this.lineItemService = lineItemService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLineItem(LineItem item)
        {
            try
            {
                lineItemService.AddLineItem(item);
                return CreatedAtAction("AddLineItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLineItem(LineItem item)
        {
            try
            {
                lineItemService.UpdateLineItem(item);
                return CreatedAtAction("UpdateLineItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLineItem(LineItem item)
        {
            try
            {
                lineItemService.DeleteLineItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //List<LineItem> GetAllLineItemsByOrderId(int id);
        //LineItem GetLineItemByOrderId(int id);
    }
}
