using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Buffers;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksServices _booksService;
        public BooksController(IBooksServices booksServices)
        {
            _booksService = booksServices;
        }
        // GET: api/books
        // Returns all books including category and authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _booksService.GetBooks();
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // GET: api/books/{id}
        // Returns single book by Id (with category and authors)

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _booksService.GetBookById(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // POST: api/books
        // Create a new book

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _booksService.CreateBook(book);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Book Not Create";
                response.Data = null;
            }
            return Ok(response);
        }

        // PUT: api/books/{id}
        // Update a book by Id

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _booksService.UpdateBook(book);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Book Not Updated";
                response.Data = null;
            }
            return Ok(response);
        }

        // DELETE: api/books/{id}
        // Delete a book by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _booksService.DeleteBookById(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Book Not Updated";
                response.Data = null;
            }
            return Ok(response);
        }

        // PATCH: api/books/{id}/availability
        // Update available copies (increment or decrement)

        [HttpPatch("{id}/availability")]
        public async Task<IActionResult> UpdateAvailability(Guid id, [FromBody] int change)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _booksService.UpdateAvailability(id, change);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Book Not Updated Availability";
                response.Data = null;
            }
            return Ok(response);
        }
    }
}
