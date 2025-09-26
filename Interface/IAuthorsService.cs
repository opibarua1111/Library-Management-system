using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface IAuthorsService
    {
        Task<CustomResponse> CreateAuthor(Author author);
        Task<CustomResponse> DeleteAuthor(Guid id);
        Task<CustomResponse> GetAuthorById(Guid id);
        Task<CustomResponse> GetAuthors();
        Task<CustomResponse> GetBooksByAuthor(Guid id);
        Task<CustomResponse> UpdateAuthor(Author author);
    }
}
