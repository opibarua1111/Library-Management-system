using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class LoansService : ILoansService
    {
        private readonly LibraryContext _context;
        public LoansService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> BorrowBook(Loan loan)
        {
            try
            {
                var response = new CustomResponse();
                var book = await _context.Books.FindAsync(loan.BookId);
                if (book == null || book.AvailableCopies <= 0) { 
                    response.Message = "Book not available";
                    return response;
                } 

                loan.LoanDate = DateTime.Now;
                loan.DueDate = DateTime.Now.AddDays(14);
                loan.Status = "Borrowed";

                book.AvailableCopies -= 1;
                loan.LoanId = Guid.NewGuid();
                _context.Loans.Add(loan);
                await _context.SaveChangesAsync();
                response.Message = "Borrowed Book";
                response.Data = loan;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CustomResponse> ReturnBook(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                var loan = await _context.Loans.Include(l => l.Book).FirstOrDefaultAsync(l => l.LoanId == id);
                if (loan == null)
                {
                    response.Message = "Not Found";
                    return response;
                }

                loan.ReturnDate = DateTime.Now;
                loan.Status = loan.DueDate < DateTime.Now ? "Overdue" : "Returned";
                loan.Book.AvailableCopies += 1;

                await _context.SaveChangesAsync();
                response.Data = loan;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> GetOverdueLoans()
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Loans.Include(l => l.Member).Include(l => l.Book)
                                .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
