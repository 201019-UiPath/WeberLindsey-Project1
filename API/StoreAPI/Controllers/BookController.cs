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
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }



        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                bookService.AddBook(book);
                return CreatedAtAction("AddBook", book);
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
        public IActionResult UpdateBook(Book book)
        {
            try
            {
                bookService.UpdateBook(book);
                return CreatedAtAction("UpdateBook", book);
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
        public IActionResult DeleteBook(Book book)
        {
            try
            {
                bookService.DeleteBook(book);
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
        public IActionResult GetAllBooks()
        {
            try
            {
                return Ok(bookService.GetAllBooks());
            } catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                return Ok(bookService.GetBookById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/title/{title}")]
        [Produces("application/json")]
        [EnableCors("allowedOrigins")]
        public IActionResult GetBookByTitle(string title) 
        { 
            try
            {
                //TODO will need to adjust this to search w/o case sensitivity
                return Ok(bookService.GetBookByTitle(title));
            } catch(Exception) 
            {
                return NotFound();
            }
        }

    }
}
