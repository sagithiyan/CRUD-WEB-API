using CRUD_Store.API.Models;
using CRUD_Store.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepostory;

        public BookController(IBookRepository bookRepostory) {
           _bookRepostory = bookRepostory;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks() {

            var books = await _bookRepostory.GetAllBooksAsync();

            return Ok(books);
            
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {

            var book = await _bookRepostory.GetBookByIdAsync(id);
            if (book ==null) {

                return NotFound();
            }
            return Ok(book);

        }



        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody]BookModel bookModel)
        {

            var id = await _bookRepostory.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById),new {id =id,Controller ="book"},id);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> updateBook([FromBody] BookModel bookModel,[FromRoute] int id)
        {

          await _bookRepostory.UpdateBookAsync(id,bookModel);
           return Ok();


        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> updateBookPatch([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {

            await _bookRepostory.updateBookPatchAsync(id, bookModel);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {

            await _bookRepostory.DeleteBookAsync(id);
            return Ok();


        }
    }
}
