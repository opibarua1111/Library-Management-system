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
    public class LoansController : ControllerBase
    {
        private readonly ILoansService _loansService;
        public LoansController(ILoansService loansService)
        {
            _loansService = loansService;
        }

        /// <summary>
        /// POST: api/loans
        /// Creates a new loan record for borrowing a book.
        /// </summary>
        /// <param name="loan">The loan object containing book and member details.</param>
        /// <returns>CustomResponse with the created loan or an error message.</returns>
        [HttpPost]
        public async Task<ActionResult<Loan>> BorrowBook(Loan loan)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _loansService.BorrowBook(loan);
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
        /// PUT: api/loans/{id}/return
        /// Marks a loan as returned by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the loan to return.</param>
        /// <returns>CustomResponse indicating success or failure of the return operation.</returns>
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _loansService.ReturnBook(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Loan Not Save";
                response.Data = null;
            }
            return Ok(response);
        }

        /// <summary>
        /// GET: api/loans/overdue
        /// Retrieves all loans that are currently overdue.
        /// </summary>
        /// <returns>CustomResponse containing a list of overdue loans or an error message.</returns>
        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetOverdueLoans()
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _loansService.GetOverdueLoans();
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
