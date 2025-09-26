using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface IBooksServices
    {
        Task<CustomResponse> GetBooks();
        Task<CustomResponse> GetBookById(Guid id);
        Task<CustomResponse> CreateBook(Book book);
        Task<CustomResponse> UpdateBook(Book book);
        Task<CustomResponse> DeleteBookById(Guid id);
        Task<CustomResponse> UpdateAvailability(Guid id, int change);
    }
}
