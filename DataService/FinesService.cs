using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class FinesService : IFinesService
    {
        private readonly LibraryContext _context;
        public FinesService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> GetFinesForMember(Guid id)
        {
            try
            {
                var response = new CustomResponse();

                response.Data = await _context.Fines.Include(f => f.Loan).ThenInclude(l => l.Book)
                                    .Where(f => f.Loan.MemberId == id && !f.Paid).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> PayFine(Guid id)
        {
            try
            {
                var response = new CustomResponse();

                var fine = await _context.Fines.FindAsync(id);
                if (fine == null) {
                    response.Message = "Not Found";
                    return response;
                }
                fine.Paid = true;
                fine.PaidDate = DateTime.Now;
                await _context.SaveChangesAsync();
                response.Data = fine;
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
