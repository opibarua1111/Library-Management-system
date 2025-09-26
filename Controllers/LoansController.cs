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
