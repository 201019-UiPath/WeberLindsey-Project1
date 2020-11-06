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
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCart(Cart cart)
        {
            try
            {
                cartService.AddCart(cart);
                return CreatedAtAction("AddCart", cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCart(Cart cart)
        {
            try
            {
                cartService.UpdateCart(cart);
                return CreatedAtAction("UpdateCart", cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCart(Cart cart)
        {
            try
            {
                cartService.DeleteCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        //TODO this needs to be refactored probably Cart GetCartByUserId(int id);
        //Cart GetCartById(int id);
        //TODO implemented but don't think it should be, doesn't work anyways void UpdateCart(Cart cart);
    }
}
