using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;
using Microsoft.AspNetCore.Cors;
using Serilog;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ICartService cartService;

        public UserController(IUserService userService, ICartService cartService)
        {
            this.userService = userService;
            this.cartService = cartService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult AddUser(User user)
        {
            try
            {
                userService.AddUser(user);
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                userService.UpdateUser(user);
                return CreatedAtAction("UpdateUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult DeleteUser(User user)
        {
            try
            {
                userService.DeleteUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(userService.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(userService.GetUserById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{username}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                return Ok(userService.GetUserByUsername(username));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("signin")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult SignIn(User user)
        {
            try
            {
                //Create sign in logger
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs\\LoginAttempts.txt")
                .CreateLogger();

                User signedInUser = userService.GetUserByUsername(user.username);

                if (signedInUser.password != user.password)
                {
                    //Log the sign in attempt
                    Log.Information($"User {user.username} attempted to sign in unsuccessfully");
                    return StatusCode(403);
                }
                else
                {
                    //Log the sign in 
                    Log.Information($"User {signedInUser.username} signed in successfully");
                    return Ok(signedInUser);
                }                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signup/cust")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult SignUpCust(User user)
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                if (ValidationService.ValidUsername(user.username, users) == false)
                {
                    return StatusCode(409);
                }

                if(ValidationService.ValidEmail(user.email) == false)
                {
                    return StatusCode(406);
                }

                if(ValidationService.ValidName(user.name) == false)
                {
                    return BadRequest();
                }

                user.type = StoreDB.Models.User.userType.Customer;

                userService.AddUser(user);

                User createdUser = userService.GetUserByUsername(user.username);

                Cart cart = new Cart();
                cart.userId = createdUser.id;
                cartService.AddCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("signup/mgr")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult SignUpMgr(User user)
        {
            try
            {
                List<User> users = userService.GetAllUsers();
                if (ValidationService.ValidUsername(user.username, users) == false)
                {
                    return StatusCode(409);
                }

                if (ValidationService.ValidEmail(user.email) == false)
                {
                    return StatusCode(406);
                }

                if (ValidationService.ValidName(user.name) == false)
                {
                    return BadRequest();
                }

                user.type = StoreDB.Models.User.userType.Manager;

                userService.AddUser(user);

                User createdUser = userService.GetUserByUsername(user.username);

                Cart cart = new Cart();
                cart.userId = createdUser.id;
                cartService.AddCart(cart);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
