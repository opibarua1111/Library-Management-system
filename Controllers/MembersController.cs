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
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.GetMembers();
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberById(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.GetMemberById(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Data Not Found";
                response.Data = null;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Member>> CreateMember(Member member)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.CreateMember(member);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Member Not Create";
                response.Data = null;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(Member member)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.UpdateMember(member);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Member Not Update";
                response.Data = null;
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.DeleteMember(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Member Not Delete";
                response.Data = null;
            }
            return Ok(response);
        }

        [HttpGet("{id}/loans")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoanHistory(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.GetLoanHistory(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Loan Get Failed";
                response.Data = null;
            }
            return Ok(response);
        }

        [HttpGet("{id}/reservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _membersService.GetReservations(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Reservation Get Failed";
                response.Data = null;
            }
            return Ok(response);
        }
    }
}
