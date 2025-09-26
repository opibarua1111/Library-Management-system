using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;

namespace LibraryManagementSystem.Interface
{
    public interface ILoansService
    {
        Task<CustomResponse> BorrowBook(Loan loan);
        Task<CustomResponse> GetOverdueLoans();
        Task<CustomResponse> ReturnBook(Guid id);
    }
}
