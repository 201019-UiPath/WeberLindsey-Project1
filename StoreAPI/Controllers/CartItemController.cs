﻿using System;
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
    public class CartItemController : ControllerBase
    {

        private readonly ICartItemService cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCartItem(CartItem item)
        {
            try
            {
                cartItemService.AddCartItem(item);
                return CreatedAtAction("AddCartItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCartItem(CartItem item)
        {
            try
            {
                cartItemService.UpdateCartItem(item);
                return CreatedAtAction("UpdateCartItem", item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCartItem(CartItem item)
        {
            try
            {
                cartItemService.DeleteCartItem(item);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        //List<CartItem> GetAllCartItemsByCartId(int id);
        //CartItem GetCartItemByCartId(int id);
        //CartItem GetCartItemById(int id);

    }
}