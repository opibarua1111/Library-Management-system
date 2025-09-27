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

        /// <summary>
        /// GET: api/members
        /// Retrieves a list of all members in the system.
        /// </summary>
        /// <returns>CustomResponse containing a list of members or an error message.</returns>
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

        /// <summary>
        /// GET: api/members/{id}
        /// Retrieves a single member by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>CustomResponse containing the requested member or an error message.</returns>
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

        /// <summary>
        /// POST: api/members
        /// Creates a new member record in the system.
        /// </summary>
        /// <param name="member">The member object to create.</param>
        /// <returns>CustomResponse with the created member or an error message.</returns>
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

        /// <summary>
        /// PUT: api/members
        /// Updates an existing member's details.
        /// </summary>
        /// <param name="member">The updated member object.</param>
        /// <returns>CustomResponse with the updated member or an error message.</returns>
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

        /// <summary>
        /// DELETE: api/members/{id}
        /// Deletes a member from the system by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the member to delete.</param>
        /// <returns>CustomResponse indicating success or failure.</returns>
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

        /// <summary>
        /// GET: api/members/{id}/loans
        /// Retrieves the loan history for a specific member.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>CustomResponse containing a list of loans or an error message.</returns>
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

        /// <summary>
        /// GET: api/members/{id}/reservations
        /// Retrieves all reservations made by a specific member.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>CustomResponse containing a list of reservations or an error message.</returns>
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
