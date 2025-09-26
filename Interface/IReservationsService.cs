using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface IReservationsService
    {
        Task<CustomResponse> CancelReservation(Guid id);
        Task<CustomResponse> CreateReservation(Reservation reservation);
        Task<CustomResponse> FulfillReservation(Guid id);
    }
}
