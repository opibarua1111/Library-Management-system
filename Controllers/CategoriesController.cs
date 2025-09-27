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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _categoriesService.GetCategories();
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _categoriesService.CreateCategory(category);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Create";
                response.Data = null;
            }
            return Ok(response);
        }
        // PUT: api/categories
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _categoriesService.UpdateCategory(category);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Update";
                response.Data = null;
            }
            return Ok(response);
        }
        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _categoriesService.DeleteCategory(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Delete";
                response.Data = null;
            }
            return Ok(response);
        }
    }
}
