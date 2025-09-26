using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.response;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataService
{
    public class MembersService : IMembersService
    {
        private readonly LibraryContext _context;
        public MembersService(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<CustomResponse> GetMembers()
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Members.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> GetMemberById(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Members.FindAsync(id);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<CustomResponse> CreateMember(Member member)
        {
            try
            {
                var response = new CustomResponse();
                member.MemberId = Guid.NewGuid();
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                response.Data = new { id = member.MemberId };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> UpdateMember(Member member)
        {
            try
            {
                var response = new CustomResponse();
                _context.Entry(member).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> DeleteMember(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                var member = await _context.Members.FindAsync(id);
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CustomResponse> GetLoanHistory(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Loans.Include(l => l.Book).Where(l => l.MemberId == id).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<CustomResponse> GetReservations(Guid id)
        {
            try
            {
                var response = new CustomResponse();
                response.Data = await _context.Reservations.Include(r => r.Book).Where(r => r.MemberId == id).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
