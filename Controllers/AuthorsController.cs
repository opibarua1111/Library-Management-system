using LibraryManagementSystem.DataService;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;
        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        [HttpGet]

        // GET: api/authors
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _authorsService.GetAuthors();
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _authorsService.GetAuthorById(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // POST: api/authors

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _authorsService.CreateAuthor(author);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // PUT: api/authors/{id}
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _authorsService.UpdateAuthor(author);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // DELETE: api/authors/{id}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _authorsService.DeleteAuthor(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // GET: api/authors/{id}/books

        [HttpGet("{id}/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _authorsService.GetBooksByAuthor(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }
    }
}
