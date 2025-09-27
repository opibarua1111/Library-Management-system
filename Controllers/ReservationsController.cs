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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;
        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        /// <summary>
        /// POST: api/reservations
        /// Creates a new reservation for a book by a member.
        /// </summary>
        /// <param name="reservation">The reservation object containing book and member details.</param>
        /// <returns>CustomResponse with the created reservation or an error message.</returns>
        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation(Reservation reservation)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _reservationsService.CreateReservation(reservation);
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
        /// PUT: api/reservations/{id}/fulfill
        /// Marks a reservation as fulfilled by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation to fulfill.</param>
        /// <returns>CustomResponse indicating success or failure of the fulfill operation.</returns>
        [HttpPut("{id}/fulfill")]
        public async Task<IActionResult> FulfillReservation(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _reservationsService.FulfillReservation(id);
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
        /// PUT: api/reservations/{id}/cancel
        /// Cancels a reservation by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the reservation to cancel.</param>
        /// <returns>CustomResponse indicating success or failure of the cancel operation.</returns>
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelReservation(Guid id)
        {
            CustomResponse response = new() { ReponseCode = 200 };
            try
            {
                response = await _reservationsService.CancelReservation(id);
            }
            catch (Exception)
            {
                response.ReponseCode = 500;
                response.Message = "Reservation Delete Failed";
                response.Data = null;
            }
            return Ok(response);
        }
    }
}
