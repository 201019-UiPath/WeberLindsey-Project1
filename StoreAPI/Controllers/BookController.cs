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

        [HttpGet("get/{title}")]
        [Produces("application/json")]
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



        //TODO this should be removed as it is not used List<Book> GetAllBooksAtLocationId(int id);
        // public IActionResult GetBookById(int id) { }

    }
}
