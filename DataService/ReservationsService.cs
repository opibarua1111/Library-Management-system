using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class ReservationsService : IReservationsService
    {
        private readonly LibraryContext _context;
        public ReservationsService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> CreateReservation(Reservation reservation)
        {
            try
            {
                var response = new CustomResponse();

                reservation.ReservationId = Guid.NewGuid();
                reservation.ReservationDate = DateTime.Now;
                reservation.Status = "Pending";
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                response.Data =  reservation;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> FulfillReservation(Guid id)
        {
            try
            {
                var response = new CustomResponse();

                var res = await _context.Reservations.Include(r => r.Book).FirstOrDefaultAsync(r => r.ReservationId == id);
                if (res == null)
                {
                    response.ReponseCode = 404;
                    response.Message = "Reservation not found";
                    return response;
                }

                res.Status = "Fulfilled";
                res.Book.AvailableCopies -= 1;
                await _context.SaveChangesAsync();
                response.Data = res;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> CancelReservation(Guid id)
        {
            try
            {
                var response = new CustomResponse();

                var res = await _context.Reservations.FindAsync(id);
                if (res == null)
                {
                    response.ReponseCode = 404;
                    response.Message = "Reservation not found";
                    return response;
                }
                res.Status = "Cancelled";
                await _context.SaveChangesAsync();
                response.Data = res;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
