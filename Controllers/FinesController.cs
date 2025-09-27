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
    public class FinesController : ControllerBase
    {
        private readonly IFinesService _finesService;
        public FinesController(IFinesService finesService)
        {
            _finesService = finesService;
        }

        /// <summary>
        /// GET: api/fines/member/{id}
        /// Retrieves all fines for a specific member by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>CustomResponse containing a list of fines for the member or an error message.</returns>
        [HttpGet("member/{id}")]
        public async Task<ActionResult<IEnumerable<Fine>>> GetFinesForMember(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _finesService.GetFinesForMember(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        /// <summary>
        /// PUT: api/fines/{id}/pay
        /// Pays a specific fine by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the fine to pay.</param>
        /// <returns>CustomResponse indicating success or failure of the payment operation.</returns>
        [HttpPut("{id}/pay")]
        public async Task<IActionResult> PayFine(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _finesService.PayFine(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Fine Not Save";
                response.Data = null;
            }
            return Ok(response);
        }
    }
}
